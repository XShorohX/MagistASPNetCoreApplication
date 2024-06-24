using System.ComponentModel.DataAnnotations;

namespace PraktASPApp.Models
{
    public class SendMessage
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
