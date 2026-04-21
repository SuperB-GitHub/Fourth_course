using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        private EnigmaMachine enigma;
        private TextBox txtInput;
        private TextBox txtOutput;
        private ComboBox cmbRotor1, cmbRotor2, cmbRotor3;
        private ComboBox cmbReflector;
        private TextBox txtRotor1Pos, txtRotor2Pos, txtRotor3Pos;
        private Button btnEncrypt;
        private Button btnClear;
        private Label lblStatus;

        public Form1()
        {
            InitializeComponent();
            InitializeEnigma();
        }

        private void InitializeComponent()
        {
            this.Text = "Enigma Machine Simulator";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Заголовок
            Label lblTitle = new Label()
            {
                Text = "Шифровальная машина Энигма",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(200, 20),
                Size = new Size(400, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Панель роторов
            GroupBox gbRotors = new GroupBox()
            {
                Text = "Настройка роторов",
                Location = new Point(20, 80),
                Size = new Size(350, 200),
                Font = new Font("Segoe UI", 10)
            };

            Label lblRotor1 = new Label() { Text = "Ротор 1:", Location = new Point(20, 30), Size = new Size(60, 25) };
            cmbRotor1 = new ComboBox() { Location = new Point(120, 30), Size = new Size(100, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRotor1.Items.AddRange(new[] { "I (EKMFLGDQVZNTOWYHXUSPAIBRCJ)", "II (AJDKSIRUXBLHWTMCQGZNPYFVOE)", "III (BDFHJLCPRTXVZNYEIWGAKMUSQO)" });
            cmbRotor1.SelectedIndex = 0;

            Label lblRotor2 = new Label() { Text = "Ротор 2:", Location = new Point(20, 70), Size = new Size(60, 25) };
            cmbRotor2 = new ComboBox() { Location = new Point(120, 70), Size = new Size(100, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRotor2.Items.AddRange(new[] { "I (EKMFLGDQVZNTOWYHXUSPAIBRCJ)", "II (AJDKSIRUXBLHWTMCQGZNPYFVOE)", "III (BDFHJLCPRTXVZNYEIWGAKMUSQO)" });
            cmbRotor2.SelectedIndex = 1;

            Label lblRotor3 = new Label() { Text = "Ротор 3:", Location = new Point(20, 110), Size = new Size(60, 25) };
            cmbRotor3 = new ComboBox() { Location = new Point(120, 110), Size = new Size(100, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRotor3.Items.AddRange(new[] { "I (EKMFLGDQVZNTOWYHXUSPAIBRCJ)", "II (AJDKSIRUXBLHWTMCQGZNPYFVOE)", "III (BDFHJLCPRTXVZNYEIWGAKMUSQO)" });
            cmbRotor3.SelectedIndex = 2;

            Label lblPos1 = new Label() { Text = "Позиция 1:", Location = new Point(20, 150), Size = new Size(70, 25) };
            txtRotor1Pos = new TextBox() { Location = new Point(120, 150), Size = new Size(40, 25), Text = "A", MaxLength = 1 };

            Label lblPos2 = new Label() { Text = "Позиция 2:", Location = new Point(170, 150), Size = new Size(70, 25) };
            txtRotor2Pos = new TextBox() { Location = new Point(250, 150), Size = new Size(40, 25), Text = "A", MaxLength = 1 };

            Label lblPos3 = new Label() { Text = "Позиция 3:", Location = new Point(20, 180), Size = new Size(70, 25) };
            txtRotor3Pos = new TextBox() { Location = new Point(120, 180), Size = new Size(40, 25), Text = "A", MaxLength = 1 };

            gbRotors.Controls.AddRange(new Control[] { lblRotor1, cmbRotor1, lblRotor2, cmbRotor2,
                lblRotor3, cmbRotor3, lblPos1, txtRotor1Pos, lblPos2, txtRotor2Pos, lblPos3, txtRotor3Pos });

            // Панель рефлектора
            GroupBox gbReflector = new GroupBox()
            {
                Text = "Настройка рефлектора",
                Location = new Point(400, 80),
                Size = new Size(200, 100),
                Font = new Font("Segoe UI", 10)
            };

            Label lblReflector = new Label() { Text = "Рефлектор:", Location = new Point(20, 30), Size = new Size(80, 25) };
            cmbReflector = new ComboBox() { Location = new Point(100, 30), Size = new Size(80, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbReflector.Items.AddRange(new[] { "B", "C" });
            cmbReflector.SelectedIndex = 0;

            gbReflector.Controls.AddRange(new Control[] { lblReflector, cmbReflector });

            // Кнопки
            btnEncrypt = new Button()
            {
                Text = "Шифровать / Дешифровать",
                Location = new Point(400, 200),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnEncrypt.Click += BtnEncrypt_Click;

            btnClear = new Button()
            {
                Text = "Очистить",
                Location = new Point(620, 200),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(220, 220, 220),
                FlatStyle = FlatStyle.Flat
            };
            btnClear.Click += (s, e) => { txtInput.Clear(); txtOutput.Clear(); };

            // Текстовые поля
            Label lblInput = new Label() { Text = "Входной текст:", Location = new Point(20, 300), Size = new Size(150, 25), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            txtInput = new TextBox()
            {
                Location = new Point(20, 330),
                Size = new Size(700, 100),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 12)
            };

            Label lblOutput = new Label() { Text = "Выходной текст:", Location = new Point(20, 440), Size = new Size(150, 25), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            txtOutput = new TextBox()
            {
                Location = new Point(20, 470),
                Size = new Size(700, 100),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 12),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            lblStatus = new Label()
            {
                Text = "Готов к работе",
                Location = new Point(20, 540),
                Size = new Size(700, 20),
                ForeColor = Color.Green
            };

            this.Controls.AddRange(new Control[] { lblTitle, gbRotors, gbReflector, btnEncrypt, btnClear,
                lblInput, txtInput, lblOutput, txtOutput, lblStatus });
        }

        private void InitializeEnigma()
        {
            UpdateEnigmaSettings();
        }

        private void UpdateEnigmaSettings()
        {
            int[] rotors = new int[3];
            rotors[0] = cmbRotor1.SelectedIndex + 1;
            rotors[1] = cmbRotor2.SelectedIndex + 1;
            rotors[2] = cmbRotor3.SelectedIndex + 1;

            char[] positions = new char[3];
            positions[0] = string.IsNullOrEmpty(txtRotor1Pos.Text) ? 'A' : char.ToUpper(txtRotor1Pos.Text[0]);
            positions[1] = string.IsNullOrEmpty(txtRotor2Pos.Text) ? 'A' : char.ToUpper(txtRotor2Pos.Text[0]);
            positions[2] = string.IsNullOrEmpty(txtRotor3Pos.Text) ? 'A' : char.ToUpper(txtRotor3Pos.Text[0]);

            string reflector = cmbReflector.SelectedItem.ToString();

            enigma = new EnigmaMachine(rotors, positions, reflector);
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateEnigmaSettings();
                string input = txtInput.Text.ToUpper();
                string output = "";

                foreach (char c in input)
                {
                    if (char.IsLetter(c))
                    {
                        output += enigma.Encrypt(c);
                    }
                    else
                    {
                        output += c;
                    }
                }

                txtOutput.Text = output;
                lblStatus.Text = "Шифрование/дешифрование выполнено успешно";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Ошибка: {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}