using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Лабораторные_работы
{
    public partial class Form1 : Form
    {
        private List<long> generatedSequence = new List<long>();
        private int sequencePeriod = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private List<long> GenerateLCGSequence(long a, long b, long m, long x0, int count)
        {
            List<long> sequence = new List<long>();
            long current = x0;

            for (int i = 0; i < count; i++)
            {
                sequence.Add(current);
                current = (a * current + b) % m;
            }

            return sequence;
        }

        private int FindPeriod(List<long> sequence)
        {
            if (sequence == null || sequence.Count < 2)
                return 0;

            // Ищем повторение начального значения
            long firstValue = sequence[0];

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] == firstValue)
                {
                    return i; // Период найден
                }
            }

            return sequence.Count; // Если период не найден, возвращаем длину последовательности
        }

        private bool CheckMaxPeriodConditions(long a, long b, long m)
        {
            // Условия для максимального периода (m):
            // 1. b и m взаимно просты
            // 2. a-1 делится на все простые делители m
            // 3. Если m делится на 4, то a-1 должно делиться на 4

            // 1. Проверка взаимной простоты b и m
            if (NOD(b, m) != 1)
            {
                CLB_MaxPeriod.SetItemChecked(0, false);
                return false;
            }
            CLB_MaxPeriod.SetItemChecked(0, true);

            // 2. Проверка делимости a-1 на все простые делители m
            long aMinus1 = a - 1;

            // Получаем простые делители m
            var primeFactors = GetPrimeFactors(m);
            foreach (var factor in primeFactors)
            {
                if (aMinus1 % factor != 0)
                {
                    CLB_MaxPeriod.SetItemChecked(1, false);
                    return false;
                }
            }
            CLB_MaxPeriod.SetItemChecked(1, true);

            // 3. Проверка для случая, когда m делится на 4
            if (m % 4 == 0 && aMinus1 % 4 != 0)
            {
                CLB_MaxPeriod.SetItemChecked(2, false);
                return false;
            }
            CLB_MaxPeriod.SetItemChecked(2, true);

            return true;
        }

        private long NOD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private List<long> GetPrimeFactors(long n)
        {
            List<long> factors = new List<long>();
            long i = 2;
            long temp = n;

            while (i * i <= temp)
            {
                if (temp % i == 0)
                {
                    factors.Add(i);
                    while (temp % i == 0)
                        temp /= i;
                }
                i++;
            }

            if (temp > 1)
                factors.Add(temp);

            return factors;
        }

        private string SequenceToString(List<long> sequence, int numbersPerLine = 10)
        {
            if (sequence == null || sequence.Count == 0)
                return "";

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sequence.Count; i++)
            {
                sb.Append($"{sequence[i],6}");

                if ((i + 1) % numbersPerLine == 0 || i == sequence.Count - 1)
                {

                    // Добавляем номер строки
                    if ((i + 1) % numbersPerLine == 0)
                    {
                        int startLine = i - numbersPerLine + 2;
                        int endLine = i + 1;
                        sb.AppendLine($"  // {startLine}-{endLine}");
                    }
                }
                else
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        // Обработчик кнопки "Сгенерировать"
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(textBoxA.Text, out long a))
                {
                    MessageBox.Show("Неверное значение параметра a", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxB.Text, out long b))
                {
                    MessageBox.Show("Неверное значение параметра b", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxM.Text, out long m) || m <= 0)
                {
                    MessageBox.Show("Неверное значение параметра m (должно быть положительным)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(textBoxX0.Text, out long x0))
                {
                    MessageBox.Show("Неверное начальное значение x₀", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int count = (int)numericUpDownCount.Value;

                generatedSequence = GenerateLCGSequence(a, b, m, x0, count);

                sequencePeriod = FindPeriod(GenerateLCGSequence(a, b, m, x0, (int)m));

                textBoxSequence.Text = SequenceToString(generatedSequence);

                textBoxPeriod.Text = sequencePeriod.ToString();

                bool hasMaxPeriod = CheckMaxPeriodConditions(a, b, m);
                checkBoxMaxPeriod.Checked = hasMaxPeriod;

                if (sequencePeriod == m)
                {
                    checkBoxMaxPeriod.Checked = true;
                    textBoxPeriod.Text += " (максимальный)";
                }
                else
                {
                    textBoxPeriod.Text += $" (обнаружен на {sequencePeriod}-м шаге)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки "Сохранить"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (generatedSequence == null || generatedSequence.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить последовательность";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"LCG_sequence_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохраняем не только числа, но и информацию о параметрах
                        StringBuilder fileContent = new StringBuilder();
                        fileContent.AppendLine("Линейный конгруэнтный генератор псевдослучайных чисел");
                        fileContent.AppendLine("======================================================");
                        fileContent.AppendLine($"Дата генерации: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        fileContent.AppendLine($"Параметры: a = {textBoxA.Text}, b = {textBoxB.Text}, m = {textBoxM.Text}, x₀ = {textBoxX0.Text}");
                        fileContent.AppendLine($"Количество чисел: {generatedSequence.Count}");
                        fileContent.AppendLine($"Период последовательности: {sequencePeriod}");
                        fileContent.AppendLine($"Максимальный период: {(checkBoxMaxPeriod.Checked ? "Да" : "Нет")}");
                        fileContent.AppendLine();
                        fileContent.AppendLine("Последовательность чисел:");
                        fileContent.AppendLine();

                        for (int i = 0; i < generatedSequence.Count; i++)
                        {
                            fileContent.Append($"{generatedSequence[i]}");
                            if (i < generatedSequence.Count - 1)
                                fileContent.Append(", ");
                        }

                        File.WriteAllText(saveDialog.FileName, fileContent.ToString());
                        MessageBox.Show($"Последовательность успешно сохранена в файл:\n{saveDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Обработчик кнопки "Очистить"
        private void buttonClear_Click(object sender, EventArgs e)
        {
            generatedSequence.Clear();
            textBoxSequence.Clear();
            textBoxPeriod.Clear();
            checkBoxMaxPeriod.Checked = false;
            sequencePeriod = 0;
        }

        // Обработчик выбора пресета
        private void comboBoxPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPresets.SelectedIndex > 0)
            {
                string selectedPreset = comboBoxPresets.SelectedItem.ToString();

                // Разбираем строку пресета
                string[] parts = selectedPreset.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 3)
                {
                    textBoxA.Text = parts[0];
                    textBoxB.Text = parts[1];
                    textBoxM.Text = parts[2];
                    textBoxX0.Text = "1"; // Устанавливаем начальное значение по умолчанию

                    // Автоматически устанавливаем количество чисел
                    numericUpDownCount.Value = 200;
                }
            }
        }

    }
}