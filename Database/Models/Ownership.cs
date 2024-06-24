using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class Ownership
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Value { get; set; }
    }
}