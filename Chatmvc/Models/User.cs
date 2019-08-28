using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chatmvc.Models
{
    public class User
    {
        [Key]
        public string id { get; set; }
        public string nickname{ get; set;}
        public bool enabled { get; set; }

    }
}