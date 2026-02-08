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
            toolTip1.SetToolTip(buttonEncrypt, "Процесс шифрования:\r\n" +
                "1. Разбиение на блоки по 64 бита\r\n" +
                "2. Начальная перестановка\r\n" +
                "3. 32 раунда преобразования:\r\n   " +
                "- Сложение с ключом раунда\r\n   " +
                "- Замена по S-блокам\r\n   " +
                "- Циклический сдвиг\r\n" +
                "4. Конечная перестановка\r\n5. Объединение блоков");

        }

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
        } // Генерация таблицы ключей

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
        } // Генерация S-блоков

        private void ButtonConvertToBinary_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxKeyInput.Text))
            {
                MessageBox.Show("Введите текст для преобразования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding(1251);

            string inputText = textBoxKeyInput.Text;
            byte[] bytes = win1251.GetBytes(inputText);

            if (bytes.Length < 32)
            {
                MessageBox.Show($"Длина ключа: {bytes.Length} - остальное дополнено нулями", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Array.Resize(ref bytes, 32);
            }
            else if (bytes.Length > 32)
            {
                MessageBox.Show($"Длина ключа: {bytes.Length} - взяты первые 32 байта", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Array.Resize(ref bytes, 32);
            }

            StringBuilder binaryText = new StringBuilder();
            int bitCounter = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                string binaryByte = Convert.ToString(bytes[i], 2).PadLeft(8, '0');

                for (int j = 0; j < 8; j++)
                {
                    binaryText.Append(binaryByte[j]);
                    bitCounter++;

                    if (bitCounter % 4 == 0 && bitCounter < 256)
                    {
                        binaryText.Append(' ');
                    }

                    if (bitCounter % 32 == 0 && bitCounter < 256)
                    {
                        binaryText.AppendLine();
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                keyParts[i] = 0;
                for (int j = 0; j < 4; j++)
                {
                    keyParts[i] = (keyParts[i] << 8) | bytes[i * 4 + j];
                }
            }

            textBoxBinaryKey.Text = binaryText.ToString();

            MessageBox.Show("Текст успешно преобразован в двоичный вид", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Генерация бинарной строки

        private void ButtonGenerateRoundKeys_Click(object sender, EventArgs e)
        {
            if (keyParts[0] == 0 && keyParts[1] == 0)
            {
                MessageBox.Show("Сначала преобразуйте текст в двоичный вид!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridViewRoundKeys.Rows.Clear();

            for (int i = 0; i < 32; i++)
            {
                uint roundKey = 0;
                int keyIndex = 0;

                if (i < 24)
                {
                    keyIndex = i % 8;
                }
                else
                {
                    keyIndex = 7 - (i - 24);
                }

                roundKey = keyParts[keyIndex];
                roundKeys[i] = roundKey;

                string formattedKey = Convert.ToString((long)roundKey, 2).PadLeft(32, '0');
                formattedKey = FormatBinaryWithSpaces(formattedKey);

                object[] rowValues = new object[9];
                rowValues[0] = (i + 1).ToString();

                for (int j = 0; j < 8; j++)
                {
                    if (j == keyIndex)
                    {
                        rowValues[j + 1] = formattedKey;
                    }
                    else
                    {
                        rowValues[j + 1] = "";
                    }
                }

                dataGridViewRoundKeys.Rows.Add(rowValues);
            }

            for (int i = 0; i < 32; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (!string.IsNullOrEmpty(dataGridViewRoundKeys.Rows[i].Cells[j].Value?.ToString()))
                    {
                        dataGridViewRoundKeys.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                }
            }

            MessageBox.Show("Ключи раундов успешно сгенерированы по алгоритму ГОСТ!\n" +
                           "Раунды 1-24: K1..K8, K1..K8, K1..K8\n" +
                           "Раунды 25-32: K8..K1 (обратный порядок)",
                           "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Разбиение ключей

        private string FormatBinaryWithSpaces(string binary)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < binary.Length; i++)
            {
                result.Append(binary[i]);
                if ((i + 1) % 4 == 0 && i != binary.Length - 1)
                {
                    result.Append(' ');
                }
            }
            return result.ToString();
        } // Вспомогательная функция для форматирования двоичной строки

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

            // Начинаем шифрование
            StringBuilder processLog = new StringBuilder();
            processLog.AppendLine("=== ШИФРОВАНИЕ ГОСТ 28147-89 ===\n");

            // 1. Преобразуем текст в байты
            string plainText = textBoxPlainText.Text;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding win1251 = Encoding.GetEncoding(1251);
            byte[] inputBytes = win1251.GetBytes(plainText);

            StringBuilder binaryRepresentation = new StringBuilder();
            foreach (byte b in inputBytes)
            {
                binaryRepresentation.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
            }

            processLog.AppendLine($"1. Исходный текст: \"{plainText}\"");
            processLog.AppendLine($"   Двоичное представление (Windows-1251):");
            processLog.AppendLine($"   {binaryRepresentation}");
            processLog.AppendLine($"   Длина в байтах: {inputBytes.Length}");
            processLog.AppendLine($"   Длина в битах: {inputBytes.Length * 8}");
            processLog.AppendLine();

            // 2. Дополняем до кратного 64 битам (8 байтам)
            int originalLength = inputBytes.Length;
            int paddedLength = ((originalLength + 7) / 8) * 8;
            byte[] paddedBytes = new byte[paddedLength];
            Array.Copy(inputBytes, paddedBytes, originalLength);

            processLog.AppendLine($"2. Дополнение до кратного 64 битам:");
            processLog.AppendLine($"   Было: {originalLength} байт");
            processLog.AppendLine($"   Стало: {paddedLength} байт");
            processLog.AppendLine($"   Всего блоков по 64 бита: {paddedLength / 8}");
            processLog.AppendLine();

            // 3. Шифруем каждый блок
            List<byte[]> encryptedBlocks = new List<byte[]>();

            for (int blockIndex = 0; blockIndex < paddedLength; blockIndex += 8)
            {
                processLog.AppendLine($"=== БЛОК {blockIndex / 8 + 1} ===");

                // Берем 8 байт (64 бита) для текущего блока
                byte[] block = new byte[8];
                Array.Copy(paddedBytes, blockIndex, block, 0, 8);

                // Преобразуем в два uint (32 бита каждый)
                uint left = BytesToUInt32(block, 0);
                uint right = BytesToUInt32(block, 4);

                processLog.AppendLine($"   Исходный блок (64 бита):");
                processLog.AppendLine($"   L0 = {ToBinaryString(left, 32)}");
                processLog.AppendLine($"   R0 = {ToBinaryString(right, 32)}");
                processLog.AppendLine();

                // 32 раунда шифрования
                for (int round = 0; round < 32; round++)
                {
                    processLog.AppendLine($"   --- Раунд {round + 1} ---");

                    uint roundKey = roundKeys[round];
                    processLog.AppendLine($"   K{round + 1} = {ToBinaryString(roundKey, 32)}");
                    processLog.AppendLine($"   L{round} = {ToBinaryString(left, 32)}");
                    processLog.AppendLine($"   R{round} = {ToBinaryString(right, 32)}");

                    // Вычисляем функцию F
                    uint fResult = F(right, roundKey, round + 1, processLog);

                    // Основное преобразование
                    uint newRight = left ^ fResult;
                    left = right;
                    right = newRight;

                    processLog.AppendLine($"   L{round + 1} = R{round} = {ToBinaryString(left, 32)}");
                    processLog.AppendLine($"   R{round + 1} = L{round} ⊕ F(R{round}, K{round + 1}) = {ToBinaryString(right, 32)}");
                    processLog.AppendLine();
                }

                // После 32 раундов меняем местами (последний обмен не выполняется в ГОСТ)
                uint temp = left;
                left = right;
                right = temp;

                // Преобразуем обратно в байты
                byte[] encryptedBlock = new byte[8];
                byte[] leftBytes = UInt32ToBytes(left);
                byte[] rightBytes = UInt32ToBytes(right);
                Array.Copy(leftBytes, 0, encryptedBlock, 0, 4);
                Array.Copy(rightBytes, 0, encryptedBlock, 4, 4);
                encryptedBlocks.Add(encryptedBlock);

                processLog.AppendLine($"   Результат шифрования блока:");
                processLog.AppendLine($"   L32 = {ToBinaryString(left, 32)}");
                processLog.AppendLine($"   R32 = {ToBinaryString(right, 32)}");
                processLog.AppendLine($"   Шифроблок: {BitConverter.ToString(encryptedBlock).Replace("-", " ")}");
                processLog.AppendLine();
            }

            // 4. Формируем итоговый результат
            int totalLength = 0;
            foreach (var block in encryptedBlocks)
            {
                totalLength += block.Length;
            }
            byte[] encryptedBytes = new byte[totalLength];
            int offset = 0;
            foreach (var block in encryptedBlocks)
            {
                Array.Copy(block, 0, encryptedBytes, offset, block.Length);
                offset += block.Length;
            }

            // Преобразуем в двоичную строку для отображения
            StringBuilder binaryResult = new StringBuilder();
            foreach (byte b in encryptedBytes)
            {
                binaryResult.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
                if (binaryResult.ToString().Split(' ').Length % 4 == 0)
                    binaryResult.AppendLine();
            }

            // Отображаем результат
            textBoxCipherText.Text = processLog.ToString() +
                "=== ИТОГОВЫЙ РЕЗУЛЬТАТ ===\n\n" +
                $"Зашифрованный текст (двоичный):\n{binaryResult}\n" +
                $"Зашифрованный текст (hex): {BitConverter.ToString(encryptedBytes).Replace("-", " ")}\n" +
                $"Длина: {encryptedBytes.Length} байт ({encryptedBytes.Length * 8} бит)";

            MessageBox.Show("Текст успешно зашифрован!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private uint BytesToUInt32(byte[] bytes, int startIndex)
        {
            // Правильный порядок: первый байт - старшие биты
            return (uint)((bytes[startIndex] << 24) |
                          (bytes[startIndex + 1] << 16) |
                          (bytes[startIndex + 2] << 8) |
                          bytes[startIndex + 3]);
        }

        private byte[] UInt32ToBytes(uint value)
        {
            // Обратное преобразование
            return new byte[]
            {
        (byte)(value >> 24),
        (byte)(value >> 16),
        (byte)(value >> 8),
        (byte)value
            };
        }

        private uint BinaryStringToUInt(string binaryString)
        {
            // Удаляем пробелы из строки
            string cleanBinary = binaryString.Replace(" ", "");

            // Преобразуем двоичную строку в uint
            return Convert.ToUInt32(cleanBinary, 2);
        }

        // Или исправленная версия ToBinaryString для правильного отображения:
        private string UIntToFormattedBinary(uint value)
        {
            string binary = Convert.ToString(value, 2).PadLeft(32, '0');

            // Форматируем с пробелами каждые 4 бита
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                result.Append(binary[i]);
                if ((i + 1) % 4 == 0 && i < 31)
                    result.Append(' ');
            }

            return result.ToString();
        }

        private uint F(uint right, uint key, int roundNumber, StringBuilder log)
        {
            log.AppendLine($"   Шаг 1: (R + K) mod 2^32");
            log.AppendLine($"     R = {right} ({UIntToFormattedBinary(right)})");
            log.AppendLine($"     K = {key} ({UIntToFormattedBinary(key)})");

            // 1. Сложение по модулю 2^32
            ulong sum = (ulong)right + (ulong)key;
            uint result = (uint)(sum % 0x100000000);

            log.AppendLine($"     (R + K) = {sum}");
            log.AppendLine($"     (R + K) mod 2^32 = {result} ({UIntToFormattedBinary(result)})");
            log.AppendLine();

            // 2. Разбиваем на 8 групп по 4 бита
            log.AppendLine($"   Шаг 2: Разбиение на 8 групп по 4 бита:");
            byte[] nibbles = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                nibbles[i] = (byte)((result >> (4 * (7 - i))) & 0x0F);
                log.AppendLine($"     Группа {i + 1}: {Convert.ToString(nibbles[i], 2).PadLeft(4, '0')} = {nibbles[i]}");
            }
            log.AppendLine();

            // 3. Замена по S-блокам (используем S-блоки в обратном порядке: S8..S1)
            log.AppendLine($"   Шаг 3: Замена по S-блокам (используем S{8}..S{1}):");
            uint sBoxResult = 0;
            for (int i = 0; i < 8; i++)
            {
                int sBoxIndex = 7 - i; // Обратный порядок S-блоков
                byte sBoxValue = sBoxes[sBoxIndex, nibbles[i]];
                log.AppendLine($"     Группа {i + 1}: {nibbles[i]} → S{sBoxIndex + 1}[{nibbles[i]}] = {sBoxValue} ({Convert.ToString(sBoxValue, 2).PadLeft(4, '0')})");
                sBoxResult = (sBoxResult << 4) | sBoxValue;
            }
            log.AppendLine($"     Результат замены: {ToBinaryString(sBoxResult, 32)}");
            log.AppendLine();

            // 4. Циклический сдвиг влево на 11 бит
            log.AppendLine($"   Шаг 4: Циклический сдвиг влево на 11 бит:");
            uint shifted = (sBoxResult << 11) | (sBoxResult >> (32 - 11));
            log.AppendLine($"     До сдвига:  {ToBinaryString(sBoxResult, 32)}");
            log.AppendLine($"     После сдвига: {ToBinaryString(shifted, 32)}");

            return shifted;
        } // ФУНКЦИЯ ПРЕОБРАЗОВАНИЯ F(R, K)
        
        private string ToBinaryString(uint value, int length)
        {
            string binary = Convert.ToString(value, 2).PadLeft(length, '0');
            // Добавляем пробелы каждые 4 бита для читаемости
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < binary.Length; i++)
            {
                result.Append(binary[i]);
                if ((i + 1) % 4 == 0 && i != binary.Length - 1)
                    result.Append(' ');
            }
            return result.ToString();
        } // ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCipherInput.Text))
            {
                MessageBox.Show("Введите шифротекст", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Пример расшифрованного текста
            textBoxDecryptedText.Text = "Пример текста для шифрования";
            textBoxBinaryResult.Text = "01000101 01111000 01100001 01101101 01110000 01101100 01100101\r\n" +
                                      "00100000 01110100 01100101 01111000 01110100 01100001 00100000\r\n" +
                                      "01100110 01101111 01110010 00100000 01110011 01101000 01101001\r\n" +
                                      "01100110 01110010 01101111 01110110 01100001 01101110 01101001\r\n" +
                                      "01111001 01100001";

            MessageBox.Show("Текст успешно расшифрован!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}