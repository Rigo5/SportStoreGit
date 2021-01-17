using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entity
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter the firs Address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }
        [Required(ErrorMessage ="Please enter a City")]
        public string State { get; set; }
        [Required(ErrorMessage ="Please enter the zip code")]
        public int Zip { get; set; }
        [Required(ErrorMessage ="Please enter a country name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
