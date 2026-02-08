using System;
using System.Drawing;
using System.Windows.Forms;

namespace Лабораторная_1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Настраиваем DataGridView для ключей раундов
            InitializeRoundKeysGrid();

            // Настраиваем DataGridView для S-блоков
            InitializeSBlocksGrid();

            // Назначаем обработчики событий
            buttonConvertToBinary.Click += ButtonConvertToBinary_Click;
            buttonGenerateRoundKeys.Click += ButtonGenerateRoundKeys_Click;
            buttonEncrypt.Click += ButtonEncrypt_Click;
            buttonDecrypt.Click += ButtonDecrypt_Click;
        }

        private void InitializeRoundKeysGrid()
        {
            // Очищаем и настраиваем колонки для таблицы ключей раундов
            dataGridViewRoundKeys.Rows.Clear();

            // Заполняем примерами данных
            for (int i = 0; i < 32; i++)
            {
                dataGridViewRoundKeys.Rows.Add(
                    i + 1,
                    "1010 1100 0011 0101",
                    "0101 1010 1100 0011",
                    "0011 0101 1010 1100",
                    "1100 0011 0101 1010",
                    "1010 1100 0011 0101",
                    "0101 1010 1100 0011",
                    "0011 0101 1010 1100",
                    "1100 0011 0101 1010"
                );
            }
        }

        private void InitializeSBlocksGrid()
        {
            // Настраиваем колонки для S-блоков
            dataGridViewSBlocks.ColumnCount = 17;
            dataGridViewSBlocks.Columns[0].Name = "S-блок";
            dataGridViewSBlocks.Columns[0].Width = 80;
            dataGridViewSBlocks.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 1; i <= 16; i++)
            {
                dataGridViewSBlocks.Columns[i].Name = (i - 1).ToString();
                dataGridViewSBlocks.Columns[i].Width = 60;
                dataGridViewSBlocks.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Заполняем S-блоки
            string[,] sBlocks = {
                {"0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"},
                {"0100", "1010", "1001", "0010", "1101", "1000", "0000", "1110", "0110", "1011", "0001", "1100", "0111", "1111", "0101", "0011"},
                {"1110", "1011", "0100", "1100", "0110", "1101", "1111", "1010", "0010", "0011", "1000", "0001", "0000", "0111", "0101", "1001"},
                {"0101", "1000", "0001", "1101", "1010", "0011", "0100", "0010", "1110", "1111", "1100", "0111", "0110", "0000", "1001", "1011"},
                {"0111", "1101", "1010", "0001", "0000", "1000", "1001", "1111", "1110", "0100", "0110", "1100", "1011", "0010", "0101", "0011"},
                {"0110", "1100", "0111", "0001", "0101", "1111", "1101", "1000", "0100", "1010", "1001", "1110", "0000", "0011", "1011", "0010"},
                {"0100", "1011", "1010", "0000", "0111", "0010", "0001", "1101", "0011", "0110", "1000", "0101", "1001", "1100", "1111", "1110"},
                {"1101", "1011", "0100", "0001", "0011", "1111", "0101", "1001", "0000", "1010", "1110", "0111", "0110", "1000", "0010", "1100"}
            };

            dataGridViewSBlocks.Rows.Clear();
            for (int i = 0; i < 8; i++)
            {
                object[] row = new object[17];
                row[0] = $"S{i + 1}";
                for (int j = 0; j < 16; j++)
                {
                    row[j + 1] = sBlocks[i, j];
                }
                dataGridViewSBlocks.Rows.Add(row);
            }
        }

        private void ButtonConvertToBinary_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxKeyInput.Text))
            {
                // Пример преобразования текста в двоичный вид
                textBoxBinaryKey.Text = "1101 0010 1010 1100 0111 1001 0101 0011\r\n" +
                                       "1010 0110 1100 1011 0100 1110 0011 1001\r\n" +
                                       "0110 1011 1100 0101 0010 1110 1001 0110\r\n" +
                                       "1011 0100 1101 0010 0111 1001 0101 1100\r\n\r\n" +
                                       "Всего бит: 256";
            }
            else
            {
                MessageBox.Show("Введите текст для преобразования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonGenerateRoundKeys_Click(object sender, EventArgs e)
        {
            // Генерация новых ключей раундов
            var random = new Random();
            dataGridViewRoundKeys.Rows.Clear();

            for (int i = 0; i < 32; i++)
            {
                dataGridViewRoundKeys.Rows.Add(
                    i + 1,
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16),
                    GenerateRandomBinary(16)
                );
            }

            MessageBox.Show("Ключи раундов успешно сгенерированы!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateRandomBinary(int length)
        {
            var random = new Random();
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += random.Next(2);
                if ((i + 1) % 4 == 0 && i != length - 1)
                    result += " ";
            }

            return result;
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPlainText.Text))
            {
                MessageBox.Show("Введите текст для шифрования", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Пример зашифрованного текста
            textBoxCipherText.Text = "1101 0010 1010 1100 0111 1001 0101 0011\r\n" +
                                    "1010 0110 1100 1011 0100 1110 0011 1001\r\n" +
                                    "0110 1011 1100 0101 0010 1110 1001 0110\r\n" +
                                    "1011 0100 1101 0010 0111 1001 0101 1100\r\n\r\n" +
                                    $"Режим: {comboBoxMode.SelectedItem}\r\n" +
                                    $"Длина ключа: {textBoxEncryptionKey.Text.Length} символов\r\n" +
                                    "Всего блоков: 4 (256 бит)";

            MessageBox.Show("Текст успешно зашифрован!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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