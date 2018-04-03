using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employerEmployees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employerEmployees",
                table: "employerEmployees",
                column: "id");

            migrationBuilder.CreateTable(
                name: "brokerCustomers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    customerID = table.Column<string>(nullable: true),
                    employeeid = table.Column<string>(nullable: true),
                    employer = table.Column<string>(nullable: true),
                    employerVerified = table.Column<bool>(nullable: false),
                    insuranceCompany = table.Column<string>(nullable: true),
                    insuranceVerified = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brokerCustomers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_brokerCustomers_brokerCustomers_customerID",
                        column: x => x.customerID,
                        principalTable: "brokerCustomers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_brokerCustomers_employerEmployees_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employerEmployees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "insuranceCustomers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    value = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceCustomers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brokerCustomers_customerID",
                table: "brokerCustomers",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_brokerCustomers_employeeid",
                table: "brokerCustomers",
                column: "employeeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brokerCustomers");

            migrationBuilder.DropTable(
                name: "insuranceCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employerEmployees",
                table: "employerEmployees");

            migrationBuilder.RenameTable(
                name: "employerEmployees",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "id");
        }
    }
}
