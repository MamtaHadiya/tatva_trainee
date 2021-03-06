using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Helperland.Models
{
    public partial class ServiceRequestAddress
    {
        public int Id { get; set; }
        public int? ServiceRequestId { get; set; }

        [Required(ErrorMessage ="Enter Street name")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Enter House no")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Enter City name")]
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Enter Postal Code")]
        public string PostalCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
