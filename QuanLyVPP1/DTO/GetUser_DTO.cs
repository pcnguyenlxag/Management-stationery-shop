using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    public class GetUser_DTO
    {
        string tenDangNhap;
        string maNV;
        public GetUser_DTO(string tendangnhap, string manv)
        {
            this.TenDangNhap = tendangnhap;
            this.MaNV = manv;
        }
        public GetUser_DTO(DataRow row)
        {
            this.TenDangNhap = (string)row["tendangnhap"].ToString();
            this.MaNV = (string)row["manv"].ToString();
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
