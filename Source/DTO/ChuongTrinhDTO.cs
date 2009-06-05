using System;
using System.Collections.Generic;
using System.Text;
using DTO;
namespace DTO
{
    public class ChuongTrinhDTO
    {
            public ChuongTrinhDTO()
        {
            id = 0;
            maKH = "";
            maMon = "";
        }
        #region Attributes
        int id;
        String maKH;
        String maMon;
        #endregion Attributes

        #region Properties
        public int ID
        {
            get { return id; }
            set { value = id; }
        }
        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        public string MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }
        #endregion Properties
    }
}
