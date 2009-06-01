using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;

namespace BUS
{
    public class Bus
    {
       
        public static DataTable Get_DiemInfo(String maLop)
        {
            return Dao.Get_DiemInfo(maLop);
        }

    }
}
