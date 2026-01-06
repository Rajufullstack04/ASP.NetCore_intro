
//using ASP.NetCore_intro.Contracts;
//using ASP.NetCore_intro.Middleware;
//using ASP.NetCore_intro.Services1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSingleton<IAuthenticateService, AuthenticationService>();
//builder.Services.AddSingleton<IJWTAuthentication , JWTAuthenticationService>();


var app = builder.Build();

//app.UseMiddleware<AuthenticationMiddelware>();
//app.UseMiddleware<JWTAuthenticationMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
