using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyVPP1.DTO
{
    class Bill_DTO
    {
        int maHD;
        DateTime? ngayXHD;
        DateTime? ngayNHD;
        bool trangThai;
        int giamGia;
       
        public Bill_DTO(int mahd, DateTime? ngaynhd, DateTime? ngayxhd, bool trangthai, int giamgia = 0)
        {
            this.MaHD = mahd;
            this.NgayNHD = ngaynhd;
            this.NgayXHD = ngayxhd;
            this.TrangThai = trangthai;
            this.GiamGia = giamgia;
        }
        public Bill_DTO(DataRow row)
        {
            this.MaHD = (int)row["mahd"];
            this.NgayNHD = (DateTime?)row["ngaynhd"];   
            var NgayxhdTmp = row["ngayxhd"];
            if(NgayxhdTmp.ToString()!="")
            {
                this.NgayXHD = (DateTime?)NgayxhdTmp;
            }
            this.TrangThai = (bool)row["trangthai"];
            this.GiamGia = (int)row["giamgia"];
        }     
        public DateTime? NgayNHD
        {
            get
            {
                return ngayNHD;
            }

            set
            {
                ngayNHD = value;
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
        public DateTime? NgayXHD
        {
            get
            {
                return ngayXHD;
            }

            set
            {
                ngayXHD = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

        public int GiamGia
        {
            get
            {
                return giamGia;
            }

            set
            {
                giamGia = value;
            }
        }       
    }
}
