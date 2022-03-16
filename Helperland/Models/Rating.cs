using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Helperland.Models
{
    public partial class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required(ErrorMessage = "Service id is required.")]
        public int ServiceRequestId { get; set; }
        
        [Required(ErrorMessage = "Customer id is required.")]
        public int RatingFrom { get; set; }
        
        [Required(ErrorMessage = "Provider id is required.")]
        public int RatingTo { get; set; }

        public decimal Ratings { get; set; }
        public string Comments { get; set; }
        public DateTime RatingDate { get; set; }

        [Required(ErrorMessage = "give rating for OntimeArrival.")]
        public decimal OnTimeArrival { get; set; }

        [Required(ErrorMessage = "give rating for Friendly.")]
        public decimal Friendly { get; set; }

        [Required(ErrorMessage = "give rating for Quality of service.")]
        public decimal QualityOfService { get; set; }

        public virtual User RatingFromNavigation { get; set; }
        public virtual User RatingToNavigation { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
