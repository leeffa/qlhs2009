using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;
using DTO;
namespace BUS
{
    public class Bus
    {
       
        public static DataTable Get_DiemInfo(String maLop)
        {
            return Dao.Get_DiemInfo(maLop);
        }
        public static UserDTO KiemTraDangNhap(String user,String pass)
        {
            return Dao.KiemTraDangNhap(user, pass);
        }
        public static DataTable SelectAll_MonHoc_byIDGiaoVien(String ID)
        {
            if (ID.Contains("\\") || ID.Contains("/") || ID.Contains("*") || ID.Contains("|"))
            {
                throw new Exception("Mã Giáo Viên không hợp lệ.");
            }
            return Dao.SelectAll_MonHoc_byIDGiaoVien(ID);
        }
        public static bool KiemTraDay(String MaGV, String maLop)
        {
            return Dao.KiemTraDay(MaGV,maLop);
        }
    }
}
