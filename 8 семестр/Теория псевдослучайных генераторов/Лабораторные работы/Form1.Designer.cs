namespace Лабораторные_работы
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.checkBoxMaxPeriod = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSequence = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPresets = new System.Windows.Forms.ComboBox();
            this.labelPreset = new System.Windows.Forms.Label();
            this.labelM = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.labelX0 = new System.Windows.Forms.Label();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxX0 = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.BTN_Generate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CLB_MaxPeriod = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 700);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 671);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Линейный конгруэнтный";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxPeriod);
            this.groupBox3.Controls.Add(this.labelPeriod);
            this.groupBox3.Controls.Add(this.numericUpDownCount);
            this.groupBox3.Location = new System.Drawing.Point(350, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результаты анализа";
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(23, 54);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.ReadOnly = true;
            this.textBoxPeriod.Size = new System.Drawing.Size(291, 22);
            this.textBoxPeriod.TabIndex = 2;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Location = new System.Drawing.Point(20, 33);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(80, 16);
            this.labelPeriod.TabIndex = 1;
            this.labelPeriod.Text = "Период (T):";
            // 
            // checkBoxMaxPeriod
            // 
            this.checkBoxMaxPeriod.AutoSize = true;
            this.checkBoxMaxPeriod.Location = new System.Drawing.Point(17, 101);
            this.checkBoxMaxPeriod.Name = "checkBoxMaxPeriod";
            this.checkBoxMaxPeriod.Size = new System.Drawing.Size(282, 20);
            this.checkBoxMaxPeriod.TabIndex = 0;
            this.checkBoxMaxPeriod.Text = "Достигнут максимальный период (T=m)";
            this.checkBoxMaxPeriod.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxSequence);
            this.groupBox2.Controls.Add(this.buttonSave);
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Location = new System.Drawing.Point(20, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1150, 500);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сгенерированная последовательность";
            // 
            // textBoxSequence
            // 
            this.textBoxSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSequence.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSequence.Location = new System.Drawing.Point(17, 21);
            this.textBoxSequence.Multiline = true;
            this.textBoxSequence.Name = "textBoxSequence";
            this.textBoxSequence.ReadOnly = true;
            this.textBoxSequence.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSequence.Size = new System.Drawing.Size(1110, 430);
            this.textBoxSequence.TabIndex = 0;
            this.textBoxSequence.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTN_Generate);
            this.groupBox1.Controls.Add(this.comboBoxPresets);
            this.groupBox1.Controls.Add(this.labelPreset);
            this.groupBox1.Controls.Add(this.labelM);
            this.groupBox1.Controls.Add(this.labelB);
            this.groupBox1.Controls.Add(this.labelA);
            this.groupBox1.Controls.Add(this.labelX0);
            this.groupBox1.Controls.Add(this.textBoxM);
            this.groupBox1.Controls.Add(this.textBoxB);
            this.groupBox1.Controls.Add(this.textBoxA);
            this.groupBox1.Controls.Add(this.textBoxX0);
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры генератора";
            // 
            // comboBoxPresets
            // 
            this.comboBoxPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPresets.FormattingEnabled = true;
            this.comboBoxPresets.Items.AddRange(new object[] {
            "Выберите пресет...",
            "106, 1283, 6075",
            "211, 1663, 7875",
            "421, 1663, 7875",
            "430, 2531, 11979",
            "936, 1399, 6655",
            "1366, 1283, 6075",
            "171, 11213, 53125",
            "859, 2531, 11979",
            "419, 6173, 29282",
            "967, 3041, 14406",
            "141, 28411, 134456",
            "625, 6571, 31104",
            "1541, 2957, 14000",
            "1741, 2731, 12960",
            "1291, 4621, 21870",
            "205, 29573, 139968"});
            this.comboBoxPresets.Location = new System.Drawing.Point(84, 72);
            this.comboBoxPresets.Name = "comboBoxPresets";
            this.comboBoxPresets.Size = new System.Drawing.Size(219, 24);
            this.comboBoxPresets.TabIndex = 14;
            this.comboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.comboBoxPresets_SelectedIndexChanged);
            // 
            // labelPreset
            // 
            this.labelPreset.AutoSize = true;
            this.labelPreset.Location = new System.Drawing.Point(14, 75);
            this.labelPreset.Name = "labelPreset";
            this.labelPreset.Size = new System.Drawing.Size(58, 16);
            this.labelPreset.TabIndex = 13;
            this.labelPreset.Text = "Пресет:";
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Location = new System.Drawing.Point(114, 47);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(21, 16);
            this.labelM.TabIndex = 12;
            this.labelM.Text = "m:";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(114, 22);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(18, 16);
            this.labelB.TabIndex = 11;
            this.labelB.Text = "b:";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(9, 47);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(18, 16);
            this.labelA.TabIndex = 10;
            this.labelA.Text = "a:";
            // 
            // labelX0
            // 
            this.labelX0.AutoSize = true;
            this.labelX0.Location = new System.Drawing.Point(9, 22);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(20, 16);
            this.labelX0.TabIndex = 9;
            this.labelX0.Text = "x₀:";
            // 
            // textBoxM
            // 
            this.textBoxM.Location = new System.Drawing.Point(139, 44);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(110, 22);
            this.textBoxM.TabIndex = 8;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(139, 19);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(110, 22);
            this.textBoxB.TabIndex = 7;
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(34, 44);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(70, 22);
            this.textBoxA.TabIndex = 6;
            // 
            // textBoxX0
            // 
            this.textBoxX0.Location = new System.Drawing.Point(34, 19);
            this.textBoxX0.Name = "textBoxX0";
            this.textBoxX0.Size = new System.Drawing.Size(70, 22);
            this.textBoxX0.TabIndex = 5;
            this.textBoxX0.Text = "1";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(10, 461);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(168, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(184, 461);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(158, 30);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(690, 60);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(130, 16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество чисел:";
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(224, 88);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(90, 22);
            this.numericUpDownCount.TabIndex = 0;
            this.numericUpDownCount.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 671);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Полиномиальный конгруэнтный";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1192, 671);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Генератор Фибоначчи ";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1192, 671);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Генератор Геффе";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // BTN_Generate
            // 
            this.BTN_Generate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BTN_Generate.Location = new System.Drawing.Point(12, 101);
            this.BTN_Generate.Name = "BTN_Generate";
            this.BTN_Generate.Size = new System.Drawing.Size(291, 23);
            this.BTN_Generate.TabIndex = 15;
            this.BTN_Generate.Text = "Сгенерировать";
            this.BTN_Generate.UseVisualStyleBackColor = false;
            this.BTN_Generate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CLB_MaxPeriod);
            this.groupBox4.Controls.Add(this.checkBoxMaxPeriod);
            this.groupBox4.Location = new System.Drawing.Point(676, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 134);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Условия достижения максимального периода";
            // 
            // CLB_MaxPeriod
            // 
            this.CLB_MaxPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLB_MaxPeriod.FormattingEnabled = true;
            this.CLB_MaxPeriod.Items.AddRange(new object[] {
            "1. Числа b и m – взаимно просты",
            "2. a-1 делится на все простые делители m",
            "3. Если m кратно 4, то и а-1 кратно 4"});
            this.CLB_MaxPeriod.Location = new System.Drawing.Point(17, 33);
            this.CLB_MaxPeriod.Name = "CLB_MaxPeriod";
            this.CLB_MaxPeriod.Size = new System.Drawing.Size(454, 51);
            this.CLB_MaxPeriod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Длина последовательности:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1216, 739);
            this.Name = "Form1";
            this.Text = "Лабораторные работы";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxSequence;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxX0;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.CheckBox checkBoxMaxPeriod;
        private System.Windows.Forms.ComboBox comboBoxPresets;
        private System.Windows.Forms.Label labelPreset;
        private System.Windows.Forms.Button BTN_Generate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox CLB_MaxPeriod;
        private System.Windows.Forms.Label label1;
    }
}