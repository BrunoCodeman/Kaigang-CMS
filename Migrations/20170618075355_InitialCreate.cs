using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kaigang.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Content = table.Column<string>(nullable: false),
                    IsDraft = table.Column<bool>(nullable: false),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
