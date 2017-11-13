using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class Bill_DAO
    {
        private static Bill_DAO instance;

        public static Bill_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Bill_DAO();
                return Bill_DAO.instance;
            }

            private set
            {
                Bill_DAO.instance = value;
            }
        }
        private Bill_DAO() { }
        public int GetUncheckBillIdByTableID(int iD)
        {
            DataTable data = DataProvider.Instace.ExcuteQuey("select * from dbo.HoaDon where id = "+ iD +"and TrangThai = 1");
            if(data.Rows.Count > 0)
            {
                Bill_DTO bill = new Bill_DTO(data.Rows[0]);
                return bill.MaHD;
            }
            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instace.ExcuteNonQuey("exec USP_InsertBill @id", new object[] {id});
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instace.ExcuteScalar("select max(MaHD) from HoaDon");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id, int giamGia, float tongGia, string maNV)
        {
            string query = "update HoaDon set NgayXHD = GetDate(), TrangThai = 0, GiamGia = " + giamGia + ", TongGia = " + tongGia + ", MaNV =N'" + maNV + "' where MaHD =" + id;
            DataProvider.Instace.ExcuteNonQuey(query);
        }
        public DataTable GetListBillByDate(DateTime NgayNHD, DateTime NgayXHD)
        {
            return DataProvider.Instace.ExcuteQuey("exec USP_GetListBillByDate @NgayNHD , @NgayXHD", new object[] { NgayNHD, NgayXHD});
        }
        public Bill_DTO GetUncheckBillIdByDate(int iD)
        {
            DataTable data = DataProvider.Instace.ExcuteQuey("select * from dbo.HoaDon where id = " + iD + "and TrangThai = 1");
            foreach (DataRow item in data.Rows)
            {
                return new Bill_DTO(item);
            }
            return null;
        }
    }
}
