using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.OleDb;
namespace DAO
{
    public class DiemDAO
    {
        public static bool InSert_Diem(DiemDTO d)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "insert into DIEM(MaHS,MaMH,Diem15,Diem1T,DiemThi,DiemTB) value(?,?,?,?,?,?)";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaHS", OleDbType.VarChar);
                cmd.Parameters.Add("@MaMH", OleDbType.VarChar);
                cmd.Parameters.Add("@Diem15", OleDbType.Numeric);
                cmd.Parameters.Add("@Diem1T", OleDbType.Numeric);
                cmd.Parameters.Add("@DiemThi", OleDbType.Numeric);
                cmd.Parameters.Add("@DiemTB", OleDbType.Numeric);

                cmd.Parameters["@MaHS"].Value = d.MaHS;
                cmd.Parameters["@MaMH"].Value = d.MaMH;
                cmd.Parameters["@Diem15"].Value = d.Diem15;
                cmd.Parameters["@Diem1T"].Value = d.Diem1T;
                cmd.Parameters["@DiemThi"].Value = d.DiemThi;
                cmd.Parameters["@DiemTB"].Value = d.DiemTB;

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
        public static bool Update_Diem(DiemDTO d)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "update DIEM set Diem15=?,Diem1T=?,DiemThi=?,DiemTB =? where MaHS=? and MaMH=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@Diem15", OleDbType.Numeric);
                cmd.Parameters.Add("@Diem1T", OleDbType.Numeric);
                cmd.Parameters.Add("@DiemThi", OleDbType.Numeric);
                cmd.Parameters.Add("@DiemTB", OleDbType.Numeric);
                cmd.Parameters.Add("@MaHS", OleDbType.VarChar);
                cmd.Parameters.Add("@MaMH", OleDbType.VarChar);

                cmd.Parameters["@Diem15"].Value = d.Diem15;
                cmd.Parameters["@Diem1T"].Value = d.Diem1T;
                cmd.Parameters["@DiemThi"].Value = d.DiemThi;
                cmd.Parameters["@DiemTB"].Value = d.DiemTB;
                cmd.Parameters["@MaHS"].Value = d.MaHS;
                cmd.Parameters["@MaMH"].Value = d.MaMH;

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
        public static bool Delete_IDDiem(String maHS, String maMH)
        {
            bool result = false;
            try
            {
                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "delete from DIEM where MaHS=? and MaMH=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@MaHS", OleDbType.VarChar);
                cmd.Parameters.Add("@MaMH", OleDbType.VarChar);

                cmd.Parameters["@MaHS"].Value = maHS;
                cmd.Parameters["@MaMH"].Value = maMH;

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
            String strSql="select * from DIEM";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DiemDTO SelectID(String maHS,String maMH)
        {
            DiemDTO diem = new DiemDTO();
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from DIEM where MaHS=? and MaMH=?";
            OleDbCommand cmd=new OleDbCommand(strSql,cnn);
            cmd.Parameters.Add("@MaHS", OleDbType.VarChar);
            cmd.Parameters.Add("@MaMH", OleDbType.VarChar);

            cmd.Parameters["@MaHS"].Value = maHS;
            cmd.Parameters["@MaMH"].Value = maMH;

            OleDbDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                return null;
            }
            diem.MaHS = maHS;
            diem.MaMH = maMH;
            while (dr.Read())
            {
                if (dr["Diem15"].ToString() != "")
                    diem.Diem15 = float.Parse(dr["Diem15"].ToString());
                if (dr["Diem1T"].ToString() != "")
                    diem.Diem15 = float.Parse(dr["Diem1T"].ToString());
                if (dr["DiemThi"] .ToString()!= "")
                    diem.Diem15 = float.Parse(dr["DiemThi"].ToString());
                if (dr["DiemTB"].ToString()!= "")
                    diem.Diem15 = float.Parse(dr["DiemTB"].ToString());
            }
            return diem;


        }
    }
}