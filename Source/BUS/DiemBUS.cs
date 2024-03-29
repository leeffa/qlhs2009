using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;
namespace BUS
{
    public class DiemBUS
    {
        public static bool InSert_Diem(DiemDTO d)
        {
            if (d.Diem15 < 0 || d.Diem15 > 10 || d.Diem1T < 0 || d.Diem1T > 10 || d.DiemThi < 0 && d.DiemThi > 10
                || d.DiemTB < 0 || d.DiemTB > 10)
                throw new Exception("Điểm phải thuộc khoảng 0 đến 10");
            return DiemDAO.InSert_Diem(d);
        }
        //updating
        public static bool Update_Diem(DiemDTO d)
        {
            if (d.Diem15 < 0 || d.Diem15 > 10 || d.Diem1T < 0 || d.Diem1T > 10 || d.DiemThi < 0 && d.DiemThi > 10
              || d.DiemTB < 0 || d.DiemTB > 10)
                throw new Exception("Điểm phải thuộc khoảng 0 đến 10");

            return DiemDAO.Update_Diem(d);
        }
        // Deleting
        public static bool Delete_IDDiem(String maHS, String maMH)
        {
            return DiemDAO.Delete_IDDiem(maHS, maMH);
        }
        public static DataTable SelectAll()
        {
            return DiemDAO.SelectAll();
        }
        public static DiemDTO SelectID(String maHS, String maMH)
        {
            return DiemDAO.SelectID(maHS,maMH);
        }

    }
}
