namespace GUI_QLSV
{
    partial class FrmBCTKe
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCanhBaoHocVu = new System.Windows.Forms.Button();
            this.btnRotMon = new System.Windows.Forms.Button();
            this.btnCamThi = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnGuiThongBao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.lblTieuDeBang = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RosyBrown;
            this.label1.Location = new System.Drawing.Point(13, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO THỐNG KÊ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(482, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại báo cáo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(923, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Học kỳ";
            // 
            // cbLoaiBaoCao
            // 
            this.cbLoaiBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiBaoCao.FormattingEnabled = true;
            this.cbLoaiBaoCao.Location = new System.Drawing.Point(636, 74);
            this.cbLoaiBaoCao.Name = "cbLoaiBaoCao";
            this.cbLoaiBaoCao.Size = new System.Drawing.Size(207, 28);
            this.cbLoaiBaoCao.TabIndex = 3;
            // 
            // cbHocKy
            // 
            this.cbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(1042, 70);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(121, 28);
            this.cbHocKy.TabIndex = 4;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.Location = new System.Drawing.Point(1042, 127);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(159, 34);
            this.btnXemBaoCao.TabIndex = 5;
            this.btnXemBaoCao.Text = "Xem Báo Cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.btnXemBaoCao);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.cbHocKy);
            this.pnlHeader.Controls.Add(this.cbLoaiBaoCao);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1220, 181);
            this.pnlHeader.TabIndex = 6;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.label4);
            this.pnlLeft.Controls.Add(this.btnCanhBaoHocVu);
            this.pnlLeft.Controls.Add(this.btnRotMon);
            this.pnlLeft.Controls.Add(this.btnCamThi);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 181);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(290, 453);
            this.pnlLeft.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(34, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "DANH SÁCH BÁO CÁO";
            // 
            // btnCanhBaoHocVu
            // 
            this.btnCanhBaoHocVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanhBaoHocVu.Location = new System.Drawing.Point(38, 312);
            this.btnCanhBaoHocVu.Name = "btnCanhBaoHocVu";
            this.btnCanhBaoHocVu.Size = new System.Drawing.Size(215, 38);
            this.btnCanhBaoHocVu.TabIndex = 2;
            this.btnCanhBaoHocVu.Text = "Sinh viên cảnh báo học vụ";
            this.btnCanhBaoHocVu.UseVisualStyleBackColor = true;
            this.btnCanhBaoHocVu.Click += new System.EventHandler(this.btnCanhBaoHocVu_Click);
            // 
            // btnRotMon
            // 
            this.btnRotMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotMon.Location = new System.Drawing.Point(38, 199);
            this.btnRotMon.Name = "btnRotMon";
            this.btnRotMon.Size = new System.Drawing.Size(215, 40);
            this.btnRotMon.TabIndex = 1;
            this.btnRotMon.Text = "Sinh viên rớt môn";
            this.btnRotMon.UseVisualStyleBackColor = true;
            this.btnRotMon.Click += new System.EventHandler(this.btnRotMon_Click);
            // 
            // btnCamThi
            // 
            this.btnCamThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamThi.Location = new System.Drawing.Point(38, 91);
            this.btnCamThi.Name = "btnCamThi";
            this.btnCamThi.Size = new System.Drawing.Size(215, 44);
            this.btnCamThi.TabIndex = 0;
            this.btnCamThi.Text = "Sinh viên bị cấm thi";
            this.btnCamThi.UseVisualStyleBackColor = true;
            this.btnCamThi.Click += new System.EventHandler(this.btnCamThi_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnInBaoCao);
            this.pnlContent.Controls.Add(this.btnGuiThongBao);
            this.pnlContent.Controls.Add(this.btnXuatExcel);
            this.pnlContent.Controls.Add(this.dgvBaoCao);
            this.pnlContent.Controls.Add(this.lblTongSo);
            this.pnlContent.Controls.Add(this.lblTieuDeBang);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(290, 181);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(930, 453);
            this.pnlContent.TabIndex = 8;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnInBaoCao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInBaoCao.Location = new System.Drawing.Point(765, 394);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(90, 38);
            this.btnInBaoCao.TabIndex = 5;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnGuiThongBao
            // 
            this.btnGuiThongBao.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGuiThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiThongBao.Location = new System.Drawing.Point(605, 394);
            this.btnGuiThongBao.Name = "btnGuiThongBao";
            this.btnGuiThongBao.Size = new System.Drawing.Size(125, 38);
            this.btnGuiThongBao.TabIndex = 4;
            this.btnGuiThongBao.Text = "Gửi thông báo";
            this.btnGuiThongBao.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnXuatExcel.Location = new System.Drawing.Point(459, 394);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(112, 38);
            this.btnXuatExcel.TabIndex = 3;
            this.btnXuatExcel.Text = "Xuất EXCEL";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(3, 45);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(924, 331);
            this.dgvBaoCao.TabIndex = 2;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSo.Location = new System.Drawing.Point(701, 20);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(172, 22);
            this.lblTongSo.TabIndex = 1;
            this.lblTongSo.Text = "Tổng số: 0 sinh viên";
            // 
            // lblTieuDeBang
            // 
            this.lblTieuDeBang.AutoSize = true;
            this.lblTieuDeBang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeBang.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTieuDeBang.Location = new System.Drawing.Point(15, 17);
            this.lblTieuDeBang.Name = "lblTieuDeBang";
            this.lblTieuDeBang.Size = new System.Drawing.Size(374, 25);
            this.lblTieuDeBang.TabIndex = 0;
            this.lblTieuDeBang.Text = "DANH SÁCH SINH VIÊN BỊ CẤM THI";
            // 
            // FrmBCTKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 634);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmBCTKe";
            this.Text = "FrmBCTKe";
            this.Load += new System.EventHandler(this.FrmBCTKe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiBaoCao;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCanhBaoHocVu;
        private System.Windows.Forms.Button btnRotMon;
        private System.Windows.Forms.Button btnCamThi;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Label lblTieuDeBang;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Button btnGuiThongBao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvBaoCao;
    }
}