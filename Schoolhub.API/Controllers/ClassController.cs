using Microsoft.AspNetCore.Mvc;
using Schoolhub.Application.Classes;

namespace Schoolhub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassController(IClassService classService) : ControllerBase
{
    [HttpPost("{studentId:guid}/assign/{classId:guid}")]
    public async Task<IActionResult> Assign(Guid studentId, Guid classId, CancellationToken ct)
    {
        await classService.AssignStudentToClassAsync(studentId, classId, ct);
        return NoContent();
    }


    [HttpPost("{studentId:guid}/unassign")]
    public async Task<IActionResult> Unassign(Guid studentId, CancellationToken ct)
    {
        await classService.UnassignStudentFromClassAsync(studentId, ct);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<List<SchoolClassDto>>> GetAllClasses(CancellationToken ct)
    {
        var dto = await classService.ListAsync(ct);
        return Ok(dto);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SchoolClassDto>> GetById(Guid id, CancellationToken ct)
    {
        var dto = await classService.GetAsync(id, ct);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSchoolClassRequest request, CancellationToken ct)
    {
        var id = await classService.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSchoolClassRequest request, CancellationToken ct)
    {
        await classService.UpdateAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await classService.DeleteAsync(id, ct);
        return NoContent();
    }
}