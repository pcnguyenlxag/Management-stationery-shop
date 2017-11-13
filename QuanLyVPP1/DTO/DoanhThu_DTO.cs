using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    public class DoanhThu_DTO
    {
        string maHH;
        string tenHH;
        string dvTinh;
        float giaMua;
        float donGia;
        int giamGia;
        float tongGia;
        public DoanhThu_DTO(string mahh, string tenhh, string dvtinh ,float giamua, float dongia, int giamgia, float tonggia)
        {
            this.MaHH = mahh;
            this.TenHH = tenhh;
            this.DvTinh = dvtinh;
            this.DonGia = dongia;
            this.GiaMua = giamua;
            this.GiamGia = giamgia;
            this.TongGia = tonggia;

        }
        public DoanhThu_DTO(DataRow row)
        {
            this.MaHH = (string)row["mahh"].ToString();
            this.TenHH = (string)row["tenhh"].ToString();
            this.DvTinh = (string)row["dvtinh"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["dongia"].ToString());
            this.GiaMua = (float)Convert.ToDouble(row["giamua"].ToString());
            this.GiamGia = (int)row["giamgia"];
            this.TongGia = (float)Convert.ToDouble(row["tonggia"].ToString());
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

        public float GiaMua
        {
            get
            {
                return giaMua;
            }

            set
            {
                giaMua = value;
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

        public float TongGia
        {
            get
            {
                return tongGia;
            }

            set
            {
                tongGia = value;
            }
        }
    }
}
