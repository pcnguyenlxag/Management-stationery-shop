using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    public class Account_DTO
    {
        string tenHienThi;
        string tenDangNhap;
        string passWord;
        string maCV;
        string tenChucVu;
        string soDT;
        string diaChi;
        string maNV;
        public Account_DTO(string tenhienthi, string tendangnhap, string macv,string diachi, string tenchucvu, string sodt, string manv, string password = null)
        {
            this.TenHienThi = tenhienthi;
            this.TenDangNhap = tendangnhap;
            this.PassWord = password;
            this.MaCV = macv;
            this.TenChucVu = tenchucvu;
            this.SoDT = sodt;
            this.DiaChi = diachi;
            this.MaNV = manv;
        }
        public Account_DTO(DataRow row)
        {
            this.TenHienThi =(string)row["tenhienthi"].ToString();
            this.TenDangNhap = (string)row["tendangnhap"].ToString();
            this.PassWord = (string)row["password"].ToString();
            this.MaCV = (string)row["macv"].ToString();
            this.TenChucVu = (string)row["tenchucvu"].ToString();
            this.SoDT = (string)row["sodt"].ToString();
            this.DiaChi = (string)row["diachi"].ToString();
            this.MaNV = (string)row["manv"].ToString();
        }
        public string TenHienThi
        {
            get
            {
                return tenHienThi;
            }

            set
            {
                tenHienThi = value;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public string MaCV
        {
            get
            {
                return maCV;
            }

            set
            {
                maCV = value;
            }
        }

        public string TenChucVu
        {
            get
            {
                return tenChucVu;
            }

            set
            {
                tenChucVu = value;
            }
        }

        public string SoDT
        {
            get
            {
                return soDT;
            }

            set
            {
                soDT = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }
    }
}
