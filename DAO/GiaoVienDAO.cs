using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DTO;
using System.Collections;

namespace DAO
{
    public class GiaoVienDAO
    {
        //viet ham them giao vien
        public static bool Them_Giao_Vien(GiaoVienDTO gvdto)
        {
            //tao ket noi
            try
            {
                OleDbConnection cn = DataProvider.ConnectionData();
                 try
                {                //tao chuoi ket noi
                    string cnstring = "insert into GIAOVIEN values(@MaGV,@HoTen,@MonDay)";
                    //thuc thi chuoi ket noi voi OleDBCommand
                    //khoi tao doi tuong OleDbCommon
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //Dinh Nghia cac Parameters
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    cmd.Parameters.Add("@HoTen", OleDbType.WChar);
                    cmd.Parameters.Add("@MonDay", OleDbType.WChar);
                    //Gan gia tri cho cac Parameters
                    cmd.Parameters["@MaGV"].Value = gvdto.MaGV;
                    cmd.Parameters["@HoTen"].Value = gvdto.HoTen;
                    cmd.Parameters["@MonDay"].Value = gvdto.MonDay;
                    //thuc thi cmd
                    int kq=cmd.ExecuteNonQuery();
                    if (kq==1)
                    {
                        return true;
                    }

                }
                catch ( Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();//dong ket noi cn


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
 
            return false;
        }
        //ham nay tra ve Danh sach giao vien tho ma mon hoc

        public static IList Lay_DS_Giao_Vien_Theo_Mon_Hoc(string ma_mon_hoc)
        { 
            try
            {
                            //tao ket noi
                OleDbConnection cn = DataProvider.ConnectionData();
 
                try
                {
                                //tao chuoi ket noi
                    string cnstring = "select * from GIAOVIEN GV where GV.MonDay=@MaMH";
                    //thuc thi voi OleDbCommand
                    OleDbCommand cmd = new OleDbCommand(cnstring,cn);
                        //khoi tao cac paramter cua cmd
                    cmd.Parameters.Add("@MaMH",OleDbType.WChar);
                        //gan gia tri cho parameters
                    cmd.Parameters["@MaMH"].Value=ma_mon_hoc;
                        //thuc thi cmd tra ve la datareader
                    OleDbDataReader dr  ;
                    dr=cmd.ExecuteReader();
                    IList DS_Giao_Vien = new ArrayList();
                    while (dr.Read())
                    {
                        GiaoVienDTO gvdto = new GiaoVienDTO();
                        gvdto.MaGV=dr["MaGV"].ToString();
                        gvdto.HoTen=dr["HoTen"].ToString();
                        gvdto.MonDay=dr["MonDay"].ToString();
                        DS_Giao_Vien.Add(gvdto);
                    }
                    dr.Close();
                    return DS_Giao_Vien;

                }
                catch ( Exception ex)
                {
                	throw ex;
                }
                finally
                {            //dong ket noi
                    cn.Close();
                    

                }
            }
            catch ( Exception ex)
            {
            	throw ex;
            }
            
            
        }
        //cap nhat
        public static bool Cap_Nhat(GiaoVienDTO gvdto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "update GIAOVIEN set HoTen=@HoTen,MonDay=@MonDay where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                    cmd.Parameters.Add("@HoTen", OleDbType.WChar);
                    cmd.Parameters.Add("@MonDay", OleDbType.WChar);
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                    cmd.Parameters["@HoTen"].Value = gvdto.HoTen;
                    cmd.Parameters["@MonDay"].Value = gvdto.MonDay;
                    cmd.Parameters["@MaGV"].Value = gvdto.MaGV;
                    //thuc thi bang ExcuteNoneQuery
                    int kq = cmd.ExecuteNonQuery();
                    if (kq == 1)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();            //dong ket noi

                }
            }
            catch ( Exception ex)
            {
                throw ex;
            }

        }
        //Xoa
        public static bool Xoa(GiaoVienDTO gvdto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "delete from GIAOVIEN where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                     cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                     cmd.Parameters["@MaGV"].Value = gvdto.MaGV;
                    //thuc thi bang ExcuteNoneQuery
                    int kq = cmd.ExecuteNonQuery();
                    if (kq == 1)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();            //dong ket noi

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       
        //tra cuu giao vien dua vao MaGV
        public static GiaoVienDTO Tra_Cuu_MaGV(GiaoVienDTO gvdto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "select * from GIAOVIEN where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                    cmd.Parameters["@MaGV"].Value = gvdto.MaGV;
                    //thuc thi bang ExcuteScalar
                    GiaoVienDTO gvdto_result = new GiaoVienDTO();
                    gvdto_result =(GiaoVienDTO) cmd.ExecuteScalar();
                    return gvdto_result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cn.Close();            //dong ket noi

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
