using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Лаба_5
{
    public partial class Form1 : Form
    {
        private static readonly Dictionary<char, (int start, int end)> CipherMap = new Dictionary<char, (int, int)>()
        {
            { ' ', (0, 144) },
            { 'О', (145, 239) },
            { 'Е', (240, 313) },
            { 'А', (314, 377) },
            { 'И', (378, 441) },
            { 'Т', (442, 497) },
            { 'Н', (498, 552) },
            { 'С', (553, 598) },
            { 'Р', (599, 639) },
            { 'В', (640, 678) },
            { 'Л', (679, 714) },
            { 'К', (715, 743) },
            { 'М', (744, 769) },
            { 'Д', (770, 795) },
            { 'П', (796, 819) },
            { 'У', (820, 840) },
            { 'Я', (841, 859) },
            { 'Ы', (860, 875) },
            { 'З', (876, 890) },
            { 'Ь', (891, 905) },
            { 'Ъ', (891, 905) },
            { 'Б', (906, 920) },
            { 'Г', (921, 934) },
            { 'Ч', (935, 947) },
            { 'Й', (948, 957) },
            { 'Х', (958, 966) },
            { 'Ж', (967, 974) },
            { 'Ю', (975, 981) },
            { 'Ш', (982, 987) },
            { 'Ц', (988, 991) },
            { 'Щ', (992, 994) },
            { 'Э', (995, 997) },
            { 'Ф', (998, 999) }
        };

        private static readonly Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
            RB_Num.Checked = true;
            ConfigureFileDialogs();
            FillCipherTable(DGV_CipherTable);
            FillCipherTable(DGV_CipherTable1);
        }

        //Работа приложения
        private void BTN_Encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = RTB_InputOT.Text;
                if (string.IsNullOrWhiteSpace(input))
                {
                    RTB_Crypted.Text = "";
                    return;
                }

                bool useNumbers = RB_Num.Checked;
                string encrypted = Encrypt(input, useNumbers);
                RTB_Crypted.Text = encrypted;
                //RTB_InputEnc.Text = encrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void BTN_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string input = RTB_InputEnc.Text.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    RTB_Decrypted.Text = "";
                    return;
                }

                string decrypted = Decrypt(input);
                RTB_Decrypted.Text = decrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровании:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void BTN_OpenOT_Click(object sender, EventArgs e)
        {
            try
            {
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string filePath = OFD.FileName;
                    string content = File.ReadAllText(filePath, Encoding.UTF8);
                    RTB_InputOT.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void BTN_OpenInc_Click(object sender, EventArgs e)
        {
            try
            {
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    string filePath = OFD.FileName;
                    string content = File.ReadAllText(filePath, Encoding.UTF8);
                    RTB_InputEnc.Text = content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void BTN_SaveOT_Click(object sender, EventArgs e)
        {
            try
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    string filePath = SFD.FileName;
                    File.WriteAllText(filePath, RTB_Crypted.Text, Encoding.UTF8);
                    MessageBox.Show("Файл успешно сохранен!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void BTN_SaveEnc_Click(object sender, EventArgs e)
        {
            try
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    string filePath = SFD.FileName;
                    File.WriteAllText(filePath, RTB_Decrypted.Text, Encoding.UTF8);
                    MessageBox.Show("Файл успешно сохранен!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        //Алгоритмы
        private string Encrypt(string text, bool useNumbers)
        {
            var result = new StringBuilder();
            string upperText = text.ToUpperInvariant();
            foreach (char c in upperText)
            {
                if (CipherMap.TryGetValue(c, out var range))
                {
                    int code = _random.Next(range.start, range.end + 1);
                    if (useNumbers)
                    {
                        if (result.Length > 0)
                            result.Append(' ');
                        result.Append(code.ToString("D3"));
                    }
                    else
                    {
                        result.Append((char)code);
                    }
                }
            }
            return result.ToString();
        }
        private string Decrypt(string input)
        {
            var result = new StringBuilder();

            if (input.All(c => char.IsDigit(c) || char.IsWhiteSpace(c) || c == '-'))
            {
                string[] parts = input.Split(' ');
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int code) && code >= 0 && code <= 999)
                    {
                        char? letter = CodeToLetter(code);
                        if (letter.HasValue)
                            result.Append(letter.Value);
                    }
                }
            }
            else
            {
                foreach (char c in input)
                {
                    int code = (int)c;
                    char? letter = CodeToLetter(code);
                    if (letter.HasValue)
                        result.Append(letter.Value);
                }
            }

            return result.ToString();
        }
        private char? CodeToLetter(int code)
        {
            foreach (var kvp in CipherMap)
            {
                if (code >= kvp.Value.start && code <= kvp.Value.end)
                    return kvp.Key;
            }
            return null;
        }

        //Конфигурации
        private void FillCipherTable(DataGridView table)
        {
            // Настраиваем столбцы
            table.Columns.Clear();
            table.Columns.Add("Letter", "Буква");
            table.Columns.Add("Probability", "Вероятность");
            table.Columns.Add("Range", "Числовой диапазон");
            table.Columns.Add("Unicode", "Символы Unicode");

            // Авторазмер
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.Columns["Probability"].DefaultCellStyle.Format = "F3";

            // Заполняем строки
            foreach (var kvp in CipherMap)
            {
                char letter = kvp.Key;
                int start = kvp.Value.start;
                int end = kvp.Value.end;

                int count = end - start + 1;
                double probability = count / 1000.0;

                string range = $"{start} – {end}";
                string unicodePreview = GetUnicodePreview(start, end, 100);

                table.Rows.Add(letter, probability, range, unicodePreview);
            }

            table.Sort(table.Columns["Probability"], System.ComponentModel.ListSortDirection.Descending);
        }
        private string GetUnicodePreview(int start, int end, int maxCount)
        {
            var sb = new StringBuilder();
            int count = 0;
            for (int i = start; i <= end && count < maxCount; i++)
            {
                char c = (char)i;
                sb.Append(c);
                count++;
            }
            return sb.ToString();
        }
        private void ConfigureFileDialogs()
        {
            OFD.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            OFD.FilterIndex = 1;
            OFD.RestoreDirectory = true;
            OFD.Title = "Открыть текстовый файл";

            SFD.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            SFD.FilterIndex = 1;
            SFD.RestoreDirectory = true;
            SFD.Title = "Сохранить текстовый файл";
        }
    }
}