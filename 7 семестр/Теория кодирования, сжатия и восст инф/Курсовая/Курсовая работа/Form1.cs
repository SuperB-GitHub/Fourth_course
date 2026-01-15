using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int s = 0;
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
        private void B_Code_Click(object sender, EventArgs e)
        {
            try
            {
                RTB_CodeText.Clear();

                // Проверка параметров кодирования
                if (string.IsNullOrEmpty(g) || g.Length < 2)
                {
                    MessageBox.Show("Введите порождающий полином g(x) (например, 1101)",
                        "Ошибка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (n <= 0)
                {
                    MessageBox.Show("Введите длину кода n > 0",
                        "Ошибка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (m >= n)
                {
                    MessageBox.Show($"Степень полинома m={m} должна быть меньше длины кода n={n}",
                        "Ошибка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (k <= 0)
                {
                    MessageBox.Show("Рассчитанное k <= 0. Проверьте параметры n и g(x)",
                        "Ошибка параметров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(binText))
                {
                    MessageBox.Show("Нет данных для кодирования. Откройте файл или введите текст",
                        "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (n != 0 && m != 0 && m == g.Length - 1)
                {
                    DGW_Matrix_1.Rows.Clear();
                    DGW_Matrix_1.Columns.Clear();
                    createMatrix(k, n, DGW_Matrix_1);
                    G = BuildGeneratorMatrix(g, n, k, m);
                }

                add_zero = (k - (binText.Length % k)) % k;
                string workText = binText + new string('0', add_zero);
                RTB_InfText.Text = workText;

                string binaryText = RTB_InfText.Text;
                int blockCount = binaryText.Length / k;

                // Оптимизация 1: Используем StringBuilder для накопления текста
                var codeTextBuilder = new StringBuilder(blockCount * n);

                // Оптимизация 2: Параллельная обработка блоков
                var results = new string[blockCount];

                Parallel.For(0, blockCount, i =>
                {
                    string binaryChunk = binaryText.Substring(i * k, k);
                    int[] infWord = binaryChunk.Select(c => c - '0').ToArray();
                    results[i] = MultiplyInfoWordWithMatrix(G, infWord);
                });

                // Собираем результаты в правильном порядке
                for (int i = 0; i < blockCount; i++)
                {
                    codeTextBuilder.Append(results[i]);
                }

                RTB_CodeText.Text = codeTextBuilder.ToString();

                L_g.Text = g;
                L_n2.Text = n.ToString();
                L_m2.Text = m.ToString();
                L_k2.Text = k.ToString();
                RTB_CodedText.Text = RTB_CodeText.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при кодировании:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void B_Decode_Click(object sender, EventArgs e)
        {
            string fullBinSeq = RTB_CodedText.Text;
            RTB_DecodedText.Clear(); RTB_DecodeProcess.Clear();

            StringBuilder decodedResult = new StringBuilder();

            int totalBlocks = fullBinSeq.Length / n;

            RTB_DecodeProcess.Text += $"Общее количество блоков: {totalBlocks}\n";

            for (int block = 0; block < totalBlocks; block++)
            {
                string receivedBinary = fullBinSeq.Substring(block * n, n);
                RTB_DecodeProcess.Text += $"\n[Блок {block + 1}/{totalBlocks}]\n";
                RTB_DecodeProcess.Text += $"Кодовое слово: {receivedBinary}\n";

                string syndrome = DivideBinaryString(receivedBinary, g, true);
                int w = syndrome.Count(x => x == '1');
                int count = 1;
                string temp = receivedBinary;

                while (w > s)
                {
                    RTB_DecodeProcess.Text += $"       {count} Синдром: {new string(' ', k * 2)}{syndrome}, но W({w}) > S({s})\n\n";
                    temp = temp.Substring(1) + temp.Substring(0,1);
                    RTB_DecodeProcess.Text += $"Кодовое слово: {temp}\n";
                    syndrome = DivideBinaryString(temp, g, true);
                    w = syndrome.Count(x => x == '1');
                    count++;
                }

                receivedBinary = temp;
                RTB_DecodeProcess.Text += $"       {count} Синдром: {new string(' ', k * 2)}{syndrome} и W({w}) <= S({s})\n";

                string correctedWord = receivedBinary;
                if (syndrome != new string('0', m))
                {
                    char[] wordChars = correctedWord.ToCharArray();
                    char[] syndChars = syndrome.ToCharArray();

                    for (int i = syndChars.Length; i != 0; i--)
                    {
                        wordChars[i + k - 1] = (wordChars[i + k - 1] == syndChars[i - 1]) ? '0' : '1';
                        if (syndChars[i - 1] == '1') 
                        {
                            RTB_DecodeProcess.Text += $"Исправлен бит: {(i + k - 1 + count) % n}\n";
                        }
                    }
                    correctedWord = new string(wordChars);
                    int lenWord = correctedWord.Length;
                    correctedWord = correctedWord.Substring(lenWord - count + 1, count - 1) + correctedWord.Substring(0, lenWord - count + 1);
                    RTB_DecodeProcess.Text += $"Исправленное: {correctedWord}\n";
                }
                else
                {
                    RTB_DecodeProcess.Text += "Ошибок не обнаружено\n";
                }
                string infoWord = DivideBinaryString(correctedWord, g, false);
                RTB_DecodeProcess.Text += $"Инф. слово:      {infoWord}\n";
                RTB_DecodeProcess.Text += new string('-', 30) + "\n";

                decodedResult.Append(infoWord);
            }

            RTB_DecodedText.Text += $"Полное сообщение: {decodedResult}\n\n";
            decodedResult.Length -= add_zero;

            byte[] final_decode = new byte[decodedResult.Length * 10];
            for (int i = 0; i < decodedResult.Length; i += 8)
            {
                string substring = decodedResult.ToString().Substring(i, 8);
                final_decode[i / 8] = Convert.ToByte(substring, 2);
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

            if (!g.All(c => c == '0' || c == '1'))
            {
                MessageBox.Show("Полином должен содержать только '0' и '1'",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                g = "";
                return;
            }

            for (int i = g.Length - 1; i >= 0; i--)
            {
                if (g[i] == '1')
                {
                    m = i;
                    break;
                }
            }
            L_m.Text = m.ToString();

            if (n > 0 && n > m)
            {
                k = n - m;
                L_k.Text = k.ToString();
            }
            else
            {
                L_k.Text = "?";
            }

            s = GetBchT(g,n);
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

            s = GetBchT(g, n);
            L_s.Text = s == 0 ? "0" : s.ToString();

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
        public static int GetBchT(string g, int n) // Функция нахождения s
        {
            // Словарь: (n, k) -> t
            var bchTable = new Dictionary<(int n, int k), int>
            {
                // n = 7
                {(7, 4), 1},
                {(7, 3), 2}, 

                // n = 15
                {(15, 11), 1}, 
                {(15, 7),  2}, 
                {(15, 5),  3}, 

                // n = 31
                {(31, 26), 1},
                {(31, 21), 2},
                {(31, 16), 3},
                {(31, 11), 5},
                {(31, 6),  7}
            };

            g = g.Trim();
            if (string.IsNullOrEmpty(g) || !g.All(c => c == '0' || c == '1'))
                return 0;

            int degree = g.Length - 1;
            if (degree <= 0) return 0;

            int firstOne = g.IndexOf('1');
            if (firstOne == -1) return 0;
            degree = g.Length - firstOne - 1;

            int k = n - degree;
            var key = (n, k);

            return bchTable.TryGetValue(key, out int t) ? t : -1;
        }
    }
}
