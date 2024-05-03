using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.Models
{
    public struct AddressModel
    {
        public string Country       { get; set; }
        public string Region        { get; set; }
        public string Settlement    { get; set; }
        public string Street        { get; set; }
        public string Building      { get; set; }
        public string Office        { get; set; }

        public void NormalizeAddress()
        {
            Country     = Country.Trim();
            Region      = Region.Trim();
            Settlement  = Settlement.Trim();
            Street      = Street.Trim();
            Building    = Building.Trim();
            Office      = Office.Trim();
        }
    }
}
