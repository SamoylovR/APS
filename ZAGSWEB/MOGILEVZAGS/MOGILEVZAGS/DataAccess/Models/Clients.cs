using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string TypeOfOperation { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
