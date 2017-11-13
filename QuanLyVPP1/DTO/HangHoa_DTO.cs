using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyVPP1.DTO
{
    public class HangHoa_DTO
    {
        string maHH;
        string tenHH;
        string dvTinh;
        float donGia;
        int maDSHH;
        string maHK;
        public HangHoa_DTO(string mahh, string tenhh, string dvtinh, float dongia,int madshh,string mahk)
        {
            this.MaHH = mahh;
            this.TenHH = tenhh;
            this.DvTinh = dvtinh;
            this.DonGia = dongia;
            this.MaDSHH = madshh;
            this.MaHK = mahk;
        }

        public HangHoa_DTO(DataRow row)
        {
            this.MaHH = (string)row["mahh"].ToString();
            this.TenHH = (string)row["tenhh"].ToString();
            this.DvTinh = (string)row["dvtinh"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["dongia"].ToString());
            this.MaDSHH = (int)row["madshh"];
            this.MaHK = (string)row["mahk"].ToString();
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

        public string TenHH
        {
            get
            {
                return tenHH;
            }

            set
            {
                tenHH = value;
            }
        }

        public string DvTinh
        {
            get
            {
                return dvTinh;
            }

            set
            {
                dvTinh = value;
            }
        }

        public float DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public int MaDSHH
        {
            get
            {
                return maDSHH;
            }

            set
            {
                maDSHH = value;
            }
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
    }
}
