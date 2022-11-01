using Microsoft.AspNetCore.Mvc;
namespace WebAPITest.Controllers;

[ApiController]
[Route("")]
public class GreetingController : ControllerBase
{
    [HttpGet]
    public string Hello()
    {
        return "Check Auto Deployment!";
    }
}