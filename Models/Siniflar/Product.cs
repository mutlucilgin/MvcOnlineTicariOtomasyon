using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        // Kısıtlama için kullanılır. Çünkü sadece string kullanıldığında sql de depolama için yüksek boyutta bir alan ayırır.
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand{ get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool State { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int Categoryid { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}