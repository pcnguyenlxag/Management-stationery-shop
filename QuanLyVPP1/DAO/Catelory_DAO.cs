using QuanLyVPP1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVPP1.DAO
{
    public class Catelory_DAO
    {
        private static Catelory_DAO instance;

        public static Catelory_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Catelory_DAO();
                return Catelory_DAO.instance;
            }

            private set
            {
                Catelory_DAO.instance = value;
            }
        }
        private Catelory_DAO() { }
        public List<Catelory_DTO> GetListCatelory()
        {
            List<Catelory_DTO> listCatelory = new List<Catelory_DTO>();
            string query = "select * from DSHangHoa";
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                Catelory_DTO catelory = new Catelory_DTO(item);
                listCatelory.Add(catelory);
            }
            return listCatelory;
        }
        public Catelory_DTO GetCateloryByID(int id)  // Select 
        {
            Catelory_DTO catelory = null;// new Catelory_DTO();
            string query = "select * from DSHangHoa where MaDSHH="+id;
            DataTable data = DataProvider.Instace.ExcuteQuey(query);
            foreach (DataRow item in data.Rows)
            {
                catelory = new Catelory_DTO(item);
                return catelory;
            }
            return catelory;
        }
    }
}
