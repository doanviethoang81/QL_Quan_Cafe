using System;

namespace DoAnTinHoc2023_DoanVietHoang
{
    [Serializable]
    public class CNuoc
    {
        private string m_idnuoc, m_tennuoc;
        private string m_gia;

        public string IDNuoc { get => m_idnuoc; set => m_idnuoc = value; }
        public string TenNuoc { get => m_tennuoc; set => m_tennuoc = value; }
        public string GiaNuoc { get => m_gia; set => m_gia = value; }
        public CNuoc() { }
        public CNuoc(string nuoc, string tennuoc, string gianuoc)
        {
            m_idnuoc = nuoc;
            m_tennuoc = tennuoc;
            m_gia = gianuoc;
        }
    }
}
