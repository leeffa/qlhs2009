using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ThanNhanDTO
    {
        
        #region Attributes
        string m_ma;
        string m_mahs;
        string m_hoten;
        string m_quanhe;
        #endregion Attributes

        #region Properties
        public string Ma
        {
            get { return m_ma; }
            set { m_ma = value; }
        }
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
        public string QuanHe
        {
            get { return m_quanhe; }
            set { m_quanhe = value; }
        }
        #endregion Properties
        public ThanNhanDTO()
        {
            m_ma = "";
            m_mahs = "";
            m_hoten = "";
            m_quanhe = "";
        }
    }
}
