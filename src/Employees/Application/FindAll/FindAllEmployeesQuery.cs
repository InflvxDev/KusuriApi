using Kusuri.Shared.Domain.Bus.Query;

namespace Kusuri.Employees.Application.FindAll;

public record FindAllEmployeesQuery() : Query<IEnumerable<EmployeeResponse>>;