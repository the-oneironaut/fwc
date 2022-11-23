using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlatworldConnect.DataAccess.Migrations
{
    public partial class Add4TablesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPhone = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "projectManagers",
                columns: table => new
                {
                    PMId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMPhone = table.Column<long>(type: "bigint", nullable: false),
                    PMLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMZipCode = table.Column<int>(type: "int", nullable: false),
                    PMState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectManagers", x => x.PMId);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    resourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    jobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skillSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<int>(type: "int", nullable: false),
                    noOfMonths = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "date", nullable: false),
                    endDate = table.Column<DateTime>(type: "date", nullable: false),
                    noOfResources = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.resourceId);
                    table.ForeignKey(
                        name: "FK_resources_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    projectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    projectEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    PMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.projectId);
                    table.ForeignKey(
                        name: "FK_projects_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_projectManagers_PMId",
                        column: x => x.PMId,
                        principalTable: "projectManagers",
                        principalColumn: "PMId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_customerId",
                table: "projects",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_PMId",
                table: "projects",
                column: "PMId");

            migrationBuilder.CreateIndex(
                name: "IX_resources_customerId",
                table: "resources",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "projectManagers");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
