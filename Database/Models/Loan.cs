using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal DebtAmount { get; set; }

        public bool Closed { get; set; }

        public Account? Account { get; set; }
        public int AccountId { get; set; }
    }
}