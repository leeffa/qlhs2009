using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;

namespace DAO
{
    public class Dao
    {
        public static DataTable Get_DiemInfo(String maLop)
        {
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select hs.MaHS , hs.HoTen, d.Diem15,d.Diem1T,d.DiemThi,d.DiemTB from HOCSINH hs, DIEM d where hs.MaHS = d.MaHS and hs.MaLop= '" + maLop + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
