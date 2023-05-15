#region builder
using UsuariosApp.API.Extensions;
using UsuariosApp.API.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddServices();
builder.Services.AddEntityFramework(builder.Configuration);
#endregion
#region
var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
#endregion