using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
