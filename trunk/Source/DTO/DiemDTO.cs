using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DiemDTO
    {
        #region Attributes
        string m_mahs;
        string m_mamh;
        float m_diem15;
        float m_diem1T;
        float m_diemThi;
        float m_diemTB;
        #endregion Attributes

        #region Properties
        public string MaHS
        {
            get { return m_mahs; }
            set { m_mahs = value; }
        }
        public string MaMH
        {
            get { return m_mamh; }
            set { m_mamh = value; }
        }
        public float Diem15
        {
            get { return m_diem15; }
            set { m_diem15= value; }
        }
        public float Diem1T
        {
            get { return m_diem1T; }
            set { m_diem1T = value; }
        }
        public float DiemThi
        {
            get { return m_diemThi; }
            set { m_diemThi = value; }
        }
        public float DiemTB
        {
            get { return m_diemTB; }
            set { m_diemTB = value; }
        }


        #endregion Properties
        public DiemDTO()
        {
            m_mahs = "";
            m_mamh = "";
            m_diem15 = 0;
            m_diem1T = 0;
            m_diemThi = 0;
            m_diemTB = 0;
        }

    }
}
