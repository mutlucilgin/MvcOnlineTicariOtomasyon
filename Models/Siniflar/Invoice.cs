using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSquenceNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverir{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Reciever { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}