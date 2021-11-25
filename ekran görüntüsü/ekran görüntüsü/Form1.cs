using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;


namespace ekran_görüntüsü
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;

        }
        private Bitmap ekrangoruntu()
        {
            Bitmap ekran = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics gfk = Graphics.FromImage(ekran);
            gfk.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            return ekran;
        }
        Bitmap pic;//kodbankam kodzilla

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Start();
            timer1.Enabled = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            string kayit = save.FileName;
            Directory.CreateDirectory(@"c:\ekranfotolarım");
            pic.Save(kayit+".jpeg", ImageFormat.Jpeg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mevcut Ekran Çözünürlüğünüz"+ Screen.PrimaryScreen.Bounds.Width + "X" + Screen.PrimaryScreen.Bounds.Height.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pic = ekrangoruntu();
            pictureBox1.Image = ekrangoruntu();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Show();
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();   
            }
        }
    }
}
