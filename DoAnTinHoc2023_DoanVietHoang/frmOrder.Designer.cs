namespace DoAnTinHoc2023_DoanVietHoang
{
    partial class frmOrder
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
            this.panelBan = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.lblthem = new System.Windows.Forms.Label();
            this.nmSLDoAn = new System.Windows.Forms.NumericUpDown();
            this.nmSLNuoc = new System.Windows.Forms.NumericUpDown();
            this.cboDoAn = new System.Windows.Forms.ComboBox();
            this.cboNuoc = new System.Windows.Forms.ComboBox();
            this.panelBill = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnXoaBill = new System.Windows.Forms.Button();
            this.txtBanDangChon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaGG = new System.Windows.Forms.ComboBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSLDoAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSLNuoc)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBan
            // 
            this.panelBan.Location = new System.Drawing.Point(5, 8);
            this.panelBan.Name = "panelBan";
            this.panelBan.Size = new System.Drawing.Size(656, 762);
            this.panelBan.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btnThemMon);
            this.panel4.Controls.Add(this.lblthem);
            this.panel4.Controls.Add(this.nmSLDoAn);
            this.panel4.Controls.Add(this.nmSLNuoc);
            this.panel4.Controls.Add(this.cboDoAn);
            this.panel4.Controls.Add(this.cboNuoc);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(667, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(765, 151);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Chọn đồ ăn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chọn nước:";
            // 
            // btnThemMon
            // 
            this.btnThemMon.BackColor = System.Drawing.Color.PeachPuff;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThemMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemMon.Location = new System.Drawing.Point(616, 68);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(146, 75);
            this.btnThemMon.TabIndex = 4;
            this.btnThemMon.Text = "Thêm Món";
            this.btnThemMon.UseVisualStyleBackColor = false;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // lblthem
            // 
            this.lblthem.AutoSize = true;
            this.lblthem.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblthem.Location = new System.Drawing.Point(299, 12);
            this.lblthem.Name = "lblthem";
            this.lblthem.Size = new System.Drawing.Size(153, 33);
            this.lblthem.TabIndex = 3;
            this.lblthem.Text = "Chọn Món";
            // 
            // nmSLDoAn
            // 
            this.nmSLDoAn.Location = new System.Drawing.Point(511, 115);
            this.nmSLDoAn.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSLDoAn.Name = "nmSLDoAn";
            this.nmSLDoAn.Size = new System.Drawing.Size(86, 30);
            this.nmSLDoAn.TabIndex = 2;
            this.nmSLDoAn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmSLNuoc
            // 
            this.nmSLNuoc.Location = new System.Drawing.Point(509, 69);
            this.nmSLNuoc.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmSLNuoc.Name = "nmSLNuoc";
            this.nmSLNuoc.Size = new System.Drawing.Size(88, 30);
            this.nmSLNuoc.TabIndex = 1;
            this.nmSLNuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboDoAn
            // 
            this.cboDoAn.FormattingEnabled = true;
            this.cboDoAn.ItemHeight = 25;
            this.cboDoAn.Location = new System.Drawing.Point(178, 114);
            this.cboDoAn.Name = "cboDoAn";
            this.cboDoAn.Size = new System.Drawing.Size(315, 33);
            this.cboDoAn.TabIndex = 0;
            // 
            // cboNuoc
            // 
            this.cboNuoc.FormattingEnabled = true;
            this.cboNuoc.ItemHeight = 25;
            this.cboNuoc.Location = new System.Drawing.Point(178, 68);
            this.cboNuoc.Name = "cboNuoc";
            this.cboNuoc.Size = new System.Drawing.Size(315, 33);
            this.cboNuoc.TabIndex = 0;
            // 
            // panelBill
            // 
            this.panelBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBill.Location = new System.Drawing.Point(667, 162);
            this.panelBill.Name = "panelBill";
            this.panelBill.Size = new System.Drawing.Size(762, 411);
            this.panelBill.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnXoaBill);
            this.panel6.Controls.Add(this.txtBanDangChon);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtTongTien);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.cboMaGG);
            this.panel6.Controls.Add(this.btnThanhToan);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(664, 579);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(765, 191);
            this.panel6.TabIndex = 6;
            // 
            // btnXoaBill
            // 
            this.btnXoaBill.BackColor = System.Drawing.Color.PeachPuff;
            this.btnXoaBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBill.Location = new System.Drawing.Point(616, 10);
            this.btnXoaBill.Name = "btnXoaBill";
            this.btnXoaBill.Size = new System.Drawing.Size(146, 72);
            this.btnXoaBill.TabIndex = 0;
            this.btnXoaBill.Text = "Xóa Bill";
            this.btnXoaBill.UseVisualStyleBackColor = false;
            this.btnXoaBill.Click += new System.EventHandler(this.btnXoaBill_Click);
            // 
            // txtBanDangChon
            // 
            this.txtBanDangChon.Location = new System.Drawing.Point(78, 68);
            this.txtBanDangChon.Name = "txtBanDangChon";
            this.txtBanDangChon.Size = new System.Drawing.Size(67, 30);
            this.txtBanDangChon.TabIndex = 10;
            this.txtBanDangChon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 75);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bàn \r\nđang\r\nchọn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tổng tiền :";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.OrangeRed;
            this.txtTongTien.Location = new System.Drawing.Point(291, 41);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(286, 30);
            this.txtTongTien.TabIndex = 8;
            this.txtTongTien.TextChanged += new System.EventHandler(this.txtTongTien_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã giảm giá";
            // 
            // cboMaGG
            // 
            this.cboMaGG.FormattingEnabled = true;
            this.cboMaGG.Items.AddRange(new object[] {
            "",
            "5%",
            "10%",
            "20%",
            "30%"});
            this.cboMaGG.Location = new System.Drawing.Point(291, 93);
            this.cboMaGG.Name = "cboMaGG";
            this.cboMaGG.Size = new System.Drawing.Size(286, 33);
            this.cboMaGG.TabIndex = 0;
            this.cboMaGG.SelectedIndexChanged += new System.EventHandler(this.cboMaGG_SelectedIndexChanged);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.PeachPuff;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(615, 89);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(146, 78);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = " Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 778);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panelBill);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelBan);
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSLDoAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSLNuoc)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Label lblthem;
        private System.Windows.Forms.NumericUpDown nmSLDoAn;
        private System.Windows.Forms.NumericUpDown nmSLNuoc;
        private System.Windows.Forms.ComboBox cboDoAn;
        private System.Windows.Forms.ComboBox cboNuoc;
        private System.Windows.Forms.Panel panelBill;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaGG;
        private System.Windows.Forms.Button btnThanhToan;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBanDangChon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXoaBill;
    }
}