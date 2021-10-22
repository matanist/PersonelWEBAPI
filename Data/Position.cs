using System.ComponentModel.DataAnnotations;

namespace PERSONELWEBAPI.Data
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public decimal MaximumSalary { get; set; }
    }
}