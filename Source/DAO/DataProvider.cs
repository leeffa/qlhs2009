using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;


namespace DAO
{
    public class DataProvider
    {
        public static OleDbConnection ConnectionData()
        {
            string cnStr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = TruongHoc.mdb";
            OleDbConnection cn = new OleDbConnection(cnStr);
            cn.Open();
            return cn;
        }
    }
}
