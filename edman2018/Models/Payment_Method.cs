using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Payment_Method")]
    public class Payment_Method
    {
        [Key]
        public int Payment_Menthod { get; set; }
        public string Payment_Type { get; set; }
    }
}