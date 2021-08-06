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

        // GET: Dependents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dependents.ToListAsync());
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
            ViewData["EmployeesNamesIds"] = _context.Employees.Select(employee =>
                new SelectListItem
                {
                    Text = $"{employee.FirstName} {employee.LastName}",
                    Value = employee.EmployeeId.ToString()
                });
            return View();
        }

        // POST: Dependents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DependentId,Employee,FirstName,LastName")] Dependent dependent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            
            ViewData["EmployeesNamesIds"] = _context.Employees.Select(employee =>
                new SelectListItem
                {
                    Text = $"{employee.FirstName} {employee.LastName}",
                    Value = employee.EmployeeId.ToString()
                });
            return View(dependent);
        }

        // POST: Dependents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DependentId,Employee,FirstName,LastName")] Dependent dependent)
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
                return RedirectToAction(nameof(Index));
            }
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
            return RedirectToAction(nameof(Index));
        }

        private bool DependentExists(int id)
        {
            return _context.Dependents.Any(e => e.DependentId == id);
        }
    }
}
