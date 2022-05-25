using Kusuri.Shared.Domain.Bus.Query;

namespace Kusuri.Employees.Application.FindID;

public record FindIDEmployeeQuery(string id) : Query<EmployeeResponse?>;