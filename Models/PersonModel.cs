using System.ComponentModel.DataAnnotations;

namespace PERSONELWEBAPI.Models
{
    public class PersonModel{
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? PositionId { get; set; }
    }
}