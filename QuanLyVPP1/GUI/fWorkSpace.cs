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
using System.Globalization;
using QuanLyVPP1.Report;

namespace QuanLyVPP1.GUI
{
    public partial class fWorkSpace : Form
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
                ChanceAccont(LoginAccount.MaCV);
                ShowNhanVien(LoginAccount.TenDangNhap);
            }
        }

        public fWorkSpace(Account_DTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadHDKhachHang();
            LoadCatelory();
            ShowDateBill();
        }
        #region Methods
        void ChanceAccont(string MaCV)              // Phân quyền
        {
            thôngTinNhânViênToolStripMenuItem.Enabled = MaCV == "QL";
            nHÂNSỰToolStripMenuItem.Enabled = MaCV == "QL";
        }
        void LoadHDKhachHang()          // Load Table hoa don
        {
            flpHDKhachHang.Controls.Clear();
            List<HoaDonKhachHang_DTO> HDKHList = HoaDonKhachHang_DAO.Instance.LoadHDKhachHang();
            foreach (HoaDonKhachHang_DTO item in HDKHList)
            {
                Button btn = new Button()
                {
                    Width = HoaDonKhachHang_DAO.HDKhachHangWidth,
                    Height = HoaDonKhachHang_DAO.HDKhachHangHeight
                };
                btn.Text = item.Name + Environment.NewLine + item.TrangThai;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.Aqua;
                        break;
                }
                flpHDKhachHang.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            if (Bill_DAO.Instance.GetUncheckBillIdByTableID(id) != -1)
            {
                txbMaHD.Text = Bill_DAO.Instance.GetUncheckBillIdByTableID(id).ToString();

            }
            else
            {
                txbMaHD.Clear();
            }
            lsvHoaDon.Items.Clear();
            List<SelectBill_DTO> ListBillinfo = SelectBill_DAO.Instance.GetListMenuByTable(id);
            float tongTien = 0;
            foreach (SelectBill_DTO item in ListBillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenHH.ToString());
                lsvItem.SubItems.Add(item.DvTinh.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.TongDonGia.ToString());
                tongTien += item.TongDonGia;
                lsvHoaDon.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txbTotalPrice.Text = tongTien.ToString("c", culture);
        }
        void LoadDate(int id)
        {
            Bill_DTO bill = Bill_DAO.Instance.GetUncheckBillIdByDate(id);
            if(bill ==null)
            {
                dtpNgayVao.Text = DateTime.Now.ToString();
                return;
            }
            dtpNgayVao.Text = bill.NgayNHD.ToString();
        }
        void LoadCatelory()         //Load danh muc hang hoa
        {
            List<Catelory_DTO> listCatelory = Catelory_DAO.Instance.GetListCatelory();
            cmbCatelory.DataSource = listCatelory;
            cmbCatelory.DisplayMember = "TenDSHH";
        }
        void LoadCusByCateloryID(int id)            // Load hang hoa theo MaDS hang hoa
        {
            List<HangHoa_DTO> listHangHoa = HangHoa_DAO.Instance.LoadCusByCateloryID(id);
            listBox1.DataSource = listHangHoa;
            listBox1.DisplayMember = "TenHH";
            //comboBox1.DataSource = listHangHoa;       //-- Hiển thị Hàng hóa khi click theo DSHangHoa trên comboBox (comboBox đã xóa)
            //comboBox1.DisplayMember = "TenHH";
            //lsvHangHoa.Items.Clear();                 // listview đã xóa

            //foreach (HangHoa_DTO item in listHangHoa)
            //{
            //    ListViewItem listHH = new ListViewItem(item.TenHH.ToString());
            //    lsvHangHoa.Items.Add(listHH);
            //}
        }
        void ShowNhanVien(string tenDangNhap)
        {
            Account_DTO acc = Account_DAO.Instance.GetAccountByUsername(tenDangNhap);
            label7.Text = acc.TenHienThi + " đăng xuất \nsau khi hết phiên làm việc";
            txbNhanVien.Text = acc.TenHienThi;
        }
        void ShowDateBill()
        {
            HoaDonKhachHang_DTO HoaDon = lsvHoaDon.Tag as HoaDonKhachHang_DTO;
            if (HoaDon != null)
            {
                Bill_DTO bill = Bill_DAO.Instance.GetUncheckBillIdByDate(HoaDon.ID);
                dtpNgayVao.Text = bill.NgayNHD.ToString();
            }
            else
                return;
        }
        #endregion

        /// ///------------------------------------------------------------------------

        #region Event
        void btn_Click(object sender, EventArgs e)
        {
            int CusBill = ((sender as Button).Tag as HoaDonKhachHang_DTO).ID;
            lsvHoaDon.Tag = (sender as Button).Tag;
            ShowBill(CusBill);
            LoadDate(CusBill);
        }
        private void cmbCatelory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }                
            Catelory_DTO selected = cb.SelectedItem as Catelory_DTO;
            id = selected.MaDSHH;
            LoadCusByCateloryID(id);
        }
        private void btnThemCus_Click(object sender, EventArgs e)
        {
            HoaDonKhachHang_DTO HoaDon = lsvHoaDon.Tag as HoaDonKhachHang_DTO;
            if (HoaDon == null)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn. Click vào hóa đơn để thao tác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maHD = Bill_DAO.Instance.GetUncheckBillIdByTableID(HoaDon.ID);
            //string maHH = (comboBox1.SelectedItem as HangHoa_DTO).MaHH;
            string maHH1 = (listBox1.SelectedItem as HangHoa_DTO).MaHH;
            int soLuong = (int)numSoluongHH.Value;
            if(soLuong==0)
            {
                MessageBox.Show("Ban chua nhap so luong hang hoa", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BillInfo_DAO.Instance.CheckSoLuong(maHH1, soLuong))
                MessageBox.Show("so luong khong du yeu cau", "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                if (maHD == -1)
                {
                    Bill_DAO.Instance.InsertBill(HoaDon.ID);
                    BillInfo_DAO.Instance.InsertBillInfo(maHH1, Bill_DAO.Instance.GetMaxIDBill(), soLuong);
                }
                else
                {
                    BillInfo_DAO.Instance.InsertBillInfo(maHH1, maHD, soLuong);
                }
            }
            ShowBill(HoaDon.ID);
            LoadHDKhachHang();
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            HoaDonKhachHang_DTO HoaDon = lsvHoaDon.Tag as HoaDonKhachHang_DTO;
            if(HoaDon ==null)
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn để thanh toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int maHD = Bill_DAO.Instance.GetUncheckBillIdByTableID(HoaDon.ID);
            int giamGia = (int)numGiamGia.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - totalPrice * (giamGia/100);
            string maNV = LoginAccount.MaNV;
            if (maHD != -1)
            {
                if (MessageBox.Show("Bạn có thực sự muốn thanh toán hóa đơn", "Thông Báo", MessageBoxButtons.OKCancel) ==System.Windows.Forms.DialogResult.OK)
                {
                    Bill_DAO.Instance.CheckOut(maHD, giamGia, (float)finalTotalPrice, maNV);
                    ShowBill(HoaDon.ID);
                    LoadHDKhachHang();
                }
            }
        }
        private void thốngKêBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTKBanHang fTKBanHang = new fTKBanHang();
            fTKBanHang.ShowDialog();
        }

        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fEmployeeManager fem = new fEmployeeManager();
            fem.ShowDialog();
        }

        private void thongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountInfo facc = new fAccountInfo(LoginAccount);
            facc.ShowDialog();
            loginAccount = Account_DAO.Instance.GetAccountByUsername(loginAccount.TenDangNhap);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cậpNhậtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fCapNhatSanPham fcn = new fCapNhatSanPham();
            fcn.InsertHH += Fcn_InsertHH;
            fcn.UpdateHH += Fcn_UpdateHH;
            fcn.DeleteHH += Fcn_DeleteHH;
            fcn.ShowDialog();
        }

        private void Fcn_DeleteHH(object sender, EventArgs e)
        {
            LoadCusByCateloryID((cmbCatelory.SelectedItem as Catelory_DTO).MaDSHH);
            if (lsvHoaDon.Tag != null)
                ShowBill((lsvHoaDon.Tag as HoaDonKhachHang_DTO).ID);
            LoadHDKhachHang();
        }

        private void Fcn_UpdateHH(object sender, EventArgs e)
        {
            LoadCusByCateloryID((cmbCatelory.SelectedItem as Catelory_DTO).MaDSHH);
            if (lsvHoaDon.Tag != null)
                ShowBill((lsvHoaDon.Tag as HoaDonKhachHang_DTO).ID);
        }

        private void Fcn_InsertHH(object sender, EventArgs e)
        {
            LoadCusByCateloryID((cmbCatelory.SelectedItem as Catelory_DTO).MaDSHH);
            if (lsvHoaDon.Tag != null)
                ShowBill((lsvHoaDon.Tag as HoaDonKhachHang_DTO).ID);
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            int giamGia = (int)numGiamGia.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - totalPrice * (giamGia / 100);
            txbTotalPrice.Text = finalTotalPrice.ToString();
        }
        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoanhThu fdoanhthu = new fDoanhThu();
            fdoanhthu.ShowDialog();
        }
        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhoHang fkhohang = new fKhoHang();
            fkhohang.ShowDialog();
        }
        #endregion

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReport frp = new fReport();
            frp.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.ShowHelp(linkLabel1, @"C:\Users\Phung Cong Nguyen\Desktop\New folder (2)\New folder (2).chm");
        }
    }
}
