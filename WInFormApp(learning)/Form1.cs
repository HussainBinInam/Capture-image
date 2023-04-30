using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInFormApp_learning_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Task.Delay(3000);
            CaptureTheScreen();
            this.WindowState = FormWindowState.Normal;
        }
        private void  CaptureTheScreen ()
        {
            try
            {
                string savePath = @"D:\CSproject\c#\project\Tests\capture.jpg";
                Bitmap captureMap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureMap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                if (File.Exists(savePath)) { 
                    File.Delete(savePath);
                }
                captureMap.Save(savePath, ImageFormat.Jpeg);
                MessageBox.Show("Screen Captured!");

            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message)    ;
            }
        }
        public static DialogResult InputBox(string title, string prompt, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();
            form.Text = title;
            label.Text = prompt;
            btnOk.Text = "OK";
            btnCancel.Text = "Cancel";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(36, 36, 372, 13);
            textBox.SetBounds(36, 86, 700, 20);
            btnOk.SetBounds(228, 160, 160, 60);
            btnCancel.SetBounds(400, 160, 160, 60);
            label.AutoSize = true;
            form.ClientSize = new Size(796, 307);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Controls.AddRange(new Control[] { label, textBox, btnOk, btnCancel });
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;
            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;

        }

        private void lblHello_Click(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
