using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.OleDb;
namespace DAO
{
    public class UsersDAO
    {
        public static bool InSert_User(UserDTO user)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "insert into USERS(ID,Pass,LoaiUser) value(?,?,?)";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@ID", OleDbType.VarChar);
                cmd.Parameters.Add("@Pass", OleDbType.VarChar);
                cmd.Parameters.Add("@LoaiUser", OleDbType.Integer);
                
                cmd.Parameters["@ID"].Value = user.ID;
                cmd.Parameters["@Pass"].Value = user.Pass;
                cmd.Parameters["@LoaiUser"].Value = user.LoaiUser;
                
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
        public static bool Update_User(UserDTO user)
        {
            bool result = false;
            try
            {
                // Create List OleDb Parameter

                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "update USER set Pass=?,LoaiUser=? where ID=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@Pass", OleDbType.VarChar);
                cmd.Parameters.Add("@LoaiUser", OleDbType.Integer);
                cmd.Parameters.Add("@ID", OleDbType.VarChar);

                cmd.Parameters["@Pass"].Value = user.Pass;
                cmd.Parameters["@LoaiUser"].Value = user.LoaiUser;
                cmd.Parameters["@ID"].Value = user.ID;
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
        public static bool Delete_IDUser(String ID)
        {
            bool result = false;
            try
            {
                OleDbConnection cnn = DataProvider.ConnectionData();
                String strSql = "delete from DIEM where ID=?";

                OleDbCommand cmd = new OleDbCommand(strSql, cnn);
                cmd.Parameters.Add("@ID", OleDbType.VarChar);

                cmd.Parameters["@ID"].Value = ID;
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
            String strSql = "select * from USER";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static UserDTO SelectID(String ID)
        {
            UserDTO user = new UserDTO();
            OleDbConnection cnn = DataProvider.ConnectionData();
            String strSql = "select * from USER where ID=?";
            OleDbCommand cmd = new OleDbCommand(strSql, cnn);
            cmd.Parameters.Add("@ID", OleDbType.VarChar);
            
            cmd.Parameters["@ID"].Value = ID;
            OleDbDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                return null;
            }
            user.ID= ID;
            while (dr.Read())
            {
                if (dr["@Pass"].ToString() != "")
                  user.Pass = dr["@Pass"].ToString();
                if (dr["LoaiUser"].ToString() != "")
                    user.LoaiUser = int.Parse(dr["LoaiUser"].ToString());
            }
            return user;


        }

    }
}
