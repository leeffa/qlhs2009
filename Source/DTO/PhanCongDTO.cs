using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhanCongDTO
    {
      
        public PhanCongDTO()
        {
            id = 0;
            maGV = "";
            maLop = "";
        }
        #region Attributes
        int id;
        String maGV;
        String maLop;
        #endregion Attributes

        #region Properties
        public int ID
        {
            get { return id; }
            set { value = id; }
        }
        public string MaGV
        {
            get { return maGV; }
            set { maGV = value; }
        }
        public string MaLop
        {
            get { return maLop; }
            set { maLop = value; }
        }
        #endregion Properties


    }
}
