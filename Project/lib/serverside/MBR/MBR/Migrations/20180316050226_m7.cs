using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brokerCustomers_insuranceCustomers_customerid",
                table: "brokerCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_brokerCustomers_employerEmployees_employeeid",
                table: "brokerCustomers");

            migrationBuilder.DropIndex(
                name: "IX_brokerCustomers_customerid",
                table: "brokerCustomers");

            migrationBuilder.DropIndex(
                name: "IX_brokerCustomers_employeeid",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "customerid",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "employeeid",
                table: "brokerCustomers");

            migrationBuilder.AddColumn<bool>(
                name: "employerApproved",
                table: "brokerCustomers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "insuranceApproved",
                table: "brokerCustomers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employerApproved",
                table: "brokerCustomers");

            migrationBuilder.DropColumn(
                name: "insuranceApproved",
                table: "brokerCustomers");

            migrationBuilder.AddColumn<string>(
                name: "customerid",
                table: "brokerCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeid",
                table: "brokerCustomers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_brokerCustomers_customerid",
                table: "brokerCustomers",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_brokerCustomers_employeeid",
                table: "brokerCustomers",
                column: "employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_brokerCustomers_insuranceCustomers_customerid",
                table: "brokerCustomers",
                column: "customerid",
                principalTable: "insuranceCustomers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_brokerCustomers_employerEmployees_employeeid",
                table: "brokerCustomers",
                column: "employeeid",
                principalTable: "employerEmployees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
