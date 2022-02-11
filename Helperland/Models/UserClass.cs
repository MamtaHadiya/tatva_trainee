using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class UserClass
    {


        [Key]
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
        [MaxLength(10, ErrorMessage ="maxlength is 10"),MinLength(10, ErrorMessage ="minlength is 10")]
        public string Mobile { get; set; }

        [Required(ErrorMessage ="Enter password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password does not match,please Type again")]
        public string Confirmpwd { get; set; }


        public int UserTypeId { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string UserProfilePicture { get; set; }
        public bool IsRegisteredUser { get; set; }
        public string PaymentGatewayUserRef { get; set; }
        public string ZipCode { get; set; }
        public bool WorksWithPets { get; set; }
        public int? LanguageId { get; set; }
        public int? NationalityId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? Status { get; set; }
        public string BankTokenId { get; set; }
        public string TaxNo { get; set; }

        
    }
}
