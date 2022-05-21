using Mapster;
using Kusuri.Employees.Domain;
using Kusuri.Shared.Domain.Bus.Command;

namespace Kusuri.Employees.Application.Create;

public class CreateEmployeeCommandHandler : CommandHandler<CreateEmployeeCommand>
{
    public readonly IEmployeeRepository _repository;

    public CreateEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    protected override async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = request.Adapt<Employee>();
        await _repository.Save(employee);
    }
 
}
