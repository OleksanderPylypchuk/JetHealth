using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class TProcedureTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Procedures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Procedures");
        }
    }
}
