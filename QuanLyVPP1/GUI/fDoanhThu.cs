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
    public partial class fDoanhThu : Form
    {
        public fDoanhThu()
        {
            InitializeComponent();
        }

        private void fDoanhThu_Load(object sender, EventArgs e)
        {
            LoadLoiNhuan();
        }
        void LoadLoiNhuan()
        {
            dgvLoiNhuan.DataSource = DoanhThu_DAO.Instance.GetLoiNhuan();
        }
    }
}
