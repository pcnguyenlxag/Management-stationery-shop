using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    class ChucVu_DTO
    {
        string maCV;
        string tenChucVu;
        public ChucVu_DTO(string macv, string tenchucvu)
        {
            this.MaCV = macv;
            this.TenChucVu = tenchucvu;
        }
        public ChucVu_DTO(DataRow row)
        {
            this.MaCV = (string)row["macv"].ToString();
            this.TenChucVu = (string)row["tenchucvu"].ToString();
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
    }
}
