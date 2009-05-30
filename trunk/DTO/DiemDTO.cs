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
        int m_diem;
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
        public int Diem
        {
            get { return m_diem; }
            set { m_diem = value; }
        }
        #endregion Properties
        public DiemDTO()
        {
            m_mahs = "";
            m_mamh = "";
            m_diem = 0;
        }

    }
}
