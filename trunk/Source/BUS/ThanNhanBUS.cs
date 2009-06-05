using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Collections;
namespace BUS
{
   public  class ThanNhanBUS
    {
       public static bool Insert(ThanNhanDTO tn)
       {
           ThanNhanDTO temp = ThanNhanDAO.SelectByID(tn.Ma);
           if (temp.Ma != "")
               return false;
           ThanNhanDAO.Insert(tn);
           return true;
       }
       public static IList SelectAll()
       {
           return ThanNhanDAO.SelectAll();
       }
       public static bool Delete(string ma)
       {
           ThanNhanDTO temp = ThanNhanDAO.SelectByID(ma);
           if (temp.Ma == "")
               return false;
           ThanNhanDAO.Delete(ma);
           return true;
       }
       public static bool Update(ThanNhanDTO tn)
       {
           ThanNhanDTO temp = ThanNhanDAO.SelectByID(tn.Ma);
           if (temp.Ma == "")
               return false;
           ThanNhanDAO.Update(tn);
           return true;
       }
    }
}
