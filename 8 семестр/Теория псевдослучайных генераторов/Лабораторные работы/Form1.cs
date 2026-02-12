using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Лабораторные_работы
{
    public partial class Form1 : Form
    {
        private List<long> SeqLCG = new List<long>();
        private List<long> SeqPCG = new List<long>();
        private (int start, int period) PeriodLCG = (0, 0);
        private (int start, int period) PeriodPCG = (0, 0);

        public Form1()
        {
            InitializeComponent();
        }

        // Генераторы псевдослучайной последовательности
        private List<long> GenLCGSeq(long a, long b, long m, long x0, int count)
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
        private List<long> GenPCGSeq(long a1, long a2, long b, long m, long x0, int count)
        {
            List<long> sequence = new List<long>();
            long current = x0;

            for (int i = 0; i < count; i++)
            {
                sequence.Add(current);
                current = (Mod(a2 * LightPow(current, 2, m), m) + Mod(a1 * current, m) + b) % m;
                //current = (a2 * current * current + a1 * current + b) % m;
            }

            return sequence;
        }

        // Проверки на максимальный период
        private bool CheckMaxPeriodLCG(long a, long b, long m)
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
        private bool CheckMaxPeriodPCG(long a1, long a2, long b, long m)
        {
            // Условия для максимального периода (m):
            // 1. Числа b и m – взаимно просты
            // 2. a₁-1 и a₂ делится на все простые делители m
            // 3. Если a₂ - чётное и если
            // 3.1 a₂ ≡ (a₁-1)(mod 4), если m кратно 4
            // 3.1 a₂ ≡ (a₁-1)(mod 2), если m кратно 2
            // 4. Если m кратно 9, то a₂ ≢ 3b(mod 9)

            // 1. Проверка взаимной простоты b и m
            if (NOD(b, m) != 1)
            {
                CLB_PCG_MaxPeriod.SetItemChecked(0, false);
                return false;
            }
            CLB_PCG_MaxPeriod.SetItemChecked(0, true);

            // 2. Проверка делимости a-1 и а2 на все простые делители m
            long aMinus1 = a1 - 1;
            var primeFactors = GetPrimeFactors(m);
            foreach (var factor in primeFactors)
            {
                if (aMinus1 % factor != 0 || a2 % factor != 0)
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(1, false);
                    return false;
                }
            }
            CLB_PCG_MaxPeriod.SetItemChecked(1, true);

            // 3. Проверка четности а2
            if (a2 % 2 == 0)
            {
                CLB_PCG_MaxPeriod.SetItemChecked(2, true);

                // 3. Проверка кратности m к 4 и сравнение
                if (m % 4 == 0 && Mod(a2, 4) == Mod(aMinus1, 4))
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(3, true);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                }
                // 3. Проверка кратности m к 2 и сравнение
                else if (m % 2 == 0 && Mod(a2,2) == Mod(aMinus1, 2))
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, true);
                }
                else
                {
                    CLB_PCG_MaxPeriod.SetItemChecked(2, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                    CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                    return false;
                }
            }
            else
            {
                CLB_PCG_MaxPeriod.SetItemChecked(2, false);
                CLB_PCG_MaxPeriod.SetItemChecked(3, false);
                CLB_PCG_MaxPeriod.SetItemChecked(4, false);
                return false;
            }

            // 4. Проверка кратности m к 9 и сравнение
            if (m % 9 != 0 || Mod(a2, 9) == Mod(3 * b, 9))
            {
                CLB_PCG_MaxPeriod.SetItemChecked(5, false);
                return false;
            }
            CLB_PCG_MaxPeriod.SetItemChecked(5, true);

            return true;
        }

        // Обработчики кнопки "Сгенерировать"
        private void BTN_GenLCGSeq_Click(object sender, EventArgs e)
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

                SeqLCG = GenLCGSeq(a, b, m, x0, count);

                PeriodLCG = FindPeriod(GenLCGSeq(a, b, m, x0, (int)m + 2));

                textBoxSequence.Text = SeqToString(SeqLCG);

                textBoxPeriod.Text = PeriodLCG.period.ToString();

                bool hasMaxPeriod = CheckMaxPeriodLCG(a, b, m);
                checkBoxMaxPeriod.Checked = hasMaxPeriod;

                if (PeriodLCG.period == m)
                {
                    checkBoxMaxPeriod.Checked = true;
                    textBoxPeriod.Text += " (максимальный)";
                }
                else
                {
                    textBoxPeriod.Text += $" (обнаружен на {PeriodLCG.start}-м шаге)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTN_GenPCGSeq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!long.TryParse(TB_PCG_a1.Text, out long a1))
                {
                    MessageBox.Show("Неверное значение параметра a₁", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_a2.Text, out long a2))
                {
                    MessageBox.Show("Неверное значение параметра a₂", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_b.Text, out long b))
                {
                    MessageBox.Show("Неверное значение параметра b", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_m.Text, out long m) || m <= 0)
                {
                    MessageBox.Show("Неверное значение параметра m (должно быть положительным)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!long.TryParse(TB_PCG_x0.Text, out long x0))
                {
                    MessageBox.Show("Неверное начальное значение x₀", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int count = (int)PCG_Count.Value;

                SeqPCG = GenPCGSeq(a1, a2, b, m, x0, count);

                PeriodPCG = FindPeriod(GenPCGSeq(a1, a2, b, m, x0, (int)m + 2));

                TB_PCG_Seq.Text = SeqToString(SeqPCG);

                TB_PCG_Period.Text = PeriodPCG.period.ToString();

                bool hasMaxPeriod = CheckMaxPeriodPCG(a1, a2, b, m);
                CB_PCG_MaxPeriod.Checked = hasMaxPeriod;

                if (PeriodPCG.period == m)
                {
                    CB_PCG_MaxPeriod.Checked = true;
                    TB_PCG_Period.Text += " (максимальный)";
                }
                else
                {
                    TB_PCG_Period.Text += $" (обнаружен на {PeriodPCG.start}-м шаге)";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации последовательности: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики кнопки "Сохранить"
        private void BTN_LCG_Save_Click(object sender, EventArgs e)
        {
            if (SeqLCG == null || SeqLCG.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(1);
        }
        private void BTN_PCG_Save_Click(object sender, EventArgs e)
        {
            if (SeqPCG == null || SeqPCG.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения. Сначала сгенерируйте последовательность.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFunc(2);
        }
        private void SaveFunc(int typeGen)
        {
            string fileName = "NaN";
            string name = "NaN";
            string param = "NaN";
            int count = 0;
            int period = 0;
            bool maxPer = false;
            List<long> seq = new List<long>();

            switch (typeGen)
            {
                case 1:
                    fileName = "ЛКГ";
                    name = "Линейный конгруэнтный генератор псевдослучайных чисел";
                    param = $"Параметры: a = {textBoxA.Text}, b = {textBoxB.Text}, m = {textBoxM.Text}, x₀ = {textBoxX0.Text}";
                    count = SeqLCG.Count;
                    period = PeriodLCG.period;
                    maxPer = checkBoxMaxPeriod.Checked;
                    seq = SeqLCG;
                    break;
                case 2:
                    fileName = "ПКГ";
                    name = "Полиномиальный конгруэнтный генератор псевдослучайных чисел";
                    param = $"Параметры: a₁ = {TB_PCG_a1.Text}, a₂ = {TB_PCG_a2.Text}, b = {TB_PCG_b.Text}, m = {TB_PCG_m.Text}, x₀ = {TB_PCG_x0.Text}";
                    count = SeqPCG.Count;
                    period = PeriodPCG.period;
                    maxPer = CB_PCG_MaxPeriod.Checked;
                    seq = SeqPCG;
                    break;
            }
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить последовательность";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"{fileName}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Сохраняем не только числа, но и информацию о параметрах
                        StringBuilder fileContent = new StringBuilder();
                        fileContent.AppendLine(name);
                        fileContent.AppendLine("======================================================");
                        fileContent.AppendLine($"Дата генерации: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                        fileContent.AppendLine(param);
                        fileContent.AppendLine($"Количество чисел: {count}");
                        fileContent.AppendLine($"Период последовательности: {period}");
                        fileContent.AppendLine($"Максимальный период: {(maxPer ? "Да" : "Нет")}");
                        fileContent.AppendLine();
                        fileContent.AppendLine("Последовательность чисел:");
                        fileContent.AppendLine();

                        for (int i = 0; i < count; i++)
                        {
                            fileContent.Append($"{seq[i]}");
                            if (i < count - 1)
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

        // Обработчики кнопки "Очистить"
        private void BTN_LCG_Clear_Click(object sender, EventArgs e)
        {
            SeqLCG.Clear();
            textBoxSequence.Clear();
            textBoxPeriod.Clear();
            checkBoxMaxPeriod.Checked = false;
            PeriodLCG = (0, 0);
        }
        private void BTN_PCG_Clear_Click(object sender, EventArgs e)
        {
            SeqPCG.Clear();
            TB_PCG_Seq.Clear();
            TB_PCG_Period.Clear();
            CB_PCG_MaxPeriod.Checked = false;
            PeriodPCG = (0, 0);
        }

        // Обработчики выбора пресета
        private void CB_LCG_PreSets_SelectedIndexChanged(object sender, EventArgs e)
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
        private void CB_PCG_PreSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_PCG_PreSets.SelectedIndex > 0)
            {
                string selectedPreset = CB_PCG_PreSets.SelectedItem.ToString();

                string[] parts = selectedPreset.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 4)
                {
                    TB_PCG_a1.Text = parts[0];
                    TB_PCG_a2.Text = parts[1];
                    TB_PCG_b.Text = parts[2];
                    TB_PCG_m.Text = parts[3];
                    TB_PCG_x0.Text = "1";

                    PCG_Count.Value = 200;
                }
            }
        }

        // Вспомогательные функции
        static long Mod(long a, long m)
        {
            return (a % m + m) % m;
        }
        static long LightPow(long num, long deg, long m)
        {
            if (deg == 0)
            {
                return 1;
            }
            else
            {
                long result = num;
                for (int i = 0; i < deg - 1; i++)
                {
                    result = Mod(result * num, m);
                }
                return result;
            }

        }
        static long NOD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
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
        private string SeqToString(List<long> sequence, int numbersPerLine = 10)
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
        private (int start, int period) FindPeriod(List<long> sequence)
        {
            if (sequence == null || sequence.Count < 2)
                return (0, 0);

            var seen = new Dictionary<(long, long), int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                long first = sequence[i];
                long second = (i + 1 < sequence.Count) ? sequence[i + 1] : sequence[0];
                var pair = (first, second);

                if (seen.ContainsKey(pair))
                {
                    int possiblePeriod = i - seen[pair];
                    return (seen[pair], possiblePeriod);
                }

                seen[pair] = i;
            }
            return (0, sequence.Count);
        }

        
    }
}