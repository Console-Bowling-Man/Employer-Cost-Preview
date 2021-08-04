using System;

namespace EmployerCostPreview.Data.Models
{
    public class Dependent
    {
        public int DependentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Employee Employee { get; set; }
    }
}