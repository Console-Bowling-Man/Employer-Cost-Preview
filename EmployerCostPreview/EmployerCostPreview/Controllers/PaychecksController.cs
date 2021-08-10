using Microsoft.AspNetCore.Mvc;
using EmployerCostPreview.Data;
using System.Threading.Tasks;
using EmployerCostPreview.Reports.Interfaces;

namespace EmployerCostPreview.Controllers
{
    public class PaychecksController : Controller
    {
        private readonly EcpData _context;
        private readonly IEmployeePaycheckReportCollectionGenerator _collectionGenerator;

        public PaychecksController(EcpData context, IEmployeePaycheckReportCollectionGenerator collectionGenerator)
        {
            _context = context;
            _collectionGenerator = collectionGenerator;
        }
        public async Task<IActionResult> IndexAsync() => View(await _collectionGenerator.GetEmployeePaycheckReportCollection());
    }
}
