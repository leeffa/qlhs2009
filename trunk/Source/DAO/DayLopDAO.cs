using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using DTO;
using System.Collections;

namespace DAO
{
    public class DayLopDAO
    {
        //viet ham them day lop
        public static bool Them_Day_Lop(DayLopDTO dldto)
        {
            //tao ket noi
            try
            {
                OleDbConnection cn = DataProvider.ConnectionData();
                try
                {                //tao chuoi ket noi
                    string cnstring = "insert into DayLop values(@MaGV,@MaLop)";
                    //thuc thi chuoi ket noi voi OleDBCommand
                    //khoi tao doi tuong OleDbCommon
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //Dinh Nghia cac Parameters
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    cmd.Parameters.Add("@MaLop", OleDbType.WChar);
                    //Gan gia tri cho cac Parameters
                    cmd.Parameters["@MaGV"].Value = dldto.MaGV;
                    cmd.Parameters["@MaLop"].Value = dldto.MaLop;
                    //thuc thi cmd
                    int kq = cmd.ExecuteNonQuery();
                    if (kq == 1)
                    {
                        return true;
                    }

                }
                catch (Exception ex)
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
        //ham nay tra ve Danh sach day lop theo ma mon hoc

        public static IList Lay_DS_Day_Lop_Theo_Mon_Hoc(string ma_mon_hoc)
        {
            try
            {
                //tao ket noi
                OleDbConnection cn = DataProvider.ConnectionData();

                try
                {
                    //tao chuoi ket noi
                    string cnstring = "select DL.MaGV,DL.MaLop from DAYLOP DL,GIAOVIEN GV where GV.MonDay=@MaMH and GV.MaGV=DL.MaGV";
                    //thuc thi voi OleDbCommand
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khoi tao cac paramter cua cmd
                    cmd.Parameters.Add("@MaMH", OleDbType.WChar);
                    //gan gia tri cho parameters
                    cmd.Parameters["@MaMH"].Value = ma_mon_hoc;
                    //thuc thi cmd tra ve la datareader
                    OleDbDataReader dr;
                    dr = cmd.ExecuteReader();
                    IList DS_Day_Lop = new ArrayList();
                    while (dr.Read())
                    {
                        DayLopDTO dldto = new DayLopDTO();
                        dldto.MaGV = dr["MaGV"].ToString();
                        dldto.MaLop = dr["MaLop"].ToString();
                        DS_Day_Lop.Add(dldto);
                    }
                    dr.Close();
                    return DS_Day_Lop;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {            //dong ket noi
                    cn.Close();


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        //cap nhat
        public static bool Cap_Nhat(DayLopDTO dldto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "update DAYLOP set  MaLop=@MaLop where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                    cmd.Parameters.Add("@MaLop", OleDbType.WChar);
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                    cmd.Parameters["@MaLop"].Value = dldto.MaLop;
                    cmd.Parameters["@MaGV"].Value = dldto.MaGV;
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
        //Xoa
        public static bool Xoa(DayLopDTO dldto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "delete from DAYLOP where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                    cmd.Parameters["@MaGV"].Value = dldto.MaGV;
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
        //tra cuu day lop dua vao MaGV
        public static DayLopDTO Tra_Cuu_MaGV(DayLopDTO dldto)
        {
            try
            {
                //tao ket noi  

                OleDbConnection cn = DataProvider.ConnectionData();
                //tao chuoi ket noi
                string cnstring = "select * from DayLop where MaGV=@MaGV";

                try
                {
                    //dung OleDbCommand de thuc thi

                    //khoi tao OleDbCommand cmd
                    OleDbCommand cmd = new OleDbCommand(cnstring, cn);
                    //khai bao cac tham so
                    cmd.Parameters.Add("@MaGV", OleDbType.WChar);
                    //gan gia tri cho cac tham so
                    cmd.Parameters["@MaGV"].Value = dldto.MaGV;
                    //thuc thi bang ExcuteScalar
                    DayLopDTO dldto_result = new DayLopDTO();
                    dldto_result = (DayLopDTO)cmd.ExecuteScalar();
                    return dldto_result;
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
