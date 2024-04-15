using cine_roxy.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlDbContext>(options =>
{
  var defaultConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
  options.UseMySql(defaultConnectionString, ServerVersion.AutoDetect(defaultConnectionString));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
