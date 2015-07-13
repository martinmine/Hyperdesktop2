using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace hyperdesktop2
{
    public partial class Snipper : Form
    {
        private static readonly Point InvalidPoint = new Point(-1, -1);

        public static Rectangle GetRegion()
        {
            var snipper = new Snipper();

            if (snipper.ShowDialog() == DialogResult.OK)
                return snipper.Rect;

            return new Rectangle(0, 0, 0, 0);
        }

        public Snipper()
        {
            InitializeComponent();

            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Cursor = Cursors.Cross;

            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;
            this.Opacity = 0.70;

            this.Location = new Point(ScreenBounds.Bounds.Left, ScreenBounds.Bounds.Top);
            this.Size = new Size(ScreenBounds.Bounds.Width, ScreenBounds.Bounds.Height);

            // TODO: Find a better solution for this lol
            new Thread(() => {
                Thread.Sleep(100);
                this.Invoke((MethodInvoker)delegate { Activate(); });
            }).Start();
        }

        public Rectangle Rect { get; set; }

        private Rectangle select = new Rectangle();
        private Rectangle previousSelect = new Rectangle();
        private Point start;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Invalidate(select);
                select = new Rectangle();
                start = InvalidPoint;
                Invalidate(select);
                return;
            }
                

            if (e.Button != MouseButtons.Left)
                return;

            start = e.Location;
            select = new Rectangle(e.Location, new Size(0, 0));
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || start == InvalidPoint)
                return;
                Debug.WriteLine("OnMouseMove");

            int x1 = Math.Min(e.X, start.X);
            int y1 = Math.Min(e.Y, start.Y);
            int x2 = Math.Max(e.X, start.X);
            int y2 = Math.Max(e.Y, start.Y);

            Invalidate(previousSelect);
            previousSelect = select;

            select = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            Invalidate(select);

            // Invalidating the whole created the delay 
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (select.Width <= 0 || select.Height <= 0 || e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            Rect = new Rectangle(
                ScreenBounds.Bounds.Left + select.Left,
                ScreenBounds.Bounds.Top + select.Top,
                select.Width,
                select.Height
            );

            DialogResult = DialogResult.OK;
        }

        Brush brush = new SolidBrush(Color.Gray);
        Pen pen = new Pen(Color.DarkGray);

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Region region = new Region(new Rectangle(0, 0, this.Width, this.Height)))
            {
                region.Exclude(select);
                region.Intersect(e.ClipRectangle);
                e.Graphics.FillRegion(brush, region);
                e.Graphics.DrawRectangle(pen, select.X, select.Y, select.Width - 1, select.Height - 1);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            if (key == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;

            return base.ProcessCmdKey(ref msg, key);
        }
    }
}