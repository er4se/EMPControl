using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.Models
{
    class OrganizationModel
    {
        public string Id    { get; set; }
        public string Name  { get; set; }
        public string TIN   { get; set; }
        public string LegalAddress    { get; set; } = "";
        public string PhysicalAddress { get; set; } = "";

        public OrganizationModel()
        {
            InitializeModel();
        }

        public void InitializeModel()
        {

        }
    }
}
