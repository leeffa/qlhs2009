using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;
using DTO;
namespace BUS
{
    public class LopBUS
    {
        public static bool InSert_LopHoc(LopHocDTO lop)
        {
             return LopDAO.InSert_LopHoc(lop);
        }
        //updating
        public static bool Update_LopHoc(LopHocDTO lop)
        {
            return LopDAO.Update_LopHoc(lop);
        }
        // Deleting
        public static bool Delete_IDLopHoc(String maLop)
        {
            return LopDAO.Delete_IDLopHoc(maLop);
        }
        public static DataTable SelectAll()
        {
            return LopDAO.SelectAll();
        }
        public static LopHocDTO SelectID(String ID)
        {
            return LopDAO.SelectID(ID);
        }
        public static DataTable Select_byKhoi(String khoi)
        {
           
            return LopDAO.Select_byKhoi(khoi);
        }
    }
}
