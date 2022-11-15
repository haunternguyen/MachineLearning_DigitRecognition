using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayHoc
{
    public partial class Form1 : Form
    {
        string DuongDanPyThon = @"E:\ProgramData\Anaconda3\python.exe";

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        string pathSelect_Image = @"anh\3.jpg";
        public string pathSave_Image;
        private void ptcChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "*.jpg,*.png,*.gif|*.jpg;*.png;*.gif";
            o.Multiselect = false;
            o.Title = "Open Image";
            if (o.ShowDialog() == DialogResult.OK)
            {
                pathSelect_Image = o.FileName;
                ptcChonAnh.Image = Image.FromStream(loadanh(o.FileName));
            }


        }
        private MemoryStream loadanh(string strdd)
        {
            byte[] byteHA = File.ReadAllBytes(strdd);
            MemoryStream ms = new MemoryStream(byteHA);
            return ms;
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            if (pathSelect_Image == @"anh\abc.png")
            {
                ptcChonAnh.Image = Image.FromStream(loadanh(pathSelect_Image));
            }
            else
            {
                ptcChonAnh.Image = Image.FromStream(loadanh(pathSelect_Image));
            }

        }

        private void txtNoiLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
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
                txtPathSave.Text = sfd.FileName;
            }
        }



        private void pic_Paint_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Paint frm_Paint = new Frm_Paint();
                frm_Paint.ShowDialog();
                if (frm_Paint.pathHienHanh != null)
                {
                    pathSelect_Image = frm_Paint.pathHienHanh;
                    Form1_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_Ok_Click(object sender, EventArgs e)
        {
            if (pathSelect_Image == "anh\\abc.png")
            {
                MessageBox.Show("Chọn ảnh cần nhận dạng.");
            }
            else if (txtPathSave.Text == "Nơi lưu ảnh nhận dạng")
            {
                MessageBox.Show("Chọn nơi cần lưu ảnh nhận dạng.");
            }
            else
            {
                //Cái cần viết ở đây.

            }
        }

        private void txtPathSave_Enter(object sender, EventArgs e)
        {
            if (txtPathSave.Text == "Nơi lưu ảnh nhận dạng")
            {
                txtPathSave.Text = "";
                txtPathSave.ForeColor = Color.Black;
            }
        }

        private void txtPathSave_Leave(object sender, EventArgs e)
        {
            if (txtPathSave.Text == "")
            {
                txtPathSave.Text = "Nơi lưu ảnh nhận dạng";
                txtPathSave.ForeColor = Color.Silver;
            }
        }

        // Call python
        private void run_cmd()
        {
            if (pathSelect_Image == "anh\\abc.png")
            {
                MessageBox.Show("Chọn ảnh cần nhận dạng.");
            }
            else if (txtPathSave.Text == "Nơi lưu ảnh nhận dạng")
            {
                MessageBox.Show("Chọn nơi cần lưu ảnh nhận dạng.");
            }
            else
            {
                //Cái cần viết ở đây.
                lbThongBao.Invoke(new Action(() => { lbThongBao.Items.Add("Compiling model!"); lbThongBao.Items.Add("Wait ..."); }));
                string fileName = @"python\SoVietTay.py";

                Process p = new Process();
                string s = string.Format(@"python\SoVietTay.py --DuongVao {0} --DuongRa {1}", pathSelect_Image, txtPathSave.Text);
                // string s = string.Format("python\\SoVietTay.py --DuongVao {0} --DuongRa {1}", "D:/a.py", "D:/b.py");
                p.StartInfo = new ProcessStartInfo(DuongDanPyThon, fileName)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = s
                };

                char[] splitter = { '\r' };
                p.Start();
                using (StreamReader reader = p.StandardOutput)
                {
                    string[] output = reader.ReadToEnd().Split(splitter);

                    foreach (string s2 in output)
                    {
                        lbThongBao.Invoke(new Action(() => { lbThongBao.Items.Add(s2); }));
                    }
                }
                p.WaitForExit();
                lbThongBao.Invoke(new Action(() => { lbThongBao.Items.Add("Finished!"); }));

            }
        }

        private void btnNhanDang_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(run_cmd);
            t.Start();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Python files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                DuongDanPyThon = selectedFileName;
                //...
            }
        }
    }
}
