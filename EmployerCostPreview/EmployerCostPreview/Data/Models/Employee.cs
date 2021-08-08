using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EmployerCostPreview.Data.Validation;

namespace EmployerCostPreview.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        [NotNullOrWhiteSpaceValidator]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [NotNullOrWhiteSpaceValidator]
        public string LastName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Dependent> Dependents { get; set; }
    }
}