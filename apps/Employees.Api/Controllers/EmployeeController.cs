using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kusuri.Employees.Application.Create;

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
}
