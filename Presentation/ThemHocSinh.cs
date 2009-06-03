using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BUS;
using DTO;
using System.Collections;
namespace Presentation
{
    public partial class ThemHocSinh : Form
    {
        public ThemHocSinh()
        {
            InitializeComponent();
        }
        string hinhanh = "";
       /* private void btn_chon_Click(object sender, EventArgs e)
        {
            if (openFileDialogHinhAnh.ShowDialog() == DialogResult.OK)
            {
                string SourceFilePath = openFileDialogHinhAnh.FileName;
                string SourceFileName = openFileDialogHinhAnh.SafeFileName;
               
                string DesFilePath = Application.StartupPath + "\\HinhAnhHocSinh\\" + SourceFileName;
                if(File.Exists(DesFilePath)==false)
                File.Copy(SourceFilePath, DesFilePath,false);
                hinhanh = "\\HinhAnhHocSinh\\" + SourceFileName;
                txt_HinhAnh.Text = SourceFilePath;
                pictureBox1.Image = Image.FromFile(SourceFilePath);
            }
        }*/

        private void btn_Them_Click(object sender, EventArgs e)
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs.MaHS = txt_Ma.Text;
            hs.HanhKiem = txt_HanhKiem.Text;
            hs.HoTen = txt_Hoten.Text;
            hs.SoDienThoai = int.Parse(txt_DienThoai.Text);
            hs.HinhAnh = hinhanh;
            hs.NgaySinh = dtp_NgaySinh.Value;
            hs.NgayNhapTruong = dtp_NgayNhapTruong.Value;
            hs.DiaChi = txt_DiaChi.Text;
            int index = cbb_MaLop.SelectedIndex;

            hs.MaLop = cbb_MaLop.Items[index].ToString();
            if (HocSinhBUS.Insert(hs))
                MessageBox.Show("Thêm thành công");
            else
            {
                MessageBox.Show("Mã học sinh đã tồn tại");
                return;
            }

            ThemHocSinh_Load(sender, e);
        }

        private void ThemHocSinh_Load(object sender, EventArgs e)
        {
            IList list = HocSinhBUS.SelectAll();
            dgv_DanhSach.DataSource = list;
            if(dgv_DanhSach.RowCount>0)
                pictureBox1.Image=Image.FromFile(Application.StartupPath+ dgv_DanhSach.Rows[0].Cells["Column9"].Value.ToString());
        }

        private void dgv_DanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs = (HocSinhDTO)dgv_DanhSach.CurrentRow.DataBoundItem;
            pictureBox1.Image = Image.FromFile(Application.StartupPath+ hs.HinhAnh);
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs = (HocSinhDTO)dgv_DanhSach.CurrentRow.DataBoundItem;
            if (HocSinhBUS.Delete(hs.MaHS))
            {
                ThemHocSinh_Load(sender, e);
            }
            else {
                MessageBox.Show("Học sinh không tồn tại");
                return;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            HocSinhDTO hs = new HocSinhDTO();
            hs.MaHS = txt_Ma.Text;
            hs.HanhKiem = txt_HanhKiem.Text;
            hs.HoTen = txt_Hoten.Text;
            hs.SoDienThoai = int.Parse(txt_DienThoai.Text);
            hs.HinhAnh = hinhanh;
            hs.NgaySinh = dtp_NgaySinh.Value;
            hs.NgayNhapTruong = dtp_NgayNhapTruong.Value;
            hs.DiaChi = txt_DiaChi.Text;
            int index = cbb_MaLop.SelectedIndex;

            hs.MaLop = cbb_MaLop.Items[index].ToString();
            if (HocSinhBUS.Update(hs))
                MessageBox.Show("Update thành công");
            else
            {
                MessageBox.Show("Mã học sinh đã tồn tại");
                return;
            }

            ThemHocSinh_Load(sender, e);
        }
    }
}