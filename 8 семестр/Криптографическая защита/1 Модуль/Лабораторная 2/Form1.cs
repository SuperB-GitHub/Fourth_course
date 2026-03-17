using static MyMathLibrary.MathUtils;

namespace Лабораторная_2
{
    public partial class Form1 : Form
    {
        // Перечисление для выбора схемы
        private enum SchemeType
        {
            Sequential, // Последовательная (ЛР 2)
            Parallel    // Параллельная (ЛР 3)
        }

        private SchemeType currentScheme = SchemeType.Parallel; // По умолчанию параллельная

        // Класс для хранения состояния одного раунда (аккредитации)
        private class AccreditationResult
        {
            public int CycleNumber { get; set; }
            public int AccreditationNumber { get; set; }
            public long r { get; set; }
            public long x { get; set; }
            public object Challenge { get; set; } // int для послед., int[] для паралл.
            public long y { get; set; }
            public bool IsSuccess { get; set; }
            public string? LogMessage { get; set; }
            public string Scheme { get; set; } = "Parallel";
        }

        // Глобальные переменные состояния
        private long p, q, n;

        // Для последовательной схемы (ЛР 2)
        private long V_single;
        private long S_single;

        // Для параллельной схемы (ЛР 3)
        private List<long> openKeys = new List<long>();
        private List<long> secretKeys = new List<long>();

        private Random random = new Random();

        // Для отслеживания процесса
        private int currentCycle = 0;
        private int currentAccreditation = 0;
        private int totalCycles = 4;
        private int accreditationsPerCycle = 5;
        private List<AccreditationResult> allResults = new List<AccreditationResult>();

        // Для отслеживания повторов r (борьба с ворами)
        private Dictionary<long, int> usedRValues = new Dictionary<long, int>();
        private bool keyStolen = false;
        private long stolenS = 0;

        // RadioButton для выбора схемы (объявляем как поля класса)
        private RadioButton radioSequential;
        private RadioButton radioParallel;

        public Form1()
        {
            InitializeComponent();
            InitializeDefaults();

            // Находим RadioButton на форме (ты их уже добавил в дизайнере)
            FindSchemeRadioButtons();
        }

        private void FindSchemeRadioButtons()
        {
            // Ищем RadioButton на tabPage1
            foreach (Control control in tabPage1.Controls)
            {
                if (control is GroupBox gb && gb.Text == "Выбор схемы идентификации")
                {
                    foreach (Control c in gb.Controls)
                    {
                        if (c is RadioButton rb)
                        {
                            if (rb.Text.Contains("Последовательная"))
                                radioSequential = rb;
                            else if (rb.Text.Contains("Параллельная"))
                                radioParallel = rb;
                        }
                    }
                    break;
                }
            }

            // Если не нашли, создаем ссылки по умолчанию (на случай если их нет)
            if (radioSequential == null || radioParallel == null)
            {
                // Создаем заглушки, но лучше чтобы они были в дизайнере
                radioParallel = new RadioButton { Checked = true };
                radioSequential = new RadioButton { Checked = false };
            }
        }

        private void InitializeDefaults()
        {
            // Установка начальных значений
            totalCycles = (int)numericTotalCycles.Value;
            accreditationsPerCycle = (int)numericAccreditationsPerCycle.Value;
            UpdateLabels();
        }

        // ========== ВКЛАДКА 1: ГЕНЕРАЦИЯ КЛЮЧЕЙ ==========

        private void ButtonGenerateKeys_Click(object sender, EventArgs e)
        {
            // Определяем выбранную схему
            if (radioParallel != null && radioParallel.Checked)
                currentScheme = SchemeType.Parallel;
            else
                currentScheme = SchemeType.Sequential;

            RTB_LogGen.Text = "";
            int pVal = (int)numericP.Value;
            int qVal = (int)numericQ.Value;

            if (!IsPrime(pVal) || !IsPrime(qVal))
            {
                MessageBox.Show("p и q должны быть простыми числами!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            p = pVal;
            q = qVal;
            n = p * q;

            RTB_LogGen.AppendText($"Генерация параметров:\r\n");
            RTB_LogGen.AppendText($"p = {p}, q = {q}\r\n");
            RTB_LogGen.AppendText($"n = p * q = {n}\r\n");
            RTB_LogGen.AppendText($"φ(n) = {EulerPhi(n)}\r\n\r\n");

            if (currentScheme == SchemeType.Sequential)
            {
                GenerateSequentialKeys();
            }
            else
            {
                GenerateKeysForParallelScheme();
            }

            // Обновляем отображение ключей
            UpdateKeyLabels();

            ResetSimulation();
        }

        private void GenerateSequentialKeys()
        {
            RTB_LogGen.AppendText("--- Последовательная схема (ЛР 2) ---\r\n");

            // Генерируем V - квадратичный вычет
            V_single = GenerateQuadraticResidue();
            RTB_LogGen.AppendText($"Выбран открытый ключ V = {V_single}\r\n");

            // Вычисляем S = sqrt(V^(-1)) mod n
            S_single = ComputeSecretKey(V_single);
            RTB_LogGen.AppendText($"Вычислен секретный ключ S = {S_single}\r\n");
            RTB_LogGen.AppendText($"Проверка: S^2 * V mod n = {(S_single * S_single * V_single) % n} (должно быть 1)\r\n");
        }

        private void GenerateKeysForParallelScheme()
        {
            RTB_LogGen.AppendText("--- Параллельная схема (ЛР 3) ---\r\n");

            openKeys = new List<long>();
            secretKeys = new List<long>();

            int k = (int)numericAccreditationsPerCycle.Value;
            RTB_LogGen.AppendText($"Генерация {k} пар ключей (K = {k})\r\n");

            for (int i = 0; i < k; i++)
            {
                RTB_LogGen.AppendText($"\r\n{i + 1}) ");
                long v = GenerateQuadraticResidue();
                openKeys.Add(v);

                long s = ComputeSecretKey(v);
                secretKeys.Add(s);

                RTB_LogGen.AppendText($"\tV{i + 1} = {v}, S{i + 1} = {s}\r\n");
                RTB_LogGen.AppendText($"\tПроверка: S{i + 1}^2 * V{i + 1} mod n = {(s * s * v) % n}\r\n");
            }
        }

        private void UpdateKeyLabels()
        {
            labelN.Text = $"n = {n} (p={p}, q={q})";

            if (currentScheme == SchemeType.Sequential)
            {
                labelOpenKey.Text = $"Открытый ключ V: {V_single}";
                labelSecretKey.Text = $"Секретный ключ S: {S_single}";
            }
            else
            {
                labelOpenKey.Text = $"Открытые ключи V: {string.Join(", ", openKeys)}";
                labelSecretKey.Text = $"Секретные ключи S: {string.Join(", ", secretKeys)}";
            }
        }

        private long GenerateQuadraticResidue()
        {
            long r = random.Next(2, (int)n - 1);
            long x = FastPowMod(r, 2, n);
            return x;
        }

        private long ComputeSecretKey(long v)
        {
            // Исправление: явно приводим к long и используем правильный метод
            long phi = EulerPhi(n);
            long exponent = phi - 1;

            // Убедимся что exponent не отрицательный
            if (exponent < 0) exponent += phi;

            long vInv = FastPowMod(v, exponent, n);
            long s = SqrtMod(vInv, n);

            RTB_LogGen.AppendText($"V⁻¹ = V^(φ(n)-1) mod n = {vInv}");
            RTB_LogGen.AppendText($"\tS = √V⁻¹ mod n = {s}");

            return s;
        }

        private long SqrtMod(long a, long mod)
        {
            for (long i = 2; i < mod; i++)
            {
                if ((i * i) % mod == a % mod)
                    return i;
            }
            return 1;
        }

        // ========== ВКЛАДКА 4: ПРОЦЕСС ==========

        private void ButtonStartProcess_Click(object sender, EventArgs e)
        {
            ResetSimulation();
            buttonStartProcess.Enabled = false;
            buttonNextCycle.Enabled = true;
            richTextBoxProtocolDetails.Clear();
            richTextBoxProtocolDetails.AppendText("Детали протокола:\r\n");
            RunNextCycle();
        }

        private void ButtonNextCycle_Click(object sender, EventArgs e)
        {
            RunNextCycle();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetSimulation();
            richTextBoxProtocolDetails.Clear();
            richTextBoxProtocolDetails.AppendText("Детали протокола будут отображаться здесь...\r\n");
        }

        private void ResetSimulation()
        {
            currentCycle = 0;
            currentAccreditation = 0;
            allResults.Clear();
            usedRValues.Clear();
            keyStolen = false;
            stolenS = 0;

            totalCycles = (int)numericTotalCycles.Value;
            accreditationsPerCycle = (int)numericAccreditationsPerCycle.Value;

            UpdateLabels();
            listBoxProcessLog.Items.Clear();
            progressBarSuccess.Value = 0;
            buttonStartProcess.Enabled = true;
            buttonNextCycle.Enabled = false;
        }

        private void UpdateLabels()
        {
            labelCurrentCycle.Text = $"Цикл: {currentCycle}/{totalCycles}";
            labelCurrentAccreditation.Text = $"Аккредитация: {currentAccreditation}/{accreditationsPerCycle}";
        }

        private void RunNextCycle()
        {
            if (currentCycle >= totalCycles)
            {
                ShowFinalResults();
                return;
            }

            currentCycle++;
            currentAccreditation = 0;

            // Обновляем текущую схему
            if (radioParallel != null && radioParallel.Checked)
                currentScheme = SchemeType.Parallel;
            else
                currentScheme = SchemeType.Sequential;

            for (int i = 0; i < accreditationsPerCycle; i++)
            {
                currentAccreditation = i + 1;
                UpdateLabels();

                if (currentScheme == SchemeType.Sequential)
                {
                    RunSequentialAccreditation(currentCycle, currentAccreditation);
                }
                else
                {
                    RunParallelAccreditation(currentCycle, currentAccreditation);
                }

                if (keyStolen) break;
            }

            UpdateProgress();
        }

        // ========== ПОСЛЕДОВАТЕЛЬНАЯ СХЕМА (ЛР 2) ==========

        private void RunSequentialAccreditation(int cycleNum, int accNum)
        {
            // ШАГ 1: А выбирает r и вычисляет x = r^2 mod n
            long r = GenerateR();
            long x = (r * r) % n;

            // Проверка на повтор r (для обнаружения кражи)
            CheckForRReuse(r, cycleNum);

            // ШАГ 2: В посылает случайный бит
            int b = random.Next(2);

            // ШАГ 3: А вычисляет y
            long y = ComputeYSequential(r, b);

            // Симуляция ошибки А (если честный А ошибся)
            bool errorOccurred = SimulateError(ref y);

            // Симуляция А-мошенника
            bool fakeSuccess = false;
            if (radioAFake.Checked && !keyStolen)
            {
                fakeSuccess = SimulateFakeASequential(b);
            }

            // ШАГ 4: В проверяет
            bool success = VerifyYSequential(x, y, b);

            // Если А-мошенник не угадал - гарантированный провал
            if (radioAFake.Checked && !keyStolen && !fakeSuccess)
            {
                success = false;
            }

            // Логирование
            LogSequentialResult(cycleNum, accNum, r, x, b, y, success);
        }

        private long ComputeYSequential(long r, int b)
        {
            if (b == 0)
                return r;
            else
                return (r * S_single) % n;
        }

        private bool VerifyYSequential(long x, long y, int b)
        {
            if (b == 0)
            {
                return x == (y * y) % n;
            }
            else
            {
                return x == (y * y * V_single) % n;
            }
        }

        private bool SimulateFakeASequential(int actualB)
        {
            // Мошенник должен угадать b заранее
            int guessedB = random.Next(2);
            return guessedB == actualB;
        }

        private void LogSequentialResult(int cycleNum, int accNum, long r, long x, int b, long y, bool success)
        {
            string details = $"Цикл {cycleNum}.{accNum} [ПОСЛЕДОВАТЕЛЬНАЯ]:\r\n";
            details += $"1. А: r = {r}, x = r² mod n = {x}\r\n";
            details += $"2. В: b = {b}\r\n";
            details += $"3. А: y = {(b == 0 ? "r" : "r*S")} = {y}\r\n";

            if (b == 0)
                details += $"4. В: Проверка x = y² mod n = {(y * y) % n} -> {(success ? "УСПЕХ" : "ПРОВАЛ")}\r\n";
            else
                details += $"4. В: Проверка x = y²*V mod n = {(y * y * V_single) % n} -> {(success ? "УСПЕХ" : "ПРОВАЛ")}\r\n";

            richTextBoxProtocolDetails.AppendText(details + new string('-', 50) + "\r\n");

            string logMessage = $"Цикл {cycleNum}.{accNum} [ПОСЛ]: x={x}, b={b}, y={y} -> {(success ? "✓" : "✗")}";
            if (keyStolen) logMessage += " [КЛЮЧ УКРАДЕН!]";

            listBoxProcessLog.Items.Insert(0, logMessage);

            allResults.Add(new AccreditationResult
            {
                CycleNumber = cycleNum,
                AccreditationNumber = accNum,
                r = r,
                x = x,
                Challenge = b,
                y = y,
                IsSuccess = success,
                LogMessage = logMessage,
                Scheme = "Sequential"
            });
        }

        // ========== ПАРАЛЛЕЛЬНАЯ СХЕМА (ЛР 3) ==========

        private void RunParallelAccreditation(int cycleNum, int accNum)
        {
            // ШАГ 1: А выбирает r и вычисляет x = r^2 mod n
            long r = GenerateR();
            long x = (r * r) % n;

            // Проверка на повтор r (для обнаружения кражи)
            CheckForRReuse(r, cycleNum);

            // ШАГ 2: В генерирует случайную битовую строку b1...bK
            int[] bBits = GenerateRandomBits(accreditationsPerCycle);

            // ШАГ 3: А вычисляет y
            long y = ComputeYParallel(r, bBits);

            // Симуляция ошибки А (если честный А ошибся)
            bool errorOccurred = SimulateError(ref y);

            // Симуляция А-мошенника
            bool fakeSuccess = false;
            if (radioAFake.Checked && !keyStolen)
            {
                fakeSuccess = SimulateFakeAParallel(bBits);
                if (!fakeSuccess)
                {
                    y = (y + 1) % n; // Портим ответ если не угадал
                }
            }

            // ШАГ 4: В проверяет
            bool success = VerifyYParallel(x, y, bBits);

            // Логирование
            LogParallelResult(cycleNum, accNum, r, x, bBits, y, success);
        }

        private long ComputeYParallel(long r, int[] bBits)
        {
            long product = 1;
            for (int i = 0; i < bBits.Length; i++)
            {
                if (bBits[i] == 1 && i < secretKeys.Count)
                {
                    product = (product * secretKeys[i]) % n;
                }
            }
            return (r * product) % n;
        }

        private bool VerifyYParallel(long x, long y, int[] bBits)
        {
            long vProduct = 1;
            for (int i = 0; i < bBits.Length; i++)
            {
                if (bBits[i] == 1 && i < openKeys.Count)
                {
                    vProduct = (vProduct * openKeys[i]) % n;
                }
            }

            long rightSide = (y * y) % n;
            rightSide = (rightSide * vProduct) % n;

            return x == rightSide;
        }

        private bool SimulateFakeAParallel(int[] bBits)
        {
            // Вероятность успеха = (1/2)^K
            double successProb = Math.Pow(0.5, bBits.Length);
            return random.NextDouble() < successProb;
        }

        private void LogParallelResult(int cycleNum, int accNum, long r, long x, int[] bBits, long y, bool success)
        {
            string bString = BitArrayToString(bBits);

            string details = $"Цикл {cycleNum}.{accNum} [ПАРАЛЛЕЛЬНАЯ]:\r\n";
            details += $"1. А: r = {r}, x = r² mod n = {x}\r\n";
            details += $"2. В: b = {bString}\r\n";
            details += $"3. А: y = r * ∏(S_i^b_i) = {y}\r\n";
            details += $"4. В: Проверка x = y² * ∏(V_i^b_i) mod n -> {(success ? "УСПЕХ" : "ПРОВАЛ")}\r\n";

            richTextBoxProtocolDetails.AppendText(details + new string('-', 50) + "\r\n");

            string logMessage = $"Цикл {cycleNum}.{accNum} [ПАРАЛ]: x={x}, b={bString}, y={y} -> {(success ? "✓" : "✗")}";
            if (keyStolen) logMessage += " [КЛЮЧ УКРАДЕН!]";

            listBoxProcessLog.Items.Insert(0, logMessage);

            allResults.Add(new AccreditationResult
            {
                CycleNumber = cycleNum,
                AccreditationNumber = accNum,
                r = r,
                x = x,
                Challenge = bBits,
                y = y,
                IsSuccess = success,
                LogMessage = logMessage,
                Scheme = "Parallel"
            });
        }

        // ========== ОБЩИЕ МЕТОДЫ ==========

        private long GenerateR()
        {
            if (checkBoxUseOldR.Checked && usedRValues.Count > 0)
            {
                // Сознательно используем старый r (для демонстрации уязвимости)
                var enumerator = usedRValues.Keys.GetEnumerator();
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }

            // Новое случайное r
            return random.Next(2, (int)n - 1);
        }

        private int[] GenerateRandomBits(int count)
        {
            int[] bits = new int[count];
            for (int i = 0; i < count; i++)
            {
                bits[i] = random.Next(2);
            }
            return bits;
        }

        private string BitArrayToString(int[] bits)
        {
            return string.Join("", bits);
        }

        private void CheckForRReuse(long r, int currentCycle)
        {
            if (usedRValues.ContainsKey(r))
            {
                if (radioBThief.Checked && checkBoxBCatchReuse.Checked)
                {
                    keyStolen = true;
                    stolenS = TryStealKey(r);
                }
            }
            else
            {
                usedRValues[r] = currentCycle;
            }
        }

        private bool SimulateError(ref long y)
        {
            if (radioAHonest.Checked && !keyStolen)
            {
                double errorProb = (double)numericErrorPercent.Value / 100.0;
                if (random.NextDouble() < errorProb)
                {
                    y = (y + 1) % n;
                    return true;
                }
            }
            return false;
        }

        private long TryStealKey(long r)
        {
            // Упрощенно для демонстрации
            if (currentScheme == SchemeType.Sequential)
                return S_single;
            else if (secretKeys.Count > 0)
                return secretKeys[0];

            return 0;
        }

        private void UpdateProgress()
        {
            int totalAccreditations = totalCycles * accreditationsPerCycle;
            int completed = allResults.Count;

            if (totalAccreditations > 0)
            {
                progressBarSuccess.Value = Math.Min(100, (completed * 100) / totalAccreditations);
            }
        }

        private void ShowFinalResults()
        {
            buttonStartProcess.Enabled = true;
            buttonNextCycle.Enabled = false;

            tabControl1.SelectedTab = tabPage5;

            // Подсчет статистики
            int totalAccreditations = allResults.Count;
            int successes = allResults.Count(r => r.IsSuccess);
            double successRate = totalAccreditations > 0 ? (double)successes / totalAccreditations : 0;

            labelSuccessRate.Text = $"Реальная успешность: {successes}/{totalAccreditations} ({successRate:P2})";

            double theoryCheatProb;
            if (currentScheme == SchemeType.Sequential)
            {
                theoryCheatProb = Math.Pow(0.5, totalCycles);
            }
            else
            {
                theoryCheatProb = Math.Pow(0.5, accreditationsPerCycle * totalCycles);
            }
            labelTheoryRate.Text = $"Теоретическая вероятность обмана: {theoryCheatProb:E4}";

            // Формирование отчета
            string summary = $"Параметры: p={p}, q={q}, n={n}\r\n";
            summary += $"Схема: {(currentScheme == SchemeType.Sequential ? "Последовательная (ЛР 2)" : "Параллельная (ЛР 3)")}\r\n";

            if (currentScheme == SchemeType.Sequential)
            {
                summary += $"Открытый ключ V: {V_single}\r\n";
                summary += $"Секретный ключ S: {S_single}\r\n";
            }
            else
            {
                summary += $"Открытые ключи V: {string.Join(", ", openKeys)}\r\n";
                summary += $"Секретные ключи S: {string.Join(", ", secretKeys)}\r\n";
            }

            summary += $"Циклов: {totalCycles}, Аккредитаций в цикле: {accreditationsPerCycle}\r\n";
            summary += $"Режим А: {(radioAHonest.Checked ? "Честный" : "Мошенник")}\r\n";
            summary += $"Режим В: {(radioBHonest.Checked ? "Честный" : "Мошенник")}\r\n";
            summary += $"Вероятность ошибки А: {numericErrorPercent.Value}%\r\n";
            summary += $"Повтор r: {(checkBoxUseOldR.Checked ? "Разрешен (опасно!)" : "Запрещен")}\r\n";
            summary += $"====================================\r\n";
            summary += $"Всего раундов: {totalAccreditations}\r\n";
            summary += $"Успешно: {successes}\r\n";
            summary += $"Провалов: {totalAccreditations - successes}\r\n";

            textBoxSummary.Text = summary;

            // Очищаем и заполняем DataGridView
            dataGridViewResults.DataSource = null;
            dataGridViewResults.Rows.Clear();
            dataGridViewResults.Columns.Clear();

            dataGridViewResults.Columns.Add("Cycle", "Цикл");
            dataGridViewResults.Columns.Add("Acc", "Аккред.");
            dataGridViewResults.Columns.Add("Scheme", "Схема");
            dataGridViewResults.Columns.Add("X", "x");
            dataGridViewResults.Columns.Add("Challenge", "Запрос");
            dataGridViewResults.Columns.Add("Y", "y");
            dataGridViewResults.Columns.Add("Result", "Результат");

            foreach (var r in allResults)
            {
                string challenge = r.Challenge is int intVal ? intVal.ToString() : string.Join("", (int[])r.Challenge);
                dataGridViewResults.Rows.Add(
                    r.CycleNumber,
                    r.AccreditationNumber,
                    r.Scheme == "Sequential" ? "Посл." : "Парал.",
                    r.x,
                    challenge,
                    r.y,
                    r.IsSuccess ? "✓" : "✗"
                );
            }

            listBoxStolenKeys.Items.Clear();
            if (keyStolen)
            {
                listBoxStolenKeys.Items.Add($"*** КЛЮЧ УКРАДЕН! S = {stolenS} ***");
                listBoxStolenKeys.Items.Add("Причина: А повторно использовал r, В-мошенник вычислил секрет");
            }

            // Добавляем последние логи
            listBoxStolenKeys.Items.Add("");
            listBoxStolenKeys.Items.Add("Последние 10 операций:");
            int startIndex = Math.Max(0, allResults.Count - 10);
            int count = Math.Min(10, allResults.Count);
            for (int i = startIndex; i < startIndex + count; i++)
            {
                listBoxStolenKeys.Items.Add(allResults[i].LogMessage);
            }
        }

        private void ButtonExportResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.FileName = $"ZKPLab_{DateTime.Now:yyyyMMdd_HHmmss}";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string content = textBoxSummary.Text;

                // Если CSV, добавляем разделители
                if (saveFileDialog.FilterIndex == 2)
                {
                    content = "Cycle,Accreditation,Scheme,X,Challenge,Y,Result\n";
                    foreach (var r in allResults)
                    {
                        string challenge = r.Challenge is int intVal ? intVal.ToString() : $"\"{string.Join("", (int[])r.Challenge)}\"";
                        content += $"{r.CycleNumber},{r.AccreditationNumber},{r.Scheme},{r.x},{challenge},{r.y},{r.IsSuccess}\n";
                    }
                }

                System.IO.File.WriteAllText(saveFileDialog.FileName, content);
                MessageBox.Show($"Результаты сохранены в файл:\n{saveFileDialog.FileName}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}