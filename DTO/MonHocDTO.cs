using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MonHocDTO
    {
        #region Attributes
        string m_mamh;
        string m_tenmh;
        #endregion Attributes

        #region Properties
        public string MaMH
        {
            get { return m_mamh; }
            set { m_mamh = value; }
        }
        public string TenMH
        {
            get { return m_tenmh; }
            set { m_tenmh = value; }
        }
        #endregion Properties
        public MonHocDTO()
        {
            m_mamh = "";
            m_tenmh = "";
        }
    }
}
