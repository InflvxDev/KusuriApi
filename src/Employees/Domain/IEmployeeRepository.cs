using Kusuri.Shared.Domain.Respository;

namespace Kusuri.Employees.Domain;

public interface IEmployeeRepository : IRepository<Employee, string>
{
}
