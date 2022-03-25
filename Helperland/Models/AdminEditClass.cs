using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class AdminEditClass
    {
        public string BookingStartTime { get; set; }
        public DateTime ServiceStartDate
        {
            get
            {
                DateTime date = DateTime.MinValue;
                if (!string.IsNullOrEmpty(this.BookingStartTime))
                    DateTime.TryParse(this.BookingStartTime, out date);
                return date;
            }
        }

        public int? ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Enter Street name")]
        public string AddressLine1 { get; set; }
        
        [Required(ErrorMessage = "Enter House no")]
        public string AddressLine2 { get; set; }
        
        [Required(ErrorMessage = "Enter City name")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Enter Postal Code")]
        public string PostalCode { get; set; }

    }
}
