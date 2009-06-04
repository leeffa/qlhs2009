using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;
using System.Collections;
namespace BUS
{
    public  class GiaoVienBUS
    {
        //viet ham insert
        public static bool Them_Giao_Vien(GiaoVienDTO gvdto)
        {
            //goi phuong thuc Them_Giao_Vien cua DAO
            return  GiaoVienDAO.Them_Giao_Vien(gvdto);
           
        }
        //lay danh sach day lop theo mon hoc
        public static  IList Lay_Danh_Sach_Giao_Vien_Theo_Mon_Hoc(string ma_mon_hoc)

        {
            return GiaoVienDAO.Lay_DS_Giao_Vien_Theo_Mon_Hoc(ma_mon_hoc);
        } 
        //cap nhat gv
        public static bool Cap_Nhat(GiaoVienDTO gvdto)
        {
            return GiaoVienDAO.Cap_Nhat(gvdto);
        }
        //xoa gv
        public static bool Xoa(GiaoVienDTO gvdto)
        {
            return GiaoVienDAO.Xoa(gvdto);
        }
        //tim gv khi biet MaGV
        public static GiaoVienDTO Tra_Cuu_MaGV(GiaoVienDTO gvdto)
        {
            return GiaoVienDAO.Tra_Cuu_MaGV(gvdto);
        }
    }
}
