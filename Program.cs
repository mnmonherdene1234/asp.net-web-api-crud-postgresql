using Microsoft.EntityFrameworkCore;
using WebAPITest.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("StudentsDB")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
