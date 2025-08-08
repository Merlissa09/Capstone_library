var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is the essential line to enable controllers
builder.Services.AddControllers();
// These two lines add support for Swagger/OpenAPI, which is great for testing your endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// In a development environment, we want to use Swagger for easy testing.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// This is the essential line that maps the controller routes to the application.
// Without this, the application won't know how to handle requests to your controllers.
app.MapControllers();

app.Run();
