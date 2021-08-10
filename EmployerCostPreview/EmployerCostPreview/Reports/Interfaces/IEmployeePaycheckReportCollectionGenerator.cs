using System.Collections.Generic;
using System.Threading.Tasks;
using EmployerCostPreview.Reports.Models;

namespace EmployerCostPreview.Reports.Interfaces
{
    public interface IEmployeePaycheckReportCollectionGenerator
    {
        Task<List<EmployeePaycheckReport>> GetEmployeePaycheckReportCollection();
    }
}