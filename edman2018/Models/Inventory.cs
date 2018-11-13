using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Inventory_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public int Critical_Level { get; set; }
        public DateTime Inventory_Date { get; set; }
    }
}