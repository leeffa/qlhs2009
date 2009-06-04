using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class PhanCongBUS
    {
        public static bool Insert(PhanCongDTO pc)
        {
            PhanCongDAO.Insert(pc);     
            return true;
        }
        public static bool Update(PhanCongDTO pc)
        {
            PhanCongDTO temp = PhanCongDAO.SelectByID(pc.MaGV);
            if (temp.MaGV == "")
                return false;
            PhanCongDAO.Update(pc);
            return true;
        }
        public static bool Delete(string ma)
        {
            PhanCongDTO temp = PhanCongDAO.SelectByID(ma);
            if (temp.MaGV == "")
                return false;
            PhanCongDAO.Delete(ma);
            return true;
        }
        public static IList SelectAll()
        {
            return PhanCongDAO.SelectAll();
        }
    }
}
