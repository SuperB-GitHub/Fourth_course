using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Лабораторная_работа_3
{
    public partial class Form1 : Form
    {
        private float a, b;

        public Form1()
        {
            InitializeComponent();
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
                labelResult.Text = $"Кривая сингулярна (дискриминант = 0)";
                labelResult.ForeColor = Color.Red;

                if (Math.Abs(a) < 1e-10 && Math.Abs(b) < 1e-10)
                    labelResult.Text += " - Точка возврата";
                else
                    labelResult.Text += " - Самопересечение";
            }
            else
            {
                labelResult.Text = $"Кривая не сингулярна (дискриминант = {D:F4})";
                labelResult.ForeColor = Color.Green;
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

            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, cx, 0, cx, h);
                g.DrawLine(pen, 0, cy, w, cy);
            }

            g.DrawString("X", new Font("Arial", 9), Brushes.Black, w - 20, cy - 15);
            g.DrawString("Y", new Font("Arial", 9), Brushes.Black, cx + 5, 5);

            float scale = 30f;

            var intervals = FindDefinedIntervals(-10f, 10f, 0.00001f);

            using (Pen curvePen = new Pen(Color.Blue, 2))
            {
                foreach (var interval in intervals)
                {
                    List<PointF> upper = new List<PointF>();
                    List<PointF> lower = new List<PointF>();

                    for (float x = interval.Start; x <= interval.End; x += 0.0001f)
                    {
                        float val = (float)(Math.Pow(x, 3) + a * x + b);
                        float y = (float)Math.Sqrt(val);

                        float screenX = cx + x * scale;
                        float screenY_up = cy - y * scale;
                        float screenY_down = cy + y * scale;

                        if (screenX < 0 || screenX > w) continue;

                        if (screenY_up >= 0 && screenY_up <= h)
                            upper.Add(new PointF(screenX, screenY_up));

                        if (screenY_down >= 0 && screenY_down <= h)
                            lower.Add(new PointF(screenX, screenY_down));
                    }

                    if (upper.Count > 1) g.DrawLines(curvePen, upper.ToArray());
                    if (lower.Count > 1) g.DrawLines(curvePen, lower.ToArray());
                }
            }

            FindAndDrawSpecialPoints(g, cx, cy, scale);
        }

        private List<Interval> FindDefinedIntervals(float start, float end, float step)
        {
            var intervals = new List<Interval>();
            bool inInterval = false;
            float intervalStart = 0;

            for (float x = start; x <= end; x += step)
            {
                float val = (float)(x * x * x + a * x + b);
                bool defined = val >= 0;

                if (defined && !inInterval)
                {
                    inInterval = true;
                    intervalStart = x;
                }
                else if (!defined && inInterval)
                {
                    inInterval = false;
                    intervals.Add(new Interval(intervalStart, x - step));
                }
            }

            if (inInterval)
                intervals.Add(new Interval(intervalStart, end));

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
                float sx = cx;
                float sy = cy;
                g.FillEllipse(Brushes.Red, sx - 5, sy - 5, 10, 10);
                g.DrawString("Точка возврата", new Font("Arial", 9), Brushes.Red, sx + 10, sy - 15);
            }
        }

        private void CheckPoint(Graphics g, int cx, int cy, float scale, float x)
        {
            float val = (float)(Math.Pow(x, 3) + a * x + b);
            if (val >= -0.01f && val <= 0.01f)   // ≈ 0
            {
                float sx = cx + x * scale;
                if (sx < 0 || sx > graphPanel.Width) return;

                float sy = cy;
                g.FillEllipse(Brushes.Red, sx - 5, sy - 5, 10, 10);
                g.DrawString("Особая точка", new Font("Arial", 9), Brushes.Red, sx + 10, sy - 10);
            }
        }

        private class Interval
        {
            public float Start { get; }
            public float End { get; }

            public Interval(float start, float end)
            {
                Start = start;
                End = end;
            }
        }
    }
}