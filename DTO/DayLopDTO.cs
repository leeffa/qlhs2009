using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DayLopDTO
    {
        #region Attributes
        string m_magv;
        string m_malop;
        #endregion Attributes

        #region Properties
        public string MaGV
        {
            get { return m_magv; }
            set { m_magv = value; }
        }
        public string MaLop
        {
            get { return m_malop; }
            set { m_malop = value; }
        }
        #endregion Properties
        public DayLopDTO()
        {
            m_magv = "";
            m_malop = "";
        }
    }
}
