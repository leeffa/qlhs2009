using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Collections;
namespace BUS
{
   public   class  HocSinhBUS
    {
       public static bool Insert(HocSinhDTO hs)
       {
           HocSinhDTO test=null;
            test = HocSinhDAO.SelectByID(hs.MaHS);
            if (test.MaHS!="")
                return false;
            HocSinhDAO.Insert(hs);
            return true;
       }
       public static bool Delete(string ma)
       {
           HocSinhDTO test = null;
           test = HocSinhDAO.SelectByID(ma);
           if (test.MaHS == "")
               return false;
         
           HocSinhDAO.Delete(ma);
           return true;
       }
       public static bool Update(HocSinhDTO hs)
       {
           HocSinhDTO test = null;
           test = HocSinhDAO.SelectByID(hs.MaHS);
           if (test.MaHS == "")
               return false;
           HocSinhDAO.Update(hs);
           return true;
       }
       public static IList SelectAll()
       {
           return HocSinhDAO.SelectAll();
       }
    }
}
