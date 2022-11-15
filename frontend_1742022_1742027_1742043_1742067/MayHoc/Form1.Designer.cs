namespace MayHoc
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtNoiLuu = new System.Windows.Forms.Button();
            this.txtPathSave = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pic_Paint = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ptcChonAnh = new System.Windows.Forms.PictureBox();
            this.btnNhanDang = new System.Windows.Forms.Button();
            this.lbThongBao = new System.Windows.Forms.ListBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnCaiDat = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Paint)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptcChonAnh)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoiLuu
            // 
            this.txtNoiLuu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoiLuu.Location = new System.Drawing.Point(416, 27);
            this.txtNoiLuu.Name = "txtNoiLuu";
            this.txtNoiLuu.Size = new System.Drawing.Size(87, 38);
            this.txtNoiLuu.TabIndex = 1;
            this.txtNoiLuu.Text = "Browse....";
            this.txtNoiLuu.UseVisualStyleBackColor = true;
            this.txtNoiLuu.Click += new System.EventHandler(this.txtNoiLuu_Click);
            // 
            // txtPathSave
            // 
            this.txtPathSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPathSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathSave.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPathSave.Location = new System.Drawing.Point(22, 33);
            this.txtPathSave.Multiline = true;
            this.txtPathSave.Name = "txtPathSave";
            this.txtPathSave.ReadOnly = true;
            this.txtPathSave.Size = new System.Drawing.Size(354, 30);
            this.txtPathSave.TabIndex = 2;
            this.txtPathSave.Text = "Nơi lưu ảnh nhận dạng";
            this.txtPathSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPathSave.Enter += new System.EventHandler(this.txtPathSave_Enter);
            this.txtPathSave.Leave += new System.EventHandler(this.txtPathSave_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.pic_Paint);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vẽ số cần nhận dạng";
            // 
            // pic_Paint
            // 
            this.pic_Paint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_Paint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_Paint.Image = global::MayHoc.Properties.Resources.Paint_Windows_7_icon;
            this.pic_Paint.Location = new System.Drawing.Point(3, 18);
            this.pic_Paint.Name = "pic_Paint";
            this.pic_Paint.Size = new System.Drawing.Size(173, 79);
            this.pic_Paint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Paint.TabIndex = 3;
            this.pic_Paint.TabStop = false;
            this.pic_Paint.Click += new System.EventHandler(this.pic_Paint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txtPathSave);
            this.groupBox2.Controls.Add(this.txtNoiLuu);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(263, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn nơi  Save";
            // 
            // ptcChonAnh
            // 
            this.ptcChonAnh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptcChonAnh.Location = new System.Drawing.Point(12, 12);
            this.ptcChonAnh.Name = "ptcChonAnh";
            this.ptcChonAnh.Size = new System.Drawing.Size(760, 300);
            this.ptcChonAnh.TabIndex = 0;
            this.ptcChonAnh.TabStop = false;
            this.ptcChonAnh.Click += new System.EventHandler(this.ptcChonAnh_Click);
            // 
            // btnNhanDang
            // 
            this.btnNhanDang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNhanDang.Location = new System.Drawing.Point(22, 28);
            this.btnNhanDang.Name = "btnNhanDang";
            this.btnNhanDang.Size = new System.Drawing.Size(87, 38);
            this.btnNhanDang.TabIndex = 10;
            this.btnNhanDang.Text = "Nhận dạng";
            this.btnNhanDang.UseVisualStyleBackColor = true;
            this.btnNhanDang.Click += new System.EventHandler(this.btnNhanDang_Click);
            // 
            // lbThongBao
            // 
            this.lbThongBao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbThongBao.FormattingEnabled = true;
            this.lbThongBao.Location = new System.Drawing.Point(12, 424);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(176, 121);
            this.lbThongBao.TabIndex = 11;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Location = new System.Drawing.Point(416, 28);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(87, 38);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.Location = new System.Drawing.Point(289, 28);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(87, 38);
            this.btnCaiDat.TabIndex = 15;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.UseVisualStyleBackColor = true;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.btnNhanDang);
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnCaiDat);
            this.groupBox3.Location = new System.Drawing.Point(263, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 89);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ptcChonAnh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhận dạng số viết tay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Paint)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptcChonAnh)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptcChonAnh;
        private System.Windows.Forms.Button txtNoiLuu;
        private System.Windows.Forms.TextBox txtPathSave;
        private System.Windows.Forms.PictureBox pic_Paint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNhanDang;
        private System.Windows.Forms.ListBox lbThongBao;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCaiDat;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

