using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Releasing")]
    public class Releasing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Releasing_No { get; set; }
        public DateTime Date_Released { get; set; }
        public int User_ID { get; set; }
        public int Order_No { get; set; }
        public int Quantity { get; set; }
    }
}