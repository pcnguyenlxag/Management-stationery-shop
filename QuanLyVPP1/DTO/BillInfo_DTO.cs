using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    class BillInfo_DTO
    {
        string maHH;
        int soLuong;
        int maHD;
        public BillInfo_DTO(string mahh, int soluong, int mahd)
        {
            this.MaHH = mahh;
            this.SoLuong = soluong;
            this.MaHD = mahd;
        }
        public BillInfo_DTO(DataRow row)
        {
            this.MaHH = (string)row["mahh"];
            this.SoLuong = (int)row["soluong"];
            this.MaHD = (int)row["mahd"];
        }
        public string MaHH
        {
            get
            {
                return maHH;
            }

            set
            {
                maHH = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }
        public int MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }
    }
}
