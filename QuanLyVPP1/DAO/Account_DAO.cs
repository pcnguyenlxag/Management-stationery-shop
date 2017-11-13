using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyVPP1.DTO;
using System.Security.Cryptography;

namespace QuanLyVPP1.DAO
{
    class Account_DAO
    {
        private static Account_DAO instance;
        public static Account_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Account_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private Account_DAO() { }

        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasPass)
            {
                hasPass += item;
            }
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instace.ExcuteQuey(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;
        }
        public Account_DTO GetAccountByUsername(string tenDangNhap)
        {
            string query = "select ChucVu.MaCV, NhanVien.MaNV, ChucVu.TenChucVu, NhanVien.DiaChi, TaiKhoan.TenDangNhap, TaiKhoan.TenHienThi, NhanVien.SoDT, TaiKhoan.PassWord from ChucVu, TaiKhoan, NhanVien where TenDangNhap = N'" + tenDangNhap + "' and TaiKhoan.MaNV = NhanVien.MaNV and NhanVien.MaCV = ChucVu.MaCV";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                return new Account_DTO(item);
            }
            return null;
        }
        public bool UpdateAccount(string tenDangNhap, string tenHienThi, string passWord, string diaChi, string soDT)
        {
            int result = DataProvider.Instace.ExcuteNonQuey("exec USP_UpdateAccount @TenDangNhap , @TenHienThi , @PassWord , @DiaChi , @SoDT ", new object[] { tenDangNhap, tenHienThi, passWord, diaChi, soDT });
            return result > 0;
        }
        public bool UpdatePssAccount(string tenDangNhap, string tenHienThi, string passWord, string newPassWord)
        {
            int result = DataProvider.Instace.ExcuteNonQuey("exec USP_UpdatePssAccount @TenDangNhap , @TenHienThi , @PassWord , @NewPassWord ", new object[] { tenDangNhap, tenHienThi, passWord, newPassWord });
            return result > 0;
        }
        public DataTable LoadNhanVien()
        {
            string query = "select NhanVien.MaNV as[Mã NV], ChucVu.MaCV as[Chức Vụ], TenNV as[Tên NV], SoDT as[Số DT], TrangThaiNV.TenTrangThai as[Trạng Thái], DiaChi as[Địa Chỉ] from NhanVien, ChucVu, TrangThaiNV where ChucVu.MaCV = NhanVien.MaCV and NhanVien.TrangThaiNV = TrangThaiNV.TrangThaiNV";
            return DataProvider.Instace.ExcuteQuey(query);
        }
        public bool InsertNhanVien(string maCV, string tenChucVu, string maNV, string tenNV, string SDT, string DiaChi, string tenDangNhap, string tenHienThi, string passWord)
        {
            string query2 = string.Format("insert into NhanVien values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}',1)", maNV, tenNV, SDT, DiaChi, maCV);
            string query3 = string.Format("insert into TaiKhoan values(N'{0}', N'{1}', N'{2}', N'{3}')", tenDangNhap, tenHienThi, passWord, maNV);
            DataProvider.Instace.ExcuteNonQuey(query2);
            int result = DataProvider.Instace.ExcuteNonQuey(query3);
            return result > 0;
        }
        public bool UpdateUserAccount(string maNV, string tenDangNhap)
        {
            string query = string.Format("update TaiKhoan set TenDangNhap =  N'{0}' where MaNV =  N'{1}'", tenDangNhap, maNV);
            int result = DataProvider.Instace.ExcuteNonQuey(query);
            return result > 0;
        }

        public bool UpdateNhanVien(string maCV, string tenChucVu, string maNV, string tenNV, string SDT, string DiaChi)
        {
            string query = string.Format("update NhanVien set TenNV = N'{0}', SoDT = N'{1}', DiaChi = N'{2}', MaCV = N'{3}' where MaNV = N'{4}'", tenNV, SDT, DiaChi, maCV, maNV);
            int result = DataProvider.Instace.ExcuteNonQuey(query);
            return result > 0;
        }
        public bool checkMaNV(string maNV)
        {
            string query = "select count(MaNV) from NhanVien where MaNV = N'" + maNV + "'";
            int resutl = (int)DataProvider.Instace.ExcuteScalar(query);
            return resutl > 0;
        }
        public DataTable GetMaNVByTenDangNhap(string tenDangNhap)
        {
            return DataProvider.Instace.ExcuteQuey("select MaNV from TaiKhoan where TenDangNhap =N'" + tenDangNhap + "'");
        }
        public Account_DTO GetAccountByMaNV(string maNV)
        {
            string query = "select ChucVu.MaCV, ChucVu.TenChucVu, NhanVien.DiaChi, TaiKhoan.TenDangNhap, TaiKhoan.TenHienThi, NhanVien.SoDT, TaiKhoan.PassWord, NhanVien.MaNV from ChucVu, TaiKhoan, NhanVien where TaiKhoan.MaNV = NhanVien.MaNV and NhanVien.MaCV = ChucVu.MaCV and TaiKhoan.MaNV = N'" + maNV + "'";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                return new Account_DTO(item);
            }
            return null;
        }
        public DataTable SearchByName(string tenNV)
        {
            DataTable data = DataProvider.Instace.ExcuteQuey("select NhanVien.MaNV as[Mã NV],  ChucVu.MaCV as[Chức Vụ], TenNV as[Tên NV], SoDT as[Số DT], DiaChi as[Địa Chỉ] from NhanVien, TaiKhoan, ChucVu where NhanVien.MaNV = TaiKhoan.MaNV and ChucVu.MaCV = NhanVien.MaCV and TenNV like N'%" + tenNV + "%'");
            return data;
        }
        public bool DeleteAccount(string maNV)
        {
            int result1 = DataProvider.Instace.ExcuteNonQuey(" delete from TaiKhoan Where MaNV = N'" + maNV + "'");
            int result2 = DataProvider.Instace.ExcuteNonQuey("update NhanVien set TrangThaiNV = 0 where MaNV =N'" + maNV + "'");
            return (result1 > 0 && result2 > 0);
        }
        public bool ResetAccount(string maNV)
        {
            int result1 = DataProvider.Instace.ExcuteNonQuey("update TaiKhoan set PassWord=N'111111' where MaNV =N'" + maNV + "'");
            return (result1 > 0);
        }
    }
}
