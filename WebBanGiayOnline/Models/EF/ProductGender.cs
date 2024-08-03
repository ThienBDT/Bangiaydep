using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanGiayOnline.Models.EF
{
    [Table("ProductGender")]
        public class ProductGender : CommonAbstract
        {
            public ProductGender()
            {
                this.Products = new HashSet<Product>();
            }
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            [StringLength(150)]
            [Index(IsUnique = true)]
            public string ProductGenderName { get; set; }
            [StringLength(150)]
            public string Alias { get; set; }
            public string Description { get; set; }
            [StringLength(250)]
            public string Icon { get; set; }
            [StringLength(250)]
            public string SeoTitle { get; set; }
            [StringLength(500)]
            public string SeoDescription { get; set; }
            [StringLength(250)]
            public string SeoKeyWords { get; set; }
            public ICollection<Product> Products { get; set; }
        }
}