using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class AccountType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }
    }
}
