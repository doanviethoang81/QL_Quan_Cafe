using System;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmGiaoDien : Form
    {
        public frmGiaoDien()
        {
            InitializeComponent();           
            this.StartPosition = FormStartPosition.Manual;
            // vị trí muốn hiển thị
            this.Location = new System.Drawing.Point(60, 0);
            this.Width = 1170;//chiều ngang
            this.Height = 650;//chiều dọc 
        }       
        private Form currentFromChild;
        private void OpenChildForm(Form childFrom)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            currentFromChild = childFrom;
            childFrom.TopLevel = false;// thực hiện các form cha khác 
            childFrom.FormBorderStyle = FormBorderStyle.None;// đóng cái khung của form gọi ra
            childFrom.Dock = DockStyle.Fill;// lấp đầy panel
            panel_Body1.Controls.Add(childFrom);
            panel_Body1.Tag = childFrom;
            childFrom.BringToFront();// hiển thị lên trên
            childFrom.Show();// show form đó lên
        }
        private void pictureBox1_Click(object sender, EventArgs e)// logo quán trở về home
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            label1.Text = "          Home";
            btnOrder.BackColor = Color.Gainsboro;
            btnQuanLySanPham.BackColor = Color.Gainsboro;
            btnThongKe.BackColor = Color.Gainsboro;
            btnTaiKhoan.BackColor = Color.Gainsboro;
            btnDangXuat.BackColor = Color.Gainsboro;
        }
         private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrder());
            label1.Text = "          Order";
            btnOrder.BackColor = Color.PeachPuff;
            btnQuanLySanPham.BackColor = Color.Gainsboro;
            btnThongKe.BackColor = Color.Gainsboro;
            btnTaiKhoan.BackColor = Color.Gainsboro;
            btnDangXuat.BackColor = Color.Gainsboro;
        }
        private void btnQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLy());
            label1.Text = "Quản Lý Sản Phẩm";
            btnOrder.BackColor = Color.Gainsboro;
            btnQuanLySanPham.BackColor = Color.PeachPuff;
            btnThongKe.BackColor = Color.Gainsboro;
            btnTaiKhoan.BackColor = Color.Gainsboro;
            btnDangXuat.BackColor = Color.Gainsboro;
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            label1.Text = "      Thống Kê";
            btnOrder.BackColor = Color.Gainsboro;
            btnQuanLySanPham.BackColor = Color.Gainsboro;
            btnThongKe.BackColor = Color.PeachPuff;
            btnTaiKhoan.BackColor = Color.Gainsboro;
            btnDangXuat.BackColor = Color.Gainsboro;
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTaiKhoan());
            label1.Text = "      Tài Khoản ";
            btnOrder.BackColor = Color.Gainsboro;
            btnQuanLySanPham.BackColor = Color.Gainsboro;
            btnThongKe.BackColor = Color.Gainsboro;
            btnTaiKhoan.BackColor = Color.PeachPuff;
            btnDangXuat.BackColor = Color.Gainsboro;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void PhanQuyen()// kiểm tra xem loại tài khoản đăng nhập là gì
        {
            if (CChucVuTaiKhoan.TaiKhoan.LoaiTaiKhoan == "Nhân viên")
            {
                btnThongKe.Enabled = false;//không cho tương tác
                btnQuanLySanPham.Enabled = false;
            }
            else if(CChucVuTaiKhoan.TaiKhoan.LoaiTaiKhoan == "Quản lý")// quản lý
            {
            }
            else
            {
                MessageBox.Show("chức vụ không hợp lệ ");
            }
        }
        private void frmGiaoDien_Load(object sender, EventArgs e)
        {
            PhanQuyen();
        }

        private void panel_Body1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
