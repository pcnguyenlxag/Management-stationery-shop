using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    public class SelectBill_DTO
    {
        string tenHH;
        int soLuong;
        float donGia;
        float tongDonGia;
        string dvTinh;

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

        public float TongDonGia
        {
            get
            {
                return tongDonGia;
            }

            set
            {
                tongDonGia = value;
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

        public SelectBill_DTO(string tenhh, string dvtinh,int soluong, float dongia, float tongdongia =0)
        {
            this.DonGia = dongia;
            this.SoLuong = soluong;
            this.TongDonGia = tongdongia;
            this.TenHH = tenhh;
            this.DvTinh = dvtinh;
        }
        public SelectBill_DTO(DataRow row)
        {
            this.DonGia = (float)Convert.ToDouble(row["dongia"].ToString());
            this.SoLuong = (int)row["soluong"];
            this.TongDonGia = (float)Convert.ToDouble(row["tongdongia"].ToString());
            this.TenHH = (string)row["tenhh"].ToString();
            this.DvTinh = (string)row["dvtinh"].ToString();
        }
    }
}
