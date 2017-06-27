using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kaigang.Migrations
{
    public partial class CreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorID",
                table: "Posts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
