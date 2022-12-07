using Microsoft.EntityFrameworkCore.Migrations;

namespace AppLaboratorio.Infraestructura.Datos.Migrations
{
    public partial class firtsmigrationv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Identificacion",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Identificacion",
                table: "Docentes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "IdCargo", "NombreCargo" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Contraseña", "Email", "IdCargo", "NombreUsuario" },
                values: new object[] { 1, "12345678", "nvelandia@unicesar.edu.co", 1, "vnemer" });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "IdEmpleado", "IdUsuario", "Identificacion", "PrimerApellido", "PrimerNombre", "SegundoApellido", "SegundoNombre" },
                values: new object[] { 1, 1, "1121328342", "Velandia", "Nemer", "Soto", "Jose" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "IdEmpleado",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cargos",
                keyColumn: "IdCargo",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacion",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identificacion",
                table: "Docentes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
