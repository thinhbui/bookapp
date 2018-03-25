using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class ThongTinTimKiem
    {
        public string TENSACH { get; set; }
        public string TENTG { get; set; }
        public int? MATHELOAI { get; set; }
        public int? MANXB { get; set; }
        public int? NAMXB { get; set; }
        public decimal? giaMIN { get; set; }
        public decimal? giaMAX { get; set; }

    }
}
