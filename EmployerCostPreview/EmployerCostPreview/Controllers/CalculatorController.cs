using Microsoft.AspNetCore.Mvc;
using EmployerCostPreview.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployerCostPreview.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly EcpData _context;

        public CalculatorController(EcpData context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Employees.ToListAsync());
        }
    }
}
