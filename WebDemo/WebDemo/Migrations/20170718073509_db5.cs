using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDemo.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDLoai",
                table: "eDM_TinhThanh",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Loai",
                table: "eDM_TinhThanh",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDLoai",
                table: "eDM_TinhThanh");

            migrationBuilder.DropColumn(
                name: "Loai",
                table: "eDM_TinhThanh");
        }
    }
}
