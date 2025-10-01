using Microsoft.AspNetCore.Mvc;
using Schoolhub.Application.Students;

namespace Schoolhub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<StudentDto>>> GetAllStudents(CancellationToken ct)
    {
        var dto = await studentService.ListAsync(ct);
        return Ok(dto);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentDto>> GetById(Guid id, CancellationToken ct)
    {
        var dto = await studentService.GetAsync(id, ct);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequest request, CancellationToken ct)
    {
        var id = await studentService.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStudentRequest request, CancellationToken ct)
    {
        await studentService.UpdateAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await studentService.DeleteAsync(id, ct);
        return NoContent();
    }
}