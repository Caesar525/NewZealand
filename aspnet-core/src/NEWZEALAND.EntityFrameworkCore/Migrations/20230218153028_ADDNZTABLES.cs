using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEWZEALAND.Migrations
{
    /// <inheritdoc />
    public partial class ADDNZTABLES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NZ_BUDGETPOOL",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MAINTENANCEUNIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "周期单位")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POOLMONEY = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "预算池"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_BUDGETPOOL", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NZ_CONSUME",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MONTH = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "月份"),
                    EXTREMUM = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "极值"),
                    INCREMENT = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "增值"),
                    LOWEST = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "最低保障值"),
                    DISPOSABLEINCOME = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "可支配收入"),
                    TOTALCONSUME = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "总收入"),
                    DISPOSABLEBALANCE = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "可支配结余"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_CONSUME", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NZ_CONSUMELIST",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MONTH = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "月份"),
                    CONSUME = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "总收入"),
                    USAGE = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, comment: "用途")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REMARK = table.Column<string>(type: "longtext", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCATION = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, comment: "地点")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HAPPENTIME = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发生时间"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_CONSUMELIST", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NZ_INCOMELIST",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MONTH = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "月份"),
                    INCOME = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "总收入"),
                    REMARK = table.Column<string>(type: "longtext", nullable: true, comment: "备注")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCATION = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, comment: "地点")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HAPPENTIME = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "发生时间"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_INCOMELIST", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NZ_MATERIALS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODE = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, comment: "物品ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GOODS = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "物品")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STANDARDPRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "标准价格"),
                    NUMBER = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "数量"),
                    UNIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "单位")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    REALSPENDING = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "实际花销"),
                    MAINTENANCESPENDING = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "周期内总维护费用"),
                    MATERIALSTYPE = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, comment: "物资类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_MATERIALS", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NZ_MATERIALSLIST",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODE = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true, comment: "物品ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MAINTENANCEUNIT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "周期单位")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SPENDING = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "本次周期内费用"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZ_MATERIALSLIST", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NZ_BUDGETPOOL");

            migrationBuilder.DropTable(
                name: "NZ_CONSUME");

            migrationBuilder.DropTable(
                name: "NZ_CONSUMELIST");

            migrationBuilder.DropTable(
                name: "NZ_INCOMELIST");

            migrationBuilder.DropTable(
                name: "NZ_MATERIALS");

            migrationBuilder.DropTable(
                name: "NZ_MATERIALSLIST");
        }
    }
}
