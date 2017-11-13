using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DTO
{
    public class Catelory_DTO
    {
        string tenDSHH;
        int maDSHH;
        public Catelory_DTO(string tendshh, int madshh)
        {
            this.MaDSHH = madshh;
            this.TenDSHH = tendshh;
        }
        public Catelory_DTO(DataRow row)
        {
            this.MaDSHH = (int)row["madshh"];
            this.TenDSHH = (string)row["tendshh"];
        }
        public string TenDSHH
        {
            get
            {
                return tenDSHH;
            }

            set
            {
                tenDSHH = value;
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
    }
}
