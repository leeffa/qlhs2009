using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;
using System.Collections;
namespace BUS
{
    public  class DayLopBUS
    {
        //viet ham insert
        public static bool Them_Day_Lop(DayLopDTO gvdto)
        {
            //goi phuong thuc Them_Day_Lop cua DAO
            return  DayLopDAO.Them_Day_Lop(gvdto);
           
        }
        //lay danh sach day lop theo mon hoc
        public static  IList Lay_Danh_Sach_Day_Lop_Theo_Mon_Hoc(string ma_mon_hoc)

        {
            return DayLopDAO.Lay_DS_Day_Lop_Theo_Mon_Hoc(ma_mon_hoc);
        } 
        //cap nhat gv
        public static bool Cap_Nhat(DayLopDTO gvdto)
        {
            return DayLopDAO.Cap_Nhat(gvdto);
        }
        //xoa gv
        public static bool Xoa(DayLopDTO gvdto)
        {
            return DayLopDAO.Xoa(gvdto);
        }
        //tim gv khi biet MaGV
        public static DayLopDTO Tra_Cuu_MaGV(DayLopDTO gvdto)
        {
            return DayLopDAO.Tra_Cuu_MaGV(gvdto);
        }
    }
}
