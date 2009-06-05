using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DTO;
using System.Data.OleDb;
namespace DAO
{
   public   class HocSinhDAO
    {
        public static void Insert(HocSinhDTO hs)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string StrSql = "insert into HOCSINH (MaHS,NgaySinh,HoTen,DiaChi,HanhKiem,SoDienThoai,NgayNhapTruong,HinhAnh,MaLop) values (?,?,?,?,?,?,?,?,?)";
            OleDbCommand cmd = new OleDbCommand(StrSql, cn);
            cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);
            cmd.Parameters.Add("@NgaySinh", OleDbType.DBDate);
            cmd.Parameters.Add("@HoTen", OleDbType.VarWChar);
            cmd.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            cmd.Parameters.Add("@HanhKiem", OleDbType.VarWChar);
            cmd.Parameters.Add("@SoDienThoai", OleDbType.Integer);
            cmd.Parameters.Add("@NgayNhapTruong", OleDbType.DBDate);
             cmd.Parameters.Add("@HinhAnh", OleDbType.VarWChar);
             cmd.Parameters.Add("@MaLop", OleDbType.VarWChar);

             cmd.Parameters["@MaHS"].Value = hs.MaHS;
             cmd.Parameters["@NgaySinh"].Value = hs.NgaySinh;
             cmd.Parameters["@HoTen"].Value = hs.HoTen;
             cmd.Parameters["@DiaChi"].Value = hs.DiaChi;
             cmd.Parameters["@HanhKiem"].Value = hs.HanhKiem;
             cmd.Parameters["@SoDienThoai"].Value = hs.SoDienThoai;
             cmd.Parameters["@NgayNhapTruong"].Value = hs.NgayNhapTruong;
             cmd.Parameters["@HinhAnh"].Value = hs.HinhAnh;
             cmd.Parameters["@MaLop"].Value = hs.MaLop;

             cmd.ExecuteNonQuery();
             cn.Close();
         }
        public static  void Update(HocSinhDTO hs)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            String StrSql = "Update HOCSINH set  NgaySinh=? , HoTen=? , DiaChi=? , HanhKiem=?" +
            " , SoDienThoai=? , NgayNhapTruong=? , HinhAnh=? , MaLop=?  where MaHS=?";

            OleDbCommand cmd = new OleDbCommand(StrSql, cn);

           
            cmd.Parameters.Add("@NgaySinh", OleDbType.DBDate);
            cmd.Parameters.Add("@HoTen", OleDbType.VarWChar);
            cmd.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            cmd.Parameters.Add("@HanhKiem", OleDbType.VarWChar);
            cmd.Parameters.Add("@SoDienThoai", OleDbType.Integer);
            cmd.Parameters.Add("@NgayNhapTruong", OleDbType.DBDate);
            cmd.Parameters.Add("@HinhAnh", OleDbType.VarWChar);
            cmd.Parameters.Add("@MaLop", OleDbType.VarWChar);
             cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);

            cmd.Parameters["@MaHS"].Value = hs.MaHS;
            cmd.Parameters["@NgaySinh"].Value = hs.NgaySinh;
            cmd.Parameters["@HoTen"].Value = hs.HoTen;
            cmd.Parameters["@DiaChi"].Value = hs.DiaChi;
            cmd.Parameters["@HanhKiem"].Value = hs.HanhKiem;
            cmd.Parameters["@SoDienThoai"].Value = hs.SoDienThoai;
            cmd.Parameters["@NgayNhapTruong"].Value = hs.NgayNhapTruong;
            cmd.Parameters["@HinhAnh"].Value = hs.HinhAnh;
            cmd.Parameters["@MaLop"].Value = hs.MaLop;

            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static  void Delete(string maHS)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string Sql = "Delete from HOCSINH where MaHS=?";
            OleDbCommand cmd = new OleDbCommand(Sql, cn);
            cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);
            cmd.Parameters["@MaHS"].Value = maHS;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static  IList SelectAll()
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string Sql = "Select * from HOCSINH";
            OleDbCommand cmd = new OleDbCommand(Sql, cn);
            OleDbDataReader dr = cmd.ExecuteReader();
            IList list = new ArrayList();
            while (dr.Read())
            {
                HocSinhDTO hs = new HocSinhDTO();
                hs.MaHS = dr["MaHS"].ToString();
                hs.NgaySinh = (DateTime)dr["NgaySinh"];
                hs.HoTen = dr["HoTen"].ToString();
                hs.HanhKiem = dr["HanhKiem"].ToString();
                hs.SoDienThoai = (int)dr["SoDienThoai"];
                hs.HinhAnh = dr["HinhAnh"].ToString();
                hs.NgayNhapTruong = (DateTime)dr["NgayNhapTruong"];
                hs.MaLop = dr["MaLop"].ToString();
                hs.DiaChi = dr["DiaChi"].ToString();
                list.Add(hs);
            }
            dr.Close();
            cn.Close();
            return list;
        }
        public static  HocSinhDTO  SelectByID(string ma)
        {
            OleDbConnection cn = DataProvider.ConnectionData();
            string Sql = "Select * from HOCSINH where MaHS=?";
            OleDbCommand cmd = new OleDbCommand(Sql, cn);
            cmd.Parameters.Add("@MaHS", OleDbType.VarWChar);
            cmd.Parameters["@MaHS"].Value =ma;
            OleDbDataReader dr = cmd.ExecuteReader();
            HocSinhDTO hs = new HocSinhDTO();
            while (dr.Read())
            {
                 hs = new HocSinhDTO();
                hs.MaHS = dr["MaHS"].ToString();
                hs.NgaySinh = (DateTime)dr["NgaySinh"];
                hs.HoTen = dr["HoTen"].ToString();
                hs.HanhKiem = dr["HanhKiem"].ToString();
                hs.SoDienThoai = (int)dr["SoDienThoai"];
                hs.HinhAnh = dr["HinhAnh"].ToString();
                hs.NgayNhapTruong = (DateTime)dr["NgayNhapTruong"];
                hs.MaLop = dr["MaLop"].ToString();
                hs.DiaChi = dr["DiaChi"].ToString();
               
            }
            dr.Close();
            cn.Close();
            return hs;
        }

    }
}
