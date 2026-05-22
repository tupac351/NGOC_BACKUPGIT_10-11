namespace GUI_QLSV
{
    partial class FrmLichThi
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
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvLichThi = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỊCH THI CÁ NHÂN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Học Kỳ: ";
            // 
            // cbHocKy
            // 
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(165, 148);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(121, 24);
            this.cbHocKy.TabIndex = 2;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(506, 140);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem lịch thi";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvLichThi
            // 
            this.dgvLichThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichThi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLichThi.Location = new System.Drawing.Point(0, 270);
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.ReadOnly = true;
            this.dgvLichThi.RowHeadersWidth = 51;
            this.dgvLichThi.RowTemplate.Height = 24;
            this.dgvLichThi.Size = new System.Drawing.Size(954, 324);
            this.dgvLichThi.TabIndex = 4;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSo.Location = new System.Drawing.Point(46, 560);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(198, 25);
            this.lblTongSo.TabIndex = 5;
            this.lblTongSo.Text = " Tổng số: 0 môn thi";
            // 
            // FrmLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 594);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.dgvLichThi);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cbHocKy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmLichThi";
            this.Text = "FrmLichThi";
            this.Load += new System.EventHandler(this.FrmLichThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvLichThi;
        private System.Windows.Forms.Label lblTongSo;
    }
}