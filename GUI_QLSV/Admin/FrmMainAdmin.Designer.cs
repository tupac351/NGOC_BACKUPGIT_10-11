namespace GUI_QLSV.Admin
{
    partial class FrmMainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainAdmin));
            this.lbChao = new System.Windows.Forms.Label();
            this.btThoat = new System.Windows.Forms.Button();
            this.pnHienThi = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btSinhVien = new System.Windows.Forms.ToolStripButton();
            this.btHocKy = new System.Windows.Forms.ToolStripButton();
            this.btMonHoc = new System.Windows.Forms.ToolStripButton();
            this.btHocPhan = new System.Windows.Forms.ToolStripButton();
            this.btDKHP = new System.Windows.Forms.ToolStripButton();
            this.btDiem = new System.Windows.Forms.ToolStripButton();
            this.btTKB = new System.Windows.Forms.ToolStripButton();
            this.btKhoa = new System.Windows.Forms.ToolStripButton();
            this.btNganhDaoTao = new System.Windows.Forms.ToolStripButton();
            this.btHeDaoTao = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbChao
            // 
            this.lbChao.AutoSize = true;
            this.lbChao.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbChao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbChao.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChao.Location = new System.Drawing.Point(878, -114);
            this.lbChao.Margin = new System.Windows.Forms.Padding(0);
            this.lbChao.Name = "lbChao";
            this.lbChao.Size = new System.Drawing.Size(0, 46);
            this.lbChao.TabIndex = 15;
            // 
            // btThoat
            // 
            this.btThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btThoat.BackColor = System.Drawing.Color.LightSlateGray;
            this.btThoat.Image = ((System.Drawing.Image)(resources.GetObject("btThoat.Image")));
            this.btThoat.Location = new System.Drawing.Point(35, 1046);
            this.btThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(259, 8);
            this.btThoat.TabIndex = 10;
            this.btThoat.Text = "Đăng Xuất";
            this.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btThoat.UseVisualStyleBackColor = false;
            // 
            // pnHienThi
            // 
            this.pnHienThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnHienThi.Location = new System.Drawing.Point(12, 69);
            this.pnHienThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnHienThi.Name = "pnHienThi";
            this.pnHienThi.Size = new System.Drawing.Size(1405, 763);
            this.pnHienThi.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btSinhVien,
            this.btHocKy,
            this.btMonHoc,
            this.btHocPhan,
            this.btDKHP,
            this.btDiem,
            this.btTKB,
            this.btKhoa,
            this.btNganhDaoTao,
            this.btHeDaoTao});
            this.toolStrip1.Location = new System.Drawing.Point(12, 7);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1409, 58);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btSinhVien
            // 
            this.btSinhVien.Image = ((System.Drawing.Image)(resources.GetObject("btSinhVien.Image")));
            this.btSinhVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSinhVien.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btSinhVien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSinhVien.Name = "btSinhVien";
            this.btSinhVien.Size = new System.Drawing.Size(106, 55);
            this.btSinhVien.Text = "Sinh Viên";
            this.btSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSinhVien.Click += new System.EventHandler(this.btSinhVien_Click);
            // 
            // btHocKy
            // 
            this.btHocKy.Image = ((System.Drawing.Image)(resources.GetObject("btHocKy.Image")));
            this.btHocKy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btHocKy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHocKy.Name = "btHocKy";
            this.btHocKy.Size = new System.Drawing.Size(91, 55);
            this.btHocKy.Text = "Học Kỳ";
            this.btHocKy.Click += new System.EventHandler(this.btHocKy_Click);
            // 
            // btMonHoc
            // 
            this.btMonHoc.Image = ((System.Drawing.Image)(resources.GetObject("btMonHoc.Image")));
            this.btMonHoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btMonHoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btMonHoc.Name = "btMonHoc";
            this.btMonHoc.Size = new System.Drawing.Size(106, 55);
            this.btMonHoc.Text = "Môn Học";
            this.btMonHoc.Click += new System.EventHandler(this.btMonHoc_Click);
            // 
            // btHocPhan
            // 
            this.btHocPhan.Image = ((System.Drawing.Image)(resources.GetObject("btHocPhan.Image")));
            this.btHocPhan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btHocPhan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHocPhan.Name = "btHocPhan";
            this.btHocPhan.Size = new System.Drawing.Size(108, 55);
            this.btHocPhan.Text = "Học Phần";
            this.btHocPhan.Click += new System.EventHandler(this.btHocPhan_Click);
            // 
            // btDKHP
            // 
            this.btDKHP.Image = ((System.Drawing.Image)(resources.GetObject("btDKHP.Image")));
            this.btDKHP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btDKHP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDKHP.Name = "btDKHP";
            this.btDKHP.Size = new System.Drawing.Size(167, 55);
            this.btDKHP.Text = "Đăng Ký Học Phần";
            this.btDKHP.Click += new System.EventHandler(this.btDKHP_Click);
            // 
            // btDiem
            // 
            this.btDiem.Image = ((System.Drawing.Image)(resources.GetObject("btDiem.Image")));
            this.btDiem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btDiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDiem.Name = "btDiem";
            this.btDiem.Size = new System.Drawing.Size(81, 55);
            this.btDiem.Text = "Điểm";
            this.btDiem.Click += new System.EventHandler(this.btDiem_Click);
            // 
            // btTKB
            // 
            this.btTKB.Image = ((System.Drawing.Image)(resources.GetObject("btTKB.Image")));
            this.btTKB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btTKB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btTKB.Name = "btTKB";
            this.btTKB.Size = new System.Drawing.Size(71, 55);
            this.btTKB.Text = "TKB";
            this.btTKB.Click += new System.EventHandler(this.btTKB_Click);
            // 
            // btKhoa
            // 
            this.btKhoa.Image = ((System.Drawing.Image)(resources.GetObject("btKhoa.Image")));
            this.btKhoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btKhoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btKhoa.Name = "btKhoa";
            this.btKhoa.Size = new System.Drawing.Size(79, 55);
            this.btKhoa.Text = "Khoa";
            // 
            // btNganhDaoTao
            // 
            this.btNganhDaoTao.Image = ((System.Drawing.Image)(resources.GetObject("btNganhDaoTao.Image")));
            this.btNganhDaoTao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btNganhDaoTao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btNganhDaoTao.Name = "btNganhDaoTao";
            this.btNganhDaoTao.Size = new System.Drawing.Size(150, 55);
            this.btNganhDaoTao.Text = "Ngành Đào Tạo";
            // 
            // btHeDaoTao
            // 
            this.btHeDaoTao.Image = ((System.Drawing.Image)(resources.GetObject("btHeDaoTao.Image")));
            this.btHeDaoTao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btHeDaoTao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHeDaoTao.Name = "btHeDaoTao";
            this.btHeDaoTao.Size = new System.Drawing.Size(174, 55);
            this.btHeDaoTao.Text = "Báo cáo - Thống kê";
            this.btHeDaoTao.Click += new System.EventHandler(this.btHeDaoTao_Click);
            // 
            // FrmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 843);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbChao);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.pnHienThi);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1069, 569);
            this.Name = "FrmMainAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbChao;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Panel pnHienThi;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btSinhVien;
        private System.Windows.Forms.ToolStripButton btDKHP;
        private System.Windows.Forms.ToolStripButton btDiem;
        private System.Windows.Forms.ToolStripButton btMonHoc;
        private System.Windows.Forms.ToolStripButton btHocKy;
        private System.Windows.Forms.ToolStripButton btTKB;
        private System.Windows.Forms.ToolStripButton btHocPhan;
        private System.Windows.Forms.ToolStripButton btKhoa;
        private System.Windows.Forms.ToolStripButton btNganhDaoTao;
        private System.Windows.Forms.ToolStripButton btHeDaoTao;
    }
}