using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Contact_Person { get; set; }
        public string Email { get; set; }
    }
}