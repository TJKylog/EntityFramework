using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("5281449e-055e-41d6-a0c2-c143a46c73ba"), "Tareas de trabajo", "Trabajo", 2 },
                    { new Guid("6c2a47e1-0a63-41a2-b943-08698f37a827"), "Tareas personales", "Personal", 1 },
                    { new Guid("8dc08aa0-0bcf-4f97-b44e-99c104f7751d"), "Tareas de estudio", "Estudio", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "Id", "CategoriaId", "Descripcion", "FechaCreacion", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1f25c5b7-8157-4a96-8d92-b23502250980"), new Guid("6c2a47e1-0a63-41a2-b943-08698f37a827"), "Tarea 1", new DateTime(2022, 11, 27, 18, 15, 14, 941, DateTimeKind.Local).AddTicks(1503), 1, "Tarea 1" },
                    { new Guid("3b13c973-8107-4d0f-b85f-0ed1a8e6c87c"), new Guid("5281449e-055e-41d6-a0c2-c143a46c73ba"), "Tarea 2", new DateTime(2022, 11, 27, 18, 15, 14, 941, DateTimeKind.Local).AddTicks(1557), 2, "Tarea 2" },
                    { new Guid("5795f5b2-46d7-4aec-8d90-afafa8e3e96f"), new Guid("8dc08aa0-0bcf-4f97-b44e-99c104f7751d"), "Tarea 3", new DateTime(2022, 11, 27, 18, 15, 14, 941, DateTimeKind.Local).AddTicks(1559), 0, "Tarea 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "Id",
                keyValue: new Guid("1f25c5b7-8157-4a96-8d92-b23502250980"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "Id",
                keyValue: new Guid("3b13c973-8107-4d0f-b85f-0ed1a8e6c87c"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "Id",
                keyValue: new Guid("5795f5b2-46d7-4aec-8d90-afafa8e3e96f"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("5281449e-055e-41d6-a0c2-c143a46c73ba"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("6c2a47e1-0a63-41a2-b943-08698f37a827"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("8dc08aa0-0bcf-4f97-b44e-99c104f7751d"));
        }
    }
}
