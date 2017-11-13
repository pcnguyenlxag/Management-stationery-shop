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
    public partial class fEmployeeManager : Form
    {
        BindingSource DSNhanVien = new BindingSource();
        public fEmployeeManager()
        {
            InitializeComponent();
        }

        private void fEmployeeManager_Load(object sender, EventArgs e)
        {
            dgvThongTinNV.DataSource = DSNhanVien;
            LoadListNhanVien();
            AddBinding();
            LoadChucVuIntoCmb(comChucVu);
        }
        void LoadListNhanVien()
        {
            DSNhanVien.DataSource = Account_DAO.Instance.LoadNhanVien();
        }
        void AddBinding()
        {
            txbMaNV.DataBindings.Add(new Binding("Text", dgvThongTinNV.DataSource, "Mã NV", true, DataSourceUpdateMode.Never));
            txbTenNV.DataBindings.Add(new Binding("Text", dgvThongTinNV.DataSource, "Tên NV", true, DataSourceUpdateMode.Never));
            txbDiaChi.DataBindings.Add(new Binding("Text", dgvThongTinNV.DataSource, "Địa Chỉ", true, DataSourceUpdateMode.Never));
            txbSoDT.DataBindings.Add(new Binding("Text", dgvThongTinNV.DataSource, "Số DT", true, DataSourceUpdateMode.Never));
        }
        void LoadChucVuIntoCmb(ComboBox cb)
        {
            cb.DataSource = ChucVu_DAO.Instance.GetListChucVu();
            cb.DisplayMember = "TenChucVu";
        }
        #region Event
        private void txbMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txbMaNV.Text;
            if (maNV != (string)dgvThongTinNV.SelectedCells[0].OwningRow.Cells["Mã NV"].Value)
            {
                txbTenNV.Clear();
                txbDiaChi.Clear();
                txbSoDT.Clear();
                txbUser.Clear();
                txbDisplayName.Clear();
                return;
            }
            if (dgvThongTinNV.SelectedCells.Count > 0)
            {
                string maCV = (string)dgvThongTinNV.SelectedCells[0].OwningRow.Cells["Chức Vụ"].Value;
                string trangThaiNV = (string)dgvThongTinNV.SelectedCells[0].OwningRow.Cells["Trạng Thái"].Value;
                if (trangThaiNV == "Đã Nghỉ Việc")
                {
                    txbUser.Text = "Đã nghỉ việc";
                    txbDisplayName.Text = "Đã nghỉ việc";
                    return;
                }
                else
                {
                    txbUser.Text = Account_DAO.Instance.GetAccountByMaNV(maNV).TenDangNhap;
                    txbDisplayName.Text = Account_DAO.Instance.GetAccountByMaNV(maNV).TenHienThi;
                }
                ChucVu_DTO chucvu = ChucVu_DAO.Instance.GetChucVuByMaCV(maCV);
                comChucVu.SelectedItem = chucvu;
                int index = -1;
                int i = 0;
                if (maCV == null)
                    return;
                foreach (ChucVu_DTO item in comChucVu.Items)
                {
                    if (item.MaCV == chucvu.MaCV)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comChucVu.SelectedIndex = index;
                
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string maNV = txbMaNV.Text;
            string tenNV = txbTenNV.Text;
            string DiaChi = txbDiaChi.Text;
            string SDT = txbSoDT.Text;
            string tenDangNhap = txbUser.Text;
            string tenHienThi = tenDangNhap;
            string maCV = (comChucVu.SelectedItem as ChucVu_DTO).MaCV;
            string tenChucVu = (comChucVu.SelectedItem as ChucVu_DTO).TenChucVu;
            string passWord = "111111";

            if (Account_DAO.Instance.checkMaNV(maNV))
            {
                MessageBox.Show("Mã nhân viên bạn nhập đã trùng. Vui lòng nhập mã nhân viên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                if (GetUser_DAO.Instance.CheckUser(tenDangNhap))
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                {
                    if (Account_DAO.Instance.InsertNhanVien(maCV, tenChucVu, maNV, tenNV, SDT, DiaChi, tenDangNhap, tenHienThi, passWord))
                    {
                        MessageBox.Show("Thêm nhân viên thàng công", "Thông Báo", MessageBoxButtons.OK);
                        LoadListNhanVien();
                    }
                    else
                        MessageBox.Show("Thêm nhân viên không thàng công", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            string maNV = txbMaNV.Text;
            string tenNV = txbTenNV.Text;
            string DiaChi = txbDiaChi.Text;
            string SDT = txbSoDT.Text;
            string tenDangNhap = txbUser.Text;
            string tenHienThi = tenDangNhap;
            string maCV = (comChucVu.SelectedItem as ChucVu_DTO).MaCV;
            string tenChucVu = (comChucVu.SelectedItem as ChucVu_DTO).TenChucVu;

            if (GetUser_DAO.Instance.GetUser(maNV, tenDangNhap))
            {
                if (Account_DAO.Instance.UpdateNhanVien(maCV, tenChucVu, maNV, tenNV, SDT, DiaChi))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thàng công", "Thông Báo", MessageBoxButtons.OK);
                    LoadListNhanVien();
                }
                else
                    MessageBox.Show("Cập nhật thông tin nhân viên không thàng công", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                if (GetUser_DAO.Instance.CheckUser(tenDangNhap))
                {
                    MessageBox.Show("Tên đăng nhập đã trùng", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                else
                    Account_DAO.Instance.UpdateUserAccount(maNV, tenDangNhap);
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            DSNhanVien.DataSource = Account_DAO.Instance.SearchByName(txbTimKiemNV.Text);
        }
        #endregion

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadListNhanVien();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string maNV = txbMaNV.Text;
            if (Account_DAO.Instance.DeleteAccount(maNV))
            {
                MessageBox.Show("Xóa nhân viên thàng công", "Thông Báo", MessageBoxButtons.OK);
                LoadListNhanVien();
            }
            else
                MessageBox.Show("Xóa nhân viên không thàng công", "Thông Báo", MessageBoxButtons.OK);
        }

        private void btnResetMK_Click(object sender, EventArgs e)
        {
            string maNV = txbMaNV.Text;
            if (Account_DAO.Instance.ResetAccount(maNV))
            {
                MessageBox.Show("Reset mật khẩu nhân viên thàng công", "Thông Báo", MessageBoxButtons.OK);
                LoadListNhanVien();
            }
            else
                MessageBox.Show("Reset mật khẩu nhân viên không thàng công", "Thông Báo", MessageBoxButtons.OK);
        }
    }
}
