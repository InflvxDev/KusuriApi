using Mapster;
using Kusuri.Employees.Domain;
using Kusuri.Shared.Domain.Bus.Query;

namespace Kusuri.Employees.Application.FindAll;

public class FindAllEmployeesQueryHandler : IQueryHandler<FindAllEmployeesQuery, IEnumerable<EmployeeResponse>>
{
    private readonly IEmployeeRepository _repository;

    public FindAllEmployeesQueryHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmployeeResponse>> Handle(FindAllEmployeesQuery query, CancellationToken cancellationToken)
    {
        var employees = await _repository.SearchAll();
        return  employees.Adapt<IEnumerable<EmployeeResponse>>();
    }
}

