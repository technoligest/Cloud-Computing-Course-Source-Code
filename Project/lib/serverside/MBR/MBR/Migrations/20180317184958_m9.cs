using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urls");

            migrationBuilder.CreateTable(
                name: "employeeUrls",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    applicationId = table.Column<string>(nullable: true),
                    callBackId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeUrls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insuranceUrls",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    applicationId = table.Column<string>(nullable: true),
                    callBackUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceUrls", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeUrls");

            migrationBuilder.DropTable(
                name: "insuranceUrls");

            migrationBuilder.CreateTable(
                name: "urls",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    applicationId = table.Column<string>(nullable: true),
                    employerUrl = table.Column<string>(nullable: true),
                    insuranceUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urls", x => x.id);
                });
        }
    }
}
