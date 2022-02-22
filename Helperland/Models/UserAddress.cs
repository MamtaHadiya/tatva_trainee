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

        [Required(ErrorMessage = "please Enter Street Name.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        public string City { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "please Enter Street Name.")]
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
