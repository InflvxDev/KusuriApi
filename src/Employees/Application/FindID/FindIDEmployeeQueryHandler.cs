using Mapster;
using Kusuri.Employees.Domain;
using Kusuri.Shared.Domain.Bus.Query;

namespace Kusuri.Employees.Application.FindID;

public class FindAllEmployeesQueryHandler : IQueryHandler<FindIDEmployeeQuery, EmployeeResponse?>
{
    private readonly IEmployeeRepository _repository;

    public FindAllEmployeesQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmployeeResponse?> Handle(FindIDEmployeeQuery query, CancellationToken cancellationToken)
    {
        var employee = await _repository.Find(query.id);
        return employee?.Adapt<EmployeeResponse>();
    }
}