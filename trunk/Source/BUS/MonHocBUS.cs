using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Collections;
namespace BUS
{
    public class MonHocBUS
    {
        public static bool Insert(MonHocDTO mh)
        {
            MonHocDTO temp = MonHocDAO.SelectByID(mh.MaMH);
            if (temp.MaMH != "")
                return false;
            MonHocDAO.Insert(mh);
            return true;
        }
        public static bool Update(MonHocDTO mh)
        {
            MonHocDTO temp = MonHocDAO.SelectByID(mh.MaMH);
            if (temp.MaMH == "")
                return false;
            MonHocDAO.Update(mh);
            return true;
        }
        public static bool Delete(string ma)
        {
            MonHocDTO temp = MonHocDAO.SelectByID(ma);
            if (temp.MaMH == "")
                return false;
            MonHocDAO.Delete(ma);
            return true;
        }
        public static IList SelectAll()
        { return MonHocDAO.SelectAll(); }
    }
}
