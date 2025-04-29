using Microsoft.EntityFrameworkCore;
using BookApi.Models;
using BookApi.Data;


// https://localhost:7179/api/books


var builder = WebApplication.CreateBuilder(args);

// Wczytanie connection stringa (lub wpisz bezpośrednio)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                      ?? "Data Source=books.db";

// Konfiguracja EF Core i SQLite
builder.Services.AddDbContext<BooksDbContext>(options =>
    options.UseSqlite("Data Source=./books.db"));


var app = builder.Build();

// Tworzenie bazy danych przy starcie
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BooksDbContext>();
    Console.WriteLine("🔧 Sprawdzanie bazy danych...");
    db.Database.EnsureCreated(); // <-- TO MUSI BYĆ
}

// Endpoints API

// GET: /api/books
app.MapGet("/api/books", async (BooksDbContext db) =>
    await db.Books.ToListAsync());

// GET: /api/books/{id}
app.MapGet("/api/books/{id}", async (int id, BooksDbContext db) =>
    await db.Books.FindAsync(id) is Book book
        ? Results.Ok(book)
        : Results.NotFound());

// POST: /api/books
app.MapPost("/api/books", async (Book book, BooksDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/api/books/{book.Id}", book);
});

// PUT: /api/books/{id}
app.MapPut("/api/books/{id}", async (int id, Book input, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    book.Title = input.Title;
    book.Author = input.Author;
    book.PublishedYear = input.PublishedYear;
    book.IsRead = input.IsRead;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE: /api/books/{id}
app.MapDelete("/api/books/{id}", async (int id, BooksDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
