using LMS.Application.Extensions;
using LMS.Application.Features.Lookups.Queries;
using LMS.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddContext(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddApplicationPackages();
builder.Services.AddMediatR(r => r.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(GetAllLookupsDropdownQueryHandler).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7052");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
