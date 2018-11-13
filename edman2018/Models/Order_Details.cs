using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Order_Details")]
    public class Order_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_No { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}