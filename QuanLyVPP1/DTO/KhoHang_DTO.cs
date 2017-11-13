using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    class KhoHang_DTO
    {
        string maHK;
        int soLuongHH;
        public KhoHang_DTO(string mahk, int soluonghh)
        {
            this.MaHK = mahk;
            this.SoLuongHH = soluonghh;
        }
        public KhoHang_DTO(DataRow row)
        {
            this.MaHK = (string)row["mahk"].ToString();
            this.SoLuongHH = (int)row["soluonghh"];
        }
        public string MaHK
        {
            get
            {
                return maHK;
            }

            set
            {
                maHK = value;
            }
        }

        public int SoLuongHH
        {
            get
            {
                return soLuongHH;
            }

            set
            {
                soLuongHH = value;
            }
        }
    }
}
