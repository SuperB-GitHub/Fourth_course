using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Лабораторная_1
{
    public partial class MainForm : Form
    {
        private uint[] keyParts = new uint[8];
        private uint[] roundKeys = new uint[32];
        private byte[,] sBoxes = new byte[8, 16];

        public MainForm()
        {
            InitializeComponent();
            InitializeRoundKeysGrid();
            InitializeSBlocksGrid();

            toolTip1 = new ToolTip();
            string textToolTip = "Процесс шифрования:\r\n" +
                "1. Разбиение на блоки по 64 бита\r\n" +
                "2. 32 раунда преобразования:\r\n   " +
                "- Целочисленное сложение по модулю\r\n   " +
                "- Замена по S-блокам\r\n   " +
                "- Циклический сдвиг влево на 11 бит\r\n   " +
                "- Сложение XOR\r\n   " +
                "- Перестановка\r\n" +
                "3. Объединение блоков";
            toolTip1.SetToolTip(buttonEncrypt, textToolTip);
            toolTip1.SetToolTip(buttonDecrypt, textToolTip);
        }

        // Инициализация таблиц
        private void InitializeRoundKeysGrid()
        {
            dataGridViewRoundKeys.Rows.Clear();
            dataGridViewRoundKeys.Columns.Clear();

            dataGridViewRoundKeys.Columns.Add("Column1", "Раунд");
            dataGridViewRoundKeys.Columns[0].Width = 60;

            for (int i = 1; i <= 8; i++)
            {
                dataGridViewRoundKeys.Columns.Add($"Column{i + 1}", $"Ключ {i}");
                dataGridViewRoundKeys.Columns[i].Width = 120;
            }

            for (int i = 0; i < 32; i++)
            {
                dataGridViewRoundKeys.Rows.Add(
                    (i + 1).ToString(),
                    "", "", "", "", "", "", "", ""
                );
            }
        }

        private void InitializeSBlocksGrid()
        {
            dataGridViewSBlocks.ColumnCount = 9;
            dataGridViewSBlocks.Columns[0].Name = "Вход";
            dataGridViewSBlocks.Columns[0].Width = 50;
            dataGridViewSBlocks.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 1; i <= 8; i++)
            {
                dataGridViewSBlocks.Columns[i].Name = $"S{9 - i}";
                dataGridViewSBlocks.Columns[i].Width = 60;
                dataGridViewSBlocks.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridViewSBlocksDecimal.ColumnCount = 9;
            dataGridViewSBlocksDecimal.Columns[0].Name = "Вход";
            dataGridViewSBlocksDecimal.Columns[0].Width = 50;
            dataGridViewSBlocksDecimal.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 1; i <= 8; i++)
            {
                dataGridViewSBlocksDecimal.Columns[i].Name = $"S{9 - i}";
                dataGridViewSBlocksDecimal.Columns[i].Width = 60;
                dataGridViewSBlocksDecimal.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            labelBinaryTitle.Text = "S-блоки в двоичном представлении:";
            labelDecimalTitle.Text = "S-блоки в десятичном представлении:";

            int[,] sBlocks = new int[16, 8]
            {
                {  1, 13,  4,  6,  7,  5, 14,  4 },
                { 15, 11, 11, 12, 13,  8, 11, 10 },
                { 13,  4, 10,  7, 10,  1,  4,  9 },
                {  0,  1,  0,  1,  1, 13, 12,  2 },
                {  5,  3,  7,  5,  0, 10,  6, 13 },
                {  7, 15,  2, 15,  8,  3, 13,  8 },
                { 10,  5,  1, 13,  9,  4, 15,  0 },
                {  4,  9, 13,  8, 15,  2, 10, 14 },
                {  9,  0,  3,  4, 14, 14,  2,  6 },
                {  2, 10,  6, 10,  4, 15,  3, 11 },
                {  3, 14,  8,  9,  6, 12,  8,  1 },
                { 14,  7,  5, 14, 12,  7,  1, 12 },
                {  6,  6,  9,  0, 11,  6,  0,  7 },
                { 11,  8, 12,  3,  2,  0,  7, 15 },
                {  8,  2, 15, 11,  5,  9,  5,  5 },
                { 12, 12, 14,  2,  3, 11,  9,  3 }
            };

            for (int sBoxNum = 0; sBoxNum < 8; sBoxNum++)
            {
                for (int input = 0; input < 16; input++)
                {
                    sBoxes[sBoxNum, input] = (byte)sBlocks[input, sBoxNum];
                }
            }

            dataGridViewSBlocks.Rows.Clear();
            for (int i = 0; i < 16; i++)
            {
                object[] row = new object[9];
                row[0] = i.ToString();
                for (int j = 0; j < 8; j++)
                {
                    row[j + 1] = Convert.ToString(sBlocks[i, j], 2).PadLeft(4, '0');
                }
                dataGridViewSBlocks.Rows.Add(row);
            }

            dataGridViewSBlocksDecimal.Rows.Clear();
            for (int i = 0; i < 16; i++)
            {
                object[] row = new object[9];
                row[0] = i.ToString();
                for (int j = 0; j < 8; j++)
                {
                    row[j + 1] = sBlocks[i, j];
                }
                dataGridViewSBlocksDecimal.Rows.Add(row);
            }
        }

        // Обработчики событий
        private void ButtonGenerateRoundKeys_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            byte[] keyBytes = new byte[32];
            random.NextBytes(keyBytes);

            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //string phrase = "АЛИНА ПОШЛА В ЛЕС СОБИРАТЬ ГРИБЫ";
            //Encoding win1251 = Encoding.GetEncoding(1251);
            //byte[] phraseBytes = win1251.GetBytes(phrase);
            //byte[] keyBytes = new byte[32];
            //Array.Copy(phraseBytes, keyBytes, Math.Min(phraseBytes.Length, 32));

            // Заполняем 8 подключей
            for (int i = 0; i < 8; i++)
            {
                keyParts[i] = BytesToUInt32(keyBytes, i * 4);
            }

            // Генерируем 32 раундовых ключа
            for (int i = 0; i < 32; i++)
            {
                int keyIndex = (i < 24) ? i % 8 : 7 - (i - 24);
                roundKeys[i] = keyParts[keyIndex];
            }

            // Отображаем 256-битный ключ
            StringBuilder binaryKeyDisplay = new StringBuilder();
            for (int i = 0; i < keyBytes.Length; i++)
            {
                string binaryByte = Convert.ToString(keyBytes[i], 2).PadLeft(8, '0');
                binaryKeyDisplay.Append(binaryByte);

                if ((i + 1) % 4 == 0 && i != keyBytes.Length - 1)
                    binaryKeyDisplay.AppendLine();
                else if (i != keyBytes.Length - 1)
                    binaryKeyDisplay.Append(" ");
            }

            textBoxBinaryKey.Text = binaryKeyDisplay.ToString();

            // Обновляем DataGridView с раундовыми ключами
            UpdateRoundKeysGridView();

            MessageBox.Show("256-битный ключ и раундовые ключи успешно сгенерированы!",
                           "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPlainText.Text))
            {
                MessageBox.Show("Введите текст для шифрования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (roundKeys[0] == 0)
            {
                MessageBox.Show("Сначала сгенерируйте ключи раундов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding(1251);
            byte[] inputBytes = win1251.GetBytes(textBoxPlainText.Text);

            string processLog;
            byte[] encryptedBytes = GOSTAlgorithm(inputBytes, true, out processLog);

            textBoxCipherText.Text = processLog.ToString();

            StringBuilder resultText = new StringBuilder();
            resultText.AppendLine("Зашифрованный текст (двоичный):");

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                resultText.Append(Convert.ToString(encryptedBytes[i], 2).PadLeft(8, '0'));
                resultText.Append(" ");
                if ((i + 1) % 4 == 0) resultText.AppendLine();
            }

            resultText.AppendLine();
            resultText.AppendLine($"Длина: {encryptedBytes.Length} байт ({encryptedBytes.Length * 8} бит)");
            TB_EncodedText.Text = resultText.ToString();

            MessageBox.Show("Текст успешно зашифрован!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxCipherInput.Text))
                {
                    MessageBox.Show("Введите шифротекст", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (roundKeys[0] == 0)
                {
                    MessageBox.Show("Сначала сгенерируйте ключи раундов!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cipherText = textBoxCipherInput.Text.Trim();

                cipherText = cipherText.Replace("\r", "").Replace("\n", " ").Replace("  ", " ");
                string[] binaryParts = cipherText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<byte> cipherBytes = new List<byte>();
                foreach (string part in binaryParts)
                {
                    if (part.Length == 8)
                    {
                        byte b = Convert.ToByte(part, 2);
                        cipherBytes.Add(b);
                    }
                }

                if (cipherBytes.Count == 0)
                {
                    MessageBox.Show("Неверный формат шифротекста! Введите двоичные данные (группы по 8 бит)",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                while (cipherBytes.Count % 8 != 0)
                {
                    cipherBytes.Add(0);
                }

                byte[] inputBytes = cipherBytes.ToArray();

                string processLog;
                byte[] decryptedBytes = GOSTAlgorithm(inputBytes, false, out processLog);

                Encoding win1251 = Encoding.GetEncoding(1251);
                string decryptedText = win1251.GetString(decryptedBytes).TrimEnd('\0');

                StringBuilder binaryResult = new StringBuilder();
                for (int i = 0; i < decryptedBytes.Length; i++)
                {
                    binaryResult.Append(Convert.ToString(decryptedBytes[i], 2).PadLeft(8, '0'));
                    binaryResult.Append(" ");
                    if ((i + 1) % 4 == 0) binaryResult.AppendLine();
                }

                textBoxDecryptedText.Text = decryptedText;
                RTB_ProcessDecode.Text = processLog;

                RTB_ProcessDecode.AppendText("\n=== ИТОГОВЫЙ РЕЗУЛЬТАТ РАСШИФРОВАНИЯ ===\n");
                RTB_ProcessDecode.AppendText($"Расшифрованный текст: \"{decryptedText}\"\n");
                RTB_ProcessDecode.AppendText($"Двоичное представление:\n{binaryResult}\n");
                RTB_ProcessDecode.AppendText($"Длина: {decryptedBytes.Length} байт ({decryptedBytes.Length * 8} бит)\n");

                MessageBox.Show("Текст успешно расшифрован!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Основной алгоритм ГОСТ 28147-89
        private byte[] GOSTAlgorithm(byte[] inputBytes, bool encrypt, out string processLog)
        {
            StringBuilder log = new StringBuilder();
            log.AppendLine($"=== {(encrypt ? "ШИФРОВАНИЕ" : "РАСШИФРОВАНИЕ")} ГОСТ 28147-89 ===\n");

            log.AppendLine($"1. Входные данные:");
            log.AppendLine($"   Длина в байтах: {inputBytes.Length}");
            log.AppendLine($"   Длина в битах: {inputBytes.Length * 8}");
            log.AppendLine($"   Двоичное представление:");

            for (int i = 0; i < inputBytes.Length; i++)
            {
                log.Append(Convert.ToString(inputBytes[i], 2).PadLeft(8, '0') + " ");
                if ((i + 1) % 4 == 0) log.AppendLine();
            }
            log.AppendLine();

            int paddedLength = ((inputBytes.Length + 7) / 8) * 8;
            byte[] paddedBytes = new byte[paddedLength];
            Array.Copy(inputBytes, paddedBytes, inputBytes.Length);

            log.AppendLine($"2. Дополнение до кратного 64 битам:");
            log.AppendLine($"   Было: {inputBytes.Length} байт");
            log.AppendLine($"   Стало: {paddedLength} байт");
            log.AppendLine($"   Блоков по 64 бита: {paddedLength / 8}");
            log.AppendLine();

            List<byte[]> resultBlocks = new List<byte[]>();
            int totalBlocks = paddedLength / 8;

            for (int blockIndex = 0; blockIndex < paddedLength; blockIndex += 8)
            {
                log.AppendLine($"=== БЛОК {blockIndex / 8 + 1}/{totalBlocks} ===");

                byte[] block = new byte[8];
                Array.Copy(paddedBytes, blockIndex, block, 0, 8);

                uint left = BytesToUInt32(block, 0);
                uint right = BytesToUInt32(block, 4);

                log.AppendLine($"   Исходный блок (64 бита):");
                log.AppendLine($"   L0 = {FormatBinary32(left)}");
                log.AppendLine($"   R0 = {FormatBinary32(right)}");
                log.AppendLine();

                if (encrypt)
                {
                    for (int round = 0; round < 32; round++)
                    {
                        ProcessRound(ref left, ref right, roundKeys[round], round + 1, encrypt, log);
                    }
                    Swap(ref left, ref right);
                }
                else
                {
                    for (int round = 31; round >= 0; round--)
                    {
                        ProcessRound(ref left, ref right, roundKeys[round], 32 - round, encrypt, log);
                    }
                    Swap(ref left, ref right);
                }

                byte[] resultBlock = new byte[8];
                byte[] leftBytes = UInt32ToBytes(left);
                byte[] rightBytes = UInt32ToBytes(right);
                Array.Copy(leftBytes, 0, resultBlock, 0, 4);
                Array.Copy(rightBytes, 0, resultBlock, 4, 4);
                resultBlocks.Add(resultBlock);

                log.AppendLine($"   Результат блока:");
                log.AppendLine($"   L = {FormatBinary32(left)}");
                log.AppendLine($"   R = {FormatBinary32(right)}");
                log.AppendLine();
            }

            byte[] resultBytes = new byte[resultBlocks.Count * 8];
            for (int i = 0; i < resultBlocks.Count; i++)
            {
                Array.Copy(resultBlocks[i], 0, resultBytes, i * 8, 8);
            }

            processLog = log.ToString();
            return resultBytes;
        }

        private uint F(uint value, uint key, int roundNumber, bool encrypt, StringBuilder log)
        {
            ulong sum = (ulong)value + (ulong)key;
            uint result = (uint)(sum % 0x100000000UL);

            log.AppendLine();
            log.AppendLine($"   Шаг 1: Целочисленное сложение по модулю");
            log.AppendLine($"      Value = {value} ({FormatBinary32(value)})");
            log.AppendLine($"         Key = {key} ({FormatBinary32(key)})");
            log.AppendLine($"     (Value + Key) mod 2^32 = ");
            log.AppendLine($"     Result = {result} ({FormatBinary32(result)})");
            log.AppendLine();

            byte[] nibbles = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                nibbles[i] = (byte)((result >> (4 * (7 - i))) & 0x0F);
            }

            log.AppendLine($"   Шаг 2: Разбиение на 8 групп по 4 бита:");
            for (int i = 0; i < 8; i++)
            {
                log.AppendLine($"     Группа {i + 1}: {Convert.ToString(nibbles[i], 2).PadLeft(4, '0')} = {nibbles[i]}");
            }
            log.AppendLine();

            log.AppendLine($"   Шаг 3: Замена по S-блокам:");
            uint sBoxResult = 0;
            for (int i = 0; i < 8; i++)
            {
                byte sBoxValue = sBoxes[i, nibbles[i]];
                log.AppendLine($"     Группа {i + 1}: {nibbles[i]} → S{8 - i}[{nibbles[i]}] = {sBoxValue} ({Convert.ToString(sBoxValue, 2).PadLeft(4, '0')})");
                sBoxResult = (sBoxResult << 4) | sBoxValue;
            }
            log.AppendLine($"     Результат замены: {FormatBinary32(sBoxResult)}");
            log.AppendLine();

            uint shifted = (sBoxResult << 11) | (sBoxResult >> (32 - 11));
            log.AppendLine($"   Шаг 4: Циклический сдвиг влево на 11 бит:");
            log.AppendLine($"     До сдвига: {FormatBinary32(sBoxResult)}");
            log.AppendLine($"     После сдвига: {FormatBinary32(shifted)}");

            return shifted;
        }

        private void ProcessRound(ref uint left, ref uint right, uint roundKey, int roundNumber, bool encrypt, StringBuilder log)
        {
            log.AppendLine($"   --- Раунд {roundNumber} ({(encrypt ? "шифрование" : "расшифрование")}) ---");
            log.AppendLine($"   K{roundNumber} = {FormatBinary32(roundKey)}");
            log.AppendLine($"   L = {FormatBinary32(left)}");
            log.AppendLine($"   R = {FormatBinary32(right)}");

            uint fResult = F(right, roundKey, roundNumber, encrypt, log);

            uint newRight = left ^ fResult;
            left = right;
            right = newRight;

            log.AppendLine();
            log.AppendLine($"   Шаг 5: Сложение XOR и перемещение:");
            log.AppendLine($"     L' = R = {FormatBinary32(left)}");
            log.AppendLine($"     R' = L ⊕ F(R, K) = {FormatBinary32(right)}");
            log.AppendLine();
        }

        // Вспомогательные функции
        private uint BytesToUInt32(byte[] bytes, int startIndex)
        {
            return (uint)((bytes[startIndex] << 24) |
                          (bytes[startIndex + 1] << 16) |
                          (bytes[startIndex + 2] << 8) |
                          bytes[startIndex + 3]);
        }

        private byte[] UInt32ToBytes(uint value)
        {
            return new byte[]
            {
                (byte)(value >> 24),
                (byte)(value >> 16),
                (byte)(value >> 8),
                (byte)value
            };
        }

        private string FormatBinary32(uint value)
        {
            string binary = Convert.ToString(value, 2).PadLeft(32, '0');
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                result.Append(binary[i]);
                if ((i + 1) % 4 == 0 && i < 31)
                    result.Append(' ');
            }
            return result.ToString();
        }

        private void UpdateRoundKeysGridView()
        {
            dataGridViewRoundKeys.Rows.Clear();

            for (int i = 0; i < 32; i++)
            {
                string formattedKey = FormatBinary32(roundKeys[i]);
                int keyIndex = (i < 24) ? i % 8 : 7 - (i - 24);

                object[] rowValues = new object[9];
                rowValues[0] = (i + 1).ToString();

                for (int j = 0; j < 8; j++)
                {
                    rowValues[j + 1] = (j == keyIndex) ? formattedKey : "";
                }

                dataGridViewRoundKeys.Rows.Add(rowValues);
            }

            // Подсветка активных ключей
            for (int i = 0; i < 32; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    var cell = dataGridViewRoundKeys.Rows[i].Cells[j];
                    if (!string.IsNullOrEmpty(cell.Value?.ToString()))
                    {
                        cell.Style.BackColor = Color.LightGreen;
                        cell.Style.Font = new Font("Consolas", 9, FontStyle.Bold);
                    }
                    else
                    {
                        cell.Style.BackColor = Color.White;
                        cell.Style.Font = new Font("Consolas", 9);
                    }
                }
                dataGridViewRoundKeys.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewRoundKeys.Rows[i].Cells[0].Style.Font = new Font(dataGridViewRoundKeys.Font, FontStyle.Bold);
            }
        }

        private void Swap(ref uint a, ref uint b)
        {
            uint temp = a;
            a = b;
            b = temp;
        }
    }
}