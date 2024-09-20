using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmThongKe : Form
    {
        private System.Windows.Forms.ListView lsvBill = new System.Windows.Forms.ListView();// doanh thu
        private System.Windows.Forms.ListView lsvMonTrongBill = new System.Windows.Forms.ListView();// số lượng món trong 1 bill
        private System.Windows.Forms.ListView lsvSLMon = new System.Windows.Forms.ListView();//sl món trong tg cụ thể
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lsvBill = DocDuLieuListView("doanhthu.dat");
            HienThiListViewTrongPanelDoanhThu(lsvBill);
            HienThiTongTien("doanhthu.dat");
            txtSoBill.Text = demSoBill.ToString();
        }
        public int demSoBill = 0;
        private System.Windows.Forms.ListView DocDuLieuListView(string tenFile)
        {
            double tien = 0;
            demSoBill = 0;// nếu đọc lại dữ liệu thì đếm lại bill
            try
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(tenFile))
                {
                    // Kiểm tra xem cột đã được thêm vào ListView chưa
                    if (lsvBill.Columns.Count == 0)
                    {
                        lsvBill.Name = $"lsvDoanhThu";
                        lsvBill.Size = new System.Drawing.Size(400, 300); // Điều chỉnh kích thước nếu cần
                        lsvBill.Location = new System.Drawing.Point(10, 10); // Điều chỉnh vị trí nếu cần
                        lsvBill.View = View.Details;
                        lsvBill.FullRowSelect = true;

                        // Thêm cột vào ListView
                        lsvBill.Columns.Add("Mã hóa đơn", 150);
                        lsvBill.Columns.Add("Tên nhân viên", 170);
                        lsvBill.Columns.Add("Thời gian", 320);
                        lsvBill.Columns.Add("tổng tiền ", 120);                      

                        lsvBill.GridLines = true;
                        lsvBill.Dock = DockStyle.Fill;
                        
                    }

                    // Xóa tất cả các mục trong ListView
                    lsvBill.Items.Clear();

                    while (!reader.EndOfStream)
                    {
                        string maHoaDon = reader.ReadLine();
                        string tenNhanVien = reader.ReadLine();
                        string thoiGianStr = reader.ReadLine();
                        string tongTien = reader.ReadLine();
                        // Chuyển thời gian từ chuỗi sang đối tượng DateTime
                        if (DateTime.TryParseExact(thoiGianStr, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime thoiGian))
                        {
                            // Kiểm tra xem thời gian có nằm trong khoảng từ ngàyBatDau đến ngàyKetThuc không
                            if (thoiGian.Date >= dateTimePickerTuNgay.Value && thoiGian.Date <= dateTimePickerDenNgay.Value)                            
                            {
                                // Tạo ListViewItem và thêm vào ListView
                                demSoBill += 1;// đếm xem được bao nhiêu bill
                                ListViewItem lvItem = new ListViewItem(maHoaDon);
                                lvItem.SubItems.Add(tenNhanVien);
                                lvItem.SubItems.Add(thoiGianStr);
                                lvItem.SubItems.Add(tongTien);

                                lsvBill.Items.Add(lvItem);
                                double giaTriTongTien;
                                if (double.TryParse(tongTien, out giaTriTongTien))
                                {
                                    tien += giaTriTongTien;
                                }
                            }
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
        private void HienThiTongTien(string tenFile)
        {
            double tongTien = 0;
            try
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(tenFile))
                {
                    // Đọc và thêm thông tin từng dòng vào ListView
                    while (!reader.EndOfStream)
                    {
                        string thoiGianStr = reader.ReadLine();
                        string tongTienStr = reader.ReadLine();

                        // Chuyển thời gian từ chuỗi sang đối tượng DateTime
                        if (DateTime.TryParseExact(thoiGianStr, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime thoiGian))
                        {
                            // Kiểm tra xem thời gian có nằm trong khoảng từ ngàyBatDau đến ngàyKetThuc không
                            if (thoiGian.Date >= dateTimePickerTuNgay.Value && thoiGian.Date <= dateTimePickerDenNgay.Value)
                            {
                                double giaTriTongTien;
                                if (double.TryParse(tongTienStr, out giaTriTongTien))
                                {
                                    tongTien += giaTriTongTien;
                                }
                            }
                        }
                    }
                }

                // Hiển thị tổng tiền trong TextBox
                txtTongTien.Text = tongTien.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
        }
        private void HienThiListViewTrongPanelDoanhThu(System.Windows.Forms.ListView listView)
        {
            // Xóa tất cả các điều khiển con trong panelBill
            panelDoanhThu.Controls.Clear();
            // Đặt căn giữa cho tất cả các cột
            foreach (ColumnHeader column in lsvBill.Columns)
            {
                column.TextAlign = HorizontalAlignment.Center;                
            }           
            // Thêm ListView vào panelBill  
            panelDoanhThu.Controls.Add(listView);
        }

        private Dictionary<string, int> soLuongDictionary = new Dictionary<string, int>();
        // số lượng nước bán ra 
        private System.Windows.Forms.ListView DocDuLieuThongKeSLMonBanRa(string tenFile)
        {
            try
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(tenFile))
                {
                    // Kiểm tra xem cột đã được thêm vào ListView chưa
                    if (lsvMonTrongBill.Columns.Count == 0)
                    {
                        lsvMonTrongBill.Name = $"lsvSLNuoc";
                        lsvMonTrongBill.Size = new System.Drawing.Size(400, 300); // Điều chỉnh kích thước nếu cần
                        lsvMonTrongBill.Location = new System.Drawing.Point(10, 10); // Điều chỉnh vị trí nếu cần
                        lsvMonTrongBill.View = View.Details;
                        lsvMonTrongBill.FullRowSelect = true;

                        // Thêm cột vào ListView
                        lsvMonTrongBill.Columns.Add("Tên món ", 150);
                        lsvMonTrongBill.Columns.Add("Số lượng ", 150);
                        lsvMonTrongBill.GridLines = true;
                        lsvMonTrongBill.Dock = DockStyle.Fill;
                    }

                    // Xóa tất cả các mục trong ListView
                    lsvMonTrongBill.Items.Clear();
                    bool kiemTraDong = false;
                    soLuongDictionary.Clear();// Xóa tất cả các mục trong ListView và cập nhật Dictionary

                    while (!reader.EndOfStream)
                    {                                          
                        if (kiemTraDong == false)// bill khác
                        { 
                            string thoiGianStr = reader.ReadLine();    
                            string tennuoc = reader.ReadLine();
                            string soluong = reader.ReadLine();
                            // Chuyển thời gian từ chuỗi sang đối tượng DateTime
                            if (DateTime.TryParseExact(thoiGianStr, "HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime thoiGian))
                            {
                                // Kiểm tra xem thời gian có nằm trong khoảng từ ngàyBatDau đến ngàyKetThuc không
                                if (thoiGian.Date >= dtpTKNTuNgay.Value && thoiGian.Date <= dtpTKNDenNgay.Value)
                                {
                                    // Tạo ListViewItem và thêm vào ListView                               
                                    ListViewItem lvItem = new ListViewItem(tennuoc);
                                    lvItem.SubItems.Add(soluong);

                                    lsvMonTrongBill.Items.Add(lvItem);
                                    kiemTraDong = true;
                                }
                            }
                            else
                            {
                                // Nếu thời gian không hợp lệ, đặt kiemTraDong là false để xử lý dòng tiếp theo
                                kiemTraDong = false;

                                // Đọc dòng trống để nhảy tới dòng tiếp theo có thể là dòng thời gian hợp lệ
                                while (!string.IsNullOrWhiteSpace(reader.ReadLine()))
                                {
                                    // Đọc qua dòng trống
                                }
                            }
                        }
                        else// kiemtradong= true; món trong bill cũ 
                        {
                            string dongTiepTheo = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(dongTiepTheo))
                            {// nếu dòng trống thì bỏ qua dòng trống và duyệt lại ngày
                                kiemTraDong = false;
                            }
                            else
                            {
                                string soluong = reader.ReadLine();
                                ListViewItem lvItem = new ListViewItem(dongTiepTheo);
                                lvItem.SubItems.Add(soluong);
                                lsvMonTrongBill.Items.Add(lvItem);
                            }
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
            return lsvMonTrongBill;
        }
        private void LuuMon(string tenFile, System.Windows.Forms.ListView lsvSL)// tổng số lượng 
        {//lúuoluongmon.dat
            try
            {
                // Tạo một Dictionary để lưu thông tin về số lượng của mỗi món
                Dictionary<string, int> thongKeMon = new Dictionary<string, int>();

                // Ghi thông tin từng dòng của ListView vào thống kê món
                foreach (ListViewItem item in lsvSL.Items)
                {
                    string tenMon = item.SubItems[0].Text; // Lấy tên món
                    int soLuong = int.Parse(item.SubItems[1].Text); // Lấy số lượng

                    // Nếu món đã tồn tại trong thống kê, cộng thêm số lượng mới vào
                    if (thongKeMon.ContainsKey(tenMon))
                    {
                        thongKeMon[tenMon] += soLuong;
                    }
                    else
                    {
                        thongKeMon[tenMon] = soLuong;
                    }
                }

                // Sắp xếp thống kê món theo số lượng giảm dần
                var sortedThongKeMon = thongKeMon.OrderByDescending(pair => pair.Value);

                // Ghi thông tin mới vào tệp tin
                List<string> lines = new List<string>();
                foreach (var pair in sortedThongKeMon)
                {
                    lines.Add(pair.Key);
                    lines.Add(pair.Value.ToString());
                }

                // Xóa dữ liệu cũ và ghi dữ liệu mới vào tệp tin
                File.WriteAllLines(tenFile, lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi file: {ex.Message}");
            }
        }
        private System.Windows.Forms.ListView DocDuLieuSoLuongMon(string tenFile)
        {
            //double tien = 0;
            //demSoBill = 0;// nếu đọc lại dữ liệu thì đếm lại bill
            try
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(tenFile))
                {
                    // Kiểm tra xem cột đã được thêm vào ListView chưa
                    if (lsvSLMon.Columns.Count == 0)
                    {
                        lsvSLMon.Name = $"lsvSLMon";
                        lsvSLMon.Size = new System.Drawing.Size(400, 300); // Điều chỉnh kích thước nếu cần
                        lsvSLMon.Location = new System.Drawing.Point(10, 10); // Điều chỉnh vị trí nếu cần
                        lsvSLMon.View = View.Details;
                        lsvSLMon.FullRowSelect = true;

                        // Thêm cột vào ListView

                        lsvSLMon.Columns.Add("Tên món ", 250);
                        lsvSLMon.Columns.Add("Số lượng ", 150);
                        lsvSLMon.GridLines = true;
                        lsvSLMon.Dock = DockStyle.Fill;                       
                    }

                    // Xóa tất cả các mục trong ListView
                    lsvSLMon.Items.Clear();
                    while (!reader.EndOfStream)
                    {
                        string tennuoc = reader.ReadLine();
                        string soluong = reader.ReadLine();
                        ListViewItem lvItem = new ListViewItem(tennuoc);
                        lvItem.SubItems.Add(soluong);

                        lsvSLMon.Items.Add(lvItem);

                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
            return lsvSLMon;
        }
        private void HienThiListSoLuongMon(System.Windows.Forms.ListView listView)
        {
            // Xóa tất cả các điều khiển con trong panelBill
            panelSLN.Controls.Clear();
            // Đặt căn giữa cho tất cả các cột
            foreach (ColumnHeader column in lsvSLMon.Columns)
            {
                column.TextAlign = HorizontalAlignment.Center;
            }
            // Thêm ListView vào panelBill
            panelSLN.Controls.Add(listView);           
        }

        private void btnThongKeSLMon_Click(object sender, EventArgs e)
        {
            lsvMonTrongBill = DocDuLieuThongKeSLMonBanRa("thongkemon.dat");
            LuuMon("thongkesoluongmon.dat", lsvMonTrongBill);
            lsvSLMon = DocDuLieuSoLuongMon("thongkesoluongmon.dat");
            HienThiListSoLuongMon(lsvSLMon);
            HienThiTongSoLuongMonBanRa("thongkesoluongmon.dat");// hiện thị tổng số lượng món đã bán
        }
        private void HienThiTongSoLuongMonBanRa(string tenFile)
        {
            int soluong = 0;
            try
            {
                // Mở tệp tin để đọc
                using (StreamReader reader = new StreamReader(tenFile))
                {
                    // Đọc và thêm thông tin từng dòng vào ListView
                    while (!reader.EndOfStream)
                    {
                        string tenmon = reader.ReadLine();
                        string soluongmon = reader.ReadLine();

                        int sl = int.Parse(soluongmon.ToString());
                        soluong += sl;
                    }
                }
                // Hiển thị tổng tiền trong TextBox
                txtSLMonBanRa.Text = soluong.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dateTimePickerDenNgay.Value=DateTime.Now;// hiện thời gian hiện tại
            dtpTKNDenNgay.Value = DateTime.Now;            
        }

    }
}
