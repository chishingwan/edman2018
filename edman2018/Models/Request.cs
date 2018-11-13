using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace edman2018.Models
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Request_ID { get; set; }
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Request_Header { get; set; }
        public string Request_Details { get; set; }
        public DateTime Request_Date { get; set; }
    }
}