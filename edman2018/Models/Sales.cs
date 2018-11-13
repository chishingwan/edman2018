using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Sales")]
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sales_Header_ID { get; set; }
        public string Sales_Header { get; set; }
        public int User_ID { get; set; }
        public DateTime Sales_Date { get; set; }
        public int Total_Amount { get; set; }
        public string Status { get; set; }
    }
}