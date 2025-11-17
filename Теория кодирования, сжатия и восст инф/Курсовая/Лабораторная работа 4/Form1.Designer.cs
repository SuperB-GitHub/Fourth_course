namespace Лабораторная_работа_4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTB_Common = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RTB_Code = new System.Windows.Forms.RichTextBox();
            this.RTB_Name_Open = new System.Windows.Forms.RichTextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.B_Code = new System.Windows.Forms.Button();
            this.B_CountParam = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RTB_CodeText = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTB_InfText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGW_Matrix_1 = new System.Windows.Forms.DataGridView();
            this.RTB_n = new System.Windows.Forms.RichTextBox();
            this.L_k = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.L_m = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RTB_g = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.B_Decode = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.RTB_DecodedText = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RTB_CodedText = new System.Windows.Forms.RichTextBox();
            this.DGW_Table_ES = new System.Windows.Forms.DataGridView();
            this.e = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_k2 = new System.Windows.Forms.Label();
            this.L_m2 = new System.Windows.Forms.Label();
            this.L_n2 = new System.Windows.Forms.Label();
            this.L_g = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Matrix_1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Table_ES)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1284, 861);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.RTB_Name_Open);
            this.tabPage1.Controls.Add(this.OpenFileButton);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1276, 835);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Этап 1. Ввод текста и бинарность";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 87);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1260, 740);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTB_Common);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1254, 364);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Текст из файла";
            // 
            // RTB_Common
            // 
            this.RTB_Common.Location = new System.Drawing.Point(0, 22);
            this.RTB_Common.Name = "RTB_Common";
            this.RTB_Common.Size = new System.Drawing.Size(1257, 342);
            this.RTB_Common.TabIndex = 0;
            this.RTB_Common.Text = "";
            this.RTB_Common.TextChanged += new System.EventHandler(this.RTB_Common_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RTB_Code);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1254, 364);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Проработанный текст";
            // 
            // RTB_Code
            // 
            this.RTB_Code.Location = new System.Drawing.Point(0, 28);
            this.RTB_Code.Name = "RTB_Code";
            this.RTB_Code.Size = new System.Drawing.Size(1259, 336);
            this.RTB_Code.TabIndex = 0;
            this.RTB_Code.Text = "";
            // 
            // RTB_Name_Open
            // 
            this.RTB_Name_Open.BackColor = System.Drawing.Color.Aquamarine;
            this.RTB_Name_Open.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Name_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RTB_Name_Open.Location = new System.Drawing.Point(8, 15);
            this.RTB_Name_Open.Name = "RTB_Name_Open";
            this.RTB_Name_Open.ReadOnly = true;
            this.RTB_Name_Open.Size = new System.Drawing.Size(897, 66);
            this.RTB_Name_Open.TabIndex = 15;
            this.RTB_Name_Open.Text = "";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFileButton.Location = new System.Drawing.Point(921, 14);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(347, 67);
            this.OpenFileButton.TabIndex = 16;
            this.OpenFileButton.Text = "Открыть файл";
            this.OpenFileButton.UseVisualStyleBackColor = false;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.DGW_Matrix_1);
            this.tabPage2.Controls.Add(this.RTB_n);
            this.tabPage2.Controls.Add(this.L_k);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.L_m);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.RTB_g);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1276, 835);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Этап 2. Кодирование";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.B_Code, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.B_CountParam, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(451, 60);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(808, 65);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // B_Code
            // 
            this.B_Code.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Code.Location = new System.Drawing.Point(407, 3);
            this.B_Code.Name = "B_Code";
            this.B_Code.Size = new System.Drawing.Size(398, 59);
            this.B_Code.TabIndex = 18;
            this.B_Code.Text = "Закодировать";
            this.B_Code.UseVisualStyleBackColor = false;
            this.B_Code.Click += new System.EventHandler(this.B_Code_Click);
            // 
            // B_CountParam
            // 
            this.B_CountParam.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_CountParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_CountParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_CountParam.Location = new System.Drawing.Point(3, 3);
            this.B_CountParam.Name = "B_CountParam";
            this.B_CountParam.Size = new System.Drawing.Size(398, 59);
            this.B_CountParam.TabIndex = 17;
            this.B_CountParam.Text = "Просчитать параметры";
            this.B_CountParam.UseVisualStyleBackColor = false;
            this.B_CountParam.Click += new System.EventHandler(this.B_CountParam_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RTB_CodeText);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(15, 429);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1244, 398);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Закодированный текст";
            // 
            // RTB_CodeText
            // 
            this.RTB_CodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_CodeText.Location = new System.Drawing.Point(3, 27);
            this.RTB_CodeText.Name = "RTB_CodeText";
            this.RTB_CodeText.Size = new System.Drawing.Size(1238, 368);
            this.RTB_CodeText.TabIndex = 0;
            this.RTB_CodeText.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTB_InfText);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(451, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 292);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информационный текст";
            // 
            // RTB_InfText
            // 
            this.RTB_InfText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_InfText.Location = new System.Drawing.Point(3, 27);
            this.RTB_InfText.Name = "RTB_InfText";
            this.RTB_InfText.Size = new System.Drawing.Size(802, 262);
            this.RTB_InfText.TabIndex = 0;
            this.RTB_InfText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "G =";
            // 
            // DGW_Matrix_1
            // 
            this.DGW_Matrix_1.AllowUserToAddRows = false;
            this.DGW_Matrix_1.AllowUserToDeleteRows = false;
            this.DGW_Matrix_1.AllowUserToResizeColumns = false;
            this.DGW_Matrix_1.AllowUserToResizeRows = false;
            this.DGW_Matrix_1.BackgroundColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW_Matrix_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGW_Matrix_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Matrix_1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGW_Matrix_1.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGW_Matrix_1.Location = new System.Drawing.Point(63, 57);
            this.DGW_Matrix_1.Name = "DGW_Matrix_1";
            this.DGW_Matrix_1.RowHeadersVisible = false;
            this.DGW_Matrix_1.Size = new System.Drawing.Size(363, 363);
            this.DGW_Matrix_1.TabIndex = 10;
            // 
            // RTB_n
            // 
            this.RTB_n.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RTB_n.Location = new System.Drawing.Point(678, 12);
            this.RTB_n.Name = "RTB_n";
            this.RTB_n.Size = new System.Drawing.Size(64, 32);
            this.RTB_n.TabIndex = 8;
            this.RTB_n.Text = "";
            this.RTB_n.TextChanged += new System.EventHandler(this.RTB_n_TextChanged);
            // 
            // L_k
            // 
            this.L_k.AutoSize = true;
            this.L_k.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_k.Location = new System.Drawing.Point(1126, 9);
            this.L_k.Name = "L_k";
            this.L_k.Size = new System.Drawing.Size(29, 31);
            this.L_k.TabIndex = 7;
            this.L_k.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(990, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "k = n - m =";
            // 
            // L_m
            // 
            this.L_m.AutoSize = true;
            this.L_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_m.Location = new System.Drawing.Point(936, 9);
            this.L_m.Name = "L_m";
            this.L_m.Size = new System.Drawing.Size(29, 31);
            this.L_m.TabIndex = 5;
            this.L_m.Text = "?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(772, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "m = deg(g) =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(627, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "n = ";
            // 
            // RTB_g
            // 
            this.RTB_g.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RTB_g.Location = new System.Drawing.Point(63, 12);
            this.RTB_g.Name = "RTB_g";
            this.RTB_g.Size = new System.Drawing.Size(530, 32);
            this.RTB_g.TabIndex = 1;
            this.RTB_g.Text = "";
            this.RTB_g.TextChanged += new System.EventHandler(this.RTB_g_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "g = ";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.MediumTurquoise;
            this.tabPage3.Controls.Add(this.B_Decode);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.DGW_Table_ES);
            this.tabPage3.Controls.Add(this.L_k2);
            this.tabPage3.Controls.Add(this.L_m2);
            this.tabPage3.Controls.Add(this.L_n2);
            this.tabPage3.Controls.Add(this.L_g);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1276, 835);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Этап 3. Декодирование";
            // 
            // B_Decode
            // 
            this.B_Decode.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Decode.Location = new System.Drawing.Point(12, 64);
            this.B_Decode.Name = "B_Decode";
            this.B_Decode.Size = new System.Drawing.Size(683, 59);
            this.B_Decode.TabIndex = 18;
            this.B_Decode.Text = "Декодировать";
            this.B_Decode.UseVisualStyleBackColor = false;
            this.B_Decode.Click += new System.EventHandler(this.B_Decode_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.RTB_DecodedText);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(12, 434);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1244, 393);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Декодированный текст";
            // 
            // RTB_DecodedText
            // 
            this.RTB_DecodedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_DecodedText.Location = new System.Drawing.Point(3, 27);
            this.RTB_DecodedText.Name = "RTB_DecodedText";
            this.RTB_DecodedText.Size = new System.Drawing.Size(1238, 363);
            this.RTB_DecodedText.TabIndex = 1;
            this.RTB_DecodedText.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RTB_CodedText);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(12, 137);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(683, 290);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Закодированный текст";
            // 
            // RTB_CodedText
            // 
            this.RTB_CodedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_CodedText.Location = new System.Drawing.Point(3, 27);
            this.RTB_CodedText.Name = "RTB_CodedText";
            this.RTB_CodedText.Size = new System.Drawing.Size(677, 260);
            this.RTB_CodedText.TabIndex = 0;
            this.RTB_CodedText.Text = "";
            // 
            // DGW_Table_ES
            // 
            this.DGW_Table_ES.AllowUserToAddRows = false;
            this.DGW_Table_ES.AllowUserToDeleteRows = false;
            this.DGW_Table_ES.AllowUserToResizeColumns = false;
            this.DGW_Table_ES.AllowUserToResizeRows = false;
            this.DGW_Table_ES.BackgroundColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGW_Table_ES.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGW_Table_ES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Table_ES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.e,
            this.S});
            this.DGW_Table_ES.Location = new System.Drawing.Point(701, 64);
            this.DGW_Table_ES.Name = "DGW_Table_ES";
            this.DGW_Table_ES.RowHeadersVisible = false;
            this.DGW_Table_ES.Size = new System.Drawing.Size(555, 363);
            this.DGW_Table_ES.TabIndex = 19;
            // 
            // e
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.e.DefaultCellStyle = dataGridViewCellStyle4;
            this.e.HeaderText = "e";
            this.e.Name = "e";
            this.e.Width = 300;
            // 
            // S
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.S.DefaultCellStyle = dataGridViewCellStyle5;
            this.S.HeaderText = "S = x * S(x) mod g(x)";
            this.S.Name = "S";
            this.S.Width = 250;
            // 
            // L_k2
            // 
            this.L_k2.AutoSize = true;
            this.L_k2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_k2.Location = new System.Drawing.Point(1212, 12);
            this.L_k2.Name = "L_k2";
            this.L_k2.Size = new System.Drawing.Size(29, 31);
            this.L_k2.TabIndex = 18;
            this.L_k2.Text = "?";
            // 
            // L_m2
            // 
            this.L_m2.AutoSize = true;
            this.L_m2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_m2.Location = new System.Drawing.Point(1090, 12);
            this.L_m2.Name = "L_m2";
            this.L_m2.Size = new System.Drawing.Size(29, 31);
            this.L_m2.TabIndex = 17;
            this.L_m2.Text = "?";
            // 
            // L_n2
            // 
            this.L_n2.AutoSize = true;
            this.L_n2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_n2.Location = new System.Drawing.Point(954, 12);
            this.L_n2.Name = "L_n2";
            this.L_n2.Size = new System.Drawing.Size(29, 31);
            this.L_n2.TabIndex = 16;
            this.L_n2.Text = "?";
            // 
            // L_g
            // 
            this.L_g.AutoSize = true;
            this.L_g.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_g.Location = new System.Drawing.Point(309, 12);
            this.L_g.Name = "L_g";
            this.L_g.Size = new System.Drawing.Size(29, 31);
            this.L_g.TabIndex = 15;
            this.L_g.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1170, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 31);
            this.label6.TabIndex = 14;
            this.label6.Text = "k =";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(1040, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 31);
            this.label9.TabIndex = 12;
            this.label9.Text = "m =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(910, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 31);
            this.label10.TabIndex = 11;
            this.label10.Text = "n = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(315, 31);
            this.label11.TabIndex = 9;
            this.label11.Text = "Параметры кодека: g = ";
            // 
            // OFD
            // 
            this.OFD.FileName = "OpenFileDialog";
            this.OFD.Filter = "Только такие| *.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабараторная работа 4";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Matrix_1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Table_ES)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RTB_Common;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox RTB_Code;
        private System.Windows.Forms.RichTextBox RTB_Name_Open;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox RTB_g;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_k;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label L_m;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RTB_n;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGW_Matrix_1;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button B_CountParam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button B_Code;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox RTB_CodeText;
        private System.Windows.Forms.RichTextBox RTB_InfText;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label L_k2;
        private System.Windows.Forms.Label L_m2;
        private System.Windows.Forms.Label L_n2;
        private System.Windows.Forms.Label L_g;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView DGW_Table_ES;
        private System.Windows.Forms.DataGridViewTextBoxColumn e;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.Button B_Decode;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox RTB_DecodedText;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox RTB_CodedText;
    }
}

