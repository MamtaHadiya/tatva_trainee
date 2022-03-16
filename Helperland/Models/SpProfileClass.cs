using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class SpProfileClass
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter valid Mobile")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "maxlength is 10"), MinLength(10, ErrorMessage = "minlength is 10")]
        public string Mobile { get; set; }

        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserProfilePicture { get; set; }
        public int? NationalityId { get; set; }

        
        [Required(ErrorMessage = "please Enter Street Name.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "please Enter House Number.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "please Enter City Name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "please Enter PostalCode.")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

    }
}
