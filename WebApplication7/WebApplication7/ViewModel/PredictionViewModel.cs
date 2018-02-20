using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.ViewModel
{
    public class PredictionViewModel
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Department ID must positive number")]
        public int Dept { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Employee ID must positive number")]
        public int StaffID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public string Event { get; set; }
        public int PotentialDay { get; set; }
        public string Session { get; set; }
        public string Weather { get; set; }
        public int jobSatisfaction { get; set; }
    }
}
