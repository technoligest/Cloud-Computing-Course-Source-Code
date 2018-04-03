using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class M16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "employer",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "insuranceCompany",
                table: "brokerCustomers");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "brokerCustomers",
                newName: "MLS_Id");

            migrationBuilder.AddColumn<int>(
                name: "value",
                table: "brokerCustomers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "brokerCustomers");

            migrationBuilder.RenameColumn(
                name: "MLS_Id",
                table: "brokerCustomers",
                newName: "phone");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "brokerCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employer",
                table: "brokerCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "insuranceCompany",
                table: "brokerCustomers",
                nullable: true);
        }
    }
}
