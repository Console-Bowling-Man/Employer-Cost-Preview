using System;
using System.ComponentModel.DataAnnotations;
using EmployerCostPreview.Data.Validation;

namespace EmployerCostPreview.Data.Models
{
    public class Dependent
    {
        public int DependentId { get; set; }
        [Display(Name = "First Name")]
        [NotNullOrWhiteSpaceValidator]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [NotNullOrWhiteSpaceValidator]
        public string LastName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}