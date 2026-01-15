using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Лабораторные_работы;

namespace Лабораторные_работы

{
    public partial class Form1 : Form
    {
        // Объявляем элементы управления как поля класса
        private Guna2ComboBox cmbParameterSet;
        private Guna2TextBox txtX0;
        private Guna2TextBox txtCount;
        private Guna2Button btnGenerate;
        private Guna2Button btnSave;
        private Guna2Button btnCheckPeriod;
        private Guna2TextBox txtResults;
        private Guna2TextBox txtAnalysis;
        private Guna2TabControl tabControl;

        private List<int> generatedNumbers = new List<int>();
        private List<LCGParameterSet> parameterSets = new List<LCGParameterSet>();

        public Form1()
        {
            // Сначала инициализируем параметры
            InitializeParameterSets();

            // Затем инициализируем компоненты формы
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    base.AutoScaleMode = AutoScaleMode.Font;
        //    this.ClientSize = new Size(1200, 800);
        //    this.Text = "Лабораторная работа №1 - Линейный конгруэнтный генератор";
        //    this.StartPosition = FormStartPosition.CenterScreen;

        //    SetupForm();
        //}

        private void InitializeParameterSets()
        {
            // Данные из таблицы
            parameterSets.AddRange(new[]
            {
                new LCGParameterSet(106, 1283, 6075),
                new LCGParameterSet(211, 1663, 7875),
                new LCGParameterSet(421, 1663, 7875),
                new LCGParameterSet(430, 2531, 11979),
                new LCGParameterSet(936, 1399, 6655),
                new LCGParameterSet(1366, 1283, 6075),
                new LCGParameterSet(171, 11213, 53125),
                new LCGParameterSet(859, 2531, 11979),
                new LCGParameterSet(419, 6173, 29282),
                new LCGParameterSet(967, 3041, 14406),
                new LCGParameterSet(141, 28411, 134456),
                new LCGParameterSet(625, 6571, 31104),
                new LCGParameterSet(1541, 2957, 14000),
                new LCGParameterSet(1741, 2731, 12960),
                new LCGParameterSet(1291, 4621, 21870),
                new LCGParameterSet(205, 29573, 139968)
            });
        }

        private void SetupForm()
        {
            // Основной контейнер
            var mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.FromArgb(245, 245, 245)
            };
            this.Controls.Add(mainPanel);

            // Заголовок
            var titleLabel = new Guna2HtmlLabel
            {
                Text = "<b>Лабораторная работа №1</b><br>" +
                       "<span style='color:#2c3e50; font-size:14pt;'>Линейный конгруэнтный генератор псевдослучайных чисел</span>",
                Location = new Point(20, 20),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            mainPanel.Controls.Add(titleLabel);

            // Панель параметров
            var paramPanel = new Guna2Panel
            {
                Location = new Point(20, 80),
                Size = new Size(1150, 180),
                BorderRadius = 15,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderThickness = 1,
                //ShadowDecoration = { Enabled = true, ShadowDepth = 10, Color = Color.FromArgb(100, 0, 0, 0) }
            };
            mainPanel.Controls.Add(paramPanel);

            // Метки и контролы для параметров
            int yPos = 30;
            var lblParams = new Guna2HtmlLabel
            {
                Text = "<b style='color:#2c3e50;'>Параметры генератора:</b>",
                Location = new Point(20, yPos),
                AutoSize = true
            };
            paramPanel.Controls.Add(lblParams);

            yPos += 40;

            // Выбор из таблицы
            var lblSelectSet = new Label
            {
                Text = "Выберите набор параметров из таблицы:",
                Location = new Point(20, yPos),
                Size = new Size(250, 25),
                Font = new Font("Segoe UI", 9F)
            };
            paramPanel.Controls.Add(lblSelectSet);

            // Создаем комбобокс
            cmbParameterSet = new Guna2ComboBox
            {
                Location = new Point(280, yPos - 3),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 9F),
                BorderRadius = 5,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(200, 200, 200)
            };

            // Заполняем комбобокс данными
            foreach (var param in parameterSets)
            {
                cmbParameterSet.Items.Add($"a={param.A}, b={param.B}, m={param.M}");
            }
            cmbParameterSet.SelectedIndex = 0;
            cmbParameterSet.SelectedIndexChanged += CmbParameterSet_SelectedIndexChanged;

            paramPanel.Controls.Add(cmbParameterSet);

            yPos += 40;

            // Поле для начального значения
            var lblX0 = new Label
            {
                Text = "Начальное значение x₀:",
                Location = new Point(20, yPos),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9F)
            };
            paramPanel.Controls.Add(lblX0);

            txtX0 = new Guna2TextBox
            {
                Location = new Point(180, yPos - 3),
                Size = new Size(150, 30),
                Text = "1",
                Font = new Font("Segoe UI", 9F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(200, 200, 200),
                //FocusedColor = Color.FromArgb(94, 148, 255)
            };
            paramPanel.Controls.Add(txtX0);

            // Поле для количества чисел
            var lblCount = new Label
            {
                Text = "Количество чисел:",
                Location = new Point(350, yPos),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9F)
            };
            paramPanel.Controls.Add(lblCount);

            txtCount = new Guna2TextBox
            {
                Location = new Point(510, yPos - 3),
                Size = new Size(150, 30),
                Text = "200",
                Font = new Font("Segoe UI", 9F),
                BorderRadius = 5,
                BorderColor = Color.FromArgb(200, 200, 200),
                //FocusedColor = Color.FromArgb(94, 148, 255)
            };
            paramPanel.Controls.Add(txtCount);

            yPos += 40;

            // Кнопка генерации
            btnGenerate = new Guna2Button
            {
                Text = "Сгенерировать последовательность",
                Location = new Point(20, yPos),
                Size = new Size(300, 40),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 10,
                FillColor = Color.FromArgb(94, 148, 255),
                ForeColor = Color.White,
                Animated = true
            };
            btnGenerate.Click += BtnGenerate_Click;
            paramPanel.Controls.Add(btnGenerate);

            // Кнопка сохранения
            btnSave = new Guna2Button
            {
                Text = "Сохранить результаты",
                Location = new Point(350, yPos),
                Size = new Size(250, 40),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 10,
                FillColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Animated = true,
                Enabled = false
            };
            btnSave.Click += BtnSave_Click;
            paramPanel.Controls.Add(btnSave);

            // Кнопка проверки периода
            btnCheckPeriod = new Guna2Button
            {
                Text = "Определить период",
                Location = new Point(620, yPos),
                Size = new Size(200, 40),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BorderRadius = 10,
                FillColor = Color.FromArgb(241, 196, 15),
                ForeColor = Color.White,
                Animated = true,
                Enabled = false
            };
            btnCheckPeriod.Click += BtnCheckPeriod_Click;
            paramPanel.Controls.Add(btnCheckPeriod);

            // Панель результатов
            var resultsPanel = new Guna2Panel
            {
                Location = new Point(20, 280),
                Size = new Size(1150, 480),
                BorderRadius = 15,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderThickness = 1,
                //ShadowDecoration = { Enabled = true, ShadowDepth = 10, Color = Color.FromArgb(100, 0, 0, 0) }
            };
            mainPanel.Controls.Add(resultsPanel);

            // Вкладки
            tabControl = new Guna2TabControl
            {
                Location = new Point(10, 10),
                Size = new Size(1130, 460),
                ItemSize = new Size(150, 40),
                SelectedIndex = 0,
                //TabBorderColor = Color.Transparent,
                //TabBorderThickness = 0
            };

            // Вкладка с числами
            var tabNumbers = new TabPage("Сгенерированные числа");
            tabNumbers.BackColor = Color.White;

            txtResults = new Guna2TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 9F),
                //BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            tabNumbers.Controls.Add(txtResults);
            tabControl.TabPages.Add(tabNumbers);

            // Вкладка с анализом
            var tabAnalysis = new TabPage("Анализ параметров");
            tabAnalysis.BackColor = Color.White;

            txtAnalysis = new Guna2TextBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                //BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            tabAnalysis.Controls.Add(txtAnalysis);
            tabControl.TabPages.Add(tabAnalysis);

            resultsPanel.Controls.Add(tabControl);

            // Обновляем анализ для первого набора параметров
            UpdateParameterDisplay(parameterSets[0]);
        }

        private void CmbParameterSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParameterSet.SelectedIndex >= 0)
            {
                var selectedParams = parameterSets[cmbParameterSet.SelectedIndex];
                UpdateParameterDisplay(selectedParams);
            }
        }

        private void UpdateParameterDisplay(LCGParameterSet parameters)
        {
            if (txtAnalysis == null) return;

            // Обновляем отображение параметров
            string analysis = $"Текущие параметры:\n";
            analysis += $"a = {parameters.A}\n";
            analysis += $"b = {parameters.B}\n";
            analysis += $"m = {parameters.M}\n\n";

            analysis += $"Проверка условий максимального периода:\n";

            // Условие 1: b и m взаимно просты
            bool condition1 = GCD(parameters.B, parameters.M) == 1;
            analysis += $"1. b и m взаимно просты (НОД({parameters.B}, {parameters.M}) = {GCD(parameters.B, parameters.M)}): ";
            analysis += condition1 ? "✓ ВЫПОЛНЕНО\n" : "✗ НЕ ВЫПОЛНЕНО\n";

            // Условие 2: a-1 кратно всем простым делителям m
            bool condition2 = CheckCondition2(parameters.A, parameters.M);
            analysis += $"2. a-1 кратно всем простым делителям m: ";
            analysis += condition2 ? "✓ ВЫПОЛНЕНО\n" : "✗ НЕ ВЫПОЛНЕНО\n";

            // Условие 3: если m кратно 4, то a-1 кратно 4
            bool condition3 = parameters.M % 4 != 0 || (parameters.A - 1) % 4 == 0;
            analysis += $"3. Если m кратно 4, то a-1 кратно 4: ";
            analysis += condition3 ? "✓ ВЫПОЛНЕНО\n" : "✗ НЕ ВЫПОЛНЕНО\n\n";

            analysis += $"Статус: ";
            if (condition1 && condition2 && condition3)
                analysis += "✓ Все условия выполнены - МАКСИМАЛЬНЫЙ ПЕРИОД";
            else
                analysis += "✗ Не все условия выполнены";

            txtAnalysis.Text = analysis;
        }

        private bool CheckCondition2(int a, int m)
        {
            int aMinus1 = a - 1;
            var primeFactors = GetPrimeFactors(m);

            foreach (var factor in primeFactors)
            {
                if (aMinus1 % factor != 0)
                    return false;
            }
            return true;
        }

        private List<int> GetPrimeFactors(int n)
        {
            var factors = new List<int>();
            int temp = n;

            for (int i = 2; i <= Math.Sqrt(temp); i++)
            {
                if (temp % i == 0)
                {
                    factors.Add(i);
                    while (temp % i == 0)
                        temp /= i;
                }
            }

            if (temp > 1)
                factors.Add(temp);

            return factors.Distinct().ToList();
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbParameterSet.SelectedIndex < 0) return;

            if (!int.TryParse(txtX0.Text, out int x0))
            {
                MessageBox.Show("Введите корректное начальное значение x₀", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCount.Text, out int count) || count < 1)
            {
                MessageBox.Show("Введите корректное количество чисел", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var parameters = parameterSets[cmbParameterSet.SelectedIndex];
            generatedNumbers.Clear();

            // Генерация последовательности
            int current = x0;
            string result = $"Параметры: a={parameters.A}, b={parameters.B}, m={parameters.M}, x₀={x0}\n\n";
            result += "Последовательность:\n";

            for (int i = 0; i < count; i++)
            {
                generatedNumbers.Add(current);
                result += $"{i + 1,3}: x_{i} = {current,8}";

                // Вычисляем следующее значение
                long next = ((long)parameters.A * current + parameters.B) % parameters.M;

                result += $" → x_{i + 1} = ({parameters.A}*{current} + {parameters.B}) mod {parameters.M} = {next}\n";
                current = (int)next;
            }

            txtResults.Text = result;
            btnSave.Enabled = true;
            btnCheckPeriod.Enabled = true;

            // Показываем статистику
            ShowStatistics();
        }

        private void ShowStatistics()
        {
            if (generatedNumbers.Count == 0) return;

            string stats = $"\n\nСтатистика:\n";
            stats += $"Количество чисел: {generatedNumbers.Count}\n";
            stats += $"Минимальное значение: {generatedNumbers.Min()}\n";
            stats += $"Максимальное значение: {generatedNumbers.Max()}\n";
            stats += $"Среднее значение: {generatedNumbers.Average():F2}\n";

            // Проверка на уникальность
            int uniqueCount = generatedNumbers.Distinct().Count();
            stats += $"Уникальных чисел: {uniqueCount} из {generatedNumbers.Count} ";
            if (uniqueCount == generatedNumbers.Count)
                stats += "(все числа уникальны)";
            else
                stats += $"(повторений: {generatedNumbers.Count - uniqueCount})";

            txtResults.Text += stats;
        }

        private void BtnCheckPeriod_Click(object sender, EventArgs e)
        {
            if (generatedNumbers.Count == 0) return;

            int period = FindPeriod();
            string periodInfo = $"\n\nАнализ периода:\n";

            if (period > 0)
            {
                periodInfo += $"Период последовательности: {period}\n";
                periodInfo += $"Длина периода составляет {period} чисел\n";

                var parameters = parameterSets[cmbParameterSet.SelectedIndex];
                int maxPossiblePeriod = parameters.M;
                periodInfo += $"Максимально возможный период (m): {maxPossiblePeriod}\n";

                if (period == maxPossiblePeriod)
                    periodInfo += "✓ Достигнут максимальный период!\n";
                else
                    periodInfo += $"Период меньше максимального ({period}/{maxPossiblePeriod})\n";

                // Показываем цикл
                periodInfo += $"\nЦикл начинается с индекса {FindCycleStart()}:\n";
                for (int i = 0; i < Math.Min(period, 20); i++)
                {
                    periodInfo += $"{generatedNumbers[i]} ";
                }
                if (period > 20)
                    periodInfo += "...";
            }
            else
            {
                periodInfo += "Период не обнаружен в сгенерированной последовательности\n";
                periodInfo += "Увеличьте количество генерируемых чисел для поиска периода";
            }

            txtResults.Text += periodInfo;
        }

        private int FindPeriod()
        {
            // Используем алгоритм Флойда для поиска цикла
            int n = generatedNumbers.Count;

            // Простой поиск повторений
            for (int start = 0; start < n; start++)
            {
                for (int length = 1; length <= (n - start) / 2; length++)
                {
                    bool isPeriod = true;
                    for (int i = 0; i < length; i++)
                    {
                        if (start + i + length >= n ||
                            generatedNumbers[start + i] != generatedNumbers[start + i + length])
                        {
                            isPeriod = false;
                            break;
                        }
                    }
                    if (isPeriod) return length;
                }
            }
            return 0;
        }

        private int FindCycleStart()
        {
            // Простой поиск начала цикла
            for (int i = 0; i < generatedNumbers.Count; i++)
            {
                for (int j = i + 1; j < generatedNumbers.Count; j++)
                {
                    if (generatedNumbers[i] == generatedNumbers[j])
                        return i;
                }
            }
            return 0;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (generatedNumbers.Count == 0) return;

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveDialog.Title = "Сохранить результаты";
                saveDialog.FileName = $"LCG_Results_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var parameters = parameterSets[cmbParameterSet.SelectedIndex];
                        string content = "ЛАБОРАТОРНАЯ РАБОТА №1\n";
                        content += "Линейный конгруэнтный генератор псевдослучайных чисел\n\n";
                        content += $"Дата: {DateTime.Now}\n";
                        content += $"Параметры: a={parameters.A}, b={parameters.B}, m={parameters.M}, x₀={txtX0.Text}\n";
                        content += $"Количество чисел: {generatedNumbers.Count}\n\n";
                        content += "ПОСЛЕДОВАТЕЛЬНОСТЬ:\n";

                        for (int i = 0; i < generatedNumbers.Count; i++)
                        {
                            content += $"{i + 1,4}: {generatedNumbers[i],8}";
                            if ((i + 1) % 5 == 0) content += "\n";
                            else content += "   ";
                        }

                        content += "\n\nАНАЛИЗ ПАРАМЕТРОВ:\n";
                        content += txtAnalysis.Text;

                        File.WriteAllText(saveDialog.FileName, content);
                        MessageBox.Show("Результаты успешно сохранены!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}