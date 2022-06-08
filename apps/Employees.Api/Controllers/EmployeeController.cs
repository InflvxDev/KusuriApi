using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kusuri.Employees.Application.Create;
using Kusuri.Employees.Application.FindAll;
using Kusuri.Employees.Application.FindID;

namespace Employees.Api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _mediator.Send(new FindAllEmployeesQuery());
        return (employees == null) ? NotFound() :  Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(string id)
    {
        var employee = await _mediator.Send(new FindIDEmployeeQuery(id));
        return (employee == null) ? NotFound() : Ok(employee);
    }
}
