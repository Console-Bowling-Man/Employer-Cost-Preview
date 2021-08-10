using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployerCostPreview.Reports.Models
{
    public class EmployeePaycheckReport
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Annual Benefits Cost")]
        public decimal TotalAnnualBenefitsCost { get; set; }
        [Display(Name = "Annual Benefits Costs")]
        public List<AnnualEmployeeBenefitCostReportLine> AnnualEmployeeBenefitCostReportLines { get; } = new();
        public string EmployeeFullName { get; set; }
        [Display(Name = "Paychecks Per Year")]
        public int PaychecksPerYear { get; set; }
        [Display(Name = "Amount Per Paycheck (Gross)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AmountPerPaycheckGross { get; set; }
        [Display(Name = "Benefits Cost Per Paycheck")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal BenefitsCostPerPaycheck { get; set; }
        [Display(Name = "Amount Per Paycheck (Net)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AmountPerPaycheckNet { get; set; }
    }
}
