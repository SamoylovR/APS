using System.ComponentModel.DataAnnotations;

namespace MOGILEVZAGS.DataAccess.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }
}
