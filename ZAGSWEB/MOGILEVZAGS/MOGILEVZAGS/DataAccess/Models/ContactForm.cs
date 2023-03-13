using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public string Email { get; set; }
    }
}
