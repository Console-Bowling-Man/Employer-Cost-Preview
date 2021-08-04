using System.Linq;
using Bogus;
using EmployerCostPreview.Data.Models;

namespace EmployerCostPreview.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EcpData context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
                return;
            var faker = new Faker();
            for (var i = 0; i < 4; i++)
                context.Employees.Add(new Employee
                {
                    FirstName = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Dependents = Enumerable.Range(0, faker.Random.Number(3)).Select(_ => new Dependent
                    {
                        FirstName = faker.Name.FirstName(),
                        LastName = faker.Name.LastName()
                    }).ToList()
                });
            
            context.SaveChanges();
        }
    }
}
