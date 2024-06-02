using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description{ get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price{ get; set; }
        public int InvoiceId{ get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}