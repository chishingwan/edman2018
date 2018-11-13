using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Product_Details")]
    public class Product_Details
    {
        [Key]
        public int Product_ID { get; set; }
        public int Purchase_No { get; set; }
        public int Quantity { get; set; }
    }
}