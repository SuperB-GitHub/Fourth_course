import matplotlib.pyplot as plt
import numpy as np

# Данные простые числа из интервала (500, 700)
primes_in_interval = [503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593,
                      599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673,
                      677, 683, 691]

# Первые 10 простых чисел
first_10_primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29]

# Интервал (500, 700)
start = 500
end = 700
total_numbers = end - start - 1  # исключаем границы? или включаем? 
# Уточним: в интервале (500, 700) натуральные числа от 501 до 699 включительно
numbers = list(range(501, 700))
total = len(numbers)

print(f"Интервал: (500, 700)")
print(f"Всего чисел в интервале: {total}")
print(f"Найдено простых чисел в интервале: {len(primes_in_interval)}")
print(f"Первые 10 простых чисел: {first_10_primes}")
print("-" * 70)

# Функция для проверки, делится ли число на любое из первых k простых
def is_not_divisible_by_first_k(num, k):
    """Проверяет, не делится ли число на первые k простых чисел"""
    for i in range(k):
        if num % first_10_primes[i] == 0:
            return False
    return True

# Расчет для каждого k от 1 до 10
k_values = list(range(1, 11))
relative_counts = []

print("Результаты:")
for k in k_values:
    # Считаем числа, не делящиеся на первые k простых
    count = 0
    for num in numbers:
        if is_not_divisible_by_first_k(num, k):
            count += 1
    
    # Относительное количество
    relative = count / total
    relative_counts.append(relative)
    
    print(f"k = {k:2d}, первые {k:2d} простых: {first_10_primes[:k]}, "
          f"не делятся: {count:3d} чисел, относительное количество: {relative:.4f}")

# Теоретические значения (произведение (1 - 1/p_i))
theoretical = []
for k in k_values:
    prod = 1.0
    for i in range(k):
        prod *= (1 - 1/first_10_primes[i])
    theoretical.append(prod)

print("-" * 70)
print("Теоретические значения (произведение (1 - 1/p_i)):")
for k in k_values:
    print(f"k = {k:2d}: {theoretical[k-1]:.4f}")

# Построение графика
plt.figure(figsize=(12, 7))

# Экспериментальные значения
plt.plot(k_values, relative_counts, 'bo-', linewidth=2, markersize=8, 
         label='Экспериментальные данные', markerfacecolor='blue')

# Теоретические значения
plt.plot(k_values, theoretical, 'rs--', linewidth=2, markersize=8, 
         label='Теоретическая кривая ∏(1-1/p_i)', markerfacecolor='red')

# Добавление значений на график
for i, (k, rel, theor) in enumerate(zip(k_values, relative_counts, theoretical)):
    plt.annotate(f'{rel:.3f}', (k, rel), textcoords="offset points", 
                xytext=(0,10), ha='center', fontsize=9, color='blue')
    plt.annotate(f'{theor:.3f}', (k, theor), textcoords="offset points", 
                xytext=(0,-15), ha='center', fontsize=9, color='red')

plt.xlabel('k - количество первых простых чисел', fontsize=12)
plt.ylabel('Относительное количество чисел, не делящихся на первые k простых', fontsize=12)
plt.title('Решето Эратосфена: относительное количество чисел в интервале (500, 700),\n'
          'не делящихся на первые k простых чисел', fontsize=14)
plt.grid(True, alpha=0.3)
plt.legend(fontsize=11)
plt.xticks(k_values)
plt.ylim(0, 1.05)

# Добавим текст с информацией об интервале
plt.text(0.02, 0.98, f'Интервал: (500, 700)\nВсего чисел: {total}\nПростых чисел: {len(primes_in_interval)}', 
         transform=plt.gca().transAxes, fontsize=10, verticalalignment='top',
         bbox=dict(boxstyle='round', facecolor='wheat', alpha=0.5))

plt.tight_layout()
plt.show()

# Сравнение экспериментальных и теоретических значений
print("-" * 70)
print("Сравнение:")
print(" k | Эксп. | Теор. | Разница")
print("---|-------|-------|--------")
for k, rel, theor in zip(k_values, relative_counts, theoretical):
    print(f"{k:2d} | {rel:.4f} | {theor:.4f} | {abs(rel-theor):.4f}")