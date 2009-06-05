using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using DTO;
namespace DAO
{
   public  class ThanNhanDAO
    {
        public static  void Insert(ThanNhanDTO tn)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "insert into THANNHAN (Ma,MaHS,HoTen,QuanHe) values(?,?,?,?)";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@Ma", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);
            cmd.Parameters.Add("@HoTen", OleDbType.VarWChar);
            cmd.Parameters.Add("@QuanHe", OleDbType.VarWChar);
            cmd.Parameters["@Ma"].Value = tn.Ma;
            cmd.Parameters["@MaHS"].Value = tn.MaHS;
            cmd.Parameters["@HoTen"].Value = tn.HoTen;
            cmd.Parameters["@QuanHe"].Value = tn.QuanHe;

            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Update(ThanNhanDTO tn)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "update THANNHAN set MaHS=? , HoTen=? , QuanHe=? where Ma=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
          
            cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);
            cmd.Parameters.Add("@HoTen", OleDbType.VarWChar);
            cmd.Parameters.Add("@QuanHe", OleDbType.VarWChar);
            cmd.Parameters.Add("@Ma", OleDbType.VarWChar);
            cmd.Parameters["@Ma"].Value = tn.Ma;
            cmd.Parameters["@MaHS"].Value = tn.MaHS;
            cmd.Parameters["@HoTen"].Value = tn.HoTen;
            cmd.Parameters["@QuanHe"].Value = tn.QuanHe;

            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Delete(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Delete from THANNHAN where Ma=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@Ma", OleDbType.VarWChar);
            cmd.Parameters["@Ma"].Value = ma;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static  IList SelectAll()
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from THANNHAN";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader dr = cmd.ExecuteReader();
            IList list = new ArrayList();
            while (dr.Read())
            {
                ThanNhanDTO tn = new ThanNhanDTO();
                tn.Ma = dr["Ma"].ToString();
                tn.MaHS = dr["MaHS"].ToString();
                tn.HoTen = dr["HoTen"].ToString();
                tn.QuanHe = dr["QuanHe"].ToString();
                list.Add(tn);
            }
            dr.Close();
            cn.Close();
            return list;
        }
        public static ThanNhanDTO  SelectByID(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from THANNHAN where Ma=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@Ma", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            OleDbDataReader dr = cmd.ExecuteReader();
            ThanNhanDTO tn = new ThanNhanDTO();
            while (dr.Read())
            {
               tn = new ThanNhanDTO();
                tn.Ma = dr["Ma"].ToString();
                tn.MaHS = dr["MaHS"].ToString();
                tn.HoTen = dr["HoTen"].ToString();
                tn.QuanHe = dr["QuanHe"].ToString();
              
            }
            dr.Close();
            cn.Close();
            return tn;
        }

    }
}
