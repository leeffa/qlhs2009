using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.OleDb;
using System.Collections;
namespace DAO
{
    class MonHocDAO
    {
        public void Insert(MonHocDTO mh)
        {
            OleDbConnection cn = new OleDbConnection();
            string SQL = "insert into MONHOC (MaMH,TenMH) values (?,?)";
            OleDbCommand cmd = new OleDbCommand(SQL, cn);
            cmd.Parameters.Add("@MaMH", OleDbType.VarWChar);
            cmd.Parameters.Add("@TenMH", OleDbType.VarWChar);
            cmd.Parameters["@MaMH"].Value = mh.MaMH;
            cmd.Parameters["@TenMH"].Value = mh.TenMH;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void Update(MonHocDTO mh)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Update MONHOC set  TenMH=? where MaMH=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@TenMH", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaMH", OleDbType.VarWChar);
            cmd.Parameters["@MaMH"].Value = mh.MaMH;
            cmd.Parameters["@TenMH"].Value = mh.TenMH;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void Delete(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "Delete From MONHOC where MaMH=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaMH", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public IList SelectAll()
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from MONHOC";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader dr = cmd.ExecuteReader();
            IList list = new ArrayList();
            while (dr.Read())
            {
                MonHocDTO ms = new MonHocDTO();
                ms.MaMH = dr["MaMH"].ToString();
                ms.TenMH = dr["TenMH"].ToString();
                list.Add(ms);
            }
            dr.Close();
            cn.Close();
            return list;
        }
        public MonHocDTO SelectByID(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string sql = "select * from MONHOC where MaMH=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            cmd.Parameters.Add("@MaMH", OleDbType.VarWChar);
            cmd.Parameters[0].Value = ma;
            OleDbDataReader dr = cmd.ExecuteReader();
            MonHocDTO ms = new MonHocDTO();
            while (dr.Read())
            {
                ms = new MonHocDTO();
                ms.MaMH = dr["MaMH"].ToString();
                ms.TenMH = dr["TenMH"].ToString();
               
            }
            dr.Close();
            cn.Close();
            return ms;
        }
    }
}
