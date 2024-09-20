namespace DoAnTinHoc2023_DoanVietHoang
{
    partial class frmTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabTaiKhoanfrm = new System.Windows.Forms.TabControl();
            this.tabCapNhatTK = new System.Windows.Forms.TabPage();
            this.labelGhiChu = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtNhapLMKCN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMatKMCN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMatKCN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTenDNCN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTaiKhoan = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cboLoaiTK = new System.Windows.Forms.ComboBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenHienThi = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtTimTK = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnSuaTK = new System.Windows.Forms.Button();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.tabTaiKhoanfrm.SuspendLayout();
            this.tabCapNhatTK.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTaiKhoan.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel18.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTaiKhoanfrm
            // 
            this.tabTaiKhoanfrm.Controls.Add(this.tabCapNhatTK);
            this.tabTaiKhoanfrm.Controls.Add(this.tabTaiKhoan);
            this.tabTaiKhoanfrm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTaiKhoanfrm.Location = new System.Drawing.Point(0, 0);
            this.tabTaiKhoanfrm.Name = "tabTaiKhoanfrm";
            this.tabTaiKhoanfrm.SelectedIndex = 0;
            this.tabTaiKhoanfrm.Size = new System.Drawing.Size(1456, 757);
            this.tabTaiKhoanfrm.TabIndex = 0;
            this.tabTaiKhoanfrm.SelectedIndexChanged += new System.EventHandler(this.tabCapNhatTaiKhoan_SelectedIndexChanged);
            this.tabTaiKhoanfrm.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabTaiKhoanfrm_Selecting);
            // 
            // tabCapNhatTK
            // 
            this.tabCapNhatTK.Controls.Add(this.labelGhiChu);
            this.tabCapNhatTK.Controls.Add(this.btnCapNhat);
            this.tabCapNhatTK.Controls.Add(this.panel5);
            this.tabCapNhatTK.Controls.Add(this.panel4);
            this.tabCapNhatTK.Controls.Add(this.panel3);
            this.tabCapNhatTK.Controls.Add(this.panel1);
            this.tabCapNhatTK.Location = new System.Drawing.Point(4, 38);
            this.tabCapNhatTK.Name = "tabCapNhatTK";
            this.tabCapNhatTK.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapNhatTK.Size = new System.Drawing.Size(1448, 715);
            this.tabCapNhatTK.TabIndex = 0;
            this.tabCapNhatTK.Text = "Cập nhật tài khoản";
            this.tabCapNhatTK.UseVisualStyleBackColor = true;
            this.tabCapNhatTK.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // labelGhiChu
            // 
            this.labelGhiChu.AutoSize = true;
            this.labelGhiChu.Location = new System.Drawing.Point(606, 413);
            this.labelGhiChu.Name = "labelGhiChu";
            this.labelGhiChu.Size = new System.Drawing.Size(31, 29);
            this.labelGhiChu.TabIndex = 15;
            this.labelGhiChu.Text = "...";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhat.Location = new System.Drawing.Point(652, 456);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(138, 57);
            this.btnCapNhat.TabIndex = 13;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtNhapLMKCN);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(355, 344);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(705, 66);
            this.panel5.TabIndex = 12;
            // 
            // txtNhapLMKCN
            // 
            this.txtNhapLMKCN.Location = new System.Drawing.Point(255, 12);
            this.txtNhapLMKCN.Multiline = true;
            this.txtNhapLMKCN.Name = "txtNhapLMKCN";
            this.txtNhapLMKCN.Size = new System.Drawing.Size(408, 41);
            this.txtNhapLMKCN.TabIndex = 1;
            this.txtNhapLMKCN.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhập lại mật khẩu :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtMatKMCN);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(355, 259);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(705, 66);
            this.panel4.TabIndex = 11;
            // 
            // txtMatKMCN
            // 
            this.txtMatKMCN.Location = new System.Drawing.Point(255, 14);
            this.txtMatKMCN.Multiline = true;
            this.txtMatKMCN.Name = "txtMatKMCN";
            this.txtMatKMCN.Size = new System.Drawing.Size(408, 41);
            this.txtMatKMCN.TabIndex = 1;
            this.txtMatKMCN.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = " Mật khẩu mới :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMatKCN);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(355, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(705, 66);
            this.panel3.TabIndex = 10;
            // 
            // txtMatKCN
            // 
            this.txtMatKCN.Location = new System.Drawing.Point(255, 12);
            this.txtMatKCN.Multiline = true;
            this.txtMatKCN.Name = "txtMatKCN";
            this.txtMatKCN.Size = new System.Drawing.Size(408, 41);
            this.txtMatKCN.TabIndex = 1;
            this.txtMatKCN.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTenDNCN);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(355, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 66);
            this.panel1.TabIndex = 8;
            // 
            // txtTenDNCN
            // 
            this.txtTenDNCN.Location = new System.Drawing.Point(255, 13);
            this.txtTenDNCN.Multiline = true;
            this.txtTenDNCN.Name = "txtTenDNCN";
            this.txtTenDNCN.Size = new System.Drawing.Size(408, 41);
            this.txtTenDNCN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập :";
            // 
            // tabTaiKhoan
            // 
            this.tabTaiKhoan.Controls.Add(this.panel6);
            this.tabTaiKhoan.Controls.Add(this.panel7);
            this.tabTaiKhoan.Controls.Add(this.panel8);
            this.tabTaiKhoan.Controls.Add(this.panel18);
            this.tabTaiKhoan.Location = new System.Drawing.Point(4, 38);
            this.tabTaiKhoan.Name = "tabTaiKhoan";
            this.tabTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaiKhoan.Size = new System.Drawing.Size(1448, 715);
            this.tabTaiKhoan.TabIndex = 1;
            this.tabTaiKhoan.Text = "Danh sách tài khoản";
            this.tabTaiKhoan.UseVisualStyleBackColor = true;
            this.tabTaiKhoan.Click += new System.EventHandler(this.tabTaiKhoan_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvTaiKhoan);
            this.panel6.Location = new System.Drawing.Point(5, 103);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(946, 446);
            this.panel6.TabIndex = 13;
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(5, 3);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 62;
            this.dgvTaiKhoan.RowTemplate.Height = 28;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(938, 440);
            this.dgvTaiKhoan.TabIndex = 0;
            this.dgvTaiKhoan.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TenDangNhap";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên đăng nhập";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenHienThi";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên hiển thị";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "MatKhau";
            this.dataGridViewTextBoxColumn3.HeaderText = "Mật khẩu";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LoaiTaiKhoan";
            this.dataGridViewTextBoxColumn4.HeaderText = "Loại Tài khoản";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cboLoaiTK);
            this.panel7.Controls.Add(this.txtMatKhau);
            this.panel7.Controls.Add(this.txtTenHienThi);
            this.panel7.Controls.Add(this.txtTenDN);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(954, 103);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(467, 446);
            this.panel7.TabIndex = 12;
            // 
            // cboLoaiTK
            // 
            this.cboLoaiTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiTK.FormattingEnabled = true;
            this.cboLoaiTK.Items.AddRange(new object[] {
            "Nhân viên",
            "Quản lý"});
            this.cboLoaiTK.Location = new System.Drawing.Point(194, 201);
            this.cboLoaiTK.Name = "cboLoaiTK";
            this.cboLoaiTK.Size = new System.Drawing.Size(244, 33);
            this.cboLoaiTK.TabIndex = 2;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(194, 145);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(244, 30);
            this.txtMatKhau.TabIndex = 1;
            // 
            // txtTenHienThi
            // 
            this.txtTenHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenHienThi.Location = new System.Drawing.Point(194, 94);
            this.txtTenHienThi.Name = "txtTenHienThi";
            this.txtTenHienThi.Size = new System.Drawing.Size(244, 30);
            this.txtTenHienThi.TabIndex = 1;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.Location = new System.Drawing.Point(194, 40);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(244, 30);
            this.txtTenDN.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên hiển thị :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Loại tài khoản :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 26);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mật khẩu :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 26);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tên đăng nhập :";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtTimTK);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Location = new System.Drawing.Point(957, 7);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(464, 93);
            this.panel8.TabIndex = 11;
            // 
            // txtTimTK
            // 
            this.txtTimTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTK.Location = new System.Drawing.Point(15, 33);
            this.txtTimTK.Name = "txtTimTK";
            this.txtTimTK.Size = new System.Drawing.Size(248, 30);
            this.txtTimTK.TabIndex = 1;
            this.txtTimTK.TextChanged += new System.EventHandler(this.txtTimTK_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(282, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 87);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tìm tên hiển thị\r\n";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.btnXoaTK);
            this.panel18.Controls.Add(this.btnSuaTK);
            this.panel18.Controls.Add(this.btnThemTK);
            this.panel18.Location = new System.Drawing.Point(8, 7);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(945, 93);
            this.panel18.TabIndex = 10;
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.BackColor = System.Drawing.Color.PeachPuff;
            this.btnXoaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaTK.Location = new System.Drawing.Point(387, 10);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(128, 73);
            this.btnXoaTK.TabIndex = 0;
            this.btnXoaTK.Text = "Xóa";
            this.btnXoaTK.UseVisualStyleBackColor = false;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnSuaTK
            // 
            this.btnSuaTK.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSuaTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaTK.Location = new System.Drawing.Point(521, 10);
            this.btnSuaTK.Name = "btnSuaTK";
            this.btnSuaTK.Size = new System.Drawing.Size(128, 73);
            this.btnSuaTK.TabIndex = 0;
            this.btnSuaTK.Text = "Sửa";
            this.btnSuaTK.UseVisualStyleBackColor = false;
            this.btnSuaTK.Click += new System.EventHandler(this.btnSuaTK_Click);
            // 
            // btnThemTK
            // 
            this.btnThemTK.BackColor = System.Drawing.Color.PeachPuff;
            this.btnThemTK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTK.Location = new System.Drawing.Point(253, 10);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(128, 73);
            this.btnThemTK.TabIndex = 0;
            this.btnThemTK.Text = "Thêm";
            this.btnThemTK.UseVisualStyleBackColor = false;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 758);
            this.Controls.Add(this.tabTaiKhoanfrm);
            this.Name = "frmTaiKhoan";
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.tabTaiKhoanfrm.ResumeLayout(false);
            this.tabCapNhatTK.ResumeLayout(false);
            this.tabCapNhatTK.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabTaiKhoan.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTaiKhoanfrm;
        private System.Windows.Forms.TabPage tabCapNhatTK;
        private System.Windows.Forms.TabPage tabTaiKhoan;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtNhapLMKCN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtMatKMCN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMatKCN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTenDNCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenHienThi;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtTimTK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnSuaTK;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox cboLoaiTK;
        private System.Windows.Forms.Label labelGhiChu;
    }
}