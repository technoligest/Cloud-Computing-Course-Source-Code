using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "insuranceProperties",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    MLS_Id = table.Column<string>(nullable: true),
                    clientName = table.Column<string>(nullable: true),
                    deductable = table.Column<double>(nullable: false),
                    insuredValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceProperties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "municipalPropertiesf",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    MLS_Id = table.Column<string>(nullable: true),
                    police = table.Column<string>(nullable: true),
                    schools = table.Column<string>(nullable: true),
                    sewage = table.Column<string>(nullable: true),
                    water = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipalPropertiesf", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "realEstates",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    MLS_Id = table.Column<string>(nullable: true),
                    MortId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realEstates", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "insuranceProperties");

            migrationBuilder.DropTable(
                name: "municipalPropertiesf");

            migrationBuilder.DropTable(
                name: "realEstates");
        }
    }
}
