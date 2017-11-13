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
    public partial class fCapNhatSanPham : Form
    {
        BindingSource DSHangHoa = new BindingSource();
        public fCapNhatSanPham()
        {
            InitializeComponent();
        }
        private void fCapNhatHang_Load(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = DSHangHoa;
            LoadListHangHoa();
            AddBinding();
            LoadGoodsIntoComb(cmbDanhMuc);
            LoadGoodsIntoComb(cmbDanhMucCN);
        }
        void LoadListHangHoa()
        {
            DSHangHoa.DataSource = HangHoa_DAO.Instance.LoadHangHoa();
        }
        void AddBinding()
        {
            txbMaHH.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "Mã HH", true, DataSourceUpdateMode.Never));
            txbTenHH.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "Tên HH", true, DataSourceUpdateMode.Never));
            numGia.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Giá Bán", true, DataSourceUpdateMode.Never));
            txbDVTinh.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "ĐV Tính", true, DataSourceUpdateMode.Never));
            numSoLuong.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Số Lượng", true, DataSourceUpdateMode.Never));
            numGiaMua.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Giá Mua", true, DataSourceUpdateMode.Never));
            txbMaHHCN.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "Mã HH", true, DataSourceUpdateMode.Never));
            txbTenHHCN.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "Tên HH", true, DataSourceUpdateMode.Never));
            numGiaCN.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Giá Bán", true, DataSourceUpdateMode.Never));
            txbDVTinhCN.DataBindings.Add(new Binding("Text", dgvHangHoa.DataSource, "ĐV Tính", true, DataSourceUpdateMode.Never));
            numSoLuongCN.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Số Lượng", true, DataSourceUpdateMode.Never));
            numGiaMuaCN.DataBindings.Add(new Binding("Value", dgvHangHoa.DataSource, "Giá Mua", true, DataSourceUpdateMode.Never));
        }
        void LoadGoodsIntoComb(ComboBox cb)
        {
            cb.DataSource = Catelory_DAO.Instance.GetListCatelory();
            cb.DisplayMember = "TenDSHH";
        }

        private void txbMaHH_TextChanged(object sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedCells.Count > 0)
            {
                if (dgvHangHoa.SelectedCells[0].OwningRow.Cells["Mã DS"].Value == null)
                    return;
                int maDSHH = (int)dgvHangHoa.SelectedCells[0].OwningRow.Cells["Mã DS"].Value;
                Catelory_DTO catelory = Catelory_DAO.Instance.GetCateloryByID(maDSHH);
                cmbDanhMuc.SelectedItem = catelory;
                int index = -1;
                int i = 0;
                foreach (Catelory_DTO item in cmbDanhMuc.Items)
                {
                    if (item.MaDSHH == catelory.MaDSHH)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cmbDanhMuc.SelectedIndex = index;
            }
        }
        private void txbMaHHCN_TextChanged(object sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedCells.Count > 0)
            {
                if (dgvHangHoa.SelectedCells[0].OwningRow.Cells["Mã DS"].Value == null)
                    return;
                int maDSHH = (int)dgvHangHoa.SelectedCells[0].OwningRow.Cells["Mã DS"].Value;
                Catelory_DTO catelory = Catelory_DAO.Instance.GetCateloryByID(maDSHH);
                cmbDanhMucCN.SelectedItem = catelory;
                int index = -1;
                int i = 0;
                foreach (Catelory_DTO item in cmbDanhMucCN.Items)
                {
                    if (item.MaDSHH == catelory.MaDSHH)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cmbDanhMucCN.SelectedIndex = index;
            }
        }
        private void btnThemHH_Click(object sender, EventArgs e)
        {
            string maHH = txbMaHH.Text;
            string tenHH = txbTenHH.Text;
            string dvTinh = txbDVTinh.Text;
            float donGia = (float)numGia.Value;
            float giaMua = (float)numGiaMua.Value;
            int maDSHH = (cmbDanhMuc.SelectedItem as Catelory_DTO).MaDSHH;
            int soLuong = (int)numSoLuong.Value;
            string maHK = maHH;

            if (giaMua > donGia)
            {
                float Lo = giaMua - donGia;
                MessageBox.Show("Giá mua lớn hơn giá bán \nBạn sẽ lỗ: " + Lo.ToString() + " vnd", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            if (HangHoa_DAO.Instance.CheckMaHH(maHH))
            {
                MessageBox.Show("Mã hàng hóa của bạn bị trùng. Vui lòng nhập mã khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                if (HangHoa_DAO.Instance.InsertHH(maHH, tenHH, dvTinh, giaMua, donGia, maDSHH, maHK, soLuong))
                {
                    MessageBox.Show("Thêm hàng hóa thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadListHangHoa();
                    if (insertHH != null)
                    {
                        insertHH(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Thêm hàng hóa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        private void btnSuaHH_Click_1(object sender, EventArgs e)
        {
            string maHH = txbMaHHCN.Text;
            string tenHH = txbTenHHCN.Text;
            string dvTinh = txbDVTinhCN.Text;
            float giaMua = (float)numGiaMuaCN.Value;
            float donGia = (float)numGiaCN.Value;
            int maDSHH = (cmbDanhMucCN.SelectedItem as Catelory_DTO).MaDSHH;
            int soLuong = (int)numSoLuongCN.Value;
            string maHK = maHH;

            if (giaMua > donGia)
            {
                float Lo = giaMua - donGia;
                MessageBox.Show("Bạn có chắc giá mua lớn hơn giá bán \nBạn sẽ lỗ: " + Lo.ToString() + " vnd", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            if (HangHoa_DAO.Instance.UpdateHH(maHH, tenHH, dvTinh, giaMua, donGia, maDSHH, maHK, soLuong))
            {
                MessageBox.Show("Cập nhật hàng hóa thành công", "Thông Báo", MessageBoxButtons.OK);
                LoadListHangHoa();
                if (updateHH != null)
                {
                    updateHH(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm hàng hóa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadListHangHoa();
        }

        private void txbTimHH_TextChanged(object sender, EventArgs e)
        {
            string tenHH = txbTimHH.Text;
            DSHangHoa.DataSource = HangHoa_DAO.Instance.SearchHangHoa(tenHH);
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            string maHH = txbMaHH.Text;
            if (HangHoa_DAO.Instance.DeleteHH(maHH))
            {
                MessageBox.Show("Xóa hàng hóa thành công", "Thông Báo", MessageBoxButtons.OK);
                LoadListHangHoa();
                if(deleteHH!=null)
                {
                    deleteHH(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa hàng hóa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private event EventHandler insertHH;
        public event EventHandler InsertHH
        {
            add { insertHH += value; }
            remove { insertHH -= value; }
        }

        private event EventHandler deleteHH;
        public event EventHandler DeleteHH
        {
            add { deleteHH += value; }
            remove { deleteHH -= value; }
        }

        private event EventHandler updateHH;
        public event EventHandler UpdateHH
        {
            add { updateHH += value; }
            remove { updateHH -= value; }
        }
    }
}
