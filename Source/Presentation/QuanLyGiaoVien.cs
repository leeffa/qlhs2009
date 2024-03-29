using System;
using System.Collections.Generic;
using System.Collections ;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
namespace Presentation
{
    public partial class QuanLyGiaoVien : Form
    {
        public QuanLyGiaoVien()
        {
            InitializeComponent();
        }
        public void Show_Giao_Vien_Theo_Mon_Hoc(string ma_mon_hoc)
        {
            IList ds_giao_vien = new ArrayList();
            ds_giao_vien = GiaoVienBUS.Lay_Danh_Sach_Giao_Vien_Theo_Mon_Hoc(ma_mon_hoc);
            //do vao datagridview
            //dtgv_DSGiaoVien.DataSource = ds_giao_vien;
            dtgv_DSGiaoVien.Rows.Clear();
            foreach (GiaoVienDTO gvdto in ds_giao_vien)
            {
                dtgv_DSGiaoVien.Rows.Add(gvdto.MaGV, gvdto.HoTen, gvdto.MonDay);
            }

        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            //khoi tao doi tuong day lop
            GiaoVienDTO gvdto = new GiaoVienDTO();
            //gvdto = các giá trị thông tin của các control.
            gvdto.MaGV=txtMaGV.Text;
            gvdto.HoTen= txtHoTen.Text;
            gvdto.MonDay=cbbMonDay.SelectedValue.ToString();
            //goi phuong thuc insert của BUS
            bool kq = GiaoVienBUS.Them_Giao_Vien(gvdto);
            //neu insert thanh cong hien thi messagebox
            if (kq == true)
            {
                MessageBox.Show("Thêm Thành Công", "Thêm");
            }
            else
                MessageBox.Show("Không Thành Công!\r\n Chọn Mã Giáo Viên khác", "Thất Bại");
            //hien thi ds day lop le dtgv_DS_Giao_Vien
            Show_Giao_Vien_Theo_Mon_Hoc(gvdto.MonDay);
        }

        private void QuanLyGiaoVien_Load(object sender, EventArgs e)
        {
            //do du lieu vao cbbMonHoc
                //ArrayList ds_mon_hoc=SelectAll cua MonHocBUS
            IList ds_mon_hoc = new ArrayList();
            ds_mon_hoc = MonHocBUS.SelectAll();
                //cbb source = ds mon_hoc
            cbbMonDay.DataSource = ds_mon_hoc;
            cbbMonDay.ValueMember = "MaMH";
            cbbMonDay.DisplayMember = "TenMH";
            //do du lieu vao dtgv_DSGiaoVien
                //lay ma_mon_hoc tu cbbMonHoc
            string ma_mon_hoc = cbbMonDay.SelectedValue.ToString();
            Show_Giao_Vien_Theo_Mon_Hoc(ma_mon_hoc);
                //do vao datagridview
            //dtgv_DSGiaoVien.DataSource = ds_giao_vien;

        }
        string kiem_tra_ma = "";// kiem tra ko cho update ma day lop
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (kiem_tra_ma==txtMaGV.Text)
            {
                //khoi tao doi tuong day lop DTO
                GiaoVienDTO gvdto = new GiaoVienDTO();
                //lay cac gia tri cua cac control            //cap nhat gia tri cho doi tuong gv

                gvdto.MaGV = txtMaGV.Text;
                gvdto.HoTen = txtHoTen.Text;
                gvdto.MonDay = cbbMonDay.SelectedValue.ToString();

                //goi ham cap nhat cua BUS
                bool kq = GiaoVienBUS.Cap_Nhat(gvdto);
                //thong bao ket qua thuc thi 
                if (kq == true)
                {
                    MessageBox.Show("Giáo viên có Mã số :" + gvdto.MaGV + "đã được câp nhật", "Thành Công");
                }
                else
                    MessageBox.Show("Không thành công", "Thất bại");
                //hien thi ds day lop sau khi cap nhat
                Show_Giao_Vien_Theo_Mon_Hoc(gvdto.MonDay);
            } 
            else
            {
                MessageBox.Show("Không thể cập nhật Mã Giáo Viên", "Thất bại");
            }
            
        }
        // xu ly su kien khi 1 cell trong dtgv_DSGiaoVien duoc click
        private void dtgv_DSGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            //lay ra doi tuong day lop duoc cap nhat

            GiaoVienDTO gvdto = new GiaoVienDTO();
            gvdto = (GiaoVienDTO)dtgv_DSGiaoVien.CurrentRow.DataBoundItem;
            //hien thi len các control

            txtMaGV.Text = dtgv_DSGiaoVien.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dtgv_DSGiaoVien.CurrentRow.Cells[1].Value.ToString();
            kiem_tra_ma = dtgv_DSGiaoVien.CurrentRow.Cells[2].Value.ToString();
        }
        //xu ly su kien khi thay doi gia tri chon trong cbbMonDay
        private void cbbMonDay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //lay ma_mon_hoc tu cbb mon hoc
            string ma_mon_hoc = cbbMonDay.SelectedValue.ToString();
            //hien thi ds day lop le dtgv_DS_Giao_Vien
            Show_Giao_Vien_Theo_Mon_Hoc(ma_mon_hoc);
        }
        //xu ly su kien khi bam button Xoa 1 day lop
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //hien thi hop thoai xác nhận
            DialogResult dlgrlt = MessageBox.Show("Xóa giáo viên có mã số: " + txtMaGV.Text + " ?", "Xóa", MessageBoxButtons.YesNo);
            if (dlgrlt==DialogResult.Yes)
            {
                    //khoi tao doi tuong gvdto
                GiaoVienDTO gvdto = new GiaoVienDTO();
                //gan gia tri cho gvdto tu cac control
                gvdto.MaGV=txtMaGV.Text;
                gvdto.MonDay = cbbMonDay.SelectedValue.ToString();
                //goi ham Xoa cua BUS
                bool kq = GiaoVienBUS.Xoa(gvdto);
                //thong bao ket qua cho nguoi dung
                if (kq==true)
                {
                    MessageBox.Show("Xóa thành công");
                    //hien thi ds day lop le dtgv_DS_Giao_Vien
                    Show_Giao_Vien_Theo_Mon_Hoc(gvdto.MonDay);

                } 
                else
                {
                    MessageBox.Show("Không thành công\r\n Vui lòng thử lại");
                }
            }

            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //ma day lop ko cho nhap khoang trang va cac ki tu la
      private void txtMaGV_KeyPress(object sender, KeyPressEventArgs e)
        {
          //khong cho nhap cac ki khac chu va so
            if ( char.IsLetterOrDigit(e.KeyChar)!=true)
                
            {
                
                e.Handled = true;
            } 
          //cho phep xoa lui
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
        //khong cho nhap so

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            //khong cho nhap so
            if (char.IsLetter(e.KeyChar)!=true)
            {
                e.Handled = true;
            }
            //cho phep xoa lui
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

       
        
    }
}