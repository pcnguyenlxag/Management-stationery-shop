using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyVPP1.Report;

namespace QuanLyVPP1.GUI
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
            documentViewer2.DocumentSource = typeof(QuanLyVPP1.Report.XtraReport1);
        }
    }
}
