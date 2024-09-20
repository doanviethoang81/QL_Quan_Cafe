using System;

namespace DoAnTinHoc2023_DoanVietHoang
{
    [Serializable]
    public class CTaiKhoan
    {
        private string m_tendangnhap, m_tenhienthi, m_matkhau, m_loaitaikhoan;

        public string TenDangNhap { get => m_tendangnhap; set => m_tendangnhap = value; }
        public string TenHienThi { get => m_tenhienthi; set => m_tenhienthi = value; }
        public string MatKhau { get => m_matkhau; set => m_matkhau = value; }
        public string LoaiTaiKhoan { get => m_loaitaikhoan; set => m_loaitaikhoan = value; }
        public CTaiKhoan() {
        }
        public CTaiKhoan(string tendangnhap, string tenhienthi, string matkhau, string loaitaikhoan)
        {
            m_tendangnhap = tendangnhap;
            m_tenhienthi = tenhienthi;
            m_matkhau = matkhau;
            m_loaitaikhoan = loaitaikhoan;
        }

    }
}
