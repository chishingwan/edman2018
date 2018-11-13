using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Review_ID { get; set; }
        public int Product_ID { get; set; }
        public DateTime Date_Received { get; set; }
        public int User_ID { get; set; }
        public int Rating { get; set; }
        public string Reviews { get; set; }
        public string Status { get; set; }
    }
}