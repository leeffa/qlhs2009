using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.OleDb;
namespace DAO
{
    public class LopDAO
    {
        public static bool InSert_LopHoc(LopHocDTO lop)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "insert into LOPHOC(MaKH,TenLop,MaKhoi) value(?,?,?)";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaLop", OleDbType.VarChar);
                cmd.Parameters.Add("@TenLop", OleDbType.VarChar);
                cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);

                cmd.Parameters["@MaLop"].Value = lop.MaLop;
                cmd.Parameters["@TenLop"].Value = lop.TenLop;
                cmd.Parameters["@MaKhoi"].Value = lop.MaKhoi;

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
        public static bool Update_LopHoc(LopHocDTO lop)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "update LOP set TenLop=?, MaKhoi = ? where MaLop=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaLop", OleDbType.VarChar);
                cmd.Parameters.Add("@TenLop", OleDbType.VarChar);
                cmd.Parameters.Add("@MaKhoi", OleDbType.VarChar);

                cmd.Parameters["@MaLop"].Value = lop.MaLop;
                cmd.Parameters["@TenLop"].Value = lop.TenLop;
                cmd.Parameters["@MaKhoi"].Value = lop.TenLop;

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
        public static bool Delete_IDLopHoc(String maLop)
        {
            bool result = false;
            try
            {
                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "delete from LOPHOC where MaLop=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaLop", OleDbType.VarChar);

                cmd.Parameters["@MaLop"].Value = maLop;
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
            String strSql = "select * from LOPHOC";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static LopHocDTO SelectID(String ID)
        {
            LopHocDTO lop = new LopHocDTO();
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from LOPHOC where MaLop=?";
            OleDbCommand cmd = new OleDbCommand(strSql, cnn);
            cmd.Parameters.Add("@MaLop", OleDbType.VarChar);

            cmd.Parameters["@MaLop"].Value = ID;
            OleDbDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                return null;
            }
            lop.MaLop = ID;
            while (dr.Read())
            {
                if (dr["@TenLop"].ToString() != "")
                    lop.TenLop = dr["@TenLop"].ToString();
                if (dr["@MaKhoi"].ToString() != "")
                    lop.MaKhoi = dr["@MaKhoi"].ToString();
            }
            return lop;
        }
        public static DataTable Select_byKhoi(String khoi)
        {
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from LOPHOC where MaKhoi= '" + khoi + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
