using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            // Đặt vị trí khởi tạo của form giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;            
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
        }
        public List<CTaiKhoan> DocFileTaiKhoan(string tenFile)
        {
            List<CTaiKhoan> danhSachTaiKhoan = new List<CTaiKhoan>();
            try
            {
                // Kiểm tra xem tệp tồn tại hay không
                if (File.Exists(tenFile))
                {
                    // Mở tệp tin để đọc dữ liệu
                    using (StreamReader sr = new StreamReader(tenFile))
                    {
                        while (!sr.EndOfStream)
                        {
                            // Đọc từng dòng từ tệp tin
                            string tendangnhap = sr.ReadLine();
                            string tenhienthi = sr.ReadLine();
                            string matkhau = sr.ReadLine();
                            string loaitaikhoan = sr.ReadLine();

                            // Tạo đối tượng hocSinh và thêm vào danh sách
                            CTaiKhoan taikhoan = new CTaiKhoan
                            {
                                TenDangNhap = tendangnhap,
                                TenHienThi = tenhienthi,
                                MatKhau = matkhau,
                                LoaiTaiKhoan = loaitaikhoan,
                            };

                            danhSachTaiKhoan.Add(taikhoan);
                            // Đọc dòng trống để phân biệt giữa các tài khoản
                            sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp {tenFile} không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu từ tệp {tenFile}: {ex.Message}");
            }
            return danhSachTaiKhoan;
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if ((txtTenDN.Text == "") || (txtMatK.Text == ""))
            {
                labChuThich.Text = "vui lòng nhập đủ thông tin ";
            }
            else
            {
                if (KiemTraDangNhap(txtTenDN.Text, txtMatK.Text))//đăng nhập thành công
                {
                    KiemTraChucVu(txtTenDN.Text, txtMatK.Text);
                    frmGiaoDien giaoDien = new frmGiaoDien();
                    this.Hide();// ẩn giao diện trước đó
                    giaoDien.ShowDialog();
                    this.Show();// hiện lại giao diện đăng nhập
                    checkBoxHienMatKhau.Checked = false;//bỏ dấu click trước đó
                    labChuThich.Text = "";
                    txtTenDN.Text = "";
                    txtMatK.Text = "";
                }
                else
                {
                    labChuThich.Text = "nhập tài khoản hoặc mật khẩu sai ";
                    txtTenDN.Text = "";
                    txtMatK.Text = "";
                }
            }
        }
        private bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            // Thực hiện đọc danh sách tài khoản từ tệp
            List<CTaiKhoan> dsTaiKhoan = DocFileTaiKhoan("dstaikhoan.dat");

            // Kiểm tra xem có tài khoản nào có tên đăng nhập và mật khẩu khớp không
            CTaiKhoan taiKhoan = dsTaiKhoan.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);
            //FirstOrDefault tìm kiếm tài khoản trong danh sách tài khoản
            // Nếu tìm thấy tài khoản, kiểm tra chức vụ (vai trò) nếu cần
            if (taiKhoan != null)
            {
                return true;
            }
            // Đăng nhập không thành công
            return false;
        }
        public bool KiemTraChucVu(string tenDangNhap, string matKhau)
        {
            // Thực hiện đọc danh sách tài khoản từ tệp
            List<CTaiKhoan> dsTaiKhoan = DocFileTaiKhoan("dstaikhoan.dat");

            // Kiểm tra xem có tài khoản nào có tên đăng nhập và mật khẩu khớp không
            CTaiKhoan taiKhoan = dsTaiKhoan.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);

            // Nếu tìm thấy tài khoản và loại tài khoản không rỗng
            if (taiKhoan != null && !string.IsNullOrEmpty(taiKhoan.LoaiTaiKhoan))
            {
                // Lưu lại tài khoản đó 
                CChucVuTaiKhoan.TaiKhoan = taiKhoan;
                return true;
            }
            else
            {               
                return false; // Trả về giá trị null hoặc chuỗi rỗng khi đăng nhập không thành công
            }
        }
      
        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {           
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBoxHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHienMatKhau.Checked)// hiện mật khẩu
            {
                txtMatK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatK.UseSystemPasswordChar = true;
            }
        }
    }
}
