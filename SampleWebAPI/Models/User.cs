using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be null or empty")]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "EMail should not be null or empty")]
        [MaxLength(50)]
        public required string EMail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile should not be null or empty")]
        [MaxLength(15)]
        public required string Mobile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Aadhaar cannot be null or empty")]
        [MaxLength(15)]
        public required string Aadhaar { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date registered cannot be null or empty")]
        [MaxLength(15)]
        public required string DateRegistered { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        public required int RoleId { get; set; }

        [NotMapped]
        public IFormFile? AadhaarImage { get; set; }

        public string? AadhaarImagePath { get; set; }
    }
}