namespace projectoef;

using Microsoft.EntityFrameworkCore;
using projectoef.Models;

public class TareasContext : DbContext
{
    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {
    }

    public DbSet<Tarea> Tareas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() { Id = Guid.NewGuid(), Nombre = "Personal", Descripcion = "Tareas personales", Peso = 1 },
            new Categoria() { Id = Guid.NewGuid(), Nombre = "Trabajo", Descripcion = "Tareas de trabajo", Peso = 2 },
            new Categoria() { Id = Guid.NewGuid(), Nombre = "Estudio", Descripcion = "Tareas de estudio", Peso = 3 },
        };
        
        modelBuilder.Entity<Categoria>(categoria =>{
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.Id);
            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(c => c.Descripcion).IsRequired().HasMaxLength(500);
            categoria.Property(c => c.Peso).IsRequired();
            categoria.HasData(categorias);
        });

        List<Tarea> tareas = new List<Tarea>()
        {
            new Tarea() { Id = Guid.NewGuid(), Titulo = "Tarea 1", Descripcion = "Tarea 1", FechaCreacion = DateTime.Now, CategoriaId = categorias[0].Id, Prioridad = Prioridad.Media },
            new Tarea() { Id = Guid.NewGuid(), Titulo = "Tarea 2", Descripcion = "Tarea 2", FechaCreacion = DateTime.Now, CategoriaId = categorias[1].Id, Prioridad = Prioridad.Alta },
            new Tarea() { Id = Guid.NewGuid(), Titulo = "Tarea 3", Descripcion = "Tarea 3", FechaCreacion = DateTime.Now, CategoriaId = categorias[2].Id, Prioridad = Prioridad.Baja },
        };

        modelBuilder.Entity<Tarea>(tarea =>{
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.Id);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
            tarea.Property(t => t.Descripcion).IsRequired();
            tarea.Property(t => t.Prioridad).IsRequired();
            tarea.Property(t => t.FechaCreacion).IsRequired();
            tarea.Ignore(t => t.Resumen);
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.HasData(tareas);
        });
            
    }
}