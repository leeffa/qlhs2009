using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DTO;
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
        public static UserDTO KiemTraDangNhap(String user, String pass)
        {
            UserDTO usr = new UserDTO();
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "Select * from [USER] where ID=? and Pass=?"; ;
            OleDbCommand cmd = new OleDbCommand(strSql, cnn);
            cmd.Parameters.Add("@ID", OleDbType.VarChar);
            cmd.Parameters.Add("@Pass", OleDbType.VarChar);
            cmd.Parameters["@ID"].Value = user;
            cmd.Parameters["@Pass"].Value = pass;

            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                usr.ID = dr["ID"].ToString();
                usr.Pass = dr["Pass"].ToString();
                usr.LoaiUser=int.Parse(dr["LoaiUser"].ToString());
            }
            cnn.Close();
            return usr;
        }
        public static DataTable SelectAll_MonHoc_byIDGiaoVien(String ID)
        {                  
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select mh.MaMH , mh.TenMH from MonHoc mh,GiaoVien gv where mh.MaMH = gv.MonDay and gv.MaGV= '" + ID + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static bool KiemTraDay(String MaGV,String maLop)
        {
            bool kq = false;
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "Select * from DAYLOP where MaGV = ? and MaLop = ?"; ;
            OleDbCommand cmd = new OleDbCommand(strSql, cnn);
            cmd.Parameters.Add("@MaGV", OleDbType.VarChar);
            cmd.Parameters.Add("@MaLop", OleDbType.VarChar);
            cmd.Parameters["@MaGV"].Value = MaGV;
            cmd.Parameters["@MaLop"].Value = maLop;

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                kq = true;
            }
            cnn.Close();
            return kq;
        }
    }
}
