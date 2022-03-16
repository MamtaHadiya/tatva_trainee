using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models
{
    public class ViewModel
    {
        public ServiceRequest serviceRequest { get; set; }
        public ServiceRequestAddress requestAddress { get; set; }
        public User user { get; set; }
        public UserAddress userAddress { get; set; }
        public Rating rating { get; set; }
        public FavoriteAndBlocked blocked { get; set; }
    }
}
