using System;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
                MessageBox.Show("Bạn phải nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            UserDTO usr=Bus.KiemTraDangNhap(txtUserName.Text,txtPassword.Text);
            if (usr.ID == "")
            {
                MessageBox.Show("Đăng nhập thất bại.\n Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ((frmMain)this.MdiParent).Thanhvien = usr;
                Close();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}