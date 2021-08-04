using System;
using System.Collections.Generic;

namespace EmployerCostPreview.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Dependent> Dependents { get; set; }
    }
}