using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Delivery")]
    public class Delivery
    {
        [Key]
        
        public int Delivery_No { get; set; }
        public string Delivery_Address { get; set; }
        public DateTime Date_Delivered { get; set; }
        public string Status { get; set; }
    }
}