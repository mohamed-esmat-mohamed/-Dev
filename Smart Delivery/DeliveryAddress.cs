using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery
{
    internal class DeliveryAddress
    {
        public string City { get; set; }
        public DeliveryAddress(string city)
        {
            City = city;
        }
    }
}
