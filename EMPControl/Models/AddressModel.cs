using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.Models
{
    class AddressModel
    {
        public string Country       { get; set; } = String.Empty;
        public string Region        { get; set; } = String.Empty;
        public string Settlement    { get; set; } = String.Empty;
        public string Street        { get; set; } = String.Empty;
        public string Building      { get; set; } = String.Empty;
        public string Office        { get; set; } = String.Empty;

        public void NormalizeAddress()
        {
            Country     = Country.Trim();
            Region      = Region.Trim();
            Settlement  = Settlement.Trim();
            Street      = Street.Trim();
            Building    = Building.Trim();
            Office      = Office.Trim();
        }

        public string GetFullAddressString()
        {
            NormalizeAddress();

            var fullAddress = new StringBuilder();

            fullAddress
                .Append(Country).Append((char)32)
                .Append(Region).Append((char)32)
                .Append(Settlement).Append((char)32)
                .Append(Street).Append((char)32)
                .Append(Building).Append((char)32)
                .Append(Office);

            return fullAddress.ToString();
        }
    }
}
