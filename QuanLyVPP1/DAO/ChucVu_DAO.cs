using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    class ChucVu_DAO
    {
        private static ChucVu_DAO instance;

        public static ChucVu_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChucVu_DAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ChucVu_DAO() { }
        public List<ChucVu_DTO> GetListChucVu()
        {
            List<ChucVu_DTO> listChucVu = new List<ChucVu_DTO>();
            string query = "select * from ChucVu";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                ChucVu_DTO chucvu = new ChucVu_DTO(item);
                listChucVu.Add(chucvu);
            }
            return listChucVu;
        }
        public ChucVu_DTO GetChucVuByMaCV(string maCV)
        {
            ChucVu_DTO chucvu = null;
            string query = "select * from ChucVu where MaCV=N'" + maCV + "'";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                chucvu = new ChucVu_DTO(item);
                return chucvu;
            }
            return chucvu;
        }
    }
}
