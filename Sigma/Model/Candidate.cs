using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Sigma.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }
        public string CallTime { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
