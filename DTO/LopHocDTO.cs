using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LopHocDTO
    {
        #region Attributes
        string m_malop;
        string m_tenlop;
        string m_makhoi;
        #endregion Attributes

        #region Properties
        public string MaLop
        {
            get { return m_malop; }
            set { m_malop = value; }
        }
        public string TenLop
        {
            get { return m_tenlop; }
            set { m_tenlop = value; }
        }
         public string MaKhoi
        {
            get { return m_makhoi; }
            set { m_makhoi = value; }
        }
        #endregion Properties
        public LopHocDTO()
        {
            m_malop = "";
            m_tenlop = "";
            m_makhoi ="";
        }

    }
}
