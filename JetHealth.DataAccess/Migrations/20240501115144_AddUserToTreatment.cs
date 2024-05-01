using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetHealth.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Treatments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_ApplicationUserId",
                table: "Treatments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_AspNetUsers_ApplicationUserId",
                table: "Treatments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_AspNetUsers_ApplicationUserId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_ApplicationUserId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Treatments");
        }
    }
}
