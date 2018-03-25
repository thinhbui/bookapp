using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class Quyen
    {
        public int MAQUYEN { get; set; }

        [StringLength(50)]
        public string TENQUYEN { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        public bool? TRANGTHAI { get; set; }
    }
}
