using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.OleDb;
namespace DAO
{
    public class KhoiDAO
    {
        public static bool InSert_Khoi(KhoiDTO khoi)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "insert into KHOI(MaKH,TenKhoi) value(?,?)";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);
                cmd.Parameters.Add("@TenKhoi", OleDbType.VarChar);

                cmd.Parameters["@MaKhoi"].Value = khoi.MaKhoi;
                cmd.Parameters["@TenKhoi"].Value = khoi.TenKhoi;

                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        //updating
        public static bool Update_Khoi(KhoiDTO khoi)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "update KHOI set TenKhoi=? where MaKhoi=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);
                cmd.Parameters["@MaKhoi"].Value = khoi.MaKhoi;
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        // Deleting
        public static bool Delete_IDKhoi(String maKH)
        {
            bool result = false;
            try
            {
                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "delete from KHOI where MaKhoi=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);

                cmd.Parameters["@MaKhoi"].Value = maKH;
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                    result = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static DataTable SelectAll()
        {
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from KHOI";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static KhoiDTO SelectID(String ID)
        {
            KhoiDTO khoi = new KhoiDTO();
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from KHOI where MaKhoi=?";
            OleDbCommand cmd = new OleDbCommand(strSql, cnn);
            cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);

            cmd.Parameters["@MaKhoi"].Value = ID;
            OleDbDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                return null;
            }
            khoi.MaKhoi= ID;
            while(dr.Read())
            {
                if (dr["@TenKhoi"].ToString() != "")
                    khoi.TenKhoi = dr["@TenKhoi"].ToString();
            }
            return khoi;
        }

    }
}
