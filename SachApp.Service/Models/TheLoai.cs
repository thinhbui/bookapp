using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class TheLoai
    {
        public int MATHELOAI { get; set; }

        [StringLength(500)]
        public string TENTHELOAI { get; set; }

        [StringLength(500)]
        public string MOTA { get; set; }
    }
}
