#!/usr/bin/env python
# -*- coding: utf-8 -*-

import sys, os, argparse, json, traceback
import cv2, numpy as np, albumentations as A
import tensorflow as tf
from tensorflow.keras import layers, Model, optimizers
from tensorflow.keras.applications import EfficientNetB0
from tensorflow.keras.preprocessing.image import ImageDataGenerator
import tf2onnx

def log(msg):
    print(msg, flush=True)
    # Log dosyasını her zaman veri klasörüne yaz
    try:
        log_path = os.path.join(os.path.abspath(args.classes), f'{getattr(args, "model_prefix", "model")}_train_log.txt')
        with open(log_path, 'a', encoding='utf-8') as f:
            f.write(msg + '\n')
    except Exception as e:
        print(f'[LOGGING ERROR] {e}', flush=True)

def check_requirements():
    try:
        log("=== GEREKSİNİMLER KONTROL EDİLİYOR ===")
        log(f"Python: {sys.version}")
        log(f"TensorFlow: {tf.__version__}")
        log(f"OpenCV: {cv2.__version__}")
        log(f"NumPy: {np.__version__}")
        log("=== GEREKSİNİMLER TAMAM ===")
    except Exception as e:
        log(f"[ERR] Gereksinim kontrolü hatası: {e}")
        raise

def check_directories(classes_dir, used_classes=None):
    try:
        log("=== KLASÖRLER KONTROL EDİLİYOR ===")
        if not os.path.exists(classes_dir):
            raise Exception(f"Klasör bulunamadı: {classes_dir}")
        
        class_dirs = [d for d in os.listdir(classes_dir) if os.path.isdir(os.path.join(classes_dir, d))]
        if used_classes is not None:
            class_dirs = [d for d in class_dirs if d in used_classes]
        log(f"Kullanılan sınıf klasörleri: {class_dirs}")
        if not class_dirs:
            raise Exception("Hiç sınıf klasörü bulunamadı!")
        
        total_files = 0
        for class_dir in class_dirs:
            files = [f for f in os.listdir(os.path.join(classes_dir, class_dir)) if f.endswith('.png')]
            log(f"{class_dir}: {len(files)} dosya")
            total_files += len(files)
        
        if total_files == 0:
            raise Exception("Hiç resim dosyası bulunamadı!")
        
        log(f"Toplam {len(class_dirs)} sınıf, {total_files} dosya bulundu")
        log("=== KLASÖR KONTROLÜ TAMAM ===")
    except Exception as e:
        log(f"[ERR] Klasör kontrolü hatası: {e}")
        raise

def preprocess_image(img):
    try:
        # img burada zaten numpy array!
        img = cv2.resize(img, (args.img_size, args.img_size))
        return img.astype('float32')/255.0
    except Exception as e:
        log(f"[ERR] Ön işlem hatası: {e}")
        raise

def create_model(num_classes):
    try:
        base = EfficientNetB0(
            include_top=False,
            input_shape=(args.img_size, args.img_size, 3),
            weights='imagenet'
        )
        base.trainable = False
        
        x = layers.GlobalAveragePooling2D()(base.output)
        x = layers.Dropout(0.3)(x)
        x = layers.Dense(128, activation='relu')(x)
        outputs = layers.Dense(num_classes, activation='softmax')(x)
        
        model = Model(base.input, outputs)
        model.compile(
            optimizer=optimizers.Adam(1e-4),
            loss='categorical_crossentropy',
            metrics=['accuracy']
        )
        return model
    except Exception as e:
        log(f"[ERR] Model oluşturma hatası: {e}")
        raise

def save_model(model, classes_dir, prefix):
    try:
        out_h5 = os.path.join(classes_dir, f'{prefix}.h5')
        out_onnx = os.path.join(classes_dir, f'{prefix}.onnx')
        
        # H5 formatında kaydet
        model.save(out_h5, save_format='h5')
        log(f".h5 saved: {out_h5}")
        
        # ONNX formatında kaydet
        spec = (tf.TensorSpec((None, args.img_size, args.img_size, 3), tf.float32, name='input'),)
        tf2onnx.convert.from_keras(model, input_signature=spec, output_path=out_onnx)
        log(f"ONNX saved: {out_onnx}")
        
        return True
    except Exception as e:
        log(f"[ERR] Model kaydetme hatası: {e}")
        return False

def main():
    global args
    try:
        log('=== PYTHON TRAINING SCRIPT BAŞLADI ===')
        
        # 1) Argümanları al
        parser = argparse.ArgumentParser(description="Advanced quality control training")
        parser.add_argument('--classes', required=True, help='path to live_dataset folder')
        parser.add_argument('--epochs', type=int, default=20)
        parser.add_argument('--batch_size', type=int, default=16)
        parser.add_argument('--img_size', type=int, default=224)
        parser.add_argument('--model_prefix', type=str, default='model')
        parser.add_argument('--used_classes', type=str, default=None)
        args = parser.parse_args()
        prefix = args.model_prefix
        used_classes = None
        if args.used_classes:
            used_classes = [x.strip() for x in args.used_classes.split(',') if x.strip()]
        log(f"used_classes: {used_classes}")

        # 2) Gereksinimleri kontrol et
        check_requirements()

        # 3) Klasörleri kontrol et
        classes_dir = os.path.abspath(args.classes)
        check_directories(classes_dir, used_classes)

        # 4) Data Generator'ları hazırla
        log("=== GENERATOR'LAR HAZIRLANIYOR ===")
        datagen = ImageDataGenerator(
            preprocessing_function=preprocess_image,
            validation_split=0.2
        )
        
        train_gen = datagen.flow_from_directory(
            classes_dir,
            target_size=(args.img_size, args.img_size),
            batch_size=args.batch_size,
            subset='training',
            class_mode='categorical',
            classes=used_classes if used_classes else None
        )
        
        val_gen = datagen.flow_from_directory(
            classes_dir,
            target_size=(args.img_size, args.img_size),
            batch_size=args.batch_size,
            subset='validation',
            class_mode='categorical',
            classes=used_classes if used_classes else None
        )
        
        log(f"Classes: {train_gen.num_classes}, Train samples: {train_gen.samples}, Val samples: {val_gen.samples}")
        
        if train_gen.samples == 0 or train_gen.num_classes == 0:
            raise Exception("Hiç eğitim verisi bulunamadı!")

        # 5) Model oluştur
        log("=== MODEL OLUŞTURULUYOR ===")
        model = create_model(train_gen.num_classes)
        model.summary(print_fn=log)
        log(f"Start training: epochs={args.epochs}, batch_size={args.batch_size}")

        # 6) Eğitim
        log("=== EĞİTİM BAŞLIYOR ===")
        history = model.fit(
            train_gen,
            validation_data=val_gen,
            epochs=args.epochs,
            callbacks=[
                tf.keras.callbacks.EarlyStopping(
                    monitor='val_loss',
                    patience=5,
                    restore_best_weights=True
                )
            ]
        )
        log("=== EĞİTİM TAMAMLANDI ===")

        # 7) History'i kaydet
        log("=== HISTORY KAYDEDİLİYOR ===")
        try:
            hist_data = {
                k: [float(val) for val in v] 
                for k, v in history.history.items()
            }
            with open(os.path.join(classes_dir, f'{prefix}_history.json'), 'w') as f:
                json.dump(hist_data, f)
            log(f"History saved -> {prefix}_history.json")
        except Exception as e:
            log(f"[ERR] history.json kaydedilemedi: {e}")

        # 8) Model'i kaydet
        log("=== MODEL KAYDEDİLİYOR ===")
        if save_model(model, classes_dir, prefix):
            log("=== İŞLEM TAMAMLANDI ===")
            sys.exit(0)
        else:
            log("[FATAL] Model dosyaları oluşturulamadı!")
            sys.exit(1)
            
    except Exception as e:
        tb = traceback.format_exc()
        log(f"[FATAL] Hata oluştu: {e}\n{tb}")
        sys.exit(1)

if __name__ == "__main__":
    main()
