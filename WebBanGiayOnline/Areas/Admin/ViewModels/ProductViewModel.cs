using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebBanGiayOnline.Models.EF;

namespace WebBanGiayOnline.Areas.Admin.ViewModels
{
    public class ProductViewModel : CommonAbstract
    {
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductGender ProductGender { get; set; }
        [NotMapped]
        public List<ProductDetailViewModel> ProductDetails { get; set; }
        public List<ProductDetailImage> ProductDetailImages { get; set; }
      
    }

    public class ProductDetailViewModel 
    {
        public int ProductDetailId { get; set; }
        public  string ColorCode { get; set; }
        //public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Stock { get; set; }
    }

}