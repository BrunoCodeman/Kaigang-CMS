using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kaigang.Migrations
{
    public partial class UpdatePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Posts",
                newName: "PublishDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Posts",
                newName: "PublicationDate");
        }
    }
}
