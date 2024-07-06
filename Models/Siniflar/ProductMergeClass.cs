using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    // Bir sayfaya birden fazla veri çekebilmek için iki tabloyu bir sınıfta birleştirerek kullanabiliriz.
    public class ProductMergeClass
    {
        public IEnumerable<Product> ProductList { get; set; }
        public IEnumerable<ProductDetailModel> ProductDetailList { get; set; }
    }
}