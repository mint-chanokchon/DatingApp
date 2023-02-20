using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
    AddTransient    -> ถูกสร้างขึ้นเมื่อมีการ Req และถูกเมื่อ Res
    AddSingleton    -> ถูกสร้างขึ้นเมื่อแอบเริ่มทำงานและถูกทำงายเมื่อแอพหยุดการทำงาน โดยปกติจะใช้ใน Catch Services
*/
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader()
                              .AllowAnyMethod()
                              .WithOrigins("http://localhost:4200"));
// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
