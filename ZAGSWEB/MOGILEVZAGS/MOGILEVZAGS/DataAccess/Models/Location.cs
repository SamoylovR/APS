using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string LocationName { get; set; }
    }
}
