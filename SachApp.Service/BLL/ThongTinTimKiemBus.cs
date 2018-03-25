using SachApp.Service.Dao;
using SachApp.Service.Models;
using System.Data;


namespace SachApp.Service.BLL
{
    public class ThongTinTimKiemBus
    {
        ThongTinTimKiemDao dao = new ThongTinTimKiemDao();


        public DataTable GetData(ThongTinTimKiem obj)
        {
            return dao.GetData(obj);
        }
    }
}
