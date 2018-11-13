using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("User_Type")]
    public class U_Type
    {
        [Key]
        public int Type_ID { get; set; }
        public string User_Type { get; set; }
    }
}