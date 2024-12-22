using System.ComponentModel.DataAnnotations;

namespace WebAPIwithRepository.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string? Address { get; set; }
        public string? PatientType { get; set; }
        public string? bednum { get; set; } = string.Empty!;
        public string? diagnosis
        {
            get; set;
        } =string.Empty;
    }
}
