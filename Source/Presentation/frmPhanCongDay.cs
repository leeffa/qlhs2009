using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
namespace Presentation
{
    public partial class frmPhanCongDay : Form
    {
        public frmPhanCongDay()
        {
            InitializeComponent();
        }
        //xử lý sự kien nut them duoc nhan
        //them moi mo 
        private void btnThem_Click(object sender, EventArgs e)
        {
            //khoi tao doi tuong day lop
            DayLopDTO dldto = new DayLopDTO();
            //dldto = các giá trị thông tin của các control.
            dldto.MaGV = txtMaGV.Text;
            dldto.MaLop = cbbLop.SelectedValue.ToString();
            //goi phuong thuc insert của BUS
            bool kq = DayLopBUS.Them_Day_Lop(dldto);
            //neu insert thanh cong hien thi messagebox
            if (kq == true)
            {
                MessageBox.Show("Thêm Thành Công", "Thêm");
            }
            else
                MessageBox.Show("Không Thành Công!", "Thất Bại");
            //hien thi ds day lop le dtdl_DS_day_lop
            IList ds_day_lop = new ArrayList();
            ds_day_lop = DayLopBUS.Lay_Danh_Sach_Day_Lop_Theo_Mon_Hoc(dldto.MaLop);
            dtgv_DSDayLop.DataSource = ds_day_lop;

        }

        private void frmPhanCongDay_Load(object sender, EventArgs e)
        {
            //do du lieu vao cbbMonHoc
            //ArrayList ds_mon_hoc=SelectAll cua MonHocBUS
            IList ds_mon_hoc = new ArrayList();
            ds_mon_hoc = MonHocBUS.SelectAll();
            //cbb source = ds mon_hoc
            cbbMonDay.DataSource = ds_mon_hoc;
            cbbMonDay.ValueMember = "MaMH";
            cbbMonDay.DisplayMember = "TenMH";
            //do du lieu vao dtgv_DSDayLop
            //lay ma_mon_hoc tu cbbMonHoc
            string ma_mon_hoc = cbbMonDay.SelectedValue.ToString();
            // goi ham Lay_DS_Giao_Vien_Theo_Mon_Hoc cua DayLopBUS
            IList ds_giao_vien = new ArrayList();
            ds_giao_vien = DayLopBUS.Lay_Danh_Sach_Day_Lop_Theo_Mon_Hoc(ma_mon_hoc);
            //do vao datagridview
            dtgv_DSDayLop.DataSource = ds_giao_vien;
            //hien thi


        }
        string kiem_tra_ma = "";// kiem tra ko cho update ma day lop

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (kiem_tra_ma == txtMaGV.Text)
            {
                //khoi tao doi tuong day lop DTO
                DayLopDTO dldto = new DayLopDTO();
                //lay cac gia tri cua cac control            //cap nhat gia tri cho doi tuong gv

                dldto.MaGV = txtMaGV.Text;
                dldto.MaLop = cbbLop.SelectedValue.ToString();

                //goi ham cap nhat cua BUS
                bool kq = DayLopBUS.Cap_Nhat(dldto);
                //thong bao ket qua thuc thi 
                if (kq == true)
                {
                    MessageBox.Show("Giáo viên có Mã số :" + dldto.MaGV + "đã được câp nhật", "Thành Công");
                }
                else
                    MessageBox.Show("Không thành công", "Thất bại");
                //hien thi ds day lop sau khi cap nhat
                //lay ma_mon_hoc tu cbbMonHoc
                string ma_mon_hoc = cbbMonDay.SelectedValue.ToString();

                IList ds_giao_vien = new ArrayList();
                ds_giao_vien = DayLopBUS.Lay_Danh_Sach_Day_Lop_Theo_Mon_Hoc(ma_mon_hoc);
                dtgv_DSDayLop.DataSource = ds_giao_vien;
            }
            else
            {
                MessageBox.Show("Không thể cập nhật Mã Giáo Viên", "Thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (kiem_tra_ma == txtMaGV.Text)
            {
                //khoi tao doi tuong day lop DTO
                DayLopDTO dldto = new DayLopDTO();
                //lay cac gia tri cua cac control            //cap nhat gia tri cho doi tuong gv

                dldto.MaGV = txtMaGV.Text;

                //goi ham cap nhat cua BUS
                bool kq = DayLopBUS.Cap_Nhat(dldto);
                //thong bao ket qua thuc thi 
                if (kq == true)
                {
                    MessageBox.Show("Giáo viên có Mã số :" + dldto.MaGV + "đã được câp nhật", "Thành Công");
                }
                else
                    MessageBox.Show("Không thành công", "Thất bại");
                //hien thi ds day lop sau khi cap nhat
                string ma_mon_hoc = cbbMonDay.SelectedValue.ToString();

                IList ds_giao_vien = new ArrayList();
                ds_giao_vien = DayLopBUS.Lay_Danh_Sach_Day_Lop_Theo_Mon_Hoc(ma_mon_hoc);
                dtgv_DSDayLop.DataSource = ds_giao_vien;
            }
            else
            {
                MessageBox.Show("Không thể cập nhật Mã Giáo Viên", "Thất bại");
            }
        }

        private void dtgv_DSDayLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        //lay ra doi tuong day lop duoc cap nhat

            DayLopDTO dldto = new DayLopDTO();
            dldto = (DayLopDTO)dtgv_DSDayLop.CurrentRow.DataBoundItem;
            //hien thi len các control

            txtMaGV.Text = dldto.MaGV;
            txtHoTen.Text = dldto.MaLop;
            kiem_tra_ma = dldto.MaGV;
        

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}