using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanGiayOnline.Models.EF
{
    [Table("ProductDetail")]
    public class ProductDetail:CommonAbstract
    {
        public ProductDetail()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductDetailId { get; set; }
           
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
      
        public int SizeId { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Sizes { get; set; } = null;

        public string ColorCode { get; set; }

        [ForeignKey("ColorCode")]
        public virtual Color Colors { get; set; } = null;

        public int Stock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } =  new List<OrderDetail>();
    }
}