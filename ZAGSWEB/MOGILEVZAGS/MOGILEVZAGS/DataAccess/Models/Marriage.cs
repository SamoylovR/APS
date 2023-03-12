using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class Marriage
    {
        [Key]
        public int Id { get; set; }

        public virtual Client Client { get; set; }

        public int ClientId { get; set; }
    }
}
