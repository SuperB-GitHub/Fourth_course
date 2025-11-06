using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
        }

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

                string encrypted = Encrypt(input);
                RTB_Crypted.Text = encrypted;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании:\n{ex.Message}",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private string Encrypt(string text)
        {
            var result = new StringBuilder();
            string upperText = text.ToUpperInvariant();

            foreach (char c in upperText)
            {
                if (CipherMap.TryGetValue(c, out var range))
                {
                    int code = _random.Next(range.start, range.end + 1);
                    if (result.Length > 0)
                        result.Append(' ');
                    result.Append(code.ToString("D3"));
                }
            }

            return result.ToString();
        }
    }
}