using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class HoaDonKhachHang_DAO
    {
        private static HoaDonKhachHang_DAO instance;

        public static HoaDonKhachHang_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonKhachHang_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public static int HDKhachHangWidth = 90;
        public static int HDKhachHangHeight = 90;
        private HoaDonKhachHang_DAO() { }

        public List<HoaDonKhachHang_DTO> LoadHDKhachHang()
        {
            List<HoaDonKhachHang_DTO> HDKHList = new List<HoaDonKhachHang_DTO>();
            DataTable data = DataProvider.Instace.ExcuteQuey("EXEC USP_LayDanhSachHDKH");
            foreach (DataRow item in data.Rows)
            {
                HoaDonKhachHang_DTO HDKH = new HoaDonKhachHang_DTO(item);
                HDKHList.Add(HDKH);
            }

            return HDKHList;
        }
    }
}
