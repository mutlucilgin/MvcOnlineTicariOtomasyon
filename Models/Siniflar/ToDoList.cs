using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class ToDoList
    {
        [Key]
        public int ToDoID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title{ get; set; }
        [Column(TypeName = "bit")]
        public bool State { get; set; }
    }
}