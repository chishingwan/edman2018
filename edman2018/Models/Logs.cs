using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Logs")]
    public class Logs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Log_ID { get; set; }
        public string Log_Type { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}