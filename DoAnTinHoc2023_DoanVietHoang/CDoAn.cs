using System;

namespace DoAnTinHoc2023_DoanVietHoang
{
    [Serializable]
    public class CDoAn
    {
        private string m_iddoan, m_tendoan;
        private string m_giadoan;

        public string IDDA { get => m_iddoan; set => m_iddoan = value; }
        public string TenDA { get => m_tendoan; set => m_tendoan = value; }
        public string GiaDA { get => m_giadoan; set => m_giadoan = value; }
        public CDoAn(string iddoan, string tendoan, string giadoan)
        {
            m_iddoan = iddoan;
            m_tendoan = tendoan;
            m_giadoan = giadoan;
        }
        public CDoAn() { }
    }
}
