using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class DoanhThu_DAO
    {
        private static DoanhThu_DAO instance;

        public static DoanhThu_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DoanhThu_DAO();
                return DoanhThu_DAO.instance;
            }

            private set
            {
                DoanhThu_DAO.instance = value;
            }
        }
        private DoanhThu_DAO() { }
        public DataTable GetLoiNhuan()
        {
            string query = "select MaHH as[Mã HH], TenHH as[Tên HH], DVTinh as[DV Tính], GiaMua as[Giá Mua], DonGia as[Giá Bán], DonGia- GiaMua as[Lợi Nhuận] from HangHoa";
            return DataProvider.Instace.ExcuteQuey(query);
        }
        //public DoanhThu_DTO GetDataDoanhThu(DateTime NgayNHD, DateTime NgayXHD)
        //{
        //    DataTable data = DataProvider.Instace.ExcuteQuey("exec USP_GetListDoanhThuByDate @NgayNHD , @NgayXHD ", new object[] { NgayNHD, NgayXHD });
        //    foreach (DataRow item in data.Rows)
        //    {
        //        return new DoanhThu_DTO(item);
        //    }
        //    return null;
        //}
    }
}
