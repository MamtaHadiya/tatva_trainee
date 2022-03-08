using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Helperland.Models
{
    public partial class UserAddress
    {
        [Key]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "UseeId is Required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "please Enter House Number.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "please Enter City Name.")]
        public string City { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "please Enter PostalCode.")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "please Enter Phone No.")]
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
