using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    class HoaDonKhachHang_DTO
    {
        int iD;
        string name;
        string trangThai;
        public HoaDonKhachHang_DTO(int id, string name, string trangthai)
        {
            this.ID = id;
            this.Name = name;
            this.TrangThai = trangthai;
        }
        public HoaDonKhachHang_DTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.TrangThai = row["trangThai"].ToString();
        }
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string TrangThai
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
    }
}
