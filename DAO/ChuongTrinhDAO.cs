using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DTO;
using System.Data.OleDb;
namespace DAO
{
    public class ChuongTrinhDAO
    {
        public static void Insert(ChuongTrinhDTO ct)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string SQL = "insert into PHANCONG (MAKH,MaMon) values (?,?)";
            OleDbCommand cmd = new OleDbCommand(SQL, cn);
            cmd.Parameters.Add("@MaKH", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaMon", OleDbType.VarWChar);
            cmd.Parameters["@MaKH"].Value = ct.MaKH;
            cmd.Parameters["@MaMon"].Value = ct.MaMon;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Update(ChuongTrinhDTO ct)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Update PHANCONG set  MaMon=? where MaKH=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaMon", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaKH", OleDbType.VarWChar);
            cmd.Parameters["@MaKH"].Value = ct.MaKH;
            cmd.Parameters["@MaMon"].Value = ct.MaMon;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void Delete(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Delete From PHANCONG where MaKH=? and MaMon=?" ;
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add(@"MaKH", OleDbType.VarWChar);
            cmd.Parameters.Add(@"MaMon", OleDbType.VarWChar);

            cmd.Parameters[@"MaKH"].Value = ma;
            cmd.Parameters[@"MaMon"].Value = ma;

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
                ChuongTrinhDTO ms = new ChuongTrinhDTO();
                ms.MaKH = dr["MaKH"].ToString();
                ms.MaMon = dr["MaMon"].ToString();
                list.Add(ms);
            }
            dr.Close();
            cn.Close();
            return list;
        }
        public static ChuongTrinhDTO SelectByID(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from PHANCONG where MaKH=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaKH", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            OleDbDataReader dr = cmd.ExecuteReader();
            ChuongTrinhDTO ms = new ChuongTrinhDTO();
            while (dr.Read())
            {
                ms = new ChuongTrinhDTO();
                ms.MaKH = dr["MaKH"].ToString();
                ms.MaMon = dr["MaMon"].ToString();

            }
            dr.Close();
            cn.Close();
            return ms;
        }
 
    }
}
