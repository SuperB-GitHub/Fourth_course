import math
import matplotlib.pyplot as plt
import numpy as np

interval_start = 1000
interval_end = 1000 + 300


primes = [1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 
          1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 
          1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 
          1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297]

print(f"Простые числа: {primes}")

L = []
for i in range(1, len(primes)):
    diff = primes[i] - primes[i-1]
    L.append(diff)

print(f"\nРазности между соседними простыми числами L(i): {L}")

# Вычисляем выборочное среднее
if L:
    L_mean = sum(L) / len(L)
    print(f"\nВыборочное среднее L_сред = {L_mean:.4f}")
    
    # Вычисляем ln(x), где x - середина интервала
    x_mid = (interval_start + interval_end) / 2
    ln_x = math.log(x_mid)
    print(f"ln(x) для x = {x_mid:.1f} (середина интервала) = {ln_x:.4f}")
    
    # Сравнение
    print(f"\nСравнение:")
    print(f"L_сред = {L_mean:.4f}")
    print(f"ln(x)  = {ln_x:.4f}")
    print(f"Отношение L_сред / ln(x) = {L_mean / ln_x:.4f}")
    
    # Построение гистограммы
    plt.figure(figsize=(10, 6))
    
    # Создаем гистограмму
    n, bins, patches = plt.hist(L, bins='auto', alpha=0.7, color='blue', edgecolor='black')
    
    # Добавляем подписи
    plt.xlabel('Разность между соседними простыми числами L(i)')
    plt.ylabel('Частота')
    plt.title(f'Гистограмма разностей между простыми числами\nв интервале ({interval_start}, {interval_end})')
    
    # Добавляем вертикальную линию для среднего значения
    plt.axvline(L_mean, color='red', linestyle='dashed', linewidth=2, 
                label=f'Среднее значение: {L_mean:.2f}')
    
    # Добавляем вертикальную линию для ln(x)
    plt.axvline(ln_x, color='green', linestyle='dashed', linewidth=2,
                label=f'ln(x): {ln_x:.2f}')
    
    plt.legend()
    plt.grid(True, alpha=0.3)
    
    # Показываем значения на гистограмме
    for i in range(len(patches)):
        height = patches[i].get_height()
        if height > 0:
            plt.text(patches[i].get_x() + patches[i].get_width()/2., height + 0.1,
                    f'{int(height)}', ha='center', va='bottom')
    
    plt.tight_layout()
    plt.show()
    
else:
    print("В интервале недостаточно простых чисел для вычисления разностей")