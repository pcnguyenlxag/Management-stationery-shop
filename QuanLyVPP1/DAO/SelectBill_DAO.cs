using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyVPP1.DTO;
using System.Data;

namespace QuanLyVPP1.DAO
{
    public class SelectBill_DAO
    {
        private static SelectBill_DAO instance;

        public static SelectBill_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SelectBill_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private SelectBill_DAO() { }

        public List<SelectBill_DTO> GetListMenuByTable(int id)
        {
            List<SelectBill_DTO> ListMenu = new List<SelectBill_DTO>();
            string query = "select HangHoa.TenHH, HangHoa.DVTinh,ChiTietHD.SoLuong, HangHoa.DonGia, HangHoa.DonGia*ChiTietHD.SoLuong as TongDonGia from HDKhachHang, HoaDon, ChiTietHD, HangHoa where HoaDon.MaHD = ChiTietHD.MaHD and HDKhachHang.id = HoaDon.id  and HangHoa.MaHH = ChiTietHD.MaHH and HoaDon.TrangThai = 1 and HDKhachHang.id=" + id;
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                SelectBill_DTO selectbill = new SelectBill_DTO(item);
                ListMenu.Add(selectbill);
            }
            return ListMenu;
        }

    }
}
