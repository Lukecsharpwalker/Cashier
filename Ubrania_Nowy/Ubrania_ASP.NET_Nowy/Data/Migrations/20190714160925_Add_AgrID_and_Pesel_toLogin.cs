using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ubrania_ASP.NET_Nowy.Data.Migrations
{
    public partial class Add_AgrID_and_Pesel_toLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agreement_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agreement_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "AspNetUsers");
        }
    }
}
