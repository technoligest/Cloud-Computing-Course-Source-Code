using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MBR.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brokerCustomers_brokerCustomers_customerID",
                table: "brokerCustomers");

            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "brokerCustomers",
                newName: "customerid");

            migrationBuilder.RenameIndex(
                name: "IX_brokerCustomers_customerID",
                table: "brokerCustomers",
                newName: "IX_brokerCustomers_customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_brokerCustomers_insuranceCustomers_customerid",
                table: "brokerCustomers",
                column: "customerid",
                principalTable: "insuranceCustomers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brokerCustomers_insuranceCustomers_customerid",
                table: "brokerCustomers");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "brokerCustomers",
                newName: "customerID");

            migrationBuilder.RenameIndex(
                name: "IX_brokerCustomers_customerid",
                table: "brokerCustomers",
                newName: "IX_brokerCustomers_customerID");

            migrationBuilder.AddForeignKey(
                name: "FK_brokerCustomers_brokerCustomers_customerID",
                table: "brokerCustomers",
                column: "customerID",
                principalTable: "brokerCustomers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
