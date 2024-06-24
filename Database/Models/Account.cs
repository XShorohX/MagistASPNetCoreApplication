using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public DateTime OpeningDate { get; set; }

        public NaturalPerson? Owner { get; set; }
        public int OwnerId { get; set; }

        public decimal CurrentBalance { get; set; } = 0.00M;

        public AccountType? Type { get; set; }
        public int AccountTypeId { get; set; }
    }
}
