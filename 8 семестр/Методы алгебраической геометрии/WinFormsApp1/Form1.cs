using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private TextBox tbA, tbB;
        private Button btnGenerate;
        private Panel graphPanel;
        private Label lblResult;
        private float a, b;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Эллиптические кривые над полем вещественных чисел";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblA = new Label() { Text = "a:", Location = new Point(20, 20), Size = new Size(30, 25) };
            tbA = new TextBox() { Location = new Point(50, 20), Size = new Size(60, 25), Text = "-3" };

            Label lblB = new Label() { Text = "b:", Location = new Point(130, 20), Size = new Size(30, 25) };
            tbB = new TextBox() { Location = new Point(160, 20), Size = new Size(60, 25), Text = "1" };

            btnGenerate = new Button() { Text = "Построить кривую", Location = new Point(240, 18), Size = new Size(120, 30) };

            lblResult = new Label() { Text = "Результат:", Location = new Point(20, 60), Size = new Size(850, 30), Font = new Font("Arial", 10, FontStyle.Bold) };

            graphPanel = new Panel() { Location = new Point(20, 100), Size = new Size(850, 550), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            graphPanel.Paint += GraphPanel_Paint;

            this.Controls.AddRange(new Control[] { lblA, tbA, lblB, tbB, btnGenerate, lblResult, graphPanel });
            btnGenerate.Click += BtnGenerate_Click;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(tbA.Text);
                b = float.Parse(tbB.Text);
                CheckSingularity();
                graphPanel.Invalidate();
            }
            catch
            {
                MessageBox.Show("Ошибка ввода!");
            }
        }

        private void CheckSingularity()
        {
            double D = 4 * Math.Pow(a, 3) + 27 * Math.Pow(b, 2);

            if (Math.Abs(D) < 1e-10)
            {
                lblResult.Text = $"СИНГУЛЯРНАЯ кривая (дискриминант = 0)";
                lblResult.ForeColor = Color.Red;

                if (Math.Abs(a) < 1e-10 && Math.Abs(b) < 1e-10)
                    lblResult.Text += " - КАСП (точка возврата)";
                else
                    lblResult.Text += " - САМОПЕРЕСЕЧЕНИЕ";
            }
            else
            {
                lblResult.Text = $"НЕСИНГУЛЯРНАЯ кривая (дискриминант = {D:F4})";
                lblResult.ForeColor = Color.Green;
            }
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int w = graphPanel.Width;
            int h = graphPanel.Height;
            int cx = w / 2;
            int cy = h / 2;

            // Рисуем оси
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, cx, 0, cx, h);
                g.DrawLine(pen, 0, cy, w, cy);
            }

            g.DrawString("X", new Font("Arial", 9), Brushes.Black, w - 20, cy - 15);
            g.DrawString("Y", new Font("Arial", 9), Brushes.Black, cx + 5, 5);

            float scale = 30f;

            // Находим интервалы, где функция определена
            List<Interval> intervals = FindDefinedIntervals(-10f, 10f, 0.00001f);

            using (Pen curvePen = new Pen(Color.Blue, 2))
            {
                foreach (var interval in intervals)
                {
                    // Рисуем верхнюю и нижнюю ветвь
                    List<PointF> upperPoints = new List<PointF>();
                    List<PointF> lowerPoints = new List<PointF>();

                    for (float x = interval.Start; x <= interval.End; x += 0.0001f)
                    {
                        float val = (float)(Math.Pow(x, 3) + a * x + b);
                        float y = (float)Math.Sqrt(val);

                        float screenX = cx + x * scale;
                        float screenY_up = cy - y * scale;
                        float screenY_down = cy + y * scale;

                        if (screenX >= 0 && screenX <= w)
                        {
                            // Верхняя ветвь (всегда добавляем, даже если y=0)
                            if (screenY_up >= 0 && screenY_up <= h)
                                upperPoints.Add(new PointF(screenX, screenY_up));

                            // Нижняя ветвь - добавляем всегда, но для y=0 точки будут совпадать с верхними
                            if (screenY_down >= 0 && screenY_down <= h)
                                lowerPoints.Add(new PointF(screenX, screenY_down));
                        }
                    }

                    if (upperPoints.Count > 1)
                        g.DrawLines(curvePen, upperPoints.ToArray());
                    if (lowerPoints.Count > 1)
                        g.DrawLines(curvePen, lowerPoints.ToArray());
                }
            }

            FindAndDrawSpecialPoints(g, cx, cy, scale);
        }

        private List<Interval> FindDefinedIntervals(float start, float end, float step)
        {
            List<Interval> intervals = new List<Interval>();
            bool inInterval = false;
            float intervalStart = 0;

            for (float x = start; x <= end; x += step)
            {
                float val = (float)(Math.Pow(x, 3) + a * x + b);
                bool isDefined = val >= 0;

                if (isDefined && !inInterval)
                {
                    // Начало нового интервала
                    inInterval = true;
                    intervalStart = x;
                }
                else if (!isDefined && inInterval)
                {
                    // Конец интервала
                    inInterval = false;
                    intervals.Add(new Interval(intervalStart, x - step));
                }
            }

            // Если закончили в интервале
            if (inInterval)
            {
                intervals.Add(new Interval(intervalStart, end));
            }

            return intervals;
        }

        private void FindAndDrawSpecialPoints(Graphics g, int cx, int cy, float scale)
        {
            if (a < 0)
            {
                float x1 = -(float)Math.Sqrt(-a / 3);
                float x2 = (float)Math.Sqrt(-a / 3);

                CheckPoint(g, cx, cy, scale, x1);
                CheckPoint(g, cx, cy, scale, x2);
            }

            if (Math.Abs(a) < 0.001f && Math.Abs(b) < 0.001f)
            {
                float screenX = cx;
                float screenY = cy;
                g.FillEllipse(Brushes.Red, screenX - 5, screenY - 5, 10, 10);
                g.DrawString("КАСП", new Font("Arial", 8), Brushes.Red, screenX + 10, screenY - 15);
            }
        }

        private void CheckPoint(Graphics g, int cx, int cy, float scale, float x)
        {
            float val = (float)(Math.Pow(x, 3) + a * x + b);

            if (Math.Abs(val) < 0.01f && val >= 0)
            {
                float screenX = cx + x * scale;
                float screenY = cy;

                if (screenX >= 0 && screenX <= graphPanel.Width)
                {
                    g.FillEllipse(Brushes.Red, screenX - 5, screenY - 5, 10, 10);
                    g.DrawString("Особая точка", new Font("Arial", 7), Brushes.Red, screenX + 10, screenY - 10);
                }
            }
        }

        // Вспомогательный класс для хранения интервалов
        private class Interval
        {
            public float Start { get; set; }
            public float End { get; set; }

            public Interval(float start, float end)
            {
                Start = start;
                End = end;
            }
        }
    }
}

