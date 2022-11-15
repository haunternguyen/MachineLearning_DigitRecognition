using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayHoc
{
    public partial class Frm_NameImage : Form
    {
        public Frm_NameImage()
        {
            InitializeComponent();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Name Image")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Name Image";
                txtName.ForeColor = Color.Silver;
            }
        }
        public string nameImage;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="")
            {
                MessageBox.Show("Tên ảnh trống.");
            }
            else
            {
                nameImage = txtName.Text;
                this.Close();

            }
        }

        private void Frm_NameImage_Load(object sender, EventArgs e)
        {
          
        }
    }
}
