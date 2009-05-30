using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class GiaoVienDTO
    {
        #region Attributes
        string m_magv;
        string m_hoten;
        string m_monday;
        #endregion Attributes

        #region Properties
        public string MaGV
        {
            get { return m_magv; }
            set { m_magv = value; }
        }
        public string HoTen
        {
            get { return m_hoten; }
            set { m_hoten = value; }
        }
         public string MonDay
        {
            get { return m_monday; }
            set { m_monday = value; }
        }
        #endregion Properties
        public GiaoVienDTO()
        {
            m_magv = "";
            m_hoten = "";
            m_monday ="";
        }

    }
}
