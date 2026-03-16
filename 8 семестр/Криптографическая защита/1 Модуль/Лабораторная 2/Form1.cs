using Microsoft.VisualBasic;
using static MyMathLibrary.MathUtils;

namespace Лабораторная_2
{
    public partial class Form1 : Form
    {
        // Класс для хранения состояния одного раунда (аккредитации)
        private class AccreditationResult
        {
            public int CycleNumber { get; set; }
            public int AccreditationNumber { get; set; }
            public long r { get; set; }
            public long x { get; set; }
            public int[]? bBits { get; set; } 
            public long y { get; set; }
            public bool IsSuccess { get; set; }
            public string? LogMessage { get; set; }
        }

        // Глобальные переменные состояния
        private long p, q, n, V, S;
        private List<long> openKeys = new List<long> { };
        private List<long> secretKeys = new List<long> { };
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

        public Form1()
        {
            InitializeComponent();
            InitializeDefaults();
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

            GenerateKeysForParallelScheme();

            labelN.Text = $"n = {n} (p={p}, q={q})";
            labelOpenKey.Text = $"Открытые ключи V: {string.Join(", ", openKeys)}";
            labelSecretKey.Text = $"Секретные ключи S: {string.Join(", ", secretKeys)}";

            ResetSimulation();
        }

        private void GenerateKeysForParallelScheme()
        {
            openKeys = new List<long>();
            secretKeys = new List<long>();

            int k = (int)numericAccreditationsPerCycle.Value;

            for (int i = 0; i < k; i++)
            {
                RTB_LogGen.Text += $"{i + 1})\n";
                long v = GenerateQuadraticResidue();
                openKeys.Add(v);

                long s = ComputeSecretKey(v);
                secretKeys.Add(s);
            }
        }

        private long GenerateQuadraticResidue()
        {
            long r = random.Next(2, (int)n - 1);
            long x = FastPowMod(r, 2, n);

            RTB_LogGen.Text += $"r = {r} => x = r²(mod n) = {x}\n";

            return x;
        }

        private long ComputeSecretKey(long v)
        {
            long vInv = FastPowMod(v, EulerPhi(n) - 1, n);
            long s = SqrtMod(vInv, n);


            RTB_LogGen.Text += $"S = √V⁻¹ (mod n) => " +
                $"\n\t  V⁻¹ = [-1 = φ(n)-1 = {EulerPhi(n)}-1 = {EulerPhi(n)-1}] = {vInv}" +
                $"\n\t√V⁻¹ (mod n) = {s}\n";

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
            RunNextCycle();
        }

        private void ButtonNextCycle_Click(object sender, EventArgs e)
        {
            RunNextCycle();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetSimulation();
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
                // Все циклы завершены, показываем результаты
                ShowFinalResults();
                return;
            }

            currentCycle++;
            currentAccreditation = 0;

            for (int i = 0; i < accreditationsPerCycle; i++)
            {
                currentAccreditation = i + 1;
                UpdateLabels();

                // Выполняем одну аккредитацию (параллельная схема)
                RunAccreditation(currentCycle, currentAccreditation);

                // Если ключ уже украли, прерываемся
                if (keyStolen) break;
            }

            UpdateProgress();
        }

        private void RunAccreditation(int cycleNum, int accNum)
        {
            // ШАГ 1: А выбирает r и вычисляет x = r^2 mod n
            long r = GenerateR();
            long x = (r * r) % n;

            // Проверка на повтор r (для обнаружения кражи)
            if (usedRValues.ContainsKey(r))
            {
                // В-мошенник может украсть ключ!
                if (radioBThief.Checked && checkBoxBCatchReuse.Checked)
                {
                    keyStolen = true;
                    stolenS = TryStealKey(r, usedRValues[r], cycleNum);
                }
            }
            else
            {
                usedRValues[r] = cycleNum;
            }

            // ШАГ 2: В генерирует случайную битовую строку b1...bK
            int[] bBits = GenerateRandomBits(accreditationsPerCycle);

            // ШАГ 3: А вычисляет y
            long y = ComputeY(r, bBits);

            // ШАГ 4: В проверяет
            bool success = VerifyY(x, y, bBits);

            // Симуляция ошибки А (если честный А ошибся)
            if (radioAHonest.Checked && !keyStolen)
            {
                double errorProb = (double)numericErrorPercent.Value / 100.0;
                if (random.NextDouble() < errorProb)
                {
                    // А ошибается - портим ответ
                    y = (y + 1) % n; // Просто меняем ответ
                    success = false;
                }
            }

            // Симуляция А-мошенника
            if (radioAFake.Checked && !keyStolen)
            {
                // Мошенник не знает S, пытается угадать
                success = SimulateFakeA(r, bBits);
            }

            // Логируем результат
            string logMessage = $"Цикл {cycleNum}.{accNum}: x={x}, b={BitArrayToString(bBits)}, y={y} -> {(success ? "УСПЕХ" : "ПРОВАЛ")}";
            if (keyStolen) logMessage += " [КЛЮЧ УКРАДЕН!]";

            listBoxProcessLog.Items.Insert(0, logMessage); // Добавляем сверху

            allResults.Add(new AccreditationResult
            {
                CycleNumber = cycleNum,
                AccreditationNumber = accNum,
                r = r,
                x = x,
                bBits = bBits,
                y = y,
                IsSuccess = success,
                LogMessage = logMessage
            });
        }

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
                bits[i] = random.Next(2); // 0 или 1
            }
            return bits;
        }

        private long ComputeY(long r, int[] bBits)
        {
            // y = r * (S1^b1 * S2^b2 * ... * SK^bK) mod n
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

        private bool VerifyY(long x, long y, int[] bBits)
        {
            // Проверка: x = y^2 * (V1^b1 * V2^b2 * ... * VK^bK) mod n
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

        private bool SimulateFakeA(long r, int[] bBits)
        {
            // Мошенник не знает S
            // Он может угадать биты и подготовиться, но не к обоим случаям сразу

            // Упрощенно: вероятность успеха = (1/2)^K
            // Здесь мы просто рандомно определяем успех/неудачу
            double successProb = Math.Pow(0.5, bBits.Length);
            return random.NextDouble() < successProb;
        }

        private long TryStealKey(long r, int oldCycle, int currentCycle)
        {
            // Если В заметил повтор r, он может вычислить S
            // Нужно найти соответствующие y из старого и нового цикла
            // S = y_new / y_old или что-то подобное

            // В реальности здесь сложная логика поиска по логам
            // Упрощенно: возвращаем какой-то ключ для демонстрации
            if (secretKeys.Count > 0)
                return secretKeys[0];

            return 0;
        }

        private string BitArrayToString(int[] bits)
        {
            return string.Join("", bits);
        }

        private void UpdateProgress()
        {
            int totalAccreditations = totalCycles * accreditationsPerCycle;
            int completed = allResults.Count;
            int successes = allResults.FindAll(r => r.IsSuccess).Count;

            if (totalAccreditations > 0)
            {
                progressBarSuccess.Value = (completed * 100) / totalAccreditations;
            }
        }

        private void ShowFinalResults()
        {
            buttonStartProcess.Enabled = true;
            buttonNextCycle.Enabled = false;

            // Переключаемся на вкладку результатов
            tabControl1.SelectedTab = tabPage5;

            // Подсчет статистики
            int totalAccreditations = allResults.Count;
            int successes = allResults.FindAll(r => r.IsSuccess).Count;
            double successRate = totalAccreditations > 0 ? (double)successes / totalAccreditations : 0;

            labelSuccessRate.Text = $"Реальная успешность: {successes}/{totalAccreditations} ({successRate:P2})";

            double theoryCheatProb = Math.Pow(0.5, accreditationsPerCycle * totalCycles);
            labelTheoryRate.Text = $"Теоретическая вероятность обмана: {theoryCheatProb:E4}";

            // Формирование отчета
            string summary = $"Параметры: p={p}, q={q}, n={n}\r\n";
            summary += $"Открытые ключи V: {string.Join(", ", openKeys)}\r\n";
            summary += $"Секретные ключи S: {string.Join(", ", secretKeys)}\r\n";
            summary += $"Циклов: {totalCycles}, Аккредитаций в цикле: {accreditationsPerCycle}\r\n";
            summary += $"Режим А: {(radioAHonest.Checked ? "Честный" : "Мошенник")}\r\n";
            summary += $"Режим В: {(radioBHonest.Checked ? "Честный" : "Мошенник")}\r\n";
            summary += $"====================================\r\n";

            textBoxSummary.Text = summary;

            // Если ключ украли, показываем это
            if (keyStolen)
            {
                listBoxStolenKeys.Items.Add($"КЛЮЧ УКРАДЕН! S={stolenS} (обнаружен повтор r)");
            }

            // Добавляем последние логи
            foreach (var result in allResults.GetRange(Math.Max(0, allResults.Count - 10), Math.Min(10, allResults.Count)))
            {
                listBoxStolenKeys.Items.Add(result.LogMessage);
            }
        }

        private void ButtonExportResults_Click(object sender, EventArgs e)
        {
            // Сохранение результатов в файл
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, textBoxSummary.Text);
                MessageBox.Show("Результаты сохранены!");
            }
        }
    }
}