using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class ChuongTrinhBUS
    {
        public static bool Insert(ChuongTrinhDTO ct)
        {
            ChuongTrinhDAO.Insert(ct);
            return true;
        }
        public static bool Update(ChuongTrinhDTO ct)
        {
            ChuongTrinhDTO temp = ChuongTrinhDAO.SelectByID(ct.MaKH);
            if (temp.MaKH == "")
                return false;
            ChuongTrinhDAO.Update(ct);
            return true;
        }
        public static bool Delete(string ma)
        {
            ChuongTrinhDTO temp = ChuongTrinhDAO.SelectByID(ma);
            if (temp.MaKH == "")
                return false;
            ChuongTrinhDAO.Delete(ma);
            return true;
        }
        public static IList SelectAll()
        {
            return ChuongTrinhDAO.SelectAll();
        }
    }
}
