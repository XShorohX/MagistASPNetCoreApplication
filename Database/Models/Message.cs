using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corpa4Sem4.Database.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public User ?FromUser { get; set; }
        public int ToUserId { get; set; }
        public User ?ToUser { get; set; }
        public string ?MessageHeadline { get; set; }

        public string ?MessageText { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;

        public bool Status { get; set; }

    }
}
