using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using DTO;

namespace DAO
{
    public class LopHocDAO
    {
        public IList LayDanhSach()
        {
            ArrayList ds = new ArrayList();
            OleDbConnection cn;
            string strSQL;
            // B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
            cn = DataProvider.ConnectionData();
            // B3: Tao chuoi strSQL thao tac CSDL
            strSQL = "Select * From LopHoc Order by MaKhoi, MaLop asc";
            OleDbCommand cmd = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            LopHocDTO l;
            while (dr.Read())
            {
                l = new LopHocDTO();
                l.MaLop = (string)dr["MaLop"];
                l.TenLop = (string)dr["TenLop"];
                l.MaKhoi = (string)dr["MaKhoi"];
                ds.Add(l);
            }
            // B5: Dong ket noi CSDL
            cn.Close();
            return ds;
        }

        public IList LayDanhSach(string makhoi)
        {
            ArrayList ds = new ArrayList();
            OleDbConnection cn;
            string strSQL;
            // B1 & B2: Tao chuoi ket noi, mo ket noi bang doi tuong ket noi
            cn = DataProvider.ConnectionData();
            // B3: Tao chuoi strSQL thao tac CSDL
            strSQL = "Select * From LopHoc where [MaKhoi]=? Order by MaKhoi, MaLop asc";
            OleDbCommand cmd = new OleDbCommand(strSQL, cn);
            cmd.Parameters.Add("@MaKhoi", OleDbType.WChar);
            cmd.Parameters["@MaKhoi"].Value = makhoi;
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            LopHocDTO l;
            while (dr.Read())
            {
                l = new LopHocDTO();
                l.MaLop = (string)dr["MaLop"];
                l.TenLop = (string)dr["TenLop"];
                l.MaKhoi = (string)dr["MaKhoi"];
                ds.Add(l);
            }
            cn.Close();
            return ds;
        }

        public void Them(LopHocDTO ldto)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string strSQL = "Insert into LopHoc([TenLop], [MaKhoi], [MaLop]) values (?, ?, ?)";
            OleDbCommand cmd = new OleDbCommand(strSQL, cn);
            cmd.Parameters.Add("@TenLop", OleDbType.WChar);
            cmd.Parameters.Add("@MaKhoi", OleDbType.WChar);
            cmd.Parameters.Add("@MaLop", OleDbType.WChar);
            cmd.Parameters["@TenLop"].Value = ldto.TenLop;
            cmd.Parameters["@MaKhoi"].Value = ldto.MaKhoi;
            cmd.Parameters["@MaLop"].Value = ldto.MaLop;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Xoa(string malop)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string strSQL = "Delete From LopHoc Where [MaLop] = ? ";
            OleDbCommand cmd = new OleDbCommand(strSQL, cn);
            cmd.Parameters.Add("@MaLop", OleDbType.WChar);
            cmd.Parameters["@MaLop"].Value = malop;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void Sua(LopHocDTO ldto)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string strSQL = "Update LopHoc Set [TenLop] = ?, [MaKhoi] = ? Where [MaLop] = ?";
            OleDbCommand cmd = new OleDbCommand(strSQL, cn);
            cmd.Parameters.Add("@TenLop", OleDbType.WChar);
            cmd.Parameters.Add("@MaKhoi", OleDbType.WChar);
            cmd.Parameters.Add("@MaLop", OleDbType.WChar);
            cmd.Parameters["@TenLop"].Value = ldto.TenLop;
            cmd.Parameters["@MaKhoi"].Value = ldto.MaKhoi;
            cmd.Parameters["@MaLop"].Value = ldto.MaLop;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
