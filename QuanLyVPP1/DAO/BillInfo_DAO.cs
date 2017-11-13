using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class BillInfo_DAO
    {
        private static BillInfo_DAO instance;

        public static BillInfo_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfo_DAO();
                return BillInfo_DAO.instance;
            }

            private set
            {
                BillInfo_DAO.instance = value;
            }
        }

        private BillInfo_DAO() { }

        //public List<BillInfo_DTO> GetListBillInfo(int maHD)
        //{
        //    List<BillInfo_DTO> ListBillinfo = new List<BillInfo_DTO>();
        //    DataTable data = DataProvider.Instace.ExcuteQuey("select * from ChiTietHD where MaHD =" + maHD);
        //    foreach (DataRow item in data.Rows)
        //    {
        //        BillInfo_DTO BillInfo = new BillInfo_DTO(item);
        //        ListBillinfo.Add(BillInfo);
        //    }
        //    return ListBillinfo;
        //}
        public void InsertBillInfo(string maHH, int mHD, int soLuong)
        {
            DataProvider.Instace.ExcuteNonQuey("USP_InsertBillInfo @MaHH , @MaHD , @SoLuong", new object[] { maHH, mHD, soLuong });
        }
        public bool CheckSoLuong(string maHH, int soLuong)
        {
            string query = "select SoLuongHH from KhoHH where MaHK =N'" + maHH + "'";

            int sluong = (int)DataProvider.Instace.ExcuteScalar(query);
            if (sluong - soLuong < 0)
                return true;
            else
                return false;
        }
        public bool DeleteBillinfoByMaHangHoa(string maHH)
        {
            int result = DataProvider.Instace.ExcuteNonQuey("delete ChiTietHD where MaHH =N'" + maHH + "'");
            return result > 0;
        }
    }
}
