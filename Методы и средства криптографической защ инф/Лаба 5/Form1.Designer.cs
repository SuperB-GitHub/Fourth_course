namespace Лаба_5
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RTB_Crypted = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RTB_InputOT = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_CipherTable = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RB_Sumb = new System.Windows.Forms.RadioButton();
            this.BTN_Encrypt = new System.Windows.Forms.Button();
            this.RB_Num = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_Decrypt = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RTB_Decrypted = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RTB_InputEnc = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DGV_CipherTable1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CipherTable)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CipherTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Шифрование";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(970, 529);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RTB_Crypted);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 414);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(964, 112);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Шифртекст";
            // 
            // RTB_Crypted
            // 
            this.RTB_Crypted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_Crypted.Location = new System.Drawing.Point(3, 25);
            this.RTB_Crypted.Name = "RTB_Crypted";
            this.RTB_Crypted.Size = new System.Drawing.Size(958, 84);
            this.RTB_Crypted.TabIndex = 0;
            this.RTB_Crypted.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RTB_InputOT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Открытый текст";
            // 
            // RTB_InputOT
            // 
            this.RTB_InputOT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_InputOT.Location = new System.Drawing.Point(3, 25);
            this.RTB_InputOT.Name = "RTB_InputOT";
            this.RTB_InputOT.Size = new System.Drawing.Size(958, 82);
            this.RTB_InputOT.TabIndex = 0;
            this.RTB_InputOT.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_CipherTable);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(964, 237);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Таблица для Шифрования/Расшифрования";
            // 
            // DGV_CipherTable
            // 
            this.DGV_CipherTable.AllowUserToAddRows = false;
            this.DGV_CipherTable.AllowUserToDeleteRows = false;
            this.DGV_CipherTable.AllowUserToResizeColumns = false;
            this.DGV_CipherTable.AllowUserToResizeRows = false;
            this.DGV_CipherTable.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.DGV_CipherTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_CipherTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_CipherTable.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DGV_CipherTable.Location = new System.Drawing.Point(3, 25);
            this.DGV_CipherTable.Name = "DGV_CipherTable";
            this.DGV_CipherTable.Size = new System.Drawing.Size(958, 209);
            this.DGV_CipherTable.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.Controls.Add(this.RB_Sumb, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.BTN_Encrypt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RB_Num, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 362);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(964, 46);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // RB_Sumb
            // 
            this.RB_Sumb.AutoSize = true;
            this.RB_Sumb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RB_Sumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB_Sumb.Location = new System.Drawing.Point(850, 3);
            this.RB_Sumb.Name = "RB_Sumb";
            this.RB_Sumb.Size = new System.Drawing.Size(111, 40);
            this.RB_Sumb.TabIndex = 7;
            this.RB_Sumb.TabStop = true;
            this.RB_Sumb.Text = "Символы";
            this.RB_Sumb.UseVisualStyleBackColor = true;
            // 
            // BTN_Encrypt
            // 
            this.BTN_Encrypt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTN_Encrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_Encrypt.Location = new System.Drawing.Point(3, 3);
            this.BTN_Encrypt.Name = "BTN_Encrypt";
            this.BTN_Encrypt.Size = new System.Drawing.Size(726, 40);
            this.BTN_Encrypt.TabIndex = 5;
            this.BTN_Encrypt.Text = "Зашифровать сообщение";
            this.BTN_Encrypt.UseVisualStyleBackColor = false;
            this.BTN_Encrypt.Click += new System.EventHandler(this.BTN_Encrypt_Click);
            // 
            // RB_Num
            // 
            this.RB_Num.AutoSize = true;
            this.RB_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RB_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RB_Num.Location = new System.Drawing.Point(735, 3);
            this.RB_Num.Name = "RB_Num";
            this.RB_Num.Size = new System.Drawing.Size(109, 40);
            this.RB_Num.TabIndex = 6;
            this.RB_Num.TabStop = true;
            this.RB_Num.Text = "Цифры";
            this.RB_Num.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расшифрование";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.BTN_Decrypt, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(970, 529);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // BTN_Decrypt
            // 
            this.BTN_Decrypt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTN_Decrypt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BTN_Decrypt.Location = new System.Drawing.Point(3, 362);
            this.BTN_Decrypt.Name = "BTN_Decrypt";
            this.BTN_Decrypt.Size = new System.Drawing.Size(964, 46);
            this.BTN_Decrypt.TabIndex = 6;
            this.BTN_Decrypt.Text = "Расшифровать сообщение";
            this.BTN_Decrypt.UseVisualStyleBackColor = false;
            this.BTN_Decrypt.Click += new System.EventHandler(this.BTN_Decrypt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RTB_Decrypted);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 414);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(964, 112);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расшифрованный текст";
            // 
            // RTB_Decrypted
            // 
            this.RTB_Decrypted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_Decrypted.Location = new System.Drawing.Point(3, 25);
            this.RTB_Decrypted.Name = "RTB_Decrypted";
            this.RTB_Decrypted.Size = new System.Drawing.Size(958, 84);
            this.RTB_Decrypted.TabIndex = 0;
            this.RTB_Decrypted.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RTB_InputEnc);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(3, 246);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(964, 110);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Шифртекст";
            // 
            // RTB_InputEnc
            // 
            this.RTB_InputEnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_InputEnc.Location = new System.Drawing.Point(3, 25);
            this.RTB_InputEnc.Name = "RTB_InputEnc";
            this.RTB_InputEnc.Size = new System.Drawing.Size(958, 82);
            this.RTB_InputEnc.TabIndex = 0;
            this.RTB_InputEnc.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DGV_CipherTable1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(964, 237);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Таблица для Шифрования/Расшифрования";
            // 
            // DGV_CipherTable1
            // 
            this.DGV_CipherTable1.AllowUserToAddRows = false;
            this.DGV_CipherTable1.AllowUserToDeleteRows = false;
            this.DGV_CipherTable1.AllowUserToResizeColumns = false;
            this.DGV_CipherTable1.AllowUserToResizeRows = false;
            this.DGV_CipherTable1.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.DGV_CipherTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_CipherTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_CipherTable1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DGV_CipherTable1.Location = new System.Drawing.Point(3, 25);
            this.DGV_CipherTable1.Name = "DGV_CipherTable1";
            this.DGV_CipherTable1.Size = new System.Drawing.Size(958, 209);
            this.DGV_CipherTable1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа 5";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CipherTable)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CipherTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox RTB_Crypted;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox RTB_InputOT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BTN_Encrypt;
        private System.Windows.Forms.RadioButton RB_Num;
        private System.Windows.Forms.RadioButton RB_Sumb;
        private System.Windows.Forms.DataGridView DGV_CipherTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BTN_Decrypt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox RTB_Decrypted;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox RTB_InputEnc;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView DGV_CipherTable1;
    }
}

