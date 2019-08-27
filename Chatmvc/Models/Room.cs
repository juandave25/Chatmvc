using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatmvc.Models
{
    public class Room
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}