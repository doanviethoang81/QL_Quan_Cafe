using System.IO;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;
using System.Linq;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmHoaDon : Form
    {
        private System.Windows.Forms.ListView lsvBill = new System.Windows.Forms.ListView();
        private frmOrder frmOrderInstance = new frmOrder();
        private frmDangNhap dangnhap;
        public frmHoaDon(string maBan)
        {
            InitializeComponent();
            this.maBan = maBan;
            // Đặt vị trí khởi tạo của form giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 520;//chiều dọc            
        }
        private System.Windows.Forms.ListView DocDuLieuListView(string maBan)
        {
            System.Windows.Forms.ListView lsvBill = new System.Windows.Forms.ListView();
            try
            {
                // Tạo tên tệp tin dựa trên tên của bàn
                string tenFile = $"{maBan}.dat"; 

                // Kiểm tra xem tệp tin có tồn tại không
                if (File.Exists(tenFile))
                {
                    // Mở tệp tin để đọc
                    using (StreamReader reader = new StreamReader(tenFile))
                    {
                        //// Đọc số lượng dòng trong ListView
                        int soLuongDong = int.Parse(reader.ReadLine());
                        // Kiểm tra xem cột đã được thêm vào ListView chưa
                        if (lsvBill.Columns.Count == 0)
                        {
                            lsvBill.Name = $"{maBan}";
                            lsvBill.Size = new System.Drawing.Size(400, 300);
                            lsvBill.Location = new System.Drawing.Point(10, 10);
                            lsvBill.View = View.Details;
                            lsvBill.FullRowSelect = true;

                            // Thêm cột vào ListView
                            lsvBill.Columns.Add("STT", 60);
                            lsvBill.Columns.Add("Tên Món", 150);
                            lsvBill.Columns.Add("Số Lượng", 70);
                            lsvBill.Columns.Add("Giá", 80);
                            lsvBill.GridLines = true;
                            lsvBill.Dock = DockStyle.Fill;
                        }

                        // Xóa tất cả các mục trong ListView
                        lsvBill.Items.Clear();

                        // Đọc và thêm thông tin từng dòng vào ListView
                        for (int i = 0; i < soLuongDong; i++)
                        {
                            string stt = reader.ReadLine();
                            string tenMon = reader.ReadLine();
                            string soLuong = reader.ReadLine();
                            string gia = reader.ReadLine();

                            // Tạo ListViewItem và thêm vào ListView
                            ListViewItem lvItem = new ListViewItem(stt);

                            lvItem.SubItems.Add(tenMon);
                            lvItem.SubItems.Add(soLuong);
                            lvItem.SubItems.Add(gia);
                            lsvBill.Items.Add(lvItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
            return lsvBill;
        }
        private void HienThiListViewTrongPanelBillHoaDon(System.Windows.Forms.ListView listView)
        {
            // Xóa tất cả các điều khiển con trong panelBill
            panelBillHoaDon.Controls.Clear();

            // Thêm ListView vào panelBill
            panelBillHoaDon.Controls.Add(listView);
        }
        private string maBan;
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dateTimePickerBill.Value= DateTime.Now;// hiện giờ hiện tại khi bill
            labTenBan.Text = maBan;// gán tên bàn trong hóa đơn
            string a = this.maBan;
            panelBillHoaDon.Controls.Clear();// xóa listView cũ
            lsvBill = DocDuLieuListView(a);
            HienThiListViewTrongPanelBillHoaDon(lsvBill);
            TenNhanVien();
            labMaHoaDon.Text = GenerateRandomNumber().ToString();
            LuuHoaDon("doanhthu.dat");
            LuuDSMon("thongkemon.dat");
        }
        public void TongTien(string tongtien)
        {
            txtTien.Text = tongtien;
        }
        public void TenNhanVien()// kiểm tra xem loại tài khoản đăng nhập là gì
        {
            labTenNhanVien.Text = CChucVuTaiKhoan.TaiKhoan.TenHienThi;
        }
        private void LuuHoaDon(string tenFile)
        {
            try
            {
                // Mở tệp tin để ghi (hoặc tạo mới nếu chưa tồn tại)
                using (StreamWriter writer = File.AppendText(tenFile))
                {
                    // Ghi dữ liệu mới vào cuối tệp tin
                    writer.WriteLine(labMaHoaDon.Text);
                    writer.WriteLine(labTenNhanVien.Text);
                    writer.WriteLine(dateTimePickerBill.Value.ToString("HH:mm:ss dd/MM/yyyy")); // Định dạng ngày giờ
                    writer.WriteLine(txtTien.Text);
                }
               
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi khi ghi tệp tin
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        private void LuuDSMon(string tenFile)//thongkemon.dat
        {
            try
            {
                // Mở tệp tin để ghi (hoặc tạo mới nếu chưa tồn tại)
                using (StreamWriter writer = File.AppendText(tenFile))
                {
                    // Ghi dữ liệu mới vào cuối tệp tin                   
                    writer.WriteLine(dateTimePickerBill.Value.ToString("HH:mm:ss dd/MM/yyyy")); // Định dạng ngày giờ
                    // Lặp qua các mục trong ListView và ghi tên món và số lượng
                    foreach (ListViewItem item in lsvBill.Items)
                    {
                        string tenMon = item.SubItems[1].Text; // Lấy tên món từ cột thứ 0
                        string soLuong = item.SubItems[2].Text; // Lấy số lượng từ cột thứ 1

                        // Ghi tên món và số lượng vào tệp tin
                        writer.WriteLine($"{tenMon}");
                        writer.WriteLine($"{soLuong}");                       
                    }
                    writer.WriteLine(); // Tạo một dòng trống để phân biệt giữa các nước
                }                
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi khi ghi tệp tin
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        public int GenerateRandomNumber()
        {
            // Sử dụng hàm Random để tạo số ngẫu nhiên
            Random random = new Random();
            // Tạo số nguyên ngẫu nhiên có 5 chữ số
            int minNumber = 10000;
            int maxNumber = 99999;
            int n = random.Next(minNumber, maxNumber+1);
            return n;
        }
    }
}
