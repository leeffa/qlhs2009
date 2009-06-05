using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DAO;
using DTO;
namespace BUS
{
    public class UserBUS
    {
        public static bool InSert_User(UserDTO user)
        {
            return UsersDAO.InSert_User(user);
        }
        //updating
        public static bool Update_User(UserDTO user)
        {
            return UsersDAO.Update_User(user);
        }
        // Deleting
        public static bool Delete_IDUser(String ID)
        {
            return UsersDAO.Delete_IDUser(ID);
        }
        public static DataTable SelectAll()
        {
            return UsersDAO.SelectAll();
        }
        public static UserDTO SelectID(String ID)
        {
            return UsersDAO.SelectID(ID);
        }

    }
}
