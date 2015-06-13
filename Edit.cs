using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace hyperdesktop2
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
			
			font = font ?? new Font("Arial", 16) ;
			check_drop_shadow.Checked = dropShadow;
		}
		
		void Frm_EditLoad(object sender, EventArgs e)
		{
			// Set picture to the one we just recieved
			picture_box.SizeMode = PictureBoxSizeMode.AutoSize;
			picture_box.Image = new Bitmap(undo[0]);
            drop_color.Text = "Red";
			
			// Set control defaults
			drop_size.SelectedIndex = 1;
			drop_color.SelectedIndex = 1;
		}
		
		#region Controls
		void Btn_okayClick(object sender, EventArgs e)
		{
			Result = new Bitmap(picture_box.Image);
			this.Close();
			picture_box.Image = null;
			undo.Clear();
		}
		
		void Text_insertClick(object sender, EventArgs e)
		{
			if(text_insert.Text == "Insert Text")
				text_insert.Text = String.Empty;
		}
		
		void Btn_penClick(object sender, EventArgs e) { usingPen = true; }
		void Btn_insertClick(object sender, EventArgs e) {
			usingPen = false;
			Drop_sizeSelectedIndexChanged(sender, e);
		}
		
		void Drop_sizeSelectedIndexChanged(object sender, EventArgs e)
		{
			penSize = Convert.ToInt16(sizes[drop_size.Text]);
			font = new Font("Arial", penSize + 12);
		}
		
		void Drop_colorSelectedIndexChanged(object sender, EventArgs e)
		{
            penColor = Color.FromName(drop_color.Text);
            brush = new SolidBrush(penColor); 
		}
		#endregion
		
		#region Menu
		void UndoToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				picture_box.Image = new Bitmap(undo[undo.Count - 2]);
				undo.RemoveAt(undo.Count - 1);
				GC.Collect();
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		
		void ResetToolStripMenuItemClick(object sender, EventArgs e)
		{
			picture_box.Image = new Bitmap(undo[0]);
		}
		
		void CopyToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			Clipboard.SetImage(picture_box.Image);
		}
		
		void Picture_boxMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;
			
			if(!usingPen) {
				g = Graphics.FromImage(picture_box.Image);
				
				if(check_drop_shadow.Checked)
					g.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), pointY.X + 1, pointY.Y + 1);
			
				g.DrawString(text_insert.Text, font, brush, pointY.X, pointY.Y);
            }
			
			pointX = e.Location;
			pen = new Pen(penColor, penSize);	
		}
		
		void SaveAsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			var dialog = new SaveFileDialog();
			dialog.FileName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
			dialog.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|All Files (*.*)|*.*"; 
			
			if(dialog.ShowDialog() == DialogResult.OK) {
				picture_box.Image.Save(
					dialog.FileName,
					GlobalFunctions.ExtensionToImageFormat(Path.GetExtension(dialog.FileName).Substring(1))
				);
			}			
		}
		#endregion
		
		#region Mouse Movements & Paint
		void Picture_boxMouseMove(object sender, MouseEventArgs e)
		{
			pointY = e.Location;
			picture_box.Invalidate();
			
			if (!(e.Button == MouseButtons.Left && usingPen))
				return;
			
			// Actually drawing on the image
			try {
				g = Graphics.FromImage(picture_box.Image);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(
					new SolidBrush(penColor),
					pointY.X - Convert.ToInt32(penSize / 2),
					pointY.Y - Convert.ToInt32(penSize / 2),
					penSize, penSize
				);
				g.DrawLine(pen, pointX, pointY);
        		pointX = e.Location;
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		
		void Picture_boxMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			undo.Add(new Bitmap(picture_box.Image));
			
			if(undo.Count > 9)
				undo.RemoveAt(1);
			
			GC.Collect();
		}
		
		void Picture_boxPaint(object sender, PaintEventArgs e)
		{
			try {
				// Our hover preview
				if(usingPen)
					e.Graphics.FillEllipse(
						new SolidBrush(penColor),
						pointY.X - Convert.ToInt32(penSize / 2),
						pointY.Y - Convert.ToInt32(penSize / 2),
						penSize, penSize
					);
				else {
					if(check_drop_shadow.Checked)
						e.Graphics.DrawString(text_insert.Text, font, new SolidBrush(Color.Black), pointY.X + 1, pointY.Y + 1);
					
					e.Graphics.DrawString(text_insert.Text, font, brush, pointY.X, pointY.Y);
				}
			} catch (Exception ex) {
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
