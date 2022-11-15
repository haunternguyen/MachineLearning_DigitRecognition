using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayHoc
{
    public partial class Frm_Paint : Form
    {

        public Frm_Paint()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
           
        }
        private Point? _Previous = null;
        private Pen _Pen = new Pen(Color.Black, 5);
        private Pen _Pen1 = new Pen(Color.White, 15);
        int? pos = null;
        int TrangThai = 0;
        public string nameImage = null;
        public string pathImage;
        public string pathHienHanh;
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {

                MessageBox.Show("Ảnh trống!");
            }
            else
            {
                //FolderBrowserDialog fd = new FolderBrowserDialog();
                //fd.RootFolder = Environment.SpecialFolder.Desktop;
                //fd.ShowNewFolderButton = false;
                //if (fd.ShowDialog() == DialogResult.OK)
                //{
                //    pathImage = fd.SelectedPath;
                //    Frm_NameImage frm_NameImage = new Frm_NameImage();
                //    frm_NameImage.ShowDialog();
                //    nameImage = frm_NameImage.nameImage;
                //    pathHienHanh = pathImage + "\\";
                //    pictureBox1.Image.Save(pathHienHanh  + nameImage + ".png");
                //}

                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = Environment.SpecialFolder.Desktop;
                sfd.Filter = "Images|*.jpg;*.bmp;*.png";
                ImageFormat format = ImageFormat.Jpeg;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    pathHienHanh = sfd.FileName;
                    pictureBox1.Image.Save(sfd.FileName, format);
                }
                this.Close();
                //
               
            }
          
        }
        //Tạo chuột
        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        Bitmap img;
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        //
        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }
        //
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(TrangThai==0)
            {
                _Previous = e.Location;
                pictureBox1_MouseMove(sender, e);
            }
            else
            {
                this.img = new Bitmap("anh/gom.png");
                this.Cursor = Frm_Paint.CreateCursor(img, 3, 3);
                _Previous = e.Location;
                pictureBox1_MouseMove(sender, e);

            }
            

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap bmp;
            if (_Previous != null)
            {
                if (pictureBox1.Image == null)
                {
                     bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    pictureBox1.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    if(TrangThai==0)
                    {
                        g.DrawLine(_Pen, _Previous.Value, e.Location);

                    }
                    else
                    {

                        Brush m_ClearBrush = new SolidBrush(Color.FromArgb(0, Color.White));
                        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        g.DrawLine(_Pen1, _Previous.Value, e.Location);

                    }
                   
                }
                pictureBox1.Invalidate();
                _Previous = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(TrangThai==0)
            {
                _Previous = null;
            }
            else
            {

                Cursor cur = Cursors.Arrow;
                this.Cursor = cur;
                 _Previous = null;
                TrangThai = 0;
                
            }
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            pictureBox1.Image=null;
            
        }

        private void Frm_Paint_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TrangThai = 1;
        }
    }
}
