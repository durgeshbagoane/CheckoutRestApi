var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI( option =>
{
    option.SwaggerEndpoint("/swagger/v1/swagger.json","Go Compare Test Checkout Documentation");
});
app.MapControllers();
app.Run();

