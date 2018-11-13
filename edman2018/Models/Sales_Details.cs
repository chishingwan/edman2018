using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Sales_Details")]
    public class Sales_Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sales_Details_ID { get; set; }
        public string Sales_Detail { get; set; }
        public int Sales_Header_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
    }
}