using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
}