using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToTProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Procedures",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Procedures");
        }
    }
}
