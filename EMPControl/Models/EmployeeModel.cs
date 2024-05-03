using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPControl.Models
{
    class EmployeeModel
    {
        public string Id                { get; set; }
        public string FirstName         { get; set; }
        public string SecondName        { get; set; }
        public string MiddleName        { get; set; }
        public string BirthDate         { get; set; }
        public string PassportSeries    { get; set; }
        public string PassportNumber    { get; set; }
    }
}
