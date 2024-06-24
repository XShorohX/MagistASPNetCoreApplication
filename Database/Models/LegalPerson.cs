using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class LegalPerson
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public NaturalPerson? Ceo { get; set; }
        public int CeoId { get; set; }

        [MaxLength(100)]
        public string BookkeeperFullName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public Ownership? Ownership { get; set; }
        public int OwnershipId { get; set; }
    }
}