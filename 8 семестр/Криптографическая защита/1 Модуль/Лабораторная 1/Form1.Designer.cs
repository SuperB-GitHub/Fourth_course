using System;
using System.Windows.Forms;

namespace Лабораторная_1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGenerateRoundKeys = new System.Windows.Forms.Button();
            this.dataGridViewRoundKeys = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBinaryKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelDecimalTitle = new System.Windows.Forms.Label();
            this.labelBinaryTitle = new System.Windows.Forms.Label();
            this.dataGridViewSBlocksDecimal = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewSBlocks = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCipherText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.textBoxPlainText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxDecryptProcess = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxBinaryResult = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxDecryptedText = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.textBoxDecryptionKey = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxCipherInput = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoundKeys)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBlocksDecimal)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBlocks)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1184, 661);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.buttonGenerateRoundKeys);
            this.tabPage1.Controls.Add(this.dataGridViewRoundKeys);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBoxBinaryKey);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1176, 631);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Формирование ключей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(549, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(485, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ключ ГОСТ 28147-89 имеет длину 256 бит и разбивается на 8 подключей";
            // 
            // buttonGenerateRoundKeys
            // 
            this.buttonGenerateRoundKeys.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerateRoundKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateRoundKeys.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonGenerateRoundKeys.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateRoundKeys.Location = new System.Drawing.Point(553, 108);
            this.buttonGenerateRoundKeys.Name = "buttonGenerateRoundKeys";
            this.buttonGenerateRoundKeys.Size = new System.Drawing.Size(500, 35);
            this.buttonGenerateRoundKeys.TabIndex = 8;
            this.buttonGenerateRoundKeys.Text = "Сгенерировать ключ и сформировать ключи раундов";
            this.buttonGenerateRoundKeys.UseVisualStyleBackColor = false;
            this.buttonGenerateRoundKeys.Click += new System.EventHandler(this.ButtonGenerateRoundKeys_Click);
            // 
            // dataGridViewRoundKeys
            // 
            this.dataGridViewRoundKeys.AllowUserToAddRows = false;
            this.dataGridViewRoundKeys.AllowUserToDeleteRows = false;
            this.dataGridViewRoundKeys.AllowUserToResizeColumns = false;
            this.dataGridViewRoundKeys.AllowUserToResizeRows = false;
            this.dataGridViewRoundKeys.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRoundKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoundKeys.Location = new System.Drawing.Point(20, 282);
            this.dataGridViewRoundKeys.Name = "dataGridViewRoundKeys";
            this.dataGridViewRoundKeys.RowHeadersVisible = false;
            this.dataGridViewRoundKeys.Size = new System.Drawing.Size(1140, 326);
            this.dataGridViewRoundKeys.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ключи раундов (32 раунда × 32 бита):";
            // 
            // textBoxBinaryKey
            // 
            this.textBoxBinaryKey.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxBinaryKey.Font = new System.Drawing.Font("Consolas", 9F);
            this.textBoxBinaryKey.Location = new System.Drawing.Point(24, 86);
            this.textBoxBinaryKey.Multiline = true;
            this.textBoxBinaryKey.Name = "textBoxBinaryKey";
            this.textBoxBinaryKey.ReadOnly = true;
            this.textBoxBinaryKey.Size = new System.Drawing.Size(500, 159);
            this.textBoxBinaryKey.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Двоичное представление ключа (256 бит):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Формирование ключей для ГОСТ 28147-89";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.labelDecimalTitle);
            this.tabPage2.Controls.Add(this.labelBinaryTitle);
            this.tabPage2.Controls.Add(this.dataGridViewSBlocksDecimal);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewSBlocks);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1176, 631);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Таблица перестановок";
            // 
            // labelDecimalTitle
            // 
            this.labelDecimalTitle.AutoSize = true;
            this.labelDecimalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelDecimalTitle.Location = new System.Drawing.Point(584, 75);
            this.labelDecimalTitle.Name = "labelDecimalTitle";
            this.labelDecimalTitle.Size = new System.Drawing.Size(281, 19);
            this.labelDecimalTitle.TabIndex = 6;
            this.labelDecimalTitle.Text = "S-блоки в десятичном представлении:";
            // 
            // labelBinaryTitle
            // 
            this.labelBinaryTitle.AutoSize = true;
            this.labelBinaryTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelBinaryTitle.Location = new System.Drawing.Point(20, 75);
            this.labelBinaryTitle.Name = "labelBinaryTitle";
            this.labelBinaryTitle.Size = new System.Drawing.Size(269, 19);
            this.labelBinaryTitle.TabIndex = 5;
            this.labelBinaryTitle.Text = "S-блоки в двоичном представлении:";
            // 
            // dataGridViewSBlocksDecimal
            // 
            this.dataGridViewSBlocksDecimal.AllowUserToAddRows = false;
            this.dataGridViewSBlocksDecimal.AllowUserToDeleteRows = false;
            this.dataGridViewSBlocksDecimal.AllowUserToResizeColumns = false;
            this.dataGridViewSBlocksDecimal.AllowUserToResizeRows = false;
            this.dataGridViewSBlocksDecimal.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSBlocksDecimal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSBlocksDecimal.Location = new System.Drawing.Point(588, 100);
            this.dataGridViewSBlocksDecimal.Name = "dataGridViewSBlocksDecimal";
            this.dataGridViewSBlocksDecimal.RowHeadersVisible = false;
            this.dataGridViewSBlocksDecimal.Size = new System.Drawing.Size(572, 437);
            this.dataGridViewSBlocksDecimal.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(20, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 80);
            this.panel1.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(794, 38);
            this.label9.TabIndex = 1;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Пояснение:";
            // 
            // dataGridViewSBlocks
            // 
            this.dataGridViewSBlocks.AllowUserToAddRows = false;
            this.dataGridViewSBlocks.AllowUserToDeleteRows = false;
            this.dataGridViewSBlocks.AllowUserToResizeColumns = false;
            this.dataGridViewSBlocks.AllowUserToResizeRows = false;
            this.dataGridViewSBlocks.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSBlocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSBlocks.Location = new System.Drawing.Point(20, 100);
            this.dataGridViewSBlocks.Name = "dataGridViewSBlocks";
            this.dataGridViewSBlocks.RowHeadersVisible = false;
            this.dataGridViewSBlocks.Size = new System.Drawing.Size(542, 437);
            this.dataGridViewSBlocks.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(456, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "ГОСТ использует 8 различных S-блоков для замены 4-битных входов:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(20, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(387, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Таблица замен (S-блоки) ГОСТ 28147-89";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1176, 631);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Зашифрование";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCipherText);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox2.Location = new System.Drawing.Point(20, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1133, 391);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результат шифрования";
            // 
            // textBoxCipherText
            // 
            this.textBoxCipherText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCipherText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCipherText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCipherText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCipherText.Location = new System.Drawing.Point(3, 21);
            this.textBoxCipherText.Name = "textBoxCipherText";
            this.textBoxCipherText.Size = new System.Drawing.Size(1127, 367);
            this.textBoxCipherText.TabIndex = 0;
            this.textBoxCipherText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEncrypt);
            this.groupBox1.Controls.Add(this.textBoxPlainText);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox1.Location = new System.Drawing.Point(20, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходный текст";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEncrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonEncrypt.ForeColor = System.Drawing.Color.White;
            this.buttonEncrypt.Location = new System.Drawing.Point(476, 130);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(200, 40);
            this.buttonEncrypt.TabIndex = 6;
            this.buttonEncrypt.Text = "Зашифровать";
            this.buttonEncrypt.UseVisualStyleBackColor = false;
            this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // textBoxPlainText
            // 
            this.textBoxPlainText.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPlainText.Location = new System.Drawing.Point(6, 24);
            this.textBoxPlainText.Multiline = true;
            this.textBoxPlainText.Name = "textBoxPlainText";
            this.textBoxPlainText.Size = new System.Drawing.Size(1121, 100);
            this.textBoxPlainText.TabIndex = 1;
            this.textBoxPlainText.Text = "Пример текста для шифрования";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(20, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(326, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Зашифрование по ГОСТ 28147-89";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1176, 631);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Расшифрование";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label24);
            this.panel3.Location = new System.Drawing.Point(20, 576);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1140, 47);
            this.panel3.TabIndex = 3;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(15, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(595, 38);
            this.label24.TabIndex = 0;
            this.label24.Text = "Расшифрование осуществляется обратными операциями в обратном порядке:\r\nиспользова" +
    "ние ключей раундов с 32-го по 1-й, обратные S-блоки, обратные перестановки.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxDecryptProcess);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.textBoxBinaryResult);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.textBoxDecryptedText);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox4.Location = new System.Drawing.Point(590, 70);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(570, 500);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результат расшифрования";
            // 
            // textBoxDecryptProcess
            // 
            this.textBoxDecryptProcess.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDecryptProcess.Font = new System.Drawing.Font("Consolas", 9F);
            this.textBoxDecryptProcess.Location = new System.Drawing.Point(20, 400);
            this.textBoxDecryptProcess.Multiline = true;
            this.textBoxDecryptProcess.Name = "textBoxDecryptProcess";
            this.textBoxDecryptProcess.ReadOnly = true;
            this.textBoxDecryptProcess.Size = new System.Drawing.Size(520, 80);
            this.textBoxDecryptProcess.TabIndex = 5;
            this.textBoxDecryptProcess.Text = "1. sds\r\nИспользование ключей раундов в обратном порядке\r\n2. Обратные S-блоки\r\n3. " +
    "Обратная перестановка\r\n4. Объединение блоков";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 370);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(172, 19);
            this.label23.TabIndex = 4;
            this.label23.Text = "Процесс расшифрования:";
            // 
            // textBoxBinaryResult
            // 
            this.textBoxBinaryResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxBinaryResult.Font = new System.Drawing.Font("Consolas", 9F);
            this.textBoxBinaryResult.Location = new System.Drawing.Point(20, 270);
            this.textBoxBinaryResult.Multiline = true;
            this.textBoxBinaryResult.Name = "textBoxBinaryResult";
            this.textBoxBinaryResult.ReadOnly = true;
            this.textBoxBinaryResult.Size = new System.Drawing.Size(520, 80);
            this.textBoxBinaryResult.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(246, 19);
            this.label22.TabIndex = 2;
            this.label22.Text = "Двоичное представление результата:";
            // 
            // textBoxDecryptedText
            // 
            this.textBoxDecryptedText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDecryptedText.Font = new System.Drawing.Font("Consolas", 10F);
            this.textBoxDecryptedText.Location = new System.Drawing.Point(20, 70);
            this.textBoxDecryptedText.Multiline = true;
            this.textBoxDecryptedText.Name = "textBoxDecryptedText";
            this.textBoxDecryptedText.ReadOnly = true;
            this.textBoxDecryptedText.Size = new System.Drawing.Size(520, 150);
            this.textBoxDecryptedText.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(162, 19);
            this.label21.TabIndex = 0;
            this.label21.Text = "Расшифрованный текст:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDecrypt);
            this.groupBox3.Controls.Add(this.textBoxDecryptionKey);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBoxCipherInput);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(20, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 500);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Входные данные для расшифрования";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDecrypt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDecrypt.ForeColor = System.Drawing.Color.White;
            this.buttonDecrypt.Location = new System.Drawing.Point(20, 370);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(200, 40);
            this.buttonDecrypt.TabIndex = 4;
            this.buttonDecrypt.Text = "Расшифровать";
            this.buttonDecrypt.UseVisualStyleBackColor = false;
            this.buttonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // textBoxDecryptionKey
            // 
            this.textBoxDecryptionKey.Font = new System.Drawing.Font("Consolas", 10F);
            this.textBoxDecryptionKey.Location = new System.Drawing.Point(20, 270);
            this.textBoxDecryptionKey.Multiline = true;
            this.textBoxDecryptionKey.Name = "textBoxDecryptionKey";
            this.textBoxDecryptionKey.Size = new System.Drawing.Size(500, 80);
            this.textBoxDecryptionKey.TabIndex = 3;
            this.textBoxDecryptionKey.Text = "Секретный ключ шифрования";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(179, 19);
            this.label19.TabIndex = 2;
            this.label19.Text = "Ключ для расшифрования:";
            // 
            // textBoxCipherInput
            // 
            this.textBoxCipherInput.Font = new System.Drawing.Font("Consolas", 9F);
            this.textBoxCipherInput.Location = new System.Drawing.Point(20, 70);
            this.textBoxCipherInput.Multiline = true;
            this.textBoxCipherInput.Name = "textBoxCipherInput";
            this.textBoxCipherInput.Size = new System.Drawing.Size(500, 150);
            this.textBoxCipherInput.TabIndex = 1;
            this.textBoxCipherInput.Text = "1101 0010 1010 1100 0111 1001 0101 0011\r\n1010 0110 1100 1011 0100 1110 0011 1001\r" +
    "\n0110 1011 1100 0101 0010 1110 1001 0110\r\n1011 0100 1101 0010 0111 1001 0101 110" +
    "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 19);
            this.label18.TabIndex = 0;
            this.label18.Text = "Шифротекст (двоичный):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(20, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(336, 25);
            this.label17.TabIndex = 0;
            this.label17.Text = "Расшифрование по ГОСТ 28147-89";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ГОСТ 28147-89 - Лабораторная работа";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoundKeys)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBlocksDecimal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSBlocks)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGenerateRoundKeys;
        private System.Windows.Forms.DataGridView dataGridViewRoundKeys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBinaryKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewSBlocks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxDecryptProcess;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxBinaryResult;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxDecryptedText;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox textBoxDecryptionKey;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxCipherInput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridViewSBlocksDecimal;
        private System.Windows.Forms.Label labelBinaryTitle;
        private System.Windows.Forms.Label labelDecimalTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RichTextBox textBoxCipherText;
    }
}