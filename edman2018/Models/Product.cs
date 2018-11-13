using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public Decimal Price { get; set; }
        public string Available { get; set; }
        public int Critical_Level { get; set; }
        public DateTime Date_Added { get; set; }
        public DateTime Date_Modified { get; set; }
    }
}