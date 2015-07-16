using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shikashi
{
    public partial class Edit : Form
    {
        private static Color penColor = Color.Red;
        private static Int16 penSize = 5;
        private List<Bitmap> undo;
        private Graphics g;
        private Point pointX, pointY;
        private Font font;
        private Pen pen = new Pen(penColor);
        private SolidBrush brush = new SolidBrush(penColor);
        private Boolean usingPen = true;

        private Dictionary<string, int> sizes = new Dictionary<string, int>();

        public Bitmap Result { set; get; }

        public Edit(Bitmap bmp, Font font = null, Boolean dropShadow = false)
        {
            InitializeComponent();

            sizes.Add("Pixel", 1);
            sizes.Add("Small", 5);
            sizes.Add("Medium", 12);
            sizes.Add("Large", 24);
            sizes.Add("Huge", 32);
            sizes.Add("Massive", 64);

            foreach (KeyValuePair<string, int> pair in sizes)
                drop_size.Items.Add(pair.Key);

            undo = new List<Bitmap>();
            undo.Add(new Bitmap(bmp));

            font = font ?? new Font("Arial", 16);
            checkDropShadow.Checked = dropShadow;
        }

        private void Frm_EditLoad(object sender, EventArgs e)
        {
            // Set picture to the one we just recieved
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = new Bitmap(undo[0]);
            dropColor.Text = "Red";

            // Set control defaults
            drop_size.SelectedIndex = 1;
            dropColor.SelectedIndex = 1;
        }

        #region Controls
        private void BtnOkClick(object sender, EventArgs e)
        {
            Result = new Bitmap(pictureBox.Image);
            this.Close();
            pictureBox.Image = null;
            undo.Clear();
        }

        private void TextInsertClick(object sender, EventArgs e)
        {
            if (text_insert.Text == "Insert Text")
                text_insert.Text = string.Empty;
        }

        private void BtnPenClick(object sender, EventArgs e) { usingPen = true; }
        private void BtnInsertClick(object sender, EventArgs e)
        {
            usingPen = false;
            DropSizeSelectedIndexChanged(sender, e);
        }

        private void DropSizeSelectedIndexChanged(object sender, EventArgs e)
        {
            penSize = Convert.ToInt16(sizes[drop_size.Text]);
            font = new Font("Arial", penSize + 12);
        }

        private void DropColorSelectedIndexChanged(object sender, EventArgs e)
        {
            penColor = Color.FromName(dropColor.Text);
            brush = new SolidBrush(penColor);
        }
        #endregion

        #region Menu
        private void UndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Image = new Bitmap(undo[undo.Count - 2]);
                undo.RemoveAt(undo.Count - 1);
                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ResetToolStripMenuItemClick(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(undo[0]);
        }

        private void CopyToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            Clipboard.SetImage(pictureBox.Image);
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!usingPen)
            {
                g = Graphics.FromImage(pictureBox.Image);

                if (checkDropShadow.Checked)
                    g.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), pointY.X + 1, pointY.Y + 1);

                g.DrawString(text_insert.Text, font, brush, pointY.X, pointY.Y);
            }

            pointX = e.Location;
            pen = new Pen(penColor, penSize);
        }

        private void SaveAsToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            dialog.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(
                    dialog.FileName,
                    GlobalFunctions.ExtensionToImageFormat(Path.GetExtension(dialog.FileName).Substring(1))
                );
            }
        }
        #endregion

        #region Mouse Movements & Paint
        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            pointY = e.Location;
            pictureBox.Invalidate();

            if (!(e.Button == MouseButtons.Left && usingPen))
                return;

            // Actually drawing on the image
            try
            {
                g = Graphics.FromImage(pictureBox.Image);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(
                    new SolidBrush(penColor),
                    pointY.X - Convert.ToInt32(penSize / 2),
                    pointY.Y - Convert.ToInt32(penSize / 2),
                    penSize, penSize
                );
                g.DrawLine(pen, pointX, pointY);
                pointX = e.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PictureBoxMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            undo.Add(new Bitmap(pictureBox.Image));

            if (undo.Count > 9)
                undo.RemoveAt(1);

            GC.Collect();
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            try
            {
                // Our hover preview
                if (usingPen)
                    e.Graphics.FillEllipse(
                        new SolidBrush(penColor),
                        pointY.X - Convert.ToInt32(penSize / 2),
                        pointY.Y - Convert.ToInt32(penSize / 2),
                        penSize, penSize
                    );
                else
                {
                    if (checkDropShadow.Checked)
                        e.Graphics.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), pointY.X + 1, pointY.Y + 1);

                    e.Graphics.DrawString(text_insert.Text, font, brush, pointY.X, pointY.Y);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            if (key == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;

            return base.ProcessCmdKey(ref msg, key);
        }
    }
}
