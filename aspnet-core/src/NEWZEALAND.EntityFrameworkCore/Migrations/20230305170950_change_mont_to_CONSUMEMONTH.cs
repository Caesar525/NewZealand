using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEWZEALAND.Migrations
{
    /// <inheritdoc />
    public partial class changemonttoCONSUMEMONTH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MONTH",
                table: "NZ_INCOMELIST",
                newName: "CONSUMEMONTH");

            migrationBuilder.RenameColumn(
                name: "MONTH",
                table: "NZ_CONSUMELIST",
                newName: "CONSUMEMONTH");

            migrationBuilder.RenameColumn(
                name: "MONTH",
                table: "NZ_CONSUME",
                newName: "CONSUMEMONTH");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONSUME",
                table: "NZ_CONSUMELIST",
                type: "decimal(65,30)",
                nullable: true,
                comment: "总消费",
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true,
                oldComment: "总收入");

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALCONSUME",
                table: "NZ_CONSUME",
                type: "decimal(65,30)",
                nullable: true,
                comment: "总消费",
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true,
                oldComment: "总收入");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CONSUMEMONTH",
                table: "NZ_INCOMELIST",
                newName: "MONTH");

            migrationBuilder.RenameColumn(
                name: "CONSUMEMONTH",
                table: "NZ_CONSUMELIST",
                newName: "MONTH");

            migrationBuilder.RenameColumn(
                name: "CONSUMEMONTH",
                table: "NZ_CONSUME",
                newName: "MONTH");

            migrationBuilder.AlterColumn<decimal>(
                name: "CONSUME",
                table: "NZ_CONSUMELIST",
                type: "decimal(65,30)",
                nullable: true,
                comment: "总收入",
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true,
                oldComment: "总消费");

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTALCONSUME",
                table: "NZ_CONSUME",
                type: "decimal(65,30)",
                nullable: true,
                comment: "总收入",
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true,
                oldComment: "总消费");
        }
    }
}
