namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tbA = new TextBox();
            tbB = new TextBox();
            btnGenerate = new Button();
            graphPanel = new Panel();
            lblResult = new Label();
            label1 = new Label();
            label2 = new Label();
            labelResult = new Label();
            SuspendLayout();
            // 
            // tbA
            // 
            tbA.Location = new Point(57, 15);
            tbA.Margin = new Padding(3, 2, 3, 2);
            tbA.Name = "tbA";
            tbA.Size = new Size(53, 23);
            tbA.TabIndex = 1;
            tbA.Text = "-3";
            // 
            // tbB
            // 
            tbB.Location = new Point(151, 16);
            tbB.Margin = new Padding(3, 2, 3, 2);
            tbB.Name = "tbB";
            tbB.Size = new Size(53, 23);
            tbB.TabIndex = 3;
            tbB.Text = "1";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(231, 14);
            btnGenerate.Margin = new Padding(3, 2, 3, 2);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(172, 29);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Построить кривую";
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // graphPanel
            // 
            graphPanel.BackColor = Color.White;
            graphPanel.BorderStyle = BorderStyle.FixedSingle;
            graphPanel.Location = new Point(18, 75);
            graphPanel.Margin = new Padding(3, 2, 3, 2);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(1254, 675);
            graphPanel.TabIndex = 6;
            graphPanel.Paint += GraphPanel_Paint;
            // 
            // lblResult
            // 
            lblResult.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblResult.Location = new Point(18, 45);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(109, 22);
            lblResult.TabIndex = 5;
            lblResult.Text = "Результат:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(37, 21);
            label1.TabIndex = 7;
            label1.Text = "a = ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(116, 14);
            label2.Name = "label2";
            label2.Size = new Size(38, 21);
            label2.TabIndex = 8;
            label2.Text = "b = ";
            // 
            // labelResult
            // 
            labelResult.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelResult.Location = new Point(116, 45);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(676, 22);
            labelResult.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 761);
            Controls.Add(labelResult);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbA);
            Controls.Add(tbB);
            Controls.Add(btnGenerate);
            Controls.Add(lblResult);
            Controls.Add(graphPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Эллиптические кривые над полем вещественных чисел";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label lblResult;
        private Label label1;
        private Label label2;
        private Label labelResult;
    }
}