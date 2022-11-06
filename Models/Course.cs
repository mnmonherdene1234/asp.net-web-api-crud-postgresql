using System.ComponentModel.DataAnnotations;
using WebAPITest.Models;

public class Course
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}