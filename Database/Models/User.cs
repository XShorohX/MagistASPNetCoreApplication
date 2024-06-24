using System.ComponentModel.DataAnnotations;

namespace Corpa4Sem4.Database.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
	}
}
