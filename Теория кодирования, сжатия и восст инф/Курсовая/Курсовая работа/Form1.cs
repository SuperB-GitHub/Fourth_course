using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string text = "";
        public byte[] data = null;
        public string binText = "";
        public string g = "";
        public int[,] G = null;
        public int m = 0;
        public int n = 0;
        public int k = 0;
        public int add_zero = 0;

        // Управление кнопками
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            RTB_Name_Open.Text = ""; RTB_Common.Text = "";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                RTB_Name_Open.Text = OFD.SafeFileName;
                string filePath = OFD.FileName;
                text = File.ReadAllText(filePath, Encoding.UTF8);
                RTB_Common.Text = text;
            }
        }
        private void B_CountParam_Click(object sender, EventArgs e)
        {
            if (n != 0 && m != 0 && m == g.Length - 1)
            {
                DGW_Matrix_1.Rows.Clear();
                DGW_Matrix_1.Columns.Clear();
                createMatrix(k, n, DGW_Matrix_1);
                G = BuildGeneratorMatrix(g, n, k, m);
            }

            add_zero = (k - (binText.Length % k)) % k; // Высчитывание доп нулей
            string workText = binText + new string('0', add_zero); // Добавление доп нулей
            RTB_InfText.Text = workText;
        }
        private void B_Code_Click(object sender, EventArgs e)
        {
            RTB_CodeText.Clear();
            string binaryText = RTB_InfText.Text;
            int blockCount = binaryText.Length / k;


            for (int i = 0; i < blockCount; i++)
            {
                string binaryChunk = binaryText.Substring(i * k, k);
                int[] infWord = binaryChunk.Select(c => c - '0').ToArray();
                RTB_CodeText.Text += MultiplyInfoWordWithMatrix(G, infWord);
            }

            L_g.Text = g;
            L_n2.Text = n.ToString();
            L_m2.Text = m.ToString();
            L_k2.Text = k.ToString();
            RTB_CodedText.Text = RTB_CodeText.Text;

        }
        private void B_Decode_Click(object sender, EventArgs e)
        {
            string fullBinSeq = RTB_CodedText.Text;
            RTB_DecodedText.Clear();

            var syndromeTable = GenerateSyndromeTable(g, n);

            StringBuilder decodedResult = new StringBuilder();
            StringBuilder stepByStepLog = new StringBuilder();

            int totalBlocks = fullBinSeq.Length / n;

            stepByStepLog.AppendLine("=== НАЧАЛО ДЕКОДИРОВАНИЯ ===");
            stepByStepLog.AppendLine($"Общее количество блоков: {totalBlocks}\n");

            for (int block = 0; block < totalBlocks; block++)
            {
                string receivedBinary = fullBinSeq.Substring(block * n, n);
                stepByStepLog.AppendLine($"\n[Блок {block + 1}/{totalBlocks}]");
                stepByStepLog.AppendLine($"Кодовое слово:   {receivedBinary}");

                string syndrome = DivideBinaryString(receivedBinary, g, true);
                stepByStepLog.AppendLine($"Синдром:         {syndrome}");


                string correctedWord = receivedBinary;
                if (syndrome != new string('0', m))
                {
                    if (syndromeTable.TryGetValue(syndrome, out int errorPos))
                    {
                        char[] wordChars = correctedWord.ToCharArray();
                        wordChars[errorPos] = (wordChars[errorPos] == '0') ? '1' : '0';
                        correctedWord = new string(wordChars);
                        stepByStepLog.AppendLine($"Исправлен бит:   {errorPos + 1}");
                        stepByStepLog.AppendLine($"Исправленное:    {correctedWord}");
                    }
                    else
                    {
                        stepByStepLog.AppendLine("Ошибка: Неизвестный синдром!");
                    }
                }
                else
                {
                    stepByStepLog.AppendLine("Ошибок не обнаружено");
                }
                string infoWord = DivideBinaryString(correctedWord, g, false);
                stepByStepLog.AppendLine($"Инф. слово:      {infoWord}");
                stepByStepLog.AppendLine(new string('-', 30));

                decodedResult.Append(infoWord);
                RTB_DecodedText.Text = stepByStepLog.ToString();
            }

            stepByStepLog.AppendLine("\n=== РЕЗУЛЬТАТ ===");
            stepByStepLog.AppendLine($"Полное сообщение: {decodedResult}\n");
            RTB_DecodedText.Text = stepByStepLog.ToString();
            decodedResult.Length -= add_zero;

            byte[] final_decode = new byte[decodedResult.Length * 10]; // Массив для хранения байтов
            for (int i = 0; i < decodedResult.Length; i += 8)
            {
                string substring = decodedResult.ToString().Substring(i, 8); // Каждые 8 элементов
                final_decode[i / 8] = Convert.ToByte(substring, 2); // Преобразование в байтовое значение и запись
            }
            RTB_DecodedText.Text += $"Расшифрованное сообщение: {Encoding.UTF8.GetString(final_decode)}";


        }

        // Управление событиями
        private void RTB_Common_TextChanged(object sender, EventArgs e)
        {
            text = RTB_Common.Text;
            data = Encoding.UTF8.GetBytes(text); // Кодирование в ASCII
            binText = string.Join("", data.Select(b => Convert.ToString(b, 2).PadLeft(8, '0'))); // Вывод

            RTB_Code.Text = binText;
            RTB_InfText.Text = binText;
        }
        private void RTB_g_TextChanged(object sender, EventArgs e)
        {
            g = RTB_g.Text.Trim();

            // Определяем степень полинома m (позиция старшей единицы)
            for (int i = g.Length - 1; i >= 0; i--)
            {
                if (g[i] == '1')
                {
                    m = i;
                    break;
                }
            }
            L_m.Text = m.ToString();

            // Пересчитываем k, если n уже введён
            if (n > 0 && n > m)
            {
                k = n - m;
                L_k.Text = k.ToString();
            }
            else
            {
                L_k.Text = "?";
            }

            // === РАСЧЁТ s — количество исправляемых ошибок ===
            int s = CalculateCorrectableErrorsCount(g);
            L_s.Text = s == 0 ? "0" : s.ToString();

        }
        private void RTB_n_TextChanged(object sender, EventArgs e)
        {
            n = (RTB_n.Text != "" ?  Convert.ToInt32(RTB_n.Text) : 0);
            if (m > 0 && n > m)
            {
                k = n - m;
                L_k.Text = k.ToString();
            }
            else { L_k.Text = "?"; }
            
        }

        // Работа алгоритмов
        private void createMatrix(int row, int col, DataGridView Matrix) // Функция для создания DataGridView по размеру
        {
            DataGridViewColumn column;
            for (int i = 0; i < col; i++)
            {
                column = new DataGridViewTextBoxColumn();
                column.Width = 40;
                Matrix.Columns.Add(column);
            }

            for (int i = 0; i < row; i++)
            {
                Matrix.Rows.Add();
                Matrix.Rows[i].Height = 40;
            }
        }
        private int[,] BuildGeneratorMatrix(string g, int n, int k, int m) // Функция создания матрицы G
        {
            // 1. Создаем двумерный массив для хранения матрицы
            int[,] matrix = new int[k, n];

            // 2. Преобразуем строку g в список битов
            int[] gBits = new int[g.Length];
            for (int i = 0; i < g.Length; i++)
            {
                gBits[i] = g[i] - '0';
            }

            // 3. Заполняем матрицу
            for (int row = 0; row < k; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = 0;
                    DGW_Matrix_1.Rows[row].Cells[col].Value = "0";
                }

                for (int i = 0; i < gBits.Length; i++)
                {
                    int pos = row + i;
                    if (pos < n)
                        matrix[row, pos] = gBits[i];
                        DGW_Matrix_1.Rows[row].Cells[pos].Value = gBits[i];
                }
            }
            return matrix;
        }
        private string MultiplyInfoWordWithMatrix(int[,] matrix, int[] infoWord) // Функция перемножения матрицы G и инф. слова
        {
            int rows = matrix.GetLength(0);     // количество строк
            int cols = matrix.GetLength(1);     // количество столбцов

            int[] result = new int[cols];

            // Инициализируем нулями
            for (int j = 0; j < cols; j++)
                result[j] = 0;

            // Перемножаем по правилу циклических кодов (XOR для строк с infoWord[i] == 1)
            for (int i = 0; i < rows && i < infoWord.Length; i++)
            {
                if (infoWord[i] == 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[j] ^= matrix[i, j]; // XOR
                    }
                }
            }

            return string.Join("", result);
        }
        private string DivideBinaryString(string dividend, string g, bool synd) // Функция деления на полином g
        {
            char[] data = dividend.ToCharArray();
            char[] ans = Enumerable.Repeat('0', k).ToArray();

            for (int i = 0; i < data.Length - m; i++)
            {
                if (data[i] == '1')
                {
                    // XOR с g, начиная с позиции i
                    for (int j = 0; j <= m; j++)
                    {
                        data[i + j] = (data[i + j] == g[j]) ? '0' : '1';
                    }
                    ans[i] = '1';
                }
            }

            return synd ? new string(data, data.Length - m, m) : new string(ans);
        }
        private Dictionary<string, int> GenerateSyndromeTable(string g, int n) // Функция создания синдромов
        {
            DGW_Table_ES.Rows.Clear();
            var table = new Dictionary<string, int>();
            int syndromeLength = g.Length - 1;

            for (int errorPos = 0; errorPos < n; errorPos++)
            {
                int[] errorVector = new int[n];
                errorVector[errorPos] = 1;
                string errorBinary = string.Join("", errorVector);

                string syndrome = DivideBinaryString(errorBinary, g,true);

                if (!table.ContainsKey(syndrome))
                {
                    table.Add(syndrome, errorPos);
                    DGW_Table_ES.Rows.Add("x^"+errorPos.ToString(), syndrome);
                }
            }

            return table;
        }
        private int CalculateCorrectableErrorsCount(string g) // Функция подсчёта кол-ва испр ошибок
        {
            if (string.IsNullOrWhiteSpace(g))
                return 0;

            g = g.Replace(" ", "").Trim();
            if (g.Length == 0)
                return 0;

            int maxConsecutiveOnes = 0;
            int current = 0;

            foreach (char c in g)
            {
                if (c == '1')
                {
                    current++;
                    if (current > maxConsecutiveOnes)
                        maxConsecutiveOnes = current;
                }
                else
                {
                    current = 0;
                }
            }

            int s = (maxConsecutiveOnes - 1) / 2;

            if (maxConsecutiveOnes >= 2)
                s = Math.Max(1, s);

            return s;
        }

    }
}
