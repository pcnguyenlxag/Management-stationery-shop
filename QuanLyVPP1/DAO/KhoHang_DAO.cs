using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class KhoHang_DAO
    {
        private static KhoHang_DAO instance;

        public static KhoHang_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoHang_DAO();
                return KhoHang_DAO.instance;
            }

            private set
            {
                KhoHang_DAO.instance = value;
            }
        }
        private KhoHang_DAO() { }
        public KhoHang_DTO GetListHangHoa()
        {
            KhoHang_DTO hanghoa = null;// new Catelory_DTO();
            string query = "select * from KhoHH";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                hanghoa = new KhoHang_DTO(item);
                return hanghoa;
            }
            return hanghoa;
        }
    }
}
