using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployerCostPreview.Data;
using EmployerCostPreview.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployerCostPreview.Controllers
{
    public class DependentsController : Controller
    {
        private readonly EcpData _context;

        public DependentsController(EcpData context)
        {
            _context = context;
        }

        // GET: Dependents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents
                .FirstOrDefaultAsync(m => m.DependentId == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // GET: Dependents/Create
        public IActionResult Create()
        {
            CreateViewPrep();
            return View();
        }

        private void CreateViewPrep()
        {
            var employeeId = GetQueryStringEmployeeId();
            ViewData["EmployeeId"] = employeeId;
            ProvideEmployeesNamesIds(employeeId);
        }

        private int GetQueryStringEmployeeId() => HttpContext.Request.Query["EmployeeId"].ToList().Select(s =>
        {
            var success = int.TryParse(s, out var integer);
            return new {success, integer};
        }).FirstOrDefault(arg => arg.success)?.integer ?? 0;

        private void ProvideEmployeesNamesIds(int employeeId)
        {
            ViewData["EmployeesNamesIds"] = _context.Employees.Select(employee => new SelectListItem
            {
                Text = $"{employee.FirstName} {employee.LastName}",
                Value = employee.EmployeeId.ToString(),
                Selected = employee.EmployeeId == employeeId
            });
        }

        // POST: Dependents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DependentId,EmployeeId,FirstName,LastName")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Employees");
            }

            CreateViewPrep();
            return View(dependent);
        }

        // GET: Dependents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents.FindAsync(id);
            if (dependent == null)
            {
                return NotFound();
            }

            ProvideEmployeesNamesIds(dependent.EmployeeId);
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DependentId,EmployeeId,FirstName,LastName")] Dependent dependent)
        {
            if (id != dependent.DependentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependentExists(dependent.DependentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Employees");
            }

            ProvideEmployeesNamesIds(dependent.EmployeeId);
            return View(dependent);
        }

        // GET: Dependents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependent = await _context.Dependents
                .FirstOrDefaultAsync(m => m.DependentId == id);
            if (dependent == null)
            {
                return NotFound();
            }

            return View(dependent);
        }

        // POST: Dependents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependent = await _context.Dependents.FindAsync(id);
            _context.Dependents.Remove(dependent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Employees");
        }

        private bool DependentExists(int id)
        {
            return _context.Dependents.Any(e => e.DependentId == id);
        }
    }
}
