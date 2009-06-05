using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;


namespace Presentation
{
    public partial class QuanLyLopHoc : Form
    {
        public QuanLyLopHoc()
        {
            InitializeComponent();
        }

        private void QuanLyLopHoc_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            load_LopHoc();
            btn_them.Enabled = false;
            txt_malop.ReadOnly = true;
        }
        private void load_LopHoc()
        {
            LopHocBUS lBus = new LopHocBUS();
            IList ds_lop = lBus.LayDanhSach();
            dataGridView1.DataSource = ds_lop;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHocBUS lBus = new LopHocBUS();
            IList ds_lop;
            string makhoi = (string)comboBox1.SelectedItem;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ds_lop = lBus.LayDanhSach();
                    dataGridView1.DataSource = ds_lop;
                    break;
                case 1:
                    ds_lop = lBus.LayDanhSach(makhoi);
                    dataGridView1.DataSource = ds_lop;
                    break;
                case 2:
                    ds_lop = lBus.LayDanhSach(makhoi);
                    dataGridView1.DataSource = ds_lop;
                    break;
                case 3:
                    ds_lop = lBus.LayDanhSach(makhoi);
                    dataGridView1.DataSource = ds_lop;
                    break;
           }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            txt_malop.Text = (string)dataGridView1.Rows[index].Cells["MaLop"].Value;
            txt_tenlop.Text = (string)dataGridView1.Rows[index].Cells["TenLop"].Value;
            cmb_makhoi.SelectedItem = dataGridView1.Rows[index].Cells["MaKhoi"].Value.ToString();
       }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btn_them.Enabled = checkBox1.Checked;
            if (checkBox1.Checked == true)
            {
                txt_malop.ReadOnly = false;
                txt_malop.Text = "";
                txt_tenlop.Text = "";
                cmb_makhoi.SelectedIndex = -1;
                btn_sua.Enabled = false;
                btn_xoa.Enabled = false;
            }
            else
            {
                txt_malop.ReadOnly = true;
                btn_sua.Enabled = true;
                btn_xoa.Enabled = true;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (txt_malop.Text == "")
            {
                label7.Text = "(*)";
                flag = true;
            }
            if (txt_tenlop.Text == "")
            {
                label5.Text = "(*)";
                flag = true;
            }
            if (cmb_makhoi.SelectedIndex == -1)
            {
                label6.Text = "(*)";
                flag = true;
            }
            if (flag == true) return;
            try
            {
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                LopHocDTO ldto = new LopHocDTO();
                ldto.MaLop = txt_malop.Text;
                ldto.TenLop = txt_tenlop.Text;
                ldto.MaKhoi = cmb_makhoi.SelectedItem.ToString();
                LopHocBUS lbus = new LopHocBUS();
                lbus.Them(ldto);

                MessageBox.Show("Đã Thêm thành công !!!!", "Thông Báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_LopHoc();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Thêm thất bại " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thực hiện xóa không?", "Xác nhận!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                string malop = txt_malop.Text;
                LopHocBUS lbus = new LopHocBUS();
                lbus.Xoa(malop);
                MessageBox.Show("Đã Xóa !!!!", "Thông Báo!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_LopHoc();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Xóa thất bại " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                LopHocDTO ldto = new LopHocDTO();
                ldto.MaLop = txt_malop.Text;
                ldto.TenLop = txt_tenlop.Text;
                ldto.MaKhoi = cmb_makhoi.SelectedItem.ToString();

                LopHocBUS lbus = new LopHocBUS();
                lbus.Sua(ldto);
                load_LopHoc();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Sữa thất bại " + ex.Message);
            }
        }
   }
}