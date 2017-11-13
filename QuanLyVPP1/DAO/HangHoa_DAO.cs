using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    public class HangHoa_DAO
    {
        private static HangHoa_DAO instance;

        public static HangHoa_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HangHoa_DAO();
                return HangHoa_DAO.instance;
            }

            private set
            {
                HangHoa_DAO.instance = value;
            }
        }
        private HangHoa_DAO() { }
        public List<HangHoa_DTO> LoadCusByCateloryID(int id)
        {
            List<HangHoa_DTO> listHH = new List<HangHoa_DTO>();
            string query = "select * from HangHoa where MaDSHH =" +id;
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                HangHoa_DTO hangHoa = new HangHoa_DTO(item);
                listHH.Add(hangHoa);
            }
            return listHH;
        }
        public DataTable LoadHangHoa()
        {
            string query = "select MaHH as[Mã HH], TenHH as[Tên HH], DVTinh as[ĐV Tính], KhoHH.SoLuongHH as[Số Lượng], GiaMua as [Giá Mua], DonGia as[Giá Bán], MaDSHH as[Mã DS] from HangHoa, KhoHH where HangHoa.MaHH=KhoHH.MaHK";
            return DataProvider.Instace.ExcuteQuey(query);
        }
        public bool InsertHH(string maHH, string tenHH, string dvTinh, float giaMua, float donGia, int maDSHH, string maHK, int soLuong)
        {
            string query = string.Format("insert into HangHoa values(N'{0}', N'{1}', N'{2}', {3}, {4}, {5}, N'{6}')", maHH, tenHH, dvTinh, giaMua, donGia, maDSHH, maHK);
            string query2 = string.Format("insert into KhoHH values(N'{0}', {1})", maHH, soLuong);
            DataProvider.Instace.ExcuteNonQuey(query2);
            int result = DataProvider.Instace.ExcuteNonQuey(query);
            return result > 0;
        }
        public bool UpdateHH(string maHH, string tenHH, string dvTinh, float giaMua, float donGia, int maDSHH, string maHK, int soLuong)
        {
            string query = string.Format("update KhoHH set SoLuongHH = {0} where MaHK=N'{1}'", soLuong, maHH);
            string query2 = string.Format("update HangHoa set TenHH = N'{0}', DVTinh = N'{1}', GiaMua = {2}, DonGia = {3}, MaDSHH = {4} where MaHH = N'{5}'", tenHH, dvTinh, giaMua, donGia, maDSHH, maHH);
            DataProvider.Instace.ExcuteNonQuey(query);
            int result = DataProvider.Instace.ExcuteNonQuey(query2);
            return result > 0;
        }
        public bool DeleteHH(string maHH)
        {
            int result = 0;
            BillInfo_DAO.Instance.DeleteBillinfoByMaHangHoa(maHH);
            string query = string.Format("delete HangHoa where MaHH = N'{0}'", maHH);
            result = DataProvider.Instace.ExcuteNonQuey(query);
            DataProvider.Instace.ExcuteNonQuey("delete KhoHH where MaHK =N'" + maHH + "'");
            return result > 0;
        }
        public bool CheckMaHH(string maHH)
        {
            string query = string.Format("select count(*) from HangHoa where MaHH = N'{0}'",maHH);
            int result = (int)DataProvider.Instace.ExcuteScalar(query);
            return result > 0;
        }
        public DataTable SearchHangHoa(string tenHH)
        {
            string query = "select MaHH as[Mã HH], TenHH as[Tên HH], DVTinh as[ĐV Tính], KhoHH.SoLuongHH as[Số Lượng], GiaMua as [Giá Mua], DonGia as[Giá Bán], MaDSHH as[Mã DS] from HangHoa, KhoHH where HangHoa.MaHH=KhoHH.MaHK and HangHoa.TenHH like N'%"+tenHH+"%'";
            return DataProvider.Instace.ExcuteQuey(query);
        }
    }
}
