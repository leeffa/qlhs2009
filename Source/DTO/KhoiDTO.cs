using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class KhoiDTO
    {
        #region Attributes
        string m_makhoi;
        string m_tenkhoi;
        #endregion Attributes

        #region Properties
        public string MaKhoi
        {
            get { return m_makhoi; }
            set { m_makhoi = value; }
        }
        public string TenKhoi
        {
            get { return m_tenkhoi; }
            set { m_tenkhoi = value; }
        }
        #endregion Properties
        public KhoiDTO()
        {
            m_makhoi = "";
            m_tenkhoi = "";
        }
    }
}
