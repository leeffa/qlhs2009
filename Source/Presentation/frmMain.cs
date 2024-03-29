using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
namespace Presentation
{
    public partial class frmMain : Form
    {
        public UserDTO Thanhvien = new UserDTO();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DM_GiaoVientoolStripMenuItem.Enabled =
                DM_HocSinhtoolStripMenuItem.Enabled =
                DM_KhoiLoptoolStripMenuItem.Enabled =
                DM_MonHoctoolStripMenuItem.Enabled = false;
            frmDangNhap frm = new frmDangNhap();
           // frm.MdiParent = this;
            // frm.Show();
            frm.ShowDialog(this);
        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Thanhvien.ID!="")
            {
                if (MessageBox.Show("Bạn có chắc là muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Thanhvien.ID = Thanhvien.Pass = "";
                    Thanhvien.LoaiUser = 0;
                    dangNhapToolStripMenuItem.Text = "Đăng nhập";
                    foreach (Form form in this.MdiChildren)
                    {
                        form.Close();
                    }
                }                
            }
            else
            {
                foreach (Form form in this.MdiChildren)
                {
                    if (form.Name.Equals("frmDangNhap"))
                    {
                        form.Close();
                    }
                }
                frmDangNhap frm = new frmDangNhap();
                frm.MdiParent = this;
                frm.Show();  
            }     
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            hocSinhToolStripMenuItem.Enabled = giaoVienToolStripMenuItem.Enabled =
                monHocToolStripMenuItem.Enabled = khoiLopToolStripMenuItem.Enabled =(Thanhvien.LoaiUser == 1);
            diemToolStripMenuItem.Enabled = (Thanhvien.LoaiUser == 2);
            giaoVienToolStripMenuItem1.Enabled = hocSinhToolStripMenuItem1.Enabled = (Thanhvien.LoaiUser == 1 || Thanhvien.LoaiUser==2);
            if (Thanhvien.ID != "")
                dangNhapToolStripMenuItem.Text = "Đăng xuất";
            else
                dangNhapToolStripMenuItem.Text = "Đăng nhập";
        }

        private void diemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals("frmDiem"))
                {
                    form.Close();
                }
            }
            frmDiem frm = new frmDiem();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hocSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals("ThemHocSinh"))
                {
                    form.Close();
                }
            }
            ThemHocSinh frm = new ThemHocSinh();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void giaoVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals("QuanLyGiaoVien"))
                {
                    form.Close();
                }
            }
            QuanLyGiaoVien frm = new QuanLyGiaoVien();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void monHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals("MonHoc"))
                {
                    form.Close();
                }
            }
            MonHoc frm = new MonHoc();
            frm.MdiParent = this;
            frm.Show();  
        }

        private void khoiLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals("MonHoc"))
                {
                    form.Close();
                }
            }
            MonHoc frm = new MonHoc();
            frm.MdiParent = this;
            frm.Show();  
            
        }

        private void giaoVienToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xin lỗi!Trong thời gian tới,chúng tôi sẽ hoàn thành chức năng này ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hocSinhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xin lỗi!Trong thời gian tới,chúng tôi sẽ hoàn thành chức năng này ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void giupDoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thongTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

        }
    }
}