using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using DTO;
using DAO;

namespace BUS
{
    public class LopHocBUS
    {
        public IList LayDanhSach()
        {
            LopHocDAO lDao = new LopHocDAO();
            IList ds;
            ds = lDao.LayDanhSach();
            return ds;
        }

        public IList LayDanhSach(string makhoi)
        {
            LopHocDAO lDao = new LopHocDAO();
            IList ds;
            ds = lDao.LayDanhSach(makhoi);
            return ds;
        }

        public void Them(LopHocDTO ldto)
        {
            LopHocDAO lDao = new LopHocDAO();
            lDao.Them(ldto);
        }

        public void Xoa(string malop)
        {
            LopHocDAO lDao = new LopHocDAO();
            lDao.Xoa(malop);
        }

        public void Sua(LopHocDTO ldto)
        {
            LopHocDAO lDao = new LopHocDAO();
            lDao.Sua(ldto);
        }
    }
}
