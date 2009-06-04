using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;
namespace Presentation
{
    public partial class frmDiem : Form
    {
        public frmDiem()
        {
            InitializeComponent();
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            cmbKhoi.ValueMember = "MaKhoi";
            cmbKhoi.DisplayMember = "TenKhoi";
            cmbKhoi.DataSource = KhoiBUS.SelectAll();
            cmbMon.ValueMember = "MaMon";
            cmbMon.DisplayMember = "TenMon";         

        }

        private void cmbKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            cmbLop.DisplayMember = "TenLop";
            cmbLop.ValueMember = "MaLop";
            cmbLop.DataSource = LopBUS.Select_byKhoi(cmbKhoi.SelectedValue.ToString());

            
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {   
            gridDanhSach.DataSource = Bus.Get_DiemInfo(cmbLop.SelectedValue.ToString());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            gridDanhSach.DataSource = Bus.Get_DiemInfo(cmbLop.SelectedValue.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắc muốn lưu thông tin không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                DataTable dt = (DataTable)gridDanhSach.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DiemDTO diem = new DiemDTO();
                    //       diem.MaMH = cmbMon.SelectedValue.ToString();
                    diem.MaMH = "1";
                    diem.MaHS = dt.Rows[i]["MaHS"].ToString();
                    if (dt.Rows[i]["Diem15"].ToString() != "")
                    {
                        diem.Diem15 = float.Parse(dt.Rows[i]["Diem15"].ToString());
                    }
                    if (dt.Rows[i]["Diem1T"].ToString() != "")
                    {
                        diem.Diem1T = float.Parse(dt.Rows[i]["Diem1T"].ToString());
                    }
                    if (dt.Rows[i]["DiemThi"].ToString() != "")
                    {
                        diem.DiemThi = float.Parse(dt.Rows[i]["DiemThi"].ToString());
                    }
                    if (dt.Rows[i]["DiemTB"].ToString() != "")
                    {
                        diem.DiemTB = float.Parse(dt.Rows[i]["DiemTB"].ToString());
                    }
                    DiemBUS.Update_Diem(diem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridDanhSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void gridDanhSach_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Bạn phải nhập vào một số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}