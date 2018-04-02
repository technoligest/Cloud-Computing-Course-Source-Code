using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class M14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_municipalPropertiesf",
                table: "municipalPropertiesf");

            migrationBuilder.RenameTable(
                name: "municipalPropertiesf",
                newName: "municipalProperties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_municipalProperties",
                table: "municipalProperties",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_municipalProperties",
                table: "municipalProperties");

            migrationBuilder.RenameTable(
                name: "municipalProperties",
                newName: "municipalPropertiesf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_municipalPropertiesf",
                table: "municipalPropertiesf",
                column: "id");
        }
    }
}
