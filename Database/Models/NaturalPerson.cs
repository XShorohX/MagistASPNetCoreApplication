using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class NaturalPerson
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        public string Address { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public Gender? Sex { get; set; }
        
        public int SexId { get; set; }

        public ClientStatus? Status { get; set; }

        public int StatusId { get; set; }

        public StaffStatus? InStaff { get; set; }
        public int InStaffId { get; set; }
    }
}