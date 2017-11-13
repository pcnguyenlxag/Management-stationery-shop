using QuanLyVPP1.DAO;
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
    public partial class fTKBanHang : Form
    {
        public fTKBanHang()
        {
            InitializeComponent();
            LoadDateTimePicker();
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }
        #region methods
        void LoadListBillByDate(DateTime NgayNHD, DateTime NgayXHD)
        {
            dgvHoaDon.DataSource = Bill_DAO.Instance.GetListBillByDate(NgayNHD, NgayXHD);
        }
        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }
        #endregion
        #region event
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }
        #endregion
    }
}
