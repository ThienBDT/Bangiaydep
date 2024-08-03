using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanGiayOnline.Models.EF
{
    [Table("Color")]
    public class Color
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public int ColorId { get; set; }
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string ColorName { get; set; }
        [Key]
        [StringLength(7)]
        public string ColorCode { get; set; } // Mã màu hex code
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}