using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Chatmvc.Models
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        public string IdUserSend { get; set; }
        public string IdRoom { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string IdUserReceive { get; set; }


    }
}