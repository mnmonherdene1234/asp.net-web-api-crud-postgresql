using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Controllers;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    public readonly DatabaseContext _context;

    public StudentController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        if (student == null)
            return BadRequest();

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();

        return student;
    }

    [HttpGet]
    public List<Student> GetStudents()
    {
        return _context.Students.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        Student student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        return student;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
    {
        Student found = await _context.Students.FindAsync(id);
        if (found == null) return NotFound();
        found.Name = student.Name;
        found.Age = student.Age;
        await _context.SaveChangesAsync();
        return found;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        Student student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return student;
    }
}