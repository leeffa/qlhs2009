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

        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            hocSinhToolStripMenuItem.Enabled = giaoVienToolStripMenuItem.Enabled =
                monHocToolStripMenuItem.Enabled = khoiLopToolStripMenuItem.Enabled =(Thanhvien.LoaiUser == 1);
            diemToolStripMenuItem.Enabled = (Thanhvien.LoaiUser == 2);
            giaoVienToolStripMenuItem1.Enabled = hocSinhToolStripMenuItem1.Enabled = (Thanhvien.LoaiUser == 1 || Thanhvien.LoaiUser==2);
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
    }
}