using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmTaiKhoan : Form
    {
        private List<CTaiKhoan> dstaikhoan = new List<CTaiKhoan>();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        public void hienthiDSTK()
        {
            dgvTaiKhoan.DataSource = dstaikhoan.ToList();
        }
        private CTaiKhoan timTaiKhoan(string ma)
        {
            foreach (CTaiKhoan n in dstaikhoan)
            {
                if (n.TenDangNhap == ma)
                    return n;
            }
            return null;
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            CTaiKhoan n = new CTaiKhoan();
            if ((txtTenDN.Text == "") || (txtTenHienThi.Text == "") || (txtMatKhau.Text == "")
                || (cboLoaiTK.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                n.TenDangNhap = txtTenDN.Text;
                n.TenHienThi = txtTenHienThi.Text;
                n.MatKhau = txtMatKhau.Text;
                n.LoaiTaiKhoan = cboLoaiTK.Text;
                if (timTaiKhoan(n.TenDangNhap) == null)
                {
                    dstaikhoan.Add(n);
                    hienthiDSTK();
                    dstaikhoan = GhiFileTaiKhoan("dstaikhoan.dat", dstaikhoan);
                }
                else
                {
                    MessageBox.Show("Trùng tên đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            CTaiKhoan n = timTaiKhoan(txtTenDN.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dstaikhoan.Remove(n);
                hienthiDSTK();
                dstaikhoan = GhiFileTaiKhoan("dstaikhoan.dat", dstaikhoan);
            }
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            CTaiKhoan n = timTaiKhoan(txtTenDN.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                n.TenDangNhap = txtTenDN.Text;
                n.TenHienThi = txtTenHienThi.Text;
                n.MatKhau = txtMatKhau.Text;
                n.LoaiTaiKhoan = cboLoaiTK.Text;
                hienthiDSTK();
                dstaikhoan = GhiFileTaiKhoan("dstaikhoan.dat", dstaikhoan);
            }
        }

        private void dgvTaiKhoan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CTaiKhoan n = new CTaiKhoan();
            txtTenDN.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenHienThi.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
            cboLoaiTK.Text = dgvTaiKhoan.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        public List<CTaiKhoan> GhiFileTaiKhoan(string tenFile, List<CTaiKhoan> danhSachTaiKhoan)
        {
            try
            {
                // Mở tệp tin để ghi dữ liệu
                using (StreamWriter sw = new StreamWriter(tenFile))
                {
                    foreach (CTaiKhoan taikhoan in danhSachTaiKhoan)
                    {
                        // Ghi thông tin của mỗi tài khoản vào tệp tin
                        sw.WriteLine($"{taikhoan.TenDangNhap}");
                        sw.WriteLine($"{taikhoan.TenHienThi}");
                        sw.WriteLine($"{taikhoan.MatKhau}");
                        sw.WriteLine($"{taikhoan.LoaiTaiKhoan}");

                        sw.WriteLine(); // Tạo một dòng trống để phân biệt giữa các tài khoản
                    }
                }
                return danhSachTaiKhoan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu vào tệp {tenFile}: {ex.Message}");
                return null;
            }
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
                                LoaiTaiKhoan=loaitaikhoan,
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
        private void txtTimTK_TextChanged(object sender, EventArgs e)
        {
            string timTenHienThi = txtTimTK.Text;
            if (!string.IsNullOrWhiteSpace(timTenHienThi))
            {
                dgvTaiKhoan.DataSource = null;
                dgvTaiKhoan.DataSource = dstaikhoan;
                List<CTaiKhoan> tmp = new List<CTaiKhoan>();
                for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
                {
                    if (dgvTaiKhoan.Rows[i].Cells[1].Value.ToString()//ToLower k phân biệt hoa thường
                        .ToLower().Contains(timTenHienThi.ToLower()))
                        tmp.Add(dstaikhoan[i]);
                }
                dgvTaiKhoan.DataSource = null;
                dgvTaiKhoan.DataSource = tmp;
            }
            else
            {
                dgvTaiKhoan.DataSource = null;
                dgvTaiKhoan.DataSource = dstaikhoan;
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dstaikhoan = DocFileTaiKhoan("dstaikhoan.dat");
            hienthiDSTK();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)//cập nhật tài khoản
        {
            CTaiKhoan n = timTaiKhoan(txtTenDNCN.Text);
            if (txtTenDNCN.Text == "" || txtMatKCN.Text == "" || txtMatKMCN.Text == "" || txtNhapLMKCN.Text == "")
            {// nhập thiếu thông tin
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // nhập đầy đủ thông tin
            {
                if (n == null)
                {
                    labelGhiChu.Text = "Không tìm thấy tài khoản ";
                    labelGhiChu.ForeColor = Color.Red;
                }
                else if (txtMatKMCN.Text != txtNhapLMKCN.Text)// nhập lại mật khẩu k giống nhau
                {
                    // Đặt các thuộc tính cho Label 
                    labelGhiChu.Text = "mật khẩu mới không giống nhau"; // Đặt nội dung của Label
                    labelGhiChu.ForeColor = Color.Red;

                }
                else// nếu tìm thấy
                {
                    if (txtMatKCN.Text == n.MatKhau)// nhập mk đúng
                    {
                        n.MatKhau = txtMatKMCN.Text;
                        dstaikhoan = GhiFileTaiKhoan("dstaikhoan.dat", dstaikhoan);
                        labelGhiChu.Text = "";
                        MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtTenDNCN.Text = "";
                        txtMatKCN.Text = "";
                        txtMatKMCN.Text = "";
                        txtNhapLMKCN.Text = "";
                    }
                    else// nhập mk sai
                    {
                        labelGhiChu.Text = "nhập mật khẩu sai ";
                        labelGhiChu.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void tabCapNhatTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void tabTaiKhoan_Click(object sender, EventArgs e)
        {
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void tabTaiKhoanfrm_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (CChucVuTaiKhoan.TaiKhoan.LoaiTaiKhoan == "Nhân viên")// nếu là nhân viên thì chỉ cho chỉnh sửa tk
            {
                if (e.TabPageIndex == 1)// không cho chuyển tab
                {
                    // Hủy sự kiện để ngăn chặn chuyển đến tab danh sách tài khoản
                    e.Cancel = true;
                }
            }
            else if (CChucVuTaiKhoan.TaiKhoan.LoaiTaiKhoan == "Quản lý")// quản lý
            {
            }
            else
            {
                MessageBox.Show("chức vụ không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
