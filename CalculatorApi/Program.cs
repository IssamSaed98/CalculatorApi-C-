var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapGet("/", () => "Welcome to Calculator API!");

app.MapGet("/add", (double a, double b) => Results.Ok(a + b));

app.MapGet("/subtract", (double a, double b) => Results.Ok(a - b));

app.MapGet("/multiply", (double a, double b) => Results.Ok(a * b));

app.MapGet("/divide", (double a, double b) =>
{
    if (b == 0)
    {
        return Results.BadRequest("Division by zero is not allowed.");
    }
    return Results.Ok(a / b);
});

app.Run();
