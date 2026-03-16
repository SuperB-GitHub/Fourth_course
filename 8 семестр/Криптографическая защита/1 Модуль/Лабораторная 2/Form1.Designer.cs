namespace Лабораторная_2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabPage1; // Генерация
        private TabPage tabPage2; // Настройка А
        private TabPage tabPage4; // Процесс
        private TabPage tabPage5; // Результаты

        // Вкладка 1: Генерация
        private GroupBox groupBoxKeys;
        private Label labelN;
        private Label labelOpenKey;
        private Label labelSecretKey;
        private Button buttonGenerateKeys;
        private NumericUpDown numericP;
        private NumericUpDown numericQ;
        private Label labelP;
        private Label labelQ;
        private GroupBox groupBoxCycles;
        private Label labelTotalCycles;
        private NumericUpDown numericTotalCycles;
        private Label labelAccreditationsPerCycle;
        private NumericUpDown numericAccreditationsPerCycle;

        // Вкладка 2: Настройка А
        private GroupBox groupBoxAMode;
        private RadioButton radioAHonest;
        private RadioButton radioAFake;
        private GroupBox groupBoxAError;
        private Label labelErrorPercent;
        private NumericUpDown numericErrorPercent;
        private CheckBox checkBoxUseOldR;

        // Вкладка 4: Процесс
        private Button buttonStartProcess;
        private Button buttonNextCycle;
        private Button buttonReset;
        private ListBox listBoxProcessLog;
        private Label labelCurrentCycle;
        private Label labelCurrentAccreditation;
        private ProgressBar progressBarSuccess;
        private RichTextBox richTextBoxProtocolDetails; // Для детального отображения шагов протокола

        // Вкладка 5: Результаты
        private TextBox textBoxSummary;
        private ListBox listBoxStolenKeys;
        private Button buttonExportResults;
        private Label labelSuccessRate;
        private Label labelTheoryRate;
        private DataGridView dataGridViewResults; // Таблица со статистикой по раундам

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox1 = new GroupBox();
            RTB_LogGen = new RichTextBox();
            groupBoxKeys = new GroupBox();
            labelP = new Label();
            numericP = new NumericUpDown();
            labelQ = new Label();
            numericQ = new NumericUpDown();
            buttonGenerateKeys = new Button();
            labelN = new Label();
            labelOpenKey = new Label();
            labelSecretKey = new Label();
            groupBoxCycles = new GroupBox();
            labelTotalCycles = new Label();
            numericTotalCycles = new NumericUpDown();
            labelAccreditationsPerCycle = new Label();
            numericAccreditationsPerCycle = new NumericUpDown();
            tabPage2 = new TabPage();
            checkBoxBCatchReuse = new CheckBox();
            groupBoxBMode = new GroupBox();
            radioBHonest = new RadioButton();
            radioBThief = new RadioButton();
            groupBoxAMode = new GroupBox();
            radioAHonest = new RadioButton();
            radioAFake = new RadioButton();
            groupBoxAError = new GroupBox();
            labelErrorPercent = new Label();
            numericErrorPercent = new NumericUpDown();
            checkBoxUseOldR = new CheckBox();
            tabPage4 = new TabPage();
            buttonStartProcess = new Button();
            buttonNextCycle = new Button();
            buttonReset = new Button();
            labelCurrentCycle = new Label();
            labelCurrentAccreditation = new Label();
            listBoxProcessLog = new ListBox();
            richTextBoxProtocolDetails = new RichTextBox();
            progressBarSuccess = new ProgressBar();
            tabPage5 = new TabPage();
            labelSuccessRate = new Label();
            labelTheoryRate = new Label();
            textBoxSummary = new TextBox();
            dataGridViewResults = new DataGridView();
            listBoxStolenKeys = new ListBox();
            buttonExportResults = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericQ).BeginInit();
            groupBoxCycles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericTotalCycles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAccreditationsPerCycle).BeginInit();
            tabPage2.SuspendLayout();
            groupBoxBMode.SuspendLayout();
            groupBoxAMode.SuspendLayout();
            groupBoxAError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericErrorPercent).BeginInit();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1050, 562);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBoxKeys);
            tabPage1.Controls.Add(groupBoxCycles);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1042, 534);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "1. Генерация";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RTB_LogGen);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(8, 271);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1006, 255);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Логи рассчётов";
            // 
            // RTB_LogGen
            // 
            RTB_LogGen.BorderStyle = BorderStyle.None;
            RTB_LogGen.Dock = DockStyle.Fill;
            RTB_LogGen.Location = new Point(3, 25);
            RTB_LogGen.Name = "RTB_LogGen";
            RTB_LogGen.Size = new Size(1000, 227);
            RTB_LogGen.TabIndex = 2;
            RTB_LogGen.Text = "";
            // 
            // groupBoxKeys
            // 
            groupBoxKeys.Controls.Add(labelP);
            groupBoxKeys.Controls.Add(numericP);
            groupBoxKeys.Controls.Add(labelQ);
            groupBoxKeys.Controls.Add(numericQ);
            groupBoxKeys.Controls.Add(buttonGenerateKeys);
            groupBoxKeys.Controls.Add(labelN);
            groupBoxKeys.Controls.Add(labelOpenKey);
            groupBoxKeys.Controls.Add(labelSecretKey);
            groupBoxKeys.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxKeys.Location = new Point(9, 9);
            groupBoxKeys.Name = "groupBoxKeys";
            groupBoxKeys.Size = new Size(1006, 156);
            groupBoxKeys.TabIndex = 0;
            groupBoxKeys.TabStop = false;
            groupBoxKeys.Text = "Генерация ключей (p и q - двузначные простые)";
            // 
            // labelP
            // 
            labelP.Location = new Point(9, 28);
            labelP.Name = "labelP";
            labelP.Size = new Size(101, 27);
            labelP.TabIndex = 0;
            labelP.Text = "p (простое):";
            // 
            // numericP
            // 
            numericP.Location = new Point(115, 26);
            numericP.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericP.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericP.Name = "numericP";
            numericP.Size = new Size(52, 29);
            numericP.TabIndex = 1;
            numericP.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // labelQ
            // 
            labelQ.Location = new Point(8, 67);
            labelQ.Name = "labelQ";
            labelQ.Size = new Size(101, 27);
            labelQ.TabIndex = 2;
            labelQ.Text = "q (простое):";
            // 
            // numericQ
            // 
            numericQ.Location = new Point(115, 65);
            numericQ.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numericQ.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericQ.Name = "numericQ";
            numericQ.Size = new Size(52, 29);
            numericQ.TabIndex = 3;
            numericQ.Value = new decimal(new int[] { 17, 0, 0, 0 });
            // 
            // buttonGenerateKeys
            // 
            buttonGenerateKeys.Location = new Point(6, 109);
            buttonGenerateKeys.Name = "buttonGenerateKeys";
            buttonGenerateKeys.Size = new Size(335, 28);
            buttonGenerateKeys.TabIndex = 4;
            buttonGenerateKeys.Text = "Сгенерировать ключи";
            buttonGenerateKeys.Click += ButtonGenerateKeys_Click;
            // 
            // labelN
            // 
            labelN.Location = new Point(175, 28);
            labelN.Name = "labelN";
            labelN.Size = new Size(262, 19);
            labelN.TabIndex = 5;
            labelN.Text = "n = ...";
            // 
            // labelOpenKey
            // 
            labelOpenKey.Location = new Point(175, 52);
            labelOpenKey.Name = "labelOpenKey";
            labelOpenKey.Size = new Size(350, 19);
            labelOpenKey.TabIndex = 6;
            labelOpenKey.Text = "Открытые ключи V: ...";
            // 
            // labelSecretKey
            // 
            labelSecretKey.Location = new Point(175, 75);
            labelSecretKey.Name = "labelSecretKey";
            labelSecretKey.Size = new Size(350, 19);
            labelSecretKey.TabIndex = 7;
            labelSecretKey.Text = "Секретные ключи S: ...";
            // 
            // groupBoxCycles
            // 
            groupBoxCycles.Controls.Add(labelTotalCycles);
            groupBoxCycles.Controls.Add(numericTotalCycles);
            groupBoxCycles.Controls.Add(labelAccreditationsPerCycle);
            groupBoxCycles.Controls.Add(numericAccreditationsPerCycle);
            groupBoxCycles.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxCycles.Location = new Point(8, 171);
            groupBoxCycles.Name = "groupBoxCycles";
            groupBoxCycles.Size = new Size(1006, 94);
            groupBoxCycles.TabIndex = 1;
            groupBoxCycles.TabStop = false;
            groupBoxCycles.Text = "Параметры циклов";
            // 
            // labelTotalCycles
            // 
            labelTotalCycles.Location = new Point(9, 25);
            labelTotalCycles.Name = "labelTotalCycles";
            labelTotalCycles.Size = new Size(177, 27);
            labelTotalCycles.TabIndex = 0;
            labelTotalCycles.Text = "Количество циклов (t):";
            // 
            // numericTotalCycles
            // 
            numericTotalCycles.Location = new Point(217, 23);
            numericTotalCycles.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericTotalCycles.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTotalCycles.Name = "numericTotalCycles";
            numericTotalCycles.Size = new Size(52, 29);
            numericTotalCycles.TabIndex = 1;
            numericTotalCycles.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // labelAccreditationsPerCycle
            // 
            labelAccreditationsPerCycle.Location = new Point(9, 53);
            labelAccreditationsPerCycle.Name = "labelAccreditationsPerCycle";
            labelAccreditationsPerCycle.Size = new Size(200, 29);
            labelAccreditationsPerCycle.TabIndex = 2;
            labelAccreditationsPerCycle.Text = "Аккредитаций в цикле (K):";
            // 
            // numericAccreditationsPerCycle
            // 
            numericAccreditationsPerCycle.Location = new Point(217, 53);
            numericAccreditationsPerCycle.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericAccreditationsPerCycle.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericAccreditationsPerCycle.Name = "numericAccreditationsPerCycle";
            numericAccreditationsPerCycle.Size = new Size(52, 29);
            numericAccreditationsPerCycle.TabIndex = 3;
            numericAccreditationsPerCycle.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(checkBoxBCatchReuse);
            tabPage2.Controls.Add(groupBoxBMode);
            tabPage2.Controls.Add(groupBoxAMode);
            tabPage2.Controls.Add(groupBoxAError);
            tabPage2.Controls.Add(checkBoxUseOldR);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(1042, 534);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "2. Настройка сторон";
            // 
            // checkBoxBCatchReuse
            // 
            checkBoxBCatchReuse.Checked = true;
            checkBoxBCatchReuse.CheckState = CheckState.Checked;
            checkBoxBCatchReuse.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBoxBCatchReuse.Location = new Point(18, 360);
            checkBoxBCatchReuse.Name = "checkBoxBCatchReuse";
            checkBoxBCatchReuse.Size = new Size(690, 29);
            checkBoxBCatchReuse.TabIndex = 4;
            checkBoxBCatchReuse.Text = "Активно пытаться украсть ключ при повторе r (рекомендуется включить)";
            // 
            // groupBoxBMode
            // 
            groupBoxBMode.Controls.Add(radioBHonest);
            groupBoxBMode.Controls.Add(radioBThief);
            groupBoxBMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxBMode.Location = new Point(9, 256);
            groupBoxBMode.Name = "groupBoxBMode";
            groupBoxBMode.Size = new Size(1006, 98);
            groupBoxBMode.TabIndex = 3;
            groupBoxBMode.TabStop = false;
            groupBoxBMode.Text = "Режим работы стороны В";
            // 
            // radioBHonest
            // 
            radioBHonest.Checked = true;
            radioBHonest.Location = new Point(9, 23);
            radioBHonest.Name = "radioBHonest";
            radioBHonest.Size = new Size(305, 31);
            radioBHonest.TabIndex = 0;
            radioBHonest.TabStop = true;
            radioBHonest.Text = "В - Честный  (просто проверяет)";
            // 
            // radioBThief
            // 
            radioBThief.Location = new Point(9, 59);
            radioBThief.Name = "radioBThief";
            radioBThief.Size = new Size(423, 33);
            radioBThief.TabIndex = 1;
            radioBThief.Text = "В - Мошенник (пытается украсть секретный ключ)";
            // 
            // groupBoxAMode
            // 
            groupBoxAMode.Controls.Add(radioAHonest);
            groupBoxAMode.Controls.Add(radioAFake);
            groupBoxAMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxAMode.Location = new Point(9, 9);
            groupBoxAMode.Name = "groupBoxAMode";
            groupBoxAMode.Size = new Size(1006, 90);
            groupBoxAMode.TabIndex = 0;
            groupBoxAMode.TabStop = false;
            groupBoxAMode.Text = "Режим работы стороны А";
            // 
            // radioAHonest
            // 
            radioAHonest.Checked = true;
            radioAHonest.Location = new Point(9, 23);
            radioAHonest.Name = "radioAHonest";
            radioAHonest.Size = new Size(317, 23);
            radioAHonest.TabIndex = 0;
            radioAHonest.TabStop = true;
            radioAHonest.Text = "А - Честный (знает S)";
            // 
            // radioAFake
            // 
            radioAFake.Location = new Point(9, 52);
            radioAFake.Name = "radioAFake";
            radioAFake.Size = new Size(412, 32);
            radioAFake.TabIndex = 1;
            radioAFake.Text = "А - Мошенник (не знает S, пытается угадать)";
            // 
            // groupBoxAError
            // 
            groupBoxAError.Controls.Add(labelErrorPercent);
            groupBoxAError.Controls.Add(numericErrorPercent);
            groupBoxAError.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBoxAError.Location = new Point(9, 105);
            groupBoxAError.Name = "groupBoxAError";
            groupBoxAError.Size = new Size(1006, 75);
            groupBoxAError.TabIndex = 1;
            groupBoxAError.TabStop = false;
            groupBoxAError.Text = "Параметры ошибок";
            // 
            // labelErrorPercent
            // 
            labelErrorPercent.Location = new Point(9, 28);
            labelErrorPercent.Name = "labelErrorPercent";
            labelErrorPercent.Size = new Size(377, 27);
            labelErrorPercent.TabIndex = 0;
            labelErrorPercent.Text = "Вероятность ошибки при ответе (для честного А):";
            // 
            // numericErrorPercent
            // 
            numericErrorPercent.Location = new Point(392, 26);
            numericErrorPercent.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericErrorPercent.Name = "numericErrorPercent";
            numericErrorPercent.Size = new Size(52, 29);
            numericErrorPercent.TabIndex = 1;
            numericErrorPercent.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // checkBoxUseOldR
            // 
            checkBoxUseOldR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            checkBoxUseOldR.Location = new Point(18, 186);
            checkBoxUseOldR.Name = "checkBoxUseOldR";
            checkBoxUseOldR.Size = new Size(878, 28);
            checkBoxUseOldR.TabIndex = 2;
            checkBoxUseOldR.Text = "Разрешить А повторно использовать r (Для уязвимости, т.е. В-мошенник сможет украсть ключ)";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(buttonStartProcess);
            tabPage4.Controls.Add(buttonNextCycle);
            tabPage4.Controls.Add(buttonReset);
            tabPage4.Controls.Add(labelCurrentCycle);
            tabPage4.Controls.Add(labelCurrentAccreditation);
            tabPage4.Controls.Add(listBoxProcessLog);
            tabPage4.Controls.Add(richTextBoxProtocolDetails);
            tabPage4.Controls.Add(progressBarSuccess);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1042, 534);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "4. Процесс";
            // 
            // buttonStartProcess
            // 
            buttonStartProcess.Location = new Point(9, 9);
            buttonStartProcess.Name = "buttonStartProcess";
            buttonStartProcess.Size = new Size(88, 38);
            buttonStartProcess.TabIndex = 0;
            buttonStartProcess.Text = "Старт";
            buttonStartProcess.Click += ButtonStartProcess_Click;
            // 
            // buttonNextCycle
            // 
            buttonNextCycle.Enabled = false;
            buttonNextCycle.Location = new Point(105, 9);
            buttonNextCycle.Name = "buttonNextCycle";
            buttonNextCycle.Size = new Size(105, 38);
            buttonNextCycle.TabIndex = 1;
            buttonNextCycle.Text = "Следующий цикл";
            buttonNextCycle.Click += ButtonNextCycle_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(219, 9);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(88, 38);
            buttonReset.TabIndex = 2;
            buttonReset.Text = "Сброс";
            buttonReset.Click += ButtonReset_Click;
            // 
            // labelCurrentCycle
            // 
            labelCurrentCycle.Location = new Point(332, 9);
            labelCurrentCycle.Name = "labelCurrentCycle";
            labelCurrentCycle.Size = new Size(131, 19);
            labelCurrentCycle.TabIndex = 3;
            labelCurrentCycle.Text = "Цикл: 0/0";
            // 
            // labelCurrentAccreditation
            // 
            labelCurrentAccreditation.Location = new Point(332, 28);
            labelCurrentAccreditation.Name = "labelCurrentAccreditation";
            labelCurrentAccreditation.Size = new Size(131, 19);
            labelCurrentAccreditation.TabIndex = 4;
            labelCurrentAccreditation.Text = "Аккредитация: 0/0";
            // 
            // listBoxProcessLog
            // 
            listBoxProcessLog.Location = new Point(9, 56);
            listBoxProcessLog.Name = "listBoxProcessLog";
            listBoxProcessLog.Size = new Size(526, 184);
            listBoxProcessLog.TabIndex = 5;
            // 
            // richTextBoxProtocolDetails
            // 
            richTextBoxProtocolDetails.Location = new Point(542, 56);
            richTextBoxProtocolDetails.Name = "richTextBoxProtocolDetails";
            richTextBoxProtocolDetails.ReadOnly = true;
            richTextBoxProtocolDetails.Size = new Size(473, 188);
            richTextBoxProtocolDetails.TabIndex = 6;
            richTextBoxProtocolDetails.Text = "Детали протокола будут отображаться здесь...";
            // 
            // progressBarSuccess
            // 
            progressBarSuccess.Location = new Point(9, 253);
            progressBarSuccess.Name = "progressBarSuccess";
            progressBarSuccess.Size = new Size(1006, 28);
            progressBarSuccess.TabIndex = 7;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(labelSuccessRate);
            tabPage5.Controls.Add(labelTheoryRate);
            tabPage5.Controls.Add(textBoxSummary);
            tabPage5.Controls.Add(dataGridViewResults);
            tabPage5.Controls.Add(listBoxStolenKeys);
            tabPage5.Controls.Add(buttonExportResults);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1042, 534);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "5. Результаты";
            // 
            // labelSuccessRate
            // 
            labelSuccessRate.Location = new Point(9, 9);
            labelSuccessRate.Name = "labelSuccessRate";
            labelSuccessRate.Size = new Size(520, 19);
            labelSuccessRate.TabIndex = 0;
            labelSuccessRate.Text = "Реальная успешность:";
            // 
            // labelTheoryRate
            // 
            labelTheoryRate.Location = new Point(9, 28);
            labelTheoryRate.Name = "labelTheoryRate";
            labelTheoryRate.Size = new Size(378, 19);
            labelTheoryRate.TabIndex = 1;
            labelTheoryRate.Text = "Теоретическая вероятность обмана:";
            // 
            // textBoxSummary
            // 
            textBoxSummary.Location = new Point(9, 56);
            textBoxSummary.Multiline = true;
            textBoxSummary.Name = "textBoxSummary";
            textBoxSummary.ReadOnly = true;
            textBoxSummary.ScrollBars = ScrollBars.Vertical;
            textBoxSummary.Size = new Size(998, 113);
            textBoxSummary.TabIndex = 2;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.Location = new Point(9, 178);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.Size = new Size(998, 141);
            dataGridViewResults.TabIndex = 3;
            // 
            // listBoxStolenKeys
            // 
            listBoxStolenKeys.Location = new Point(9, 328);
            listBoxStolenKeys.Name = "listBoxStolenKeys";
            listBoxStolenKeys.Size = new Size(788, 199);
            listBoxStolenKeys.TabIndex = 4;
            // 
            // buttonExportResults
            // 
            buttonExportResults.Location = new Point(805, 328);
            buttonExportResults.Name = "buttonExportResults";
            buttonExportResults.Size = new Size(201, 38);
            buttonExportResults.TabIndex = 5;
            buttonExportResults.Text = "Экспорт результатов в файл";
            buttonExportResults.Click += ButtonExportResults_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 562);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная работа 2: Идентификация с нулевым разглашением";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBoxKeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericQ).EndInit();
            groupBoxCycles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericTotalCycles).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAccreditationsPerCycle).EndInit();
            tabPage2.ResumeLayout(false);
            groupBoxBMode.ResumeLayout(false);
            groupBoxAMode.ResumeLayout(false);
            groupBoxAError.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericErrorPercent).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        private RichTextBox RTB_LogGen;
        private GroupBox groupBox1;
        private CheckBox checkBoxBCatchReuse;
        private GroupBox groupBoxBMode;
        private RadioButton radioBHonest;
        private RadioButton radioBThief;
    }
}