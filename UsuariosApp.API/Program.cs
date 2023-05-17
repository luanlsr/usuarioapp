#region builder
using UsuariosApp.API.Extensions;
using UsuariosApp.API.Extentions;
using UsuariosApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddServices();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddAutoMapperProfiles();

#endregion
#region
var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();

public partial class Program { }
#endregion