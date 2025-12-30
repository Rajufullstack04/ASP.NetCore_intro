using ASP.NetCore_intro.Extensions;

using ASP.NetCore_intro.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();


// the middleware will be activating here.......






//1 st Middleware

app.UseMiddleware<HttpContextMiddleware>();

//app.UseHttpContextMiddleware();
//2nd Middleware
app.UseMiddleware<LoggingMiddleware>();
//app.UseLoggingMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
