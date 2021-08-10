using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployerCostPreview.Data;
using EmployerCostPreview.Reports.Interfaces;
using EmployerCostPreview.Reports.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployerCostPreview.Reports
{
    public class EmployeePaycheckReportCollectionGenerator : IEmployeePaycheckReportCollectionGenerator
    {
        private readonly EcpData _context;

        public EmployeePaycheckReportCollectionGenerator(EcpData context)
        {
            _context = context;
        }

        public async Task<List<EmployeePaycheckReport>> GetEmployeePaycheckReportCollection()
        {
            var reports = new List<EmployeePaycheckReport>();

            foreach (var employee in await _context.Employees.Include(employee => employee.Dependents).ToListAsync())
            {
                var employeePaycheckReport = new EmployeePaycheckReport();
                void AddEmployeeBenefitCost(string fullName, string description, decimal cost)
                {
                    employeePaycheckReport.AnnualEmployeeBenefitCostReportLines.Add(new AnnualEmployeeBenefitCostReportLine
                    {
                        Description = $"{fullName}: {description}",
                        Cost = cost
                    });
                    employeePaycheckReport.TotalAnnualBenefitsCost += cost;
                }
                void ConsiderCoveredPerson(string fullName, decimal cost, string firstName)
                {
                    AddEmployeeBenefitCost(fullName, "Cost of Benefits", cost);
                    if (firstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
                        AddEmployeeBenefitCost(fullName, "Letter \"A\" Appreciation Discount", cost * -0.1m);
                }

                var employeeFullName = $"{employee.FirstName} {employee.LastName}";
                employeePaycheckReport.EmployeeFullName = employeeFullName;
                ConsiderCoveredPerson(employeeFullName, 1000m, employee.FirstName);

                foreach (var dependent in employee.Dependents)
                {
                    var dependentFullName = $"{dependent.FirstName} {dependent.LastName}";
                    ConsiderCoveredPerson(dependentFullName, 500m, dependent.FirstName);
                }

                employeePaycheckReport.PaychecksPerYear = 26;
                employeePaycheckReport.AmountPerPaycheckGross = 2000m;
                employeePaycheckReport.BenefitsCostPerPaycheck = employeePaycheckReport.TotalAnnualBenefitsCost /
                                                                 employeePaycheckReport.PaychecksPerYear;
                employeePaycheckReport.AmountPerPaycheckNet = employeePaycheckReport.AmountPerPaycheckGross -
                                                              employeePaycheckReport.BenefitsCostPerPaycheck;

                reports.Add(employeePaycheckReport);
            }

            return reports;
        }
    }
}