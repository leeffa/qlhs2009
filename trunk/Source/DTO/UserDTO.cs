using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UserDTO
    {
        #region Attributes
        string m_id;
        string m_pass;
        int m_loaiuser;
        #endregion Attributes

        #region Properties
        public string ID
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string Pass
        {
            get { return m_pass; }
            set { m_pass = value; }
        }
        public int LoaiUser
        {
            get { return m_loaiuser; }
            set { m_loaiuser = value; }
        }
        #endregion Properties
        public UserDTO()
        {
            m_id = "";
            m_pass = "";
            m_loaiuser = 0;
            //Loaiuser: 0--> mới đăng ký, chưa được ký hoạt.
            //  :1-->Học Sinh
            //  :2-->Giáo Viên
            //  :3-->Admin
        }
    }
}
