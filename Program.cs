using Microsoft.EntityFrameworkCore;
using TableandCommandControl.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TableComandContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
// "ConnectionStrings": {
    //"ConexaoPadrao": "Server=localhost\\sqlexpress01; Initial Catalog=TCC;TrustServerCertificate=True; Integrated Security=True"
//}

// builder.Services.AddDbContext<TableComandContext>(options =>
// {
//     options.UseMySql(
//         builder.Configuration.GetConnectionString("DefaultConnection"),
//         new MySqlServerVersion(new Version(8, 0, 26))); // Substitua pela versão correta do MySQL
// });




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
