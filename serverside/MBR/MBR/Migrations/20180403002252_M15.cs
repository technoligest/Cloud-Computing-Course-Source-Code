using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class M15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "insuranceUrls");

            migrationBuilder.CreateTable(
                name: "realEstateCallbackURLs",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    MLS_Id = table.Column<string>(nullable: true),
                    MortId = table.Column<string>(nullable: true),
                    urlString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realEstateCallbackURLs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "realEstateCallbackURLs");

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
    }
}
