using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConstituentDocumentDocumentUrlOnListString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentUrl",
                table: "ConstituentDocuments");

            migrationBuilder.AddColumn<List<string>>(
                name: "DocumentsUrl",
                table: "ConstituentDocuments",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentsUrl",
                table: "ConstituentDocuments");

            migrationBuilder.AddColumn<string>(
                name: "DocumentUrl",
                table: "ConstituentDocuments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
