using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Welcomen Herr Marcel, Ich bin Calculator API!");

// Funktion zum Sammeln von Zahlen

app.MapGet("/add", (double a, double b) => 
Results.Ok(a + b));

//Funktion zum Subtrahieren von Zahlen

app.MapGet("/subtract", (double a, double b) =>
Results.Ok(a - b));

//Funktion zum Multiplizieren von Zahlen
app.MapGet("/multiply", (double a, double b) =>
Results.Ok(a * b));

//Funktion zum Teilen durch eine beliebige Zahl außer Null
app.MapGet("/divide", (double a, double b) =>
{
    if (b == 0)
    {
        return Results.BadRequest("Eine Zahl kann nicht durch Null geteilt werden !");
    }
    return Results.Ok(a / b);
});

app.Run();
