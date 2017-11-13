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
    public partial class fKhoHang : Form
    {
        public fKhoHang()
        {
            InitializeComponent();
        }
        private void fKhoHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
            DatagridviewColor();
        }
        void LoadKhoHang()
        {
            dgvKhoHang.DataSource = HangHoa_DAO.Instance.LoadHangHoa();
        }
        void DatagridviewColor()
        {
            //dgvKhoHang.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
        }
    }
}
