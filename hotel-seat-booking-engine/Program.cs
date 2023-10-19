using Microsoft.EntityFrameworkCore;
using QueryModelMapper.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(connectionString));

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder
//            .WithOrigins("http://localhost:4200", "http://localhost")   // Allow requests from any origin
//            .AllowAnyMethod()   // Allow any HTTP method (GET, POST, PUT, etc.)
//            .AllowAnyHeader();  // Allow any HTTP headers
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseAuthorization();
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
app.MapControllers();

app.Run();
