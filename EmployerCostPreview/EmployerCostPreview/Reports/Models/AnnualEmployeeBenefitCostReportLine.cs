using System.ComponentModel.DataAnnotations;

namespace EmployerCostPreview.Reports.Models
{
    public class AnnualEmployeeBenefitCostReportLine
    {
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}