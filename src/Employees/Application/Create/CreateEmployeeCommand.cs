using Kusuri.Shared.Domain.Bus.Command;

namespace Kusuri.Employees.Application.Create;

public record CreateEmployeeCommand(string Id, string Name, string LastName, int Age, string Email, string Phone, string Address, string Gender) : Command;
