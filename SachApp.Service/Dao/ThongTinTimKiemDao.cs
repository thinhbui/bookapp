using SachApp.Service.Models;
using System.Data;
using System.Data.SqlClient;

namespace SachApp.Service.Dao
{
    public class ThongTinTimKiemDao : dbContext
    {
        public DataTable GetData(ThongTinTimKiem timkiem)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tenSach",timkiem.TENSACH),
                new SqlParameter("tenTacGia", timkiem.TENTG),
                new SqlParameter("maNXB",timkiem.MANXB),
                new SqlParameter("maTheLoai",timkiem.MATHELOAI),
                new SqlParameter("namXb",timkiem.NAMXB),
                new SqlParameter("giaMin",timkiem.giaMIN),
                new SqlParameter("giaMax",timkiem.giaMAX)
            };
            return base.GetData("SACH_SEARCH", para);
        }
    }
}
