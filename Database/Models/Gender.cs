using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Value { get; set; }
    }
}