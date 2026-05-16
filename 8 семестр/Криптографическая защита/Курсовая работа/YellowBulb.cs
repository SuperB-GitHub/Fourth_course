using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class YellowBulb : UserControl
    {
        private bool _isOn = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsOn { get => _isOn; set { _isOn = value; Invalidate(); } }
        public YellowBulb()
        {
            Size = new Size(50, 50);
            BackColor = Color.Transparent;
            ResizeRedraw = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int side = Math.Min(Width, Height);
            Size = new Size(side, side);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color colorBulb = _isOn ? Color.Gold : Color.Gray;

            int padding = (int)(Width * 0.1);
            int diameter = Width - padding * 2;

            using SolidBrush brush = new(colorBulb);
            g.FillEllipse(brush, padding, padding, diameter, diameter);

            using Pen pen = new(Color.Gray, 4);
            g.DrawEllipse(pen, padding, padding, diameter, diameter);
        }

    }
}