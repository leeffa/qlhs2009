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
    public partial class MonHoc : Form
    {
        public MonHoc()
        {
            InitializeComponent();
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
            IList list = MonHocBUS.SelectAll();
            dataGridView1.DataSource = list;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            MonHocDTO mh = new MonHocDTO();
            mh.MaMH = txt_ma.Text;
            mh.TenMH = txt_ten.Text;
            if (MonHocBUS.Insert(mh))
            {
                MessageBox.Show("Thêm thành công");
                MonHoc_Load(sender, e);

            }
            else
            {
                MessageBox.Show("Mã môn học đã tồn tại");
                return;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MonHocDTO mh =(MonHocDTO ) dataGridView1.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MonHocBUS.Delete(mh.MaMH))
                {

                    MonHoc_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Tên môn học không tồn tại");
                    return;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            MonHocDTO mh = new MonHocDTO();
            mh.MaMH = txt_ma.Text;
            mh.TenMH = txt_ten.Text;
            if (MonHocBUS.Update(mh))
            {
                MessageBox.Show("Update thành công");
                MonHoc_Load(sender, e);

            }
            else
            {
                MessageBox.Show("Mã môn học đã tồn tại");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MonHocDTO mh = (MonHocDTO)dataGridView1.CurrentRow.DataBoundItem;
            txt_ma.Text = mh.MaMH;
            txt_ten.Text = mh.TenMH;
        }
    }
}