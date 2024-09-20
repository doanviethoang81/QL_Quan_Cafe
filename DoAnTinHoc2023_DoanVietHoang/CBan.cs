using System;

namespace DoAnTinHoc2023_DoanVietHoang
{
    [Serializable]
    public class CBan
    {
        private string m_idban;
        private string m_trangthai;

        public string IDBan { get => m_idban; set => m_idban = value; }
        public string TrangThaiBan { get => m_trangthai; set => m_trangthai = value; }

        public CBan()
        {

        }
        public CBan(string idban, string trangthai)
        {
            m_idban = idban;
            m_trangthai = trangthai;
        }
    }
}
