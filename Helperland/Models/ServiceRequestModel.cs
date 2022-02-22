using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class ServiceRequestModel
    {
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("UserId")]
        public int UserId { get; set; }
        [JsonPropertyName("hours")]
        public double Hours { get; set; }
        [JsonPropertyName("ServiceHourlyRate")]
        public decimal ServiceHourlyRate { get; set; }
        [JsonPropertyName("ExtraHours")]
        public double ExtraHours { get; set; }
        [JsonPropertyName("SubTotal")]
        public decimal SubTotal { get; set; }
        [JsonPropertyName("TotalCost")]
        public decimal TotalCost { get; set; }
        [JsonPropertyName("Comments")]
        public string Comments { get; set; }
        [JsonPropertyName("HasPets")]
        public bool HasPets { get; set; }
        [JsonPropertyName("bookingStartTime")]
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
    }
}
