using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    public class GetUser_DAO
    {
        private static GetUser_DAO instance;

        public static GetUser_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GetUser_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        GetUser_DAO() { }
        public bool GetUser(string maNV, string tenDangNhap)
        {
            string query = string.Format("select count(*) from TaiKhoan where TenDangNhap = N'{0}' and MaNV = N'{1}'",tenDangNhap, maNV);
            int result = (int)DataProvider.Instace.ExcuteScalar(query);
            return result > 0;
        }
        public bool CheckUser(string tenDangNhap)
        {
            string query = string.Format("select count(*) from TaiKhoan where TenDangNhap = N'{0}'", tenDangNhap);
            int result = (int)DataProvider.Instace.ExcuteScalar(query);
            return result > 0;
        }
    }
}
