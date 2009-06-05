using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class HocSinhDTO
    {
        #region Attributes
        string m_mahs;
        string m_hoten;
        DateTime m_ngaysinh;      
        string m_diachi;
        string m_hanhkiem;
        int m_sodienthoai;
        DateTime m_ngaynhaptruong;
        string m_hinhanh;
        string m_malop;
       
        #endregion Attributes

        #region Properties
        public string MaHS
        {
            get { return m_mahs; }
            set { m_mahs = value; }
        }
        public string HoTen
        {
            get { return m_hoten; }
            set { m_hoten = value; }
        }
        public DateTime NgaySinh
        {
            get { return m_ngaysinh; }
            set { m_ngaysinh = value; }
        }
        public string DiaChi
        {
            get { return m_diachi; }
            set { m_diachi = value; }
        }
        public string HanhKiem
        {
            get { return m_hanhkiem; }
            set { m_hanhkiem = value; }
        }
        public int SoDienThoai
        {
            get { return m_sodienthoai; }
            set { m_sodienthoai = value; }
        }
        public DateTime NgayNhapTruong
        {
            get { return m_ngaynhaptruong; }
            set { m_ngaynhaptruong = value; }
        }
        public string HinhAnh
        {
            get { return m_hinhanh; }
            set { m_hinhanh = value; }
        }
         public string MaLop
        {
            get { return m_malop; }
            set { m_malop = value; }
        }
        #endregion Properties
        public HocSinhDTO()
        {
            m_mahs = "";
            m_hoten = "";
            m_ngaysinh = new DateTime(1/1/1);      
            m_diachi = "";
            m_hanhkiem = "";
            m_sodienthoai = 0;
            m_ngaynhaptruong = new DateTime(1/1/1);
            m_hinhanh = "";
            m_malop = "";
        }
    }
}
