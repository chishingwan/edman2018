using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Return")]
    public class Return
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Return_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime Return_Date { get; set; }
    }
}