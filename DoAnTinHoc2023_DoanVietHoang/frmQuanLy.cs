using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DoAnTinHoc2023_DoanVietHoang
{
    public partial class frmQuanLy : Form
    {
        private List<CNuoc> dsnuoc = new List<CNuoc>();
        private List<CDoAn> dsdoan = new List<CDoAn>();
        private List<CBan> dsban = new List<CBan>();
        public frmQuanLy()
        {
            InitializeComponent();
        }
        #region "quản lý nước "
        private void hienthiDSNuoc()
        {
            dgvNuoc.DataSource = dsnuoc.ToList();
        }
        private CNuoc timNuoc(string ma)
        {
            foreach (CNuoc n in dsnuoc)
            {
                if (n.IDNuoc == ma)
                    return n;
            }
            return null;
        }
        private void btnThemNuoc_Click(object sender, EventArgs e)
        {
            CNuoc n = new CNuoc();
            if ((txtIDNuoc.Text == "") || (txtTenNuoc.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                n.IDNuoc = txtIDNuoc.Text;
                n.TenNuoc = txtTenNuoc.Text;
                n.GiaNuoc = nmGiaNuoc.Text;
                if (timNuoc(n.IDNuoc) == null)
                {
                    dsnuoc.Add(n);
                    SapSepNuoc();
                    hienthiDSNuoc();
                    dsnuoc = GhiFileNuoc("dsnuoc.dat", dsnuoc);
                }
                else
                {
                    MessageBox.Show("Trùng ID nước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaNuoc_Click(object sender, EventArgs e)
        {
            CNuoc n = timNuoc(txtIDNuoc.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy ID nước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dsnuoc.Remove(n);
                SapSepNuoc();
                hienthiDSNuoc();
                dsnuoc = GhiFileNuoc("dsnuoc.dat", dsnuoc);
            }
        }

        private void btnSuaNuoc_Click(object sender, EventArgs e)
        {
            CNuoc n = timNuoc(txtIDNuoc.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy ID nước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtTenNuoc.Text != "")
                {
                    n.IDNuoc = txtIDNuoc.Text;
                    n.TenNuoc = txtTenNuoc.Text;
                    n.GiaNuoc = nmGiaNuoc.Text;
                    SapSepNuoc();
                    hienthiDSNuoc();
                    dsnuoc = GhiFileNuoc("dsnuoc.dat", dsnuoc);
                }
                else
                {
                    MessageBox.Show("Chưa nhập tên nước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public List<CNuoc> GhiFileNuoc(string tenFile, List<CNuoc> danhSachNuoc)
        {
            try
            {
                // Mở tệp tin để ghi dữ liệu
                using (StreamWriter sw = new StreamWriter(tenFile))
                {
                    foreach (CNuoc nuoc in danhSachNuoc)
                    {
                        // Ghi thông tin của mỗi nước vào tệp tin
                        sw.WriteLine($"{nuoc.IDNuoc}");
                        sw.WriteLine($"{nuoc.TenNuoc}");
                        sw.WriteLine($"{nuoc.GiaNuoc}");

                        sw.WriteLine(); // Tạo một dòng trống để phân biệt giữa các nước
                    }
                }
                return danhSachNuoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu vào tệp {tenFile}: {ex.Message}");
                return null;
            }
        }
        public List<CNuoc> DocFileNuoc(string tenFile)
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

                            // Tạo đối tượng hocSinh và thêm vào danh sách
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

        private void txtTimNuoc_TextChanged(object sender, EventArgs e)
        {
            string timTenNuoc = txtTimNuoc.Text;
            if (!string.IsNullOrWhiteSpace(timTenNuoc))
            {
                dgvNuoc.DataSource = null;
                dgvNuoc.DataSource = dsnuoc;
                List<CNuoc> tmp = new List<CNuoc>();
                for (int i = 0; i < dgvNuoc.Rows.Count; i++)
                {
                    if (dgvNuoc.Rows[i].Cells[1].Value.ToString()//ToLower k phân biệt hoa thường
                        .ToLower().Contains(timTenNuoc.ToLower()))
                        tmp.Add(dsnuoc[i]);
                }
                dgvNuoc.DataSource = null;
                dgvNuoc.DataSource = tmp;
            }
            else
            {
                dgvNuoc.DataSource = null;
                dgvNuoc.DataSource = dsnuoc;
            }
        }
        #endregion
        // -------------------------Do An-----------------------
        #region "quản đồ ăn "
        private void hienthiDSDoAn()
        {
            dgvDoAn.DataSource = dsdoan.ToList();
        }
        private CDoAn timDoAn(string ma)
        {
            foreach (CDoAn a in dsdoan)
            {
                if (a.IDDA == ma)
                {
                    return a;
                }
            }
            return null;
        }
        private void btnThemDA_Click(object sender, EventArgs e)
        {
            CDoAn a = new CDoAn();
            if ((txtIDDA.Text == "") || (txtTenDA.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                a.IDDA = txtIDDA.Text;
                a.TenDA = txtTenDA.Text;
                a.GiaDA = mnGiaDA.Text;
                if (timDoAn(a.IDDA) == null)
                {
                    dsdoan.Add(a);
                    SapSepDoAn();
                    hienthiDSDoAn();
                    dsdoan = GhiFileDoAn("dsdoan.dat", dsdoan);
                }
                else
                {
                    MessageBox.Show("Trùng ID đồ ăn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoaDA_Click(object sender, EventArgs e)
        {
            CDoAn n = timDoAn(txtIDDA.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy ID đồ ăn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dsdoan.Remove(n);
                SapSepDoAn();
                hienthiDSDoAn();
                dsdoan = GhiFileDoAn("dsdoan.dat", dsdoan);
            }
        }

        private void btnSuaDA_Click(object sender, EventArgs e)
        {
            CDoAn n = timDoAn(txtIDDA.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy ID đồ ăn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtTenDA.Text != "")
                {
                    n.IDDA = txtIDDA.Text;
                    n.TenDA = txtTenDA.Text;
                    n.GiaDA = mnGiaDA.Text;
                    SapSepDoAn();
                    hienthiDSDoAn();
                    dsdoan = GhiFileDoAn("dsdoan.dat", dsdoan);
                }
                else
                {
                    MessageBox.Show("Chưa nhập tên đồ ăn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtTimDA_TextChanged(object sender, EventArgs e)
        {
            string timTenDoAn = txtTimDA.Text;
            if (!string.IsNullOrWhiteSpace(timTenDoAn))
            {
                dgvDoAn.DataSource = null;
                dgvDoAn.DataSource = dsdoan;
                List<CDoAn> tmp = new List<CDoAn>();
                for (int i = 0; i < dgvDoAn.Rows.Count; i++)
                {
                    if (dgvDoAn.Rows[i].Cells[1].Value.ToString()//ToLower k phân biệt hoa thường
                        .ToLower().Contains(timTenDoAn.ToLower()))
                        tmp.Add(dsdoan[i]);
                }
                dgvDoAn.DataSource = null;
                dgvDoAn.DataSource = tmp;
            }
            else
            {
                dgvDoAn.DataSource = null;
                dgvDoAn.DataSource = dsdoan;
            }
        }
        public List<CDoAn> GhiFileDoAn(string tenFile, List<CDoAn> danhSachDoAn)
        {
            try
            {
                // Mở tệp tin để ghi dữ liệu
                using (StreamWriter sw = new StreamWriter(tenFile))
                {
                    foreach (CDoAn doan in danhSachDoAn)
                    {
                        // Ghi thông tin của mỗi món vào tệp tin
                        sw.WriteLine($"{doan.IDDA}");
                        sw.WriteLine($"{doan.TenDA}");
                        sw.WriteLine($"{doan.GiaDA}");

                        sw.WriteLine(); // Tạo một dòng trống để phân biệt giữa các đồ ăn
                    }
                }
                return danhSachDoAn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu vào tệp {tenFile}: {ex.Message}");
                return null;
            }           
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

        private void dgvNuoc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CNuoc n = new CNuoc();
            txtIDNuoc.Text = dgvNuoc.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNuoc.Text = dgvNuoc.Rows[e.RowIndex].Cells[1].Value.ToString();
            nmGiaNuoc.Text = dgvNuoc.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvDoAn_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            CDoAn n = new CDoAn();
            txtIDDA.Text = dgvDoAn.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenDA.Text = dgvDoAn.Rows[e.RowIndex].Cells[1].Value.ToString();
            mnGiaDA.Text = dgvDoAn.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        #endregion
        //quan ly ban 
        #region "quản lý bàn "
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            CBan n = new CBan();
            if ((txtIDBan.Text == "") || (cboTrangThaiB.Text == ""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                n.IDBan = txtIDBan.Text;
                n.TrangThaiBan = cboTrangThaiB.Text;
                if (timBan(n.IDBan) == null)
                {
                    dsban.Add(n);
                    SapSepBan();
                    hienthiDSBan();
                    dsban = GhiFileBan("dsban.dat", dsban);
                }
                else
                {
                    MessageBox.Show("Trùng ID bàn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void hienthiDSBan()
        {
            dgvBan.DataSource = dsban.ToList();
        }
        private CBan timBan(string ma)
        {
            foreach (CBan n in dsban)
            {
                if (n.IDBan == ma)
                    return n;
            }
            return null;
        }
        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            CBan n = timBan(txtIDBan.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy id bàn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dsban.Remove(n);
                SapSepBan();
                hienthiDSBan();
                dsban = GhiFileBan("dsban.dat", dsban);
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            CBan n = timBan(txtIDBan.Text);
            if (n == null)
            {
                MessageBox.Show("Không tìm thấy id bàn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                n.IDBan = txtIDBan.Text;
                n.TrangThaiBan = cboTrangThaiB.Text;
                SapSepBan();
                hienthiDSBan();
                dsban = GhiFileBan("dsban.dat", dsban);

            }
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
        public List<CBan> DocFileBan(string tenFile)
        {           
            List<CBan> danhSachBan = new List<CBan>();

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
                    MessageBox.Show($"Tệp {tenFile} không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu từ tệp {tenFile}: {ex.Message}");
            }

            return danhSachBan;
        }
        #endregion

        private void frmQuanLy_Load_1(object sender, EventArgs e)
        {
            dgvDoAn.AutoGenerateColumns = false;
            dgvNuoc.AutoGenerateColumns = false;
            dgvBan.AutoGenerateColumns = false;
            dsnuoc = DocFileNuoc("dsnuoc.dat");
            // Sắp xếp lại theo cột "Điểm"
            SapSepNuoc();// sắp xếp theo giá nước 

            dsdoan = DocFileDoAn("dsdoan.dat");
            // Sắp xếp lại theo cột "Điểm"
            SapSepDoAn();// sắp xếp theo giá đồ ăn 

            dsban = DocFileBan("dsban.dat");
            // Sắp xếp lại theo cột "Điểm"
            SapSepBan();// sắp xếp theo mã bàn
            hienthiDSBan();
        }

        private void txtTimBan_TextChanged(object sender, EventArgs e)
        {
            string timIDBan = txtTimIDBan.Text;
            if (!string.IsNullOrWhiteSpace(timIDBan))
            {
                dgvBan.DataSource = null;
                dgvBan.DataSource = dsban;
                List<CBan> tmp = new List<CBan>();
                for (int i = 0; i < dgvBan.Rows.Count; i++)
                {
                    if (dgvBan.Rows[i].Cells[0].Value.ToString()
                        .Contains(timIDBan.ToLower()))
                        tmp.Add(dsban[i]);
                }
                dgvBan.DataSource = null;
                dgvBan.DataSource = tmp;
            }
            else
            {
                dgvBan.DataSource = null;
                dgvBan.DataSource = dsban;
            }
        }


        private void SapSepNuoc()// theo giá
        {
            //OrderBy tăng dần 
            //OrderByDescending giảm dần
            dsnuoc = dsnuoc.OrderBy(nuoc => nuoc.GiaNuoc).ToList();
            // Cập nhật lại dữ liệu trong DataGridView
            dgvNuoc.DataSource = null;
            dgvNuoc.DataSource = dsnuoc;
        }
        private void SapSepDoAn()// theo giá
        {
            //OrderBy tăng dần 
            dsdoan = dsdoan.OrderBy(doan => doan.GiaDA).ToList();
            // Cập nhật lại dữ liệu trong DataGridView
            dgvDoAn.DataSource = null;
            dgvDoAn.DataSource = dsdoan;
        }
        private void SapSepBan()// theo mã
        {
            //OrderBy tăng dần 
            dsban = dsban.OrderBy(ban => int.Parse(ban.IDBan)).ToList();
            // Cập nhật lại dữ liệu trong DataGridView
            dgvBan.DataSource = null;
            dgvBan.DataSource = dsban;
        }
        private void dgvBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CBan n = new CBan();
            txtIDBan.Text = dgvBan.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboTrangThaiB.Text = dgvBan.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void tabNuoc_Click(object sender, EventArgs e)
        {

        }
    }
}
