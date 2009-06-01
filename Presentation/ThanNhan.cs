using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Collections;
namespace Presentation
{
    public partial class ThanNhan : Form
    {
        public ThanNhan()
        {
            InitializeComponent();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThanNhanDTO tn = new ThanNhanDTO();
            tn.Ma = txt_Ma.Text;
            tn.HoTen = txt_hoten.Text;
            tn.QuanHe = txt_quanhe.Text;
            tn.MaHS = txt_quanhe.Text;
            if (ThanNhanBUS.Insert(tn))
            {
                MessageBox.Show("Thêm thành công");
                ThanNhan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Mã thân nhân đã tồn tại");
                return;
            }
        }


        private void ThanNhan_Load(object sender, EventArgs e)
        {
            IList list = ThanNhanBUS.SelectAll();
            dataGridView1.DataSource = list;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ThanNhanDTO tn=(ThanNhanDTO ) dataGridView1.CurrentRow.DataBoundItem;
            if (ThanNhanBUS.Delete(tn.Ma))
                ThanNhan_Load(sender, e);
            else
            {
                MessageBox.Show("Thân nhân không tồn tại");
                return;

            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ThanNhanDTO tn = new ThanNhanDTO();
            tn.Ma = txt_Ma.Text;
            tn.HoTen = txt_hoten.Text;
            tn.QuanHe = txt_quanhe.Text;
            tn.MaHS = txt_quanhe.Text;
            if (ThanNhanBUS.Update(tn))
            {
                MessageBox.Show("Update thành công");
                ThanNhan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Mã thân nhân đã tồn tại");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ThanNhanDTO tn = (ThanNhanDTO)dataGridView1.CurrentRow.DataBoundItem;
             txt_Ma.Text=tn.Ma ;
             txt_hoten.Text=tn.HoTen ;
             txt_quanhe.Text= tn.QuanHe;
             txt_maHS.Text= tn.MaHS;
        }
    }
}