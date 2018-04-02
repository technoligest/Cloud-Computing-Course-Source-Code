using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employerVerified",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "insuranceVerified",
                table: "brokerCustomers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "employerVerified",
                table: "brokerCustomers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "insuranceVerified",
                table: "brokerCustomers",
                nullable: false,
                defaultValue: false);
        }
    }
}
