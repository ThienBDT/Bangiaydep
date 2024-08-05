using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanGiayOnline.Models.EF
{
    [Table("Product")]
    public class Product:CommonAbstract
    {
        public Product()
        {
            this.ProductDetailImages = new HashSet<ProductDetailImage>();
            this.ProductDetails = new HashSet<ProductDetail>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string ProductCode { get; set; }  
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; } 
        public decimal Price { get; set; }   
        public int Quantity { get; set; }
        public decimal PriceSale { get; set; } 
        public bool IsHome { get; set; }     // Hiển thị trang Home
        public bool IsSale { get; set; }     // Hiển thị sản phẩm giảm giá   
        public bool IsFeature { get; set; }  // Hiển thị sản phẩm nổi bật
        public bool IsHot { get; set; }      // Hiển thị sản phẩm Hot
        public bool IsActive { get; set; }   // Trạng thái hiện thị sản phẩm

        [ForeignKey("ProductCategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductGenderId")]
        public virtual ProductGender ProductGender { get; set; }
        public int ProductGenderId { get; set; }
        public virtual ICollection<ProductDetailImage> ProductDetailImages { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }     
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeyWords { get; set; }
    }
}