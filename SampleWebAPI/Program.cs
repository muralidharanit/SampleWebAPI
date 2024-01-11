using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services helps to configure your services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDBContext>(options =>
            options.UseNpgsql("Server=localhost;Port=5433;Database=SampleWebAPIDb;User Id=postgres;Password=password"));

builder.Services.AddMvc().AddXmlSerializerFormatters();

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

// Ensure the database is created.
using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDBContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.Run();