using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEWZEALAND.Migrations
{
    /// <inheritdoc />
    public partial class ADDCOLUMNTenantId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_MATERIALSLIST",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_MATERIALS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_INCOMELIST",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_CONSUMELIST",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_CONSUME",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "NZ_BUDGETPOOL",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_MATERIALSLIST");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_MATERIALS");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_INCOMELIST");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_CONSUMELIST");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_CONSUME");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "NZ_BUDGETPOOL");
        }
    }
}
