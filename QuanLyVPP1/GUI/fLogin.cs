using QuanLyVPP1.DAO;
using QuanLyVPP1.DTO;
using QuanLyVPP1.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVPP1
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn co thực sự muốn thoát chương trình", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txbTenDN.Text;
            string passWord = txbMatKhau.Text;
            if (Login(userName, passWord))
            {
                Account_DTO loginAccount = Account_DAO.Instance.GetAccountByUsername(userName);
                fWorkSpace fwp = new fWorkSpace(loginAccount);
                Hide();
                fwp.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK);
            }
        }
        bool Login(string userName, string passWord)
        {
            return Account_DAO.Instance.Login(userName, passWord);

        }
    }
}
