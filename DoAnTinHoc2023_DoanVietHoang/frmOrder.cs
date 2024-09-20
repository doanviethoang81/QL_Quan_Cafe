using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnTinHoc2023_DoanVietHoang
{
    [Serializable]
    public partial class frmOrder : Form
    {
        private List<CNuoc> dsnuoc;
        private List<CDoAn> dsdoan;
        frmHoaDon hoadon;
       
        public frmOrder()
        {
            InitializeComponent();                 
        }

        private List<CNuoc> DocFileNuoc(string tenFile)
        {
            List<CNuoc> danhSachNuoc = new List<CNuoc>();
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
                            string id = sr.ReadLine();
                            string ten = sr.ReadLine();
                            string gia = sr.ReadLine();

                            // Tạo đối tượng nuoc và thêm vào danh sách
                            CNuoc nuoc = new CNuoc
                            {
                                IDNuoc = id,
                                TenNuoc = ten,
                                GiaNuoc = gia
                            };
                            danhSachNuoc.Add(nuoc);
                            // Đọc dòng trống để phân biệt giữa các loại nước
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
            return danhSachNuoc;        
        }
        public List<CDoAn> DocFileDoAn(string tenFile)
        {
            List<CDoAn> danhSachDoAn = new List<CDoAn>();
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
                            string id = sr.ReadLine();
                            string ten = sr.ReadLine();
                            string gia = sr.ReadLine();

                            // Tạo đối tượng doAn và thêm vào danh sách
                            CDoAn doAn = new CDoAn
                            {
                                IDDA = id,
                                TenDA = ten,
                                GiaDA = gia
                            };

                            danhSachDoAn.Add(doAn);
                            // Đọc dòng trống để phân biệt giữa các món
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
            return danhSachDoAn;
        }        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (kiemTraTrangThaiBan(mabandangchon)== "Chưa Chọn")// mabandangchon là mã bàn đã lấy trong clickbtnBan 
            {// kiểm tra trạng thái của bàn
                MessageBox.Show("Bạn chưa chọn bàn hoặc chưa gọi món để thanh toán !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Kiểm tra xem tệp có dữ liệu hay không
                string tenFile = $"{mabandangchon}.dat";
                if (File.Exists(tenFile) && new FileInfo(tenFile).Length > 0)
                {
                    // Tạo một instance của frmHoaDon và truyền giá trị mã bàn
                    frmHoaDon hoadon = new frmHoaDon(mabandangchon);

                    // Lấy giá trị từ txtTongTien trên frmOrder
                    string Tien = layGiaTriTongTien();

                    // Gán giá trị cho txtTien trên frmHoaDon
                    hoadon.TongTien(Tien);
                    hoadon.ShowDialog();

                    // Cập nhật trạng thái bàn và làm sạch các điều khiển
                    CapNhatTrangThaiBan(mabandangchon, "Trống");
                    panelBan.Controls.Clear();
                    TaoVaHienThiDanhSachBan();

                    // Xóa tệp tin của bàn và làm sạch các điều khiển khác
                    File.Delete(tenFile);
                    panelBill.Controls.Clear();
                    txtBanDangChon.Text = "";
                    txtTongTien.Text = "";
                    cboNuoc.Text = "";
                    cboDoAn.Text = "";
                    nmSLNuoc.Value = 0;
                    nmSLDoAn.Value = 0;
                }
                else
                {
                    MessageBox.Show("Bàn chưa gọi món !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                  
            }
        }
        public string layGiaTriTongTien()
        {
            return txtTongTien.Text;
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            // Gọi hàm DocFileNuoc để đọc danh sách nước từ file
            dsnuoc = DocFileNuoc("dsnuoc.dat");
            // Thêm giá trị trống vào đầu danh sách nước
            dsnuoc.Insert(0, new CNuoc { IDNuoc = "", TenNuoc = "", GiaNuoc = "0" });
            // Gán danh sách nước vào ComboBox
            cboNuoc.DataSource = dsnuoc;
            cboNuoc.ValueMember = "TenNuoc"; 

            dsdoan = DocFileDoAn("dsdoan.dat");
            dsdoan.Insert(0, new CDoAn { IDDA = "", TenDA = "", GiaDA = "0" });
            cboDoAn.DataSource = dsdoan;
            cboDoAn.ValueMember = "TenDA";
            TaoVaHienThiDanhSachBan();
        }
        private int timGiaNuoc()
        {
            // Lấy tên nước được chọn từ ComboBox            
            string tenNuocDuocChon = cboNuoc.Text;

            // Tìm giá trị giá nước trong danh sách nước từ hàm đọc file
            List<CNuoc> dsNuoc = DocFileNuoc("dsnuoc.dat");
            CNuoc nuocDuocChon = dsNuoc.FirstOrDefault(n => n.TenNuoc == tenNuocDuocChon);

            // Nếu tìm thấy, trả về giá nước; nếu không trả về 0
            return nuocDuocChon != null ? Convert.ToInt32(nuocDuocChon.GiaNuoc) : 0;
        }
        private int timGiaDoAn()
        {
            string tenDoAnDuocChon = cboDoAn.Text;

            // Tìm giá trị giá nước trong danh sách nước từ hàm đọc file
            List<CDoAn> dsDoAn = DocFileDoAn("dsdoan.dat");
            CDoAn DoAnDuocChon = dsDoAn.FirstOrDefault(n => n.TenDA == tenDoAnDuocChon);

            // Nếu tìm thấy, trả về giá nước; nếu không trả về 0
            return DoAnDuocChon != null ? Convert.ToInt32(DoAnDuocChon.GiaDA) : 0;
        }
        private void cboMaGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            // trường hợp chọn mã giảm giá sau khi gọi món
            // thì phải gọi lại hàm tính tiền 
            double Tien = TinhTongTien();
            txtTongTien.Text = Tien.ToString();
        }
        public double TinhTongTien()
        {
            double tongTien = 0;
            // Duyệt qua tất cả các mục trong ListView
            foreach (ListViewItem item in lsvBill.Items)
            {
                // Lấy giá tiền của mục
                double giaTien = double.Parse(item.SubItems[3].Text);

                // Cộng vào tổng tiền
                tongTien += giaTien;
            }
            // Kiểm tra xem có mã giảm giá được chọn hay không
            if (cboMaGG.SelectedItem != null)
            {
                // Lấy giá trị mã giảm giá từ ComboBox
                string maGiamGia = cboMaGG.SelectedItem.ToString();
                double tiengiamgia = 1;
                // Kiểm tra mã giảm giá và áp dụng giảm giá
                switch (maGiamGia)
                {
                    case "5%":
                        tiengiamgia = tongTien * 0.05;
                        tongTien -= tiengiamgia; // Giảm giá 5%
                        break;
                    case "10%":
                        tiengiamgia = tongTien * 0.1;
                        tongTien -= tiengiamgia;// Giảm giá 10%
                        break;
                    case "20%":
                        tiengiamgia = tongTien * 0.2;
                        tongTien -= tiengiamgia;// Giảm giá 20%
                        break;
                    case "30%":
                        tiengiamgia = tongTien * 0.3;
                        tongTien -= tiengiamgia;// Giảm giá 30%
                        break;
                }
            }
            return tongTien;
        }
        //------------tạo bàn---------------------------------------------
       
        private const string pathToDsBan = "dsban.dat"; // Đường dẫn đến tệp tin chứa danh sách bàn
        private System.Windows.Forms.ListView lsvBill= new System.Windows.Forms.ListView();
        private List<CBan> DocDanhSachBan()
        {          
            List<CBan> danhSachBan = new List<CBan>();

            try
            {
                // Kiểm tra xem tệp tồn tại hay không
                if (File.Exists(pathToDsBan))
                {
                    // Mở tệp tin để đọc dữ liệu
                    using (StreamReader sr = new StreamReader(pathToDsBan))
                    {
                        while (!sr.EndOfStream)
                        {
                            // Đọc từng dòng từ tệp tin
                            string id = sr.ReadLine();
                            string trangthai = sr.ReadLine();

                            // Tạo đối tượng ban và thêm vào danh sách
                            CBan ban = new CBan
                            {
                                IDBan = id,
                                TrangThaiBan = trangthai
                            };

                            danhSachBan.Add(ban);

                            // Đọc dòng trống để phân biệt giữa các bàn
                            sr.ReadLine();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp {pathToDsBan} không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu từ tệp {pathToDsBan}: {ex.Message}");
            }
            return danhSachBan;
        }
        public List<CBan> GhiFileBan(string tenFile, List<CBan> danhSachBan)
        {
            try
            {
                // Mở tệp tin để ghi dữ liệu
                using (StreamWriter sw = new StreamWriter(tenFile))
                {
                    foreach (CBan ban in danhSachBan)
                    {
                        // Ghi thông tin của mỗi bàn vào tệp tin
                        sw.WriteLine($"{ban.IDBan}");
                        sw.WriteLine($"{ban.TrangThaiBan}");
                        sw.WriteLine(); // Tạo một dòng trống để phân biệt giữa các bàn
                    }
                }
                return danhSachBan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu vào tệp {tenFile}: {ex.Message}");
                return null;
            }           
        }
        private void TaoVaHienThiDanhSachBan()// tạo và hiển thị Button cho mỗi bàn
        {
            // Đọc danh sách bàn từ tệp tin
            List<CBan> danhSachBan = DocDanhSachBan();

            // Tạo TableLayoutPanel để tự động xếp các Button
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoScroll = true;// tự động cuộn khi quá nhiều bàn
            
            // Tạo và hiển thị Button cho mỗi bàn
            int soButtonTrenHangHienTai = 0;            
            int soHangHienTai = 0;//số dọc ngang hiện tại 
            foreach (CBan ban in danhSachBan)
            {
                System.Windows.Forms.Button btnBan = TaoButton(ban.IDBan, ban.TrangThaiBan);
                
                // Thêm Button vào TableLayoutPanel
                tableLayoutPanel.Controls.Add(btnBan, soButtonTrenHangHienTai, soHangHienTai);//kiểu ij ma trận
                soButtonTrenHangHienTai++;

                if (soButtonTrenHangHienTai  == 4)//tối đa 1 hàng nganh tạo 4 btn
                {
                    // Nếu đã đủ số lượng Button trên hàng, tăng số hàng
                    soHangHienTai++;
                    tableLayoutPanel.RowCount++;
                    soButtonTrenHangHienTai = 0;
                }
            }
            // Thêm TableLayoutPanel vào panelBan
            panelBan.Controls.Add(tableLayoutPanel);
        }

        private const int khoangCachNgang = 10; // Khoảng cách giữa các Button theo chiều ngang
        private const int khoangCachDoc = 10;
        private System.Windows.Forms.Button TaoButton(string maBan, string trangThai) // Hàm để tạo Button với mã bàn và trạng thái
        {
            System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            btn.Text = "Bàn " + maBan + "\n" + trangThai;
            btn.Name = maBan;
            btn.Size = new System.Drawing.Size(90, 90); //kích thước 
            btn.Margin = new Padding(khoangCachNgang, khoangCachDoc, 0, 0); // Khoảng cách giữa các Button
            if (trangThai == "Trống")
            {
                // Bàn trống - màu xanh
                btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            }
            else
            {
                // Bàn có khách - màu đỏ
                btn.BackColor = System.Drawing.Color.LightCoral;
            }
            // Thêm sự kiện Click cho Button
            btn.Click += BtnBan_Click;
            return btn;
        }
        private string kiemTraTrangThaiBan(string maBan)
        {
            List<CBan> danhSachBan = DocDanhSachBan();

            // Tìm trạng thái bàn trong danh sách 
            CBan ban = danhSachBan.Find(b => b.IDBan == maBan);
            if (ban != null)
            {
                return ban.TrangThaiBan;
            }
            return "Chưa Chọn"; // Trả về "Chưa Chọn" nếu chưa chọn bàn
        }

        private System.Windows.Forms.ListView TaoLsvBill(string maBan)// tạo bill mới cho bàn 
        {
            System.Windows.Forms.ListView lsvBill = new System.Windows.Forms.ListView();
            lsvBill.Name = $"{maBan}";
            lsvBill.Size = new System.Drawing.Size(400, 300); //kích thước nếu cần
            lsvBill.Location = new System.Drawing.Point(10, 10); //vị trí 
            lsvBill.View = View.Details;
            lsvBill.FullRowSelect = true;

            // Thêm cột vào ListView
            lsvBill.Columns.Add("STT", 90);
            lsvBill.Columns.Add("Tên Món", 200);
            lsvBill.Columns.Add("Số Lượng", 90);
            lsvBill.Columns.Add("Giá", 120);
            // Đặt căn giữa cho tất cả các cột
            foreach (ColumnHeader column in lsvBill.Columns)
            {
                column.TextAlign = HorizontalAlignment.Center;
            }
            lsvBill.GridLines = true;
            lsvBill.Dock = DockStyle.Fill;
            return lsvBill;
        }
        private void ThemNuocVaoBill(string tenNuoc)
        {
            if (cboNuoc.Text == "")
            {
            }
            else if (lsvBill != null)
            {
                // Kiểm tra nếu món đã tồn tại trong lsvBill
                ListViewItem existingItem = TimMonTrongBill(tenNuoc);
                // Nếu tồn tại, kiểm tra số lượng mới
                if (existingItem != null)
                {
                    //// Nếu món đã tồn tại, cập nhật số lượng và thành tiền
                    int soLuongHienTai = int.Parse(existingItem.SubItems[2].Text);
                    int giaNuoc = timGiaNuoc();
                    // Nếu tồn tại, kiểm tra số lượng mới
                    int soLuongMoi = int.Parse(nmSLNuoc.Text);

                    if (soLuongMoi > 0)
                    {
                        // Tăng số lượng và cập nhật giá tiền
                        existingItem.SubItems[2].Text = (soLuongHienTai + soLuongMoi).ToString();
                        existingItem.SubItems[3].Text = (giaNuoc * int.Parse(existingItem.SubItems[2].Text)).ToString();
                    }
                    else if (soLuongMoi <= 0)
                    {
                        //giảm số lượng và cập nhật giá tiền
                        existingItem.SubItems[2].Text = (soLuongHienTai + soLuongMoi).ToString();
                        existingItem.SubItems[3].Text = (giaNuoc * int.Parse(existingItem.SubItems[2].Text)).ToString();
                        //nếu số lượng mới âm thì xóa luôn món
                        if ((soLuongHienTai + soLuongMoi) <= 0)
                        {
                            lsvBill.Items.Remove(TimMonTrongBill(tenNuoc));
                        }
                    }
                }
                else // Nếu không tồn tại, thêm mới nếu số lượng mới là lớn hơn 0
                {
                    int soLuongMoi = int.Parse(nmSLNuoc.Text);
                    if (soLuongMoi > 0)
                    {
                        ListViewItem lv2 = new ListViewItem(x.ToString());
                        lv2.SubItems.Add(tenNuoc);
                        lv2.SubItems.Add(soLuongMoi.ToString());
                        lv2.SubItems.Add((timGiaNuoc() * soLuongMoi).ToString());
                        lsvBill.Items.Add(lv2);
                        // Tăng giá trị của x lên 1 cho lần nhấn tiếp theo
                        x++;
                    }
                    // Nếu số lượng mới là 0 hoặc âm, không thêm mục mới
                }
            }
        }
        private void ThemDoAnVaoBill(string tenDoAn)
        {
            if (cboDoAn.Text == "")
            {
            }
            else if (lsvBill != null)
            {
                // Kiểm tra nếu món đã tồn tại trong lsvBill
                ListViewItem existingItem = TimMonTrongBill(tenDoAn);
                // Nếu tồn tại, kiểm tra số lượng mới
                if (existingItem != null)
                {
                    //// Nếu món đã tồn tại, cập nhật số lượng và thành tiền
                    int soLuongHienTai = int.Parse(existingItem.SubItems[2].Text);
                    int giaDoAn = timGiaDoAn();
                    // Nếu tồn tại, kiểm tra số lượng mới
                    int soLuongMoi = int.Parse(nmSLDoAn.Text);

                    if (soLuongMoi > 0)
                    {
                        // Tăng số lượng và cập nhật giá tiền
                        existingItem.SubItems[2].Text = (soLuongHienTai + soLuongMoi).ToString();
                        existingItem.SubItems[3].Text = (giaDoAn * int.Parse(existingItem.SubItems[2].Text)).ToString();
                    }
                    else if (soLuongMoi <= 0)
                    {
                        //giảm số lượng và cập nhật giá tiền
                        existingItem.SubItems[2].Text = (soLuongHienTai + soLuongMoi).ToString();
                        existingItem.SubItems[3].Text = (giaDoAn * int.Parse(existingItem.SubItems[2].Text)).ToString();
                        //nếu số lượng mới âm thì xóa luôn món
                        if ((soLuongHienTai + soLuongMoi) <= 0)
                        {
                            lsvBill.Items.Remove(TimMonTrongBill(tenDoAn));
                        }
                    }
                }
                else // Nếu không tồn tại, thêm mới nếu số lượng mới là lớn hơn 0
                {
                    int soLuongMoi = int.Parse(nmSLDoAn.Text);
                    if (soLuongMoi > 0)
                    {
                        ListViewItem lv2 = new ListViewItem(x.ToString());
                        lv2.SubItems.Add(tenDoAn);
                        lv2.SubItems.Add(soLuongMoi.ToString());
                        lv2.SubItems.Add((timGiaDoAn() * soLuongMoi).ToString());
                        lsvBill.Items.Add(lv2);
                        // Tăng giá trị của x lên 1 cho lần nhấn tiếp theo
                        x++;
                    }
                    // Nếu số lượng mới là 0 hoặc âm, không thêm mục mới
                }
            }
        }
        
        private ListViewItem TimMonTrongBill(string tenMon)// Hàm để tìm món trong lsvBill
        {
            if (lsvBill != null)
            {
                foreach (ListViewItem item in lsvBill.Items)
                {
                    if (item.SubItems[1].Text == tenMon)
                    {
                        return item; // Trả về món nếu đã tồn tại trong lsvBill
                    }
                }
            }
            return null; // Trả về null nếu món chưa tồn tại trong lsvBill
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (batThemMon == 1)//// Kiểm tra nếu đã chọn bàn
            {
                string maban = lsvBill.Name;
                string tenFile = $"{maban}.dat";
                ThemNuocVaoBill(cboNuoc.Text);
                ThemDoAnVaoBill(cboDoAn.Text);
                LuuDuLieuListViewXuongFile(tenFile);
                CapNhatTrangThaiBan(maban, "Có khách");//nếu có món trong bill thì có khách
                panelBan.Controls.Clear();// xóa các button bàn cũ 
                TaoVaHienThiDanhSachBan();// cập nhật lại trạng thái bàn
                txtTongTien.Text = TinhTongTien().ToString();//xuất tiền                                                                            
            }
            else
            {
                // Hiển thị thông báo nếu chưa chọn bàn
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CapNhatTrangThaiBan(string maBan, string trangThaiMoi)
        {
            List<CBan> danhSachBan = DocDanhSachBan();

            // Tìm bàn trong danh sách và cập nhật trạng thái mới
            CBan banCanCapNhat = danhSachBan.FirstOrDefault(ban => ban.IDBan == maBan);
            if (banCanCapNhat != null)
            {
                banCanCapNhat.TrangThaiBan = trangThaiMoi;
            }
            // Lưu danh sách bàn cập nhật xuống file
            GhiFileBan("dsban.dat", danhSachBan);
        }
        private int x = 1;// Biến toàn cục để lưu giữ giá trị của x
        private int y = 0;
        private int batThemMon = 0;
        public string mabandangchon;       
        public void BtnBan_Click(object sender, EventArgs e)  // tạo sự kiện click btn
        {            
            batThemMon = 1;// khi click vào bàn thì mới thêm món được
            txtTongTien.Text = "";
            cboMaGG.Text = "";
            // Kiểm tra và xóa ListView cũ nếu tồn tại
            if (lsvBill != null)
            {
                panelBill.Controls.Remove(lsvBill);
                lsvBill.Dispose();
                lsvBill = null;
            }
            // Lấy thông tin mã bàn từ Button
            string maBan = ((System.Windows.Forms.Button)sender).Name;
            mabandangchon = maBan;// a là mã bàn sẽ đc gắn qua cho frm hóa đơn 
            txtBanDangChon.Text = maBan;
            // Kiểm tra xem có dữ liệu của bàn trong file không 
            string tenFile = $"{maBan}.dat";
            if (File.Exists(tenFile))
            {
                // Đọc dữ liệu từ tệp tin và cập nhật ListView trong panelBill
                panelBill.Controls.Clear();// xóa listView cũ
                lsvBill = DocDuLieuListView(maBan);
                x = y + 1;//cộng thêm 1 giá trị stt
                HienThiListViewTrongPanelBill(lsvBill);
                txtTongTien.Text = TinhTongTien().ToString();               
            }
            // Kiểm tra xem đã có dữ liệu cho bàn này chưa
            else
            {
                x = 1;
                // Nếu chưa có dữ liệu, tạo một ListView rỗng trong panelBill
                TaoListViewRongChoBan(maBan);
            }
        }
        // Hàm tạo một ListView rỗng cho bàn chưa có dữ liệu
        private void TaoListViewRongChoBan(string maBan)
        {
            // Tạo một ListView mới và cấu hình            
            lsvBill = TaoLsvBill(maBan);
            // Hiển thị ListView trong panelBill
            HienThiListViewTrongPanelBill(lsvBill);//nè luôn
        }

        // Hàm hiển thị ListView trong panelBill
        private void HienThiListViewTrongPanelBill(System.Windows.Forms.ListView listView)
        {
            // Xóa tất cả các điều khiển con trong panelBill
            panelBill.Controls.Clear();
            // Đặt căn giữa cho tất cả các cột
            foreach (ColumnHeader column in lsvBill.Columns)
            {
                column.TextAlign = HorizontalAlignment.Center;
            }
            // Thêm ListView vào panelBill
            panelBill.Controls.Add(listView);
        }
        private void LuuDuLieuListViewXuongFile(string tenFile)//tenBan
        {
            try
            {
                // Kiểm tra xem tệp tin đã tồn tại hay không
                if (File.Exists(tenFile))
                {
                    // Nếu đã tồn tại, đọc dữ liệu cũ và ghi đè dữ liệu mới
                    List<string> duLieuCu = new List<string>(File.ReadAllLines(tenFile));
                    duLieuCu.RemoveAt(0); // Loại bỏ dòng chứa số lượng dòng cũ
                    // Ghi dữ liệu mới
                    using (StreamWriter writer = new StreamWriter(tenFile))
                    {
                        writer.WriteLine(lsvBill.Items.Count);

                        foreach (ListViewItem item in lsvBill.Items)
                        {
                            writer.WriteLine(item.SubItems[0].Text);  // STT
                            writer.WriteLine(item.SubItems[1].Text);  // Tên món
                            writer.WriteLine(item.SubItems[2].Text);  // Số lượng
                            writer.WriteLine(item.SubItems[3].Text);  // Giá
                        }

                        foreach (string dong in duLieuCu)
                        {
                            writer.WriteLine(dong);
                        }
                    }
                }
                else
                {
                    // Nếu tệp tin chưa tồn tại, ghi dữ liệu mới
                    using (StreamWriter writer = new StreamWriter(tenFile))
                    {
                        writer.WriteLine(lsvBill.Items.Count);

                        foreach (ListViewItem item in lsvBill.Items)
                        {
                            writer.WriteLine(item.SubItems[0].Text);  // STT
                            writer.WriteLine(item.SubItems[1].Text);  // Tên món
                            writer.WriteLine(item.SubItems[2].Text);  // Số lượng
                            writer.WriteLine(item.SubItems[3].Text);  // Giá
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
            }
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
                            lsvBill.Size = new System.Drawing.Size(400, 300); // Điều chỉnh kích thước nếu cần
                            lsvBill.Location = new System.Drawing.Point(10, 10); // Điều chỉnh vị trí nếu cần
                            lsvBill.View = View.Details;
                            lsvBill.FullRowSelect = true;

                            // Thêm cột vào ListView
                            lsvBill.Columns.Add("STT", 90);
                            lsvBill.Columns.Add("Tên Món", 200);
                            lsvBill.Columns.Add("Số Lượng", 90);
                            lsvBill.Columns.Add("Giá", 120);
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
                            if(i==soLuongDong-1)
                            {
                                y = Convert.ToInt32(stt);// chuyển int y sang string stt
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
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
        }
        private void btnXoaBill_Click(object sender, EventArgs e)
        {
            string tenFile = $"{mabandangchon}.dat";// a là mã bàn đã gán trong clickBan
            File.Delete(tenFile);// xóa file bàn đó
            panelBill.Controls.Clear();// xóa listView bàn cũ 
            CapNhatTrangThaiBan(mabandangchon, "Trống");//xuất bill và cập nhật bàn trống
            panelBan.Controls.Clear();// xóa các button bàn cũ 
            TaoVaHienThiDanhSachBan();
            txtTongTien.Text = "";
            txtBanDangChon.Text = "";
            cboNuoc.Text = "";
            cboDoAn.Text = "";
            nmSLNuoc.Value = 0;
            nmSLDoAn.Value = 0;
        }
    }
}