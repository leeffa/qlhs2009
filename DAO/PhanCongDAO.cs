using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using DTO;
namespace DAO
{
   public class PhanCongDAO
    {
        public static void Insert(PhanCongDTO pc)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string SQL = "insert into PHANCONG (MAGV,MaLop) values (?,?)";
            OleDbCommand cmd = new OleDbCommand(SQL, cn);
            cmd.Parameters.Add("@MaGV", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaLop", OleDbType.VarWChar);
            cmd.Parameters["@MaGV"].Value = pc.MaGV;
            cmd.Parameters["@MaLop"].Value = pc.MaLop;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Update(PhanCongDTO pc)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Update PHANCONG set  MaLop=? where MaGV=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaLop", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaGV", OleDbType.VarWChar);
            cmd.Parameters["@MaGV"].Value = pc.MaGV;
            cmd.Parameters["@MaLop"].Value = pc.MaLop;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Delete(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Delete From PHANCONG where MaGV=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaGV", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static IList SelectAll()
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from PHANCONG";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader dr = cmd.ExecuteReader();
            IList list = new ArrayList();
            while (dr.Read())
            {
                PhanCongDTO ms = new PhanCongDTO();
                ms.MaGV = dr["MaGV"].ToString();
                ms.MaLop = dr["MaLop"].ToString();
                list.Add(ms);
            }
            dr.Close();
            cn.Close();
            return list;
        }
        public static PhanCongDTO SelectByID(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from PHANCONG where MaGV=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaGV", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            OleDbDataReader dr = cmd.ExecuteReader();
            PhanCongDTO ms = new PhanCongDTO();
            while (dr.Read())
            {
                ms = new PhanCongDTO();
                ms.MaGV = dr["MaGV"].ToString();
                ms.MaLop = dr["MaLop"].ToString();

            }
            dr.Close();
            cn.Close();
            return ms;
        }
 
    }
}
