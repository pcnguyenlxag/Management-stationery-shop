using QuanLyVPP1.DAO;
using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVPP1.GUI
{
    public partial class fAccountInfo : Form
    {
        Account_DTO loginAccount;

        public Account_DTO LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                LoadAccounInfo(LoginAccount);
            }
        }
        public fAccountInfo(Account_DTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        public void UpdateAccount()
        {
            string tenHienThi = txbDisplayName.Text;
            string tenDangNhap = txbUserName.Text;
            string diaChi = txbAddress.Text;
            string soDT = txbTel.Text;
            string passWord = txbPss.Text;
            if(soDT.Length>11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (Account_DAO.Instance.UpdateAccount(tenDangNhap, tenHienThi, passWord, diaChi, soDT))
            {
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK);
                //LoadAccounInfo(LoginAccount);
            }
            else
                MessageBox.Show("Cập nhật không thành công", "Thông Báo", MessageBoxButtons.OK);
            
        }
        public void UpdatePssAccount()
        {
            string tenDangNhapPss = txbUsChancePss.Text;
            string tenHienThiPss = txbDsChancePss.Text;
            string passWord = txbOldPss.Text;
            string newPassWord = txbNewPss.Text;
            string renewPass = txbRenewPss.Text;
            if (!renewPass.Equals(newPassWord))
                MessageBox.Show("Mật khẩu mới không khớp với nhập lại mật khẩu", "Thông Báo", MessageBoxButtons.OK);
            else
            {
                if (Account_DAO.Instance.UpdatePssAccount(tenDangNhapPss, tenHienThiPss, passWord, newPassWord))
                    MessageBox.Show("Cập nhật thành công");
                else
                    MessageBox.Show("Vui lòng nhập lại mật khẩu");
            }
        }

        void LoadAccounInfo(Account_DTO acc)
        {
            txbUserName.Text = acc.TenDangNhap;
            txbUsChancePss.Text = acc.TenDangNhap;
            txbDisplayName.Text = acc.TenHienThi;
            txbDsChancePss.Text = acc.TenHienThi;
            comJob.Text = acc.TenChucVu;
            comjob2.Text = acc.TenChucVu;
            txbTel.Text = acc.SoDT.ToString();
            txbAddress.Text = acc.DiaChi.ToString(); 
        }
        private void btnExitAcc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExitChancePass_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUpdateAcc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật thông tin", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateAccount();
            }
        }

        private void btnChancePass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đỗi PassWord", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                UpdatePssAccount();
        }
    }
}
