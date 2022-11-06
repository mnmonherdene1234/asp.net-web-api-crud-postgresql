using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

[ApiController]
[Route("courses")]
public class CoursesController : ControllerBase
{
    private readonly DatabaseContext _context;
    public CoursesController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        if (course == null) return BadRequest();
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    [HttpGet]
    public List<Course> GetCourses()
    {
        return _context.Courses.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        Course course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();

        return course;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Course>> UpdateCourse(int id, Course update)
    {
        Course course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();
        course.Name = update.Name;
        await _context.SaveChangesAsync();
        return course;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Course>> DeleteCourse(int id)
    {
        Course course = await _context.Courses.FindAsync(id);
        if (course == null) return NotFound();
        return course;
    }
}