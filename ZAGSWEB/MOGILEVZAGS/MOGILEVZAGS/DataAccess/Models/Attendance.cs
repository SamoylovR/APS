using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
    }
}
