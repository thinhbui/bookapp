using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class NhanVien
    {
        public int MANV { get; set; }

        [StringLength(500)]
        public string TENNV { get; set; }

        [StringLength(3)]
        public string GT { get; set; }

        public DateTime? NGAYSINH { get; set; }

        [StringLength(50)]
        public string DIENTHOAI { get; set; }

        [StringLength(500)]
        public string DIACHI { get; set; }

        [StringLength(32)]
        public string TAIKHOAN { get; set; }

        [StringLength(32)]
        public string MATKHAU { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        public int? MAQUYEN { get; set; }
    }
}
