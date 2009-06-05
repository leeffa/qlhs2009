using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;
using DTO;
namespace BUS
{
    public class KhoiBUS
    {
        public static bool InSert_Khoi(KhoiDTO khoi)
        {
            return KhoiDAO.InSert_Khoi(khoi);
        }
        //updating
        public static bool Update_Khoi(KhoiDTO khoi)
        {
            return KhoiDAO.Update_Khoi(khoi);
        }
        // Deleting
        public static bool Delete_IDKhoi(String ID)
        {
            return KhoiDAO.Delete_IDKhoi(ID);
        }
        public static DataTable SelectAll()
        {
            return KhoiDAO.SelectAll();
        }
        public static KhoiDTO SelectID(String ID)
        {
            return KhoiDAO.SelectID(ID);
        }

    }
}
