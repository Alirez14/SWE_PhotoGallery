using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
using Microsoft.Extensions.Options;

namespace BL.Models
{
    public class BLPhotographer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "{0} must be between {2} and {1}", MinimumLength = 6)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1}", MinimumLength = 6)]

        public string MiddleName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1}", MinimumLength = 6)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} must be between {2} and {1}", MinimumLength = 6)]

        public string Notice { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 7)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{8,}$", ErrorMessage = "The {0} does not meet requirements.")]
        public string Password { get; set; }
    }
}
