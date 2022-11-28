using projectoef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext db) =>
{
    db.Database.EnsureCreated();
    return Results.Ok("Base de datos creada: "+db.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext db) =>
{
    var tareas = await db.Tareas.Include(t => t.Categoria).ToListAsync();
    return Results.Ok(tareas);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext db, [FromBody] projectoef.Models.Tarea tarea) =>
{
    tarea.Id = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await db.Tareas.AddAsync(tarea);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext db, [FromRoute] Guid id, [FromBody] projectoef.Models.Tarea tarea) =>
{
    var tareaDB = db.Tareas.Find(id);
    if (tareaDB == null)
        return Results.NotFound();
    tareaDB.Titulo = tarea.Titulo;
    tareaDB.Descripcion = tarea.Descripcion;
    tareaDB.Prioridad = tarea.Prioridad;
    tareaDB.CategoriaId = tarea.CategoriaId;
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext db, [FromRoute] Guid id) =>
{
    var tareaDB = db.Tareas.Find(id);
    if (tareaDB == null)
        return Results.NotFound();
    db.Tareas.Remove(tareaDB);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
