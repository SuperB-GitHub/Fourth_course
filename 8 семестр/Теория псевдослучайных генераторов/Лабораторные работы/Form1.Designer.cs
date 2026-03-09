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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CLB_MaxPeriod = new System.Windows.Forms.CheckedListBox();
            this.checkBoxMaxPeriod = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSequence = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.GB_LCG_ParamGen = new System.Windows.Forms.GroupBox();
            this.BTN_Generate = new System.Windows.Forms.Button();
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
            this.labelCount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GB_PCG_Condit = new System.Windows.Forms.GroupBox();
            this.CLB_PCG_MaxPeriod = new System.Windows.Forms.CheckedListBox();
            this.GB_PCG_Results = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_PCG_MaxPeriod = new System.Windows.Forms.CheckBox();
            this.TB_PCG_Period = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PCG_Count = new System.Windows.Forms.NumericUpDown();
            this.GB_PCG_GenSeq = new System.Windows.Forms.GroupBox();
            this.TB_PCG_Seq = new System.Windows.Forms.TextBox();
            this.BTN_PCG_Save = new System.Windows.Forms.Button();
            this.BTN_PCG_Clear = new System.Windows.Forms.Button();
            this.GB_PCG_ParamGen = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_PCG_m = new System.Windows.Forms.TextBox();
            this.BTN_GenPCGSeq = new System.Windows.Forms.Button();
            this.CB_PCG_PreSets = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_PCG_b = new System.Windows.Forms.TextBox();
            this.TB_PCG_a2 = new System.Windows.Forms.TextBox();
            this.TB_PCG_a1 = new System.Windows.Forms.TextBox();
            this.TB_PCG_x0 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            // Генератор Фибоначчи - основные компоненты
            this.GB_Fib_Params = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Results = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Conditions = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Visualization = new System.Windows.Forms.GroupBox();
            this.tabControl_Fib_Visual = new System.Windows.Forms.TabControl();
            this.tabPage_Scheme = new System.Windows.Forms.TabPage();
            this.tabPage_Diagram = new System.Windows.Forms.TabPage();
            this.tabPage_Sequence = new System.Windows.Forms.TabPage();
            this.tabPage_Decimal = new System.Windows.Forms.TabPage();
            this.TB_Fib_Scheme = new System.Windows.Forms.TextBox();
            this.PB_Fib_Diagram = new System.Windows.Forms.PictureBox();
            this.TB_Fib_Sequence = new System.Windows.Forms.TextBox();
            this.TB_Fib_Decimal = new System.Windows.Forms.TextBox();

            // Параметры генератора
            this.nud_Fib_Bits = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TB_Fib_Polynomial = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TB_Fib_Shift = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TB_Fib_Initial = new System.Windows.Forms.TextBox();
            this.CB_Fib_Presets = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BTN_Fib_Generate = new System.Windows.Forms.Button();

            // Результаты анализа
            this.label17 = new System.Windows.Forms.Label();
            this.TB_Fib_PeriodFormula = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TB_Fib_PeriodCount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nud_Fib_SeqLength = new System.Windows.Forms.NumericUpDown();
            this.CB_Fib_MaxPeriod = new System.Windows.Forms.CheckBox();
            this.CLB_Fib_Conditions = new System.Windows.Forms.CheckedListBox();

            // Добавьте это для поддержки PictureBox
            ((System.ComponentModel.ISupportInitialize)(this.PB_Fib_Diagram)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.GB_LCG_ParamGen.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.GB_PCG_Condit.SuspendLayout();
            this.GB_PCG_Results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCG_Count)).BeginInit();
            this.GB_PCG_GenSeq.SuspendLayout();
            this.GB_PCG_ParamGen.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.GB_LCG_ParamGen);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 671);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Линейный конгруэнтный";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Длина последовательности:";
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
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(10, 461);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(168, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.BTN_LCG_Save_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(184, 461);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(158, 30);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.BTN_LCG_Clear_Click);
            // 
            // GB_LCG_ParamGen
            // 
            this.GB_LCG_ParamGen.Controls.Add(this.BTN_Generate);
            this.GB_LCG_ParamGen.Controls.Add(this.comboBoxPresets);
            this.GB_LCG_ParamGen.Controls.Add(this.labelPreset);
            this.GB_LCG_ParamGen.Controls.Add(this.labelM);
            this.GB_LCG_ParamGen.Controls.Add(this.labelB);
            this.GB_LCG_ParamGen.Controls.Add(this.labelA);
            this.GB_LCG_ParamGen.Controls.Add(this.labelX0);
            this.GB_LCG_ParamGen.Controls.Add(this.textBoxM);
            this.GB_LCG_ParamGen.Controls.Add(this.textBoxB);
            this.GB_LCG_ParamGen.Controls.Add(this.textBoxA);
            this.GB_LCG_ParamGen.Controls.Add(this.textBoxX0);
            this.GB_LCG_ParamGen.Controls.Add(this.labelCount);
            this.GB_LCG_ParamGen.Location = new System.Drawing.Point(20, 20);
            this.GB_LCG_ParamGen.Name = "GB_LCG_ParamGen";
            this.GB_LCG_ParamGen.Size = new System.Drawing.Size(320, 134);
            this.GB_LCG_ParamGen.TabIndex = 0;
            this.GB_LCG_ParamGen.TabStop = false;
            this.GB_LCG_ParamGen.Text = "Параметры генератора";
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
            this.BTN_Generate.Click += new System.EventHandler(this.BTN_GenLCGSeq_Click);
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
            this.comboBoxPresets.SelectedIndexChanged += new System.EventHandler(this.CB_LCG_PreSets_SelectedIndexChanged);
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
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(690, 60);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(130, 16);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество чисел:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GB_PCG_Condit);
            this.tabPage2.Controls.Add(this.GB_PCG_Results);
            this.tabPage2.Controls.Add(this.GB_PCG_GenSeq);
            this.tabPage2.Controls.Add(this.GB_PCG_ParamGen);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 671);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Полиномиальный конгруэнтный";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GB_PCG_Condit
            // 
            this.GB_PCG_Condit.Controls.Add(this.CLB_PCG_MaxPeriod);
            this.GB_PCG_Condit.Location = new System.Drawing.Point(676, 20);
            this.GB_PCG_Condit.Name = "GB_PCG_Condit";
            this.GB_PCG_Condit.Size = new System.Drawing.Size(494, 134);
            this.GB_PCG_Condit.TabIndex = 7;
            this.GB_PCG_Condit.TabStop = false;
            this.GB_PCG_Condit.Text = "Условия достижения максимального периода";
            // 
            // CLB_PCG_MaxPeriod
            // 
            this.CLB_PCG_MaxPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLB_PCG_MaxPeriod.FormattingEnabled = true;
            this.CLB_PCG_MaxPeriod.Items.AddRange(new object[] {
            "1. Числа b и m – взаимно просты",
            "2. a₁-1 и a₂ делится на все простые делители m",
            "3. Если a₂ - чётное и если",
            "3.1. a₂ ≡ (a₁-1)(mod 4), если m кратно 4",
            "3.2. a₂ ≡ (a₁-1)(mod 2), если m кратно 2",
            "4. Если m кратно 9, то a₂ ≢ 3b(mod 9)"});
            this.CLB_PCG_MaxPeriod.Location = new System.Drawing.Point(17, 21);
            this.CLB_PCG_MaxPeriod.Name = "CLB_PCG_MaxPeriod";
            this.CLB_PCG_MaxPeriod.Size = new System.Drawing.Size(454, 102);
            this.CLB_PCG_MaxPeriod.TabIndex = 1;
            // 
            // GB_PCG_Results
            // 
            this.GB_PCG_Results.Controls.Add(this.label2);
            this.GB_PCG_Results.Controls.Add(this.CB_PCG_MaxPeriod);
            this.GB_PCG_Results.Controls.Add(this.TB_PCG_Period);
            this.GB_PCG_Results.Controls.Add(this.label3);
            this.GB_PCG_Results.Controls.Add(this.PCG_Count);
            this.GB_PCG_Results.Location = new System.Drawing.Point(350, 20);
            this.GB_PCG_Results.Name = "GB_PCG_Results";
            this.GB_PCG_Results.Size = new System.Drawing.Size(320, 134);
            this.GB_PCG_Results.TabIndex = 6;
            this.GB_PCG_Results.TabStop = false;
            this.GB_PCG_Results.Text = "Результаты анализа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Длина последовательности:";
            // 
            // CB_PCG_MaxPeriod
            // 
            this.CB_PCG_MaxPeriod.AutoSize = true;
            this.CB_PCG_MaxPeriod.Location = new System.Drawing.Point(23, 97);
            this.CB_PCG_MaxPeriod.Name = "CB_PCG_MaxPeriod";
            this.CB_PCG_MaxPeriod.Size = new System.Drawing.Size(282, 20);
            this.CB_PCG_MaxPeriod.TabIndex = 0;
            this.CB_PCG_MaxPeriod.Text = "Достигнут максимальный период (T=m)";
            this.CB_PCG_MaxPeriod.UseVisualStyleBackColor = true;
            // 
            // TB_PCG_Period
            // 
            this.TB_PCG_Period.Location = new System.Drawing.Point(23, 41);
            this.TB_PCG_Period.Name = "TB_PCG_Period";
            this.TB_PCG_Period.ReadOnly = true;
            this.TB_PCG_Period.Size = new System.Drawing.Size(291, 22);
            this.TB_PCG_Period.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Период (T):";
            // 
            // PCG_Count
            // 
            this.PCG_Count.Location = new System.Drawing.Point(224, 69);
            this.PCG_Count.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PCG_Count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PCG_Count.Name = "PCG_Count";
            this.PCG_Count.Size = new System.Drawing.Size(90, 22);
            this.PCG_Count.TabIndex = 0;
            this.PCG_Count.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // GB_PCG_GenSeq
            // 
            this.GB_PCG_GenSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_PCG_GenSeq.Controls.Add(this.TB_PCG_Seq);
            this.GB_PCG_GenSeq.Controls.Add(this.BTN_PCG_Save);
            this.GB_PCG_GenSeq.Controls.Add(this.BTN_PCG_Clear);
            this.GB_PCG_GenSeq.Location = new System.Drawing.Point(20, 160);
            this.GB_PCG_GenSeq.Name = "GB_PCG_GenSeq";
            this.GB_PCG_GenSeq.Size = new System.Drawing.Size(1150, 500);
            this.GB_PCG_GenSeq.TabIndex = 5;
            this.GB_PCG_GenSeq.TabStop = false;
            this.GB_PCG_GenSeq.Text = "Сгенерированная последовательность";
            // 
            // TB_PCG_Seq
            // 
            this.TB_PCG_Seq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_PCG_Seq.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_PCG_Seq.Location = new System.Drawing.Point(17, 21);
            this.TB_PCG_Seq.Multiline = true;
            this.TB_PCG_Seq.Name = "TB_PCG_Seq";
            this.TB_PCG_Seq.ReadOnly = true;
            this.TB_PCG_Seq.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_PCG_Seq.Size = new System.Drawing.Size(1110, 430);
            this.TB_PCG_Seq.TabIndex = 0;
            this.TB_PCG_Seq.WordWrap = false;
            // 
            // BTN_PCG_Save
            // 
            this.BTN_PCG_Save.Location = new System.Drawing.Point(10, 461);
            this.BTN_PCG_Save.Name = "BTN_PCG_Save";
            this.BTN_PCG_Save.Size = new System.Drawing.Size(168, 30);
            this.BTN_PCG_Save.TabIndex = 3;
            this.BTN_PCG_Save.Text = "Сохранить";
            this.BTN_PCG_Save.UseVisualStyleBackColor = true;
            this.BTN_PCG_Save.Click += new System.EventHandler(this.BTN_PCG_Save_Click);
            // 
            // BTN_PCG_Clear
            // 
            this.BTN_PCG_Clear.Location = new System.Drawing.Point(184, 461);
            this.BTN_PCG_Clear.Name = "BTN_PCG_Clear";
            this.BTN_PCG_Clear.Size = new System.Drawing.Size(158, 30);
            this.BTN_PCG_Clear.TabIndex = 2;
            this.BTN_PCG_Clear.Text = "Очистить";
            this.BTN_PCG_Clear.UseVisualStyleBackColor = true;
            this.BTN_PCG_Clear.Click += new System.EventHandler(this.BTN_PCG_Clear_Click);
            // 
            // GB_PCG_ParamGen
            // 
            this.GB_PCG_ParamGen.Controls.Add(this.label10);
            this.GB_PCG_ParamGen.Controls.Add(this.TB_PCG_m);
            this.GB_PCG_ParamGen.Controls.Add(this.BTN_GenPCGSeq);
            this.GB_PCG_ParamGen.Controls.Add(this.CB_PCG_PreSets);
            this.GB_PCG_ParamGen.Controls.Add(this.label4);
            this.GB_PCG_ParamGen.Controls.Add(this.label5);
            this.GB_PCG_ParamGen.Controls.Add(this.label6);
            this.GB_PCG_ParamGen.Controls.Add(this.label7);
            this.GB_PCG_ParamGen.Controls.Add(this.label8);
            this.GB_PCG_ParamGen.Controls.Add(this.TB_PCG_b);
            this.GB_PCG_ParamGen.Controls.Add(this.TB_PCG_a2);
            this.GB_PCG_ParamGen.Controls.Add(this.TB_PCG_a1);
            this.GB_PCG_ParamGen.Controls.Add(this.TB_PCG_x0);
            this.GB_PCG_ParamGen.Controls.Add(this.label9);
            this.GB_PCG_ParamGen.Location = new System.Drawing.Point(20, 20);
            this.GB_PCG_ParamGen.Name = "GB_PCG_ParamGen";
            this.GB_PCG_ParamGen.Size = new System.Drawing.Size(320, 134);
            this.GB_PCG_ParamGen.TabIndex = 4;
            this.GB_PCG_ParamGen.TabStop = false;
            this.GB_PCG_ParamGen.Text = "Параметры генератора";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "m:";
            // 
            // TB_PCG_m
            // 
            this.TB_PCG_m.Location = new System.Drawing.Point(248, 19);
            this.TB_PCG_m.Name = "TB_PCG_m";
            this.TB_PCG_m.Size = new System.Drawing.Size(55, 22);
            this.TB_PCG_m.TabIndex = 16;
            // 
            // BTN_GenPCGSeq
            // 
            this.BTN_GenPCGSeq.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BTN_GenPCGSeq.Location = new System.Drawing.Point(12, 101);
            this.BTN_GenPCGSeq.Name = "BTN_GenPCGSeq";
            this.BTN_GenPCGSeq.Size = new System.Drawing.Size(291, 23);
            this.BTN_GenPCGSeq.TabIndex = 15;
            this.BTN_GenPCGSeq.Text = "Сгенерировать";
            this.BTN_GenPCGSeq.UseVisualStyleBackColor = false;
            this.BTN_GenPCGSeq.Click += new System.EventHandler(this.BTN_GenPCGSeq_Click);
            // 
            // CB_PCG_PreSets
            // 
            this.CB_PCG_PreSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PCG_PreSets.FormattingEnabled = true;
            this.CB_PCG_PreSets.Items.AddRange(new object[] {
            "Выберите пресет...",
            "121, 30, 13, 150",
            "151, 60, 17, 150",
            "181, 90, 19, 150",
            "211, 120, 23, 150",
            "241, 150, 29, 150",
            "",
            "421, 210, 31, 210",
            "631, 420, 37, 210",
            "841, 630, 43, 210",
            "1051, 840, 47, 210",
            "1261, 1050, 53, 210",
            "",
            "121, 30, 14, 150",
            "121, 31, 13, 150",
            "121, 30, 13, 151",
            "121, 30, 13, 152",
            "121, 30, 13, 153"});
            this.CB_PCG_PreSets.Location = new System.Drawing.Point(84, 72);
            this.CB_PCG_PreSets.Name = "CB_PCG_PreSets";
            this.CB_PCG_PreSets.Size = new System.Drawing.Size(219, 24);
            this.CB_PCG_PreSets.TabIndex = 14;
            this.CB_PCG_PreSets.SelectedIndexChanged += new System.EventHandler(this.CB_PCG_PreSets_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Пресет:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "b:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "a₂:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "a₁:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "x₀:";
            // 
            // TB_PCG_b
            // 
            this.TB_PCG_b.Location = new System.Drawing.Point(139, 44);
            this.TB_PCG_b.Name = "TB_PCG_b";
            this.TB_PCG_b.Size = new System.Drawing.Size(55, 22);
            this.TB_PCG_b.TabIndex = 8;
            // 
            // TB_PCG_a2
            // 
            this.TB_PCG_a2.Location = new System.Drawing.Point(139, 19);
            this.TB_PCG_a2.Name = "TB_PCG_a2";
            this.TB_PCG_a2.Size = new System.Drawing.Size(55, 22);
            this.TB_PCG_a2.TabIndex = 7;
            // 
            // TB_PCG_a1
            // 
            this.TB_PCG_a1.Location = new System.Drawing.Point(34, 44);
            this.TB_PCG_a1.Name = "TB_PCG_a1";
            this.TB_PCG_a1.Size = new System.Drawing.Size(55, 22);
            this.TB_PCG_a1.TabIndex = 6;
            // 
            // TB_PCG_x0
            // 
            this.TB_PCG_x0.Location = new System.Drawing.Point(34, 19);
            this.TB_PCG_x0.Name = "TB_PCG_x0";
            this.TB_PCG_x0.Size = new System.Drawing.Size(55, 22);
            this.TB_PCG_x0.TabIndex = 5;
            this.TB_PCG_x0.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(690, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Количество чисел:";
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
            // tabPage3 (Генератор Фибоначчи)
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.GB_Fib_Conditions);
            this.tabPage3.Controls.Add(this.GB_Fib_Results);
            this.tabPage3.Controls.Add(this.GB_Fib_Visualization);
            this.tabPage3.Controls.Add(this.GB_Fib_Params);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1192, 671);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Генератор Фибоначчи";
            this.tabPage3.UseVisualStyleBackColor = true;

            // 
            // GB_Fib_Params
            // 
            this.GB_Fib_Params = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Params.Controls.Add(this.BTN_Fib_Generate);
            this.GB_Fib_Params.Controls.Add(this.CB_Fib_Presets);
            this.GB_Fib_Params.Controls.Add(this.label11);
            //this.GB_Fib_Params.Controls.Add(this.label12);
            this.GB_Fib_Params.Controls.Add(this.label13);
            this.GB_Fib_Params.Controls.Add(this.label14);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Polynomial);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Shift);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Initial);
            this.GB_Fib_Params.Controls.Add(this.label15);
            this.GB_Fib_Params.Controls.Add(this.nud_Fib_Bits);
            this.GB_Fib_Params.Controls.Add(this.label16);
            this.GB_Fib_Params.Location = new System.Drawing.Point(20, 20);
            this.GB_Fib_Params.Name = "GB_Fib_Params";
            this.GB_Fib_Params.Size = new System.Drawing.Size(350, 150);
            this.GB_Fib_Params.TabIndex = 0;
            this.GB_Fib_Params.TabStop = false;
            this.GB_Fib_Params.Text = "Параметры генератора Фибоначчи";

            // 
            // nud_Fib_Bits
            // 
            this.nud_Fib_Bits = new System.Windows.Forms.NumericUpDown();
            this.nud_Fib_Bits.Location = new System.Drawing.Point(150, 25);
            this.nud_Fib_Bits.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            this.nud_Fib_Bits.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            this.nud_Fib_Bits.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.nud_Fib_Bits.Name = "nud_Fib_Bits";
            this.nud_Fib_Bits.Size = new System.Drawing.Size(60, 22);
            this.nud_Fib_Bits.TabIndex = 5;

            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 16);
            this.label16.TabIndex = 4;
            this.label16.Text = "Разрядность (макс. ст.):";

            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Примитивный многочлен:";

            // 
            // TB_Fib_Polynomial
            // 
            this.TB_Fib_Polynomial = new System.Windows.Forms.TextBox();
            this.TB_Fib_Polynomial.Location = new System.Drawing.Point(150, 52);
            this.TB_Fib_Polynomial.Name = "TB_Fib_Polynomial";
            this.TB_Fib_Polynomial.Size = new System.Drawing.Size(180, 22);
            this.TB_Fib_Polynomial.TabIndex = 7;
            this.TB_Fib_Polynomial.Text = "x^5 + x^2 + 1";
            this.TB_Fib_Polynomial.Font = new System.Drawing.Font("Consolas", 9.75F);

            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 16);
            this.label14.TabIndex = 8;
            this.label14.Text = "Сдвиг k:";

            // 
            // TB_Fib_Shift
            // 
            this.TB_Fib_Shift = new System.Windows.Forms.TextBox();
            this.TB_Fib_Shift.Location = new System.Drawing.Point(150, 80);
            this.TB_Fib_Shift.Name = "TB_Fib_Shift";
            this.TB_Fib_Shift.Size = new System.Drawing.Size(60, 22);
            this.TB_Fib_Shift.TabIndex = 9;
            this.TB_Fib_Shift.Text = "2";

            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Начальное состояние:";

            // 
            // TB_Fib_Initial
            // 
            this.TB_Fib_Initial = new System.Windows.Forms.TextBox();
            this.TB_Fib_Initial.Location = new System.Drawing.Point(150, 108);
            this.TB_Fib_Initial.Name = "TB_Fib_Initial";
            this.TB_Fib_Initial.Size = new System.Drawing.Size(180, 22);
            this.TB_Fib_Initial.TabIndex = 11;
            this.TB_Fib_Initial.Text = "11111";
            this.TB_Fib_Initial.Font = new System.Drawing.Font("Consolas", 9.75F);

            // 
            // CB_Fib_Presets
            // 
            this.CB_Fib_Presets = new System.Windows.Forms.ComboBox();
            this.CB_Fib_Presets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Fib_Presets.FormattingEnabled = true;
            this.CB_Fib_Presets.Items.AddRange(new object[] {
"Выберите пресет...",
"Вариант 1: x^5 + x^2 + 1, k=2",
"Вариант 2: x^5 + x^2 + 1, k=3",
"Вариант 3: x^5 + x^2 + 1, k=4",
"Вариант 4: x^5 + x^3 + 1, k=2",
"Вариант 5: x^5 + x^3 + 1, k=3",
"Вариант 6: x^5 + x^3 + 1, k=4",
"Вариант 7: x^5 + x^3 + x^2 + x + 1, k=2",
"Вариант 8: x^5 + x^3 + x^2 + x + 1, k=3",
"Вариант 9: x^5 + x^3 + x^2 + x + 1, k=4",
"Вариант 10: x^5 + x^4 + x^2 + x + 1, k=2",
"Вариант 11: x^5 + x^4 + x^2 + x + 1, k=3",
"Вариант 12: x^5 + x^4 + x^2 + x + 1, k=4",
"Вариант 13: x^5 + x^4 + x^3 + x + 1, k=2",
"Вариант 14: x^5 + x^4 + x^3 + x + 1, k=3",
"Вариант 15: x^5 + x^4 + x^3 + x + 1, k=4",
"Вариант 16: x^5 + x^4 + x^3 + x^2 + 1, k=2",
"Вариант 17: x^5 + x^4 + x^3 + x^2 + 1, k=3",
"Вариант 18: x^5 + x^4 + x^3 + x^2 + 1, k=4"
});
            this.CB_Fib_Presets.Location = new System.Drawing.Point(150, 135);
            this.CB_Fib_Presets.Name = "CB_Fib_Presets";
            this.CB_Fib_Presets.Size = new System.Drawing.Size(180, 24);
            this.CB_Fib_Presets.TabIndex = 14;

            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "Пресет:";

            // 
            // BTN_Fib_Generate
            // 
            this.BTN_Fib_Generate = new System.Windows.Forms.Button();
            this.BTN_Fib_Generate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BTN_Fib_Generate.Location = new System.Drawing.Point(336, 25);
            this.BTN_Fib_Generate.Name = "BTN_Fib_Generate";
            this.BTN_Fib_Generate.Size = new System.Drawing.Size(110, 40);
            this.BTN_Fib_Generate.TabIndex = 15;
            this.BTN_Fib_Generate.Text = "Генерировать";
            this.BTN_Fib_Generate.UseVisualStyleBackColor = false;

            // 
            // GB_Fib_Results
            // 
            this.GB_Fib_Results = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Results.Controls.Add(this.label17);
            this.GB_Fib_Results.Controls.Add(this.TB_Fib_PeriodCount);
            this.GB_Fib_Results.Controls.Add(this.TB_Fib_PeriodFormula);
            this.GB_Fib_Results.Controls.Add(this.label18);
            this.GB_Fib_Results.Controls.Add(this.label19);
            this.GB_Fib_Results.Controls.Add(this.CB_Fib_MaxPeriod);
            this.GB_Fib_Results.Controls.Add(this.nud_Fib_SeqLength);
            this.GB_Fib_Results.Location = new System.Drawing.Point(380, 20);
            this.GB_Fib_Results.Name = "GB_Fib_Results";
            this.GB_Fib_Results.Size = new System.Drawing.Size(360, 150);
            this.GB_Fib_Results.TabIndex = 16;
            this.GB_Fib_Results.TabStop = false;
            this.GB_Fib_Results.Text = "Результаты анализа";

            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(135, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "Период (по формуле):";

            // 
            // TB_Fib_PeriodFormula
            // 
            this.TB_Fib_PeriodFormula = new System.Windows.Forms.TextBox();
            this.TB_Fib_PeriodFormula.Location = new System.Drawing.Point(180, 27);
            this.TB_Fib_PeriodFormula.Name = "TB_Fib_PeriodFormula";
            this.TB_Fib_PeriodFormula.ReadOnly = true;
            this.TB_Fib_PeriodFormula.Size = new System.Drawing.Size(160, 22);
            this.TB_Fib_PeriodFormula.TabIndex = 5;

            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(15, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 16);
            this.label18.TabIndex = 6;
            this.label18.Text = "Период (счетом):";

            // 
            // TB_Fib_PeriodCount
            // 
            this.TB_Fib_PeriodCount = new System.Windows.Forms.TextBox();
            this.TB_Fib_PeriodCount.Location = new System.Drawing.Point(180, 55);
            this.TB_Fib_PeriodCount.Name = "TB_Fib_PeriodCount";
            this.TB_Fib_PeriodCount.ReadOnly = true;
            this.TB_Fib_PeriodCount.Size = new System.Drawing.Size(160, 22);
            this.TB_Fib_PeriodCount.TabIndex = 7;

            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(153, 16);
            this.label19.TabIndex = 8;
            this.label19.Text = "Длина последовательности:";

            // 
            // nud_Fib_SeqLength
            // 
            this.nud_Fib_SeqLength = new System.Windows.Forms.NumericUpDown();
            this.nud_Fib_SeqLength.Location = new System.Drawing.Point(180, 113);
            this.nud_Fib_SeqLength.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nud_Fib_SeqLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nud_Fib_SeqLength.Name = "nud_Fib_SeqLength";
            this.nud_Fib_SeqLength.Size = new System.Drawing.Size(90, 22);
            this.nud_Fib_SeqLength.TabIndex = 9;
            this.nud_Fib_SeqLength.Value = new decimal(new int[] { 50, 0, 0, 0 });

            // 
            // CB_Fib_MaxPeriod
            // 
            this.CB_Fib_MaxPeriod = new System.Windows.Forms.CheckBox();
            this.CB_Fib_MaxPeriod.AutoSize = true;
            this.CB_Fib_MaxPeriod.Location = new System.Drawing.Point(18, 86);
            this.CB_Fib_MaxPeriod.Name = "CB_Fib_MaxPeriod";
            this.CB_Fib_MaxPeriod.Size = new System.Drawing.Size(281, 20);
            this.CB_Fib_MaxPeriod.TabIndex = 10;
            this.CB_Fib_MaxPeriod.Text = "Достигнут максимальный период (2^n - 1)";
            this.CB_Fib_MaxPeriod.UseVisualStyleBackColor = true;
            this.CB_Fib_MaxPeriod.Enabled = false;

            // 
            // GB_Fib_Conditions
            // 
            this.GB_Fib_Conditions = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Conditions.Controls.Add(this.CLB_Fib_Conditions);
            this.GB_Fib_Conditions.Location = new System.Drawing.Point(750, 20);
            this.GB_Fib_Conditions.Name = "GB_Fib_Conditions";
            this.GB_Fib_Conditions.Size = new System.Drawing.Size(420, 150);
            this.GB_Fib_Conditions.TabIndex = 17;
            this.GB_Fib_Conditions.TabStop = false;
            this.GB_Fib_Conditions.Text = "Условия (примитивный многочлен)";

            // 
            // CLB_Fib_Conditions
            // 
            this.CLB_Fib_Conditions = new System.Windows.Forms.CheckedListBox();
            this.CLB_Fib_Conditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLB_Fib_Conditions.FormattingEnabled = true;
            this.CLB_Fib_Conditions.Items.AddRange(new object[] {
"1. Многочлен примитивный (неприводимый)",
"2. Степень многочлена = разрядность регистра",
"3. Обратная связь по выбранным разрядам",
"4. Начальное состояние ≠ 0",
"5. Период M = 2ⁿ - 1 (для n разрядов)"
});
            this.CLB_Fib_Conditions.Location = new System.Drawing.Point(15, 21);
            this.CLB_Fib_Conditions.Name = "CLB_Fib_Conditions";
            this.CLB_Fib_Conditions.Size = new System.Drawing.Size(390, 102);
            this.CLB_Fib_Conditions.TabIndex = 0;
            this.CLB_Fib_Conditions.Enabled = false;

            // 
            // GB_Fib_Visualization
            // 
            this.GB_Fib_Visualization = new System.Windows.Forms.GroupBox();
            this.GB_Fib_Visualization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Fib_Visualization.Controls.Add(this.tabControl_Fib_Visual);
            this.GB_Fib_Visualization.Location = new System.Drawing.Point(20, 176);
            this.GB_Fib_Visualization.Name = "GB_Fib_Visualization";
            this.GB_Fib_Visualization.Size = new System.Drawing.Size(1150, 487);
            this.GB_Fib_Visualization.TabIndex = 18;
            this.GB_Fib_Visualization.TabStop = false;
            this.GB_Fib_Visualization.Text = "Визуализация";

            // 
            // tabControl_Fib_Visual
            // 
            this.tabControl_Fib_Visual = new System.Windows.Forms.TabControl();
            this.tabControl_Fib_Visual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Fib_Visual.Controls.Add(this.tabPage_Scheme);
            this.tabControl_Fib_Visual.Controls.Add(this.tabPage_Diagram);
            this.tabControl_Fib_Visual.Controls.Add(this.tabPage_Sequence);
            this.tabControl_Fib_Visual.Controls.Add(this.tabPage_Decimal);
            this.tabControl_Fib_Visual.Location = new System.Drawing.Point(3, 18);
            this.tabControl_Fib_Visual.Name = "tabControl_Fib_Visual";
            this.tabControl_Fib_Visual.SelectedIndex = 0;
            this.tabControl_Fib_Visual.Size = new System.Drawing.Size(1144, 466);
            this.tabControl_Fib_Visual.TabIndex = 0;

            // 
            // tabPage_Scheme
            // 
            this.tabPage_Scheme = new System.Windows.Forms.TabPage();
            this.tabPage_Scheme.Controls.Add(this.TB_Fib_Scheme);
            this.tabPage_Scheme.Text = "Схема (ASCII)";
            this.tabPage_Scheme.UseVisualStyleBackColor = true;

            // 
            // TB_Fib_Scheme
            // 
            this.TB_Fib_Scheme = new System.Windows.Forms.TextBox();
            this.TB_Fib_Scheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Fib_Scheme.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Fib_Scheme.Location = new System.Drawing.Point(3, 3);
            this.TB_Fib_Scheme.Multiline = true;
            this.TB_Fib_Scheme.Name = "TB_Fib_Scheme";
            this.TB_Fib_Scheme.ReadOnly = true;
            this.TB_Fib_Scheme.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Fib_Scheme.Size = new System.Drawing.Size(1130, 432);
            this.TB_Fib_Scheme.TabIndex = 0;
            this.TB_Fib_Scheme.WordWrap = false;
            this.TB_Fib_Scheme.Text = "Схема будет отображена после генерации...";

            // 
            // tabPage_Diagram
            // 
            this.tabPage_Diagram = new System.Windows.Forms.TabPage();
            this.tabPage_Diagram.Controls.Add(this.PB_Fib_Diagram);
            this.tabPage_Diagram.Text = "Диаграмма состояний";
            this.tabPage_Diagram.UseVisualStyleBackColor = true;

            // 
            // PB_Fib_Diagram
            // 
            this.PB_Fib_Diagram = new System.Windows.Forms.PictureBox();
            this.PB_Fib_Diagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_Fib_Diagram.Location = new System.Drawing.Point(3, 3);
            this.PB_Fib_Diagram.Name = "PB_Fib_Diagram";
            this.PB_Fib_Diagram.Size = new System.Drawing.Size(1130, 432);
            this.PB_Fib_Diagram.TabIndex = 0;
            this.PB_Fib_Diagram.TabStop = false;
            this.PB_Fib_Diagram.BackColor = System.Drawing.Color.White;
            this.PB_Fib_Diagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.PB_Fib_Diagram.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Fib_Diagram_Paint);

            // 
            // tabPage_Sequence
            // 
            this.tabPage_Sequence = new System.Windows.Forms.TabPage();
            this.tabPage_Sequence.Controls.Add(this.TB_Fib_Sequence);
            this.tabPage_Sequence.Text = "Двоичная последовательность";
            this.tabPage_Sequence.UseVisualStyleBackColor = true;

            // 
            // TB_Fib_Sequence
            // 
            this.TB_Fib_Sequence = new System.Windows.Forms.TextBox();
            this.TB_Fib_Sequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Fib_Sequence.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.TB_Fib_Sequence.Location = new System.Drawing.Point(3, 3);
            this.TB_Fib_Sequence.Multiline = true;
            this.TB_Fib_Sequence.Name = "TB_Fib_Sequence";
            this.TB_Fib_Sequence.ReadOnly = true;
            this.TB_Fib_Sequence.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Fib_Sequence.Size = new System.Drawing.Size(1130, 432);
            this.TB_Fib_Sequence.TabIndex = 1;
            this.TB_Fib_Sequence.WordWrap = false;

            // 
            // tabPage_Decimal
            // 
            this.tabPage_Decimal = new System.Windows.Forms.TabPage();
            this.tabPage_Decimal.Controls.Add(this.TB_Fib_Decimal);
            this.tabPage_Decimal.Text = "Десятичная последовательность";
            this.tabPage_Decimal.UseVisualStyleBackColor = true;

            // 
            // TB_Fib_Decimal
            // 
            this.TB_Fib_Decimal = new System.Windows.Forms.TextBox();
            this.TB_Fib_Decimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Fib_Decimal.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.TB_Fib_Decimal.Location = new System.Drawing.Point(3, 3);
            this.TB_Fib_Decimal.Multiline = true;
            this.TB_Fib_Decimal.Name = "TB_Fib_Decimal";
            this.TB_Fib_Decimal.ReadOnly = true;
            this.TB_Fib_Decimal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Fib_Decimal.Size = new System.Drawing.Size(1130, 432);
            this.TB_Fib_Decimal.TabIndex = 2;
            this.TB_Fib_Decimal.WordWrap = false;

            this.GB_Fib_Params.Controls.Add(this.nud_Fib_Bits);
            this.GB_Fib_Params.Controls.Add(this.label16);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Polynomial);
            this.GB_Fib_Params.Controls.Add(this.label15);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Shift);
            this.GB_Fib_Params.Controls.Add(this.label14);
            this.GB_Fib_Params.Controls.Add(this.TB_Fib_Initial);
            this.GB_Fib_Params.Controls.Add(this.label13);
            this.GB_Fib_Params.Controls.Add(this.CB_Fib_Presets);
            this.GB_Fib_Params.Controls.Add(this.label11);
            this.GB_Fib_Params.Controls.Add(this.BTN_Fib_Generate);

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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1216, 739);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторные работы";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GB_LCG_ParamGen.ResumeLayout(false);
            this.GB_LCG_ParamGen.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.GB_PCG_Condit.ResumeLayout(false);
            this.GB_PCG_Results.ResumeLayout(false);
            this.GB_PCG_Results.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCG_Count)).EndInit();
            this.GB_PCG_GenSeq.ResumeLayout(false);
            this.GB_PCG_GenSeq.PerformLayout();
            this.GB_PCG_ParamGen.ResumeLayout(false);
            this.GB_PCG_ParamGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Fib_Diagram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox GB_LCG_ParamGen;
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
        private System.Windows.Forms.GroupBox GB_PCG_Condit;
        private System.Windows.Forms.CheckedListBox CLB_PCG_MaxPeriod;
        private System.Windows.Forms.CheckBox CB_PCG_MaxPeriod;
        private System.Windows.Forms.GroupBox GB_PCG_Results;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_PCG_Period;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PCG_Count;
        private System.Windows.Forms.GroupBox GB_PCG_GenSeq;
        private System.Windows.Forms.TextBox TB_PCG_Seq;
        private System.Windows.Forms.Button BTN_PCG_Save;
        private System.Windows.Forms.Button BTN_PCG_Clear;
        private System.Windows.Forms.GroupBox GB_PCG_ParamGen;
        private System.Windows.Forms.Button BTN_GenPCGSeq;
        private System.Windows.Forms.ComboBox CB_PCG_PreSets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_PCG_b;
        private System.Windows.Forms.TextBox TB_PCG_a2;
        private System.Windows.Forms.TextBox TB_PCG_a1;
        private System.Windows.Forms.TextBox TB_PCG_x0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_PCG_m;
        private System.Windows.Forms.GroupBox GB_Fib_Params;
        private System.Windows.Forms.GroupBox GB_Fib_Results;
        private System.Windows.Forms.GroupBox GB_Fib_Conditions;
        private System.Windows.Forms.GroupBox GB_Fib_Visualization;
        private System.Windows.Forms.TabControl tabControl_Fib_Visual;
        private System.Windows.Forms.TabPage tabPage_Scheme;
        private System.Windows.Forms.TabPage tabPage_Diagram;
        private System.Windows.Forms.TabPage tabPage_Sequence;
        private System.Windows.Forms.TabPage tabPage_Decimal;
        private System.Windows.Forms.TextBox TB_Fib_Scheme;
        private System.Windows.Forms.PictureBox PB_Fib_Diagram;
        private System.Windows.Forms.TextBox TB_Fib_Sequence;
        private System.Windows.Forms.TextBox TB_Fib_Decimal;
        private System.Windows.Forms.NumericUpDown nud_Fib_Bits;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TB_Fib_Polynomial;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TB_Fib_Shift;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TB_Fib_Initial;
        private System.Windows.Forms.ComboBox CB_Fib_Presets;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BTN_Fib_Generate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TB_Fib_PeriodFormula;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TB_Fib_PeriodCount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nud_Fib_SeqLength;
        private System.Windows.Forms.CheckBox CB_Fib_MaxPeriod;
        private System.Windows.Forms.CheckedListBox CLB_Fib_Conditions;
    }
}