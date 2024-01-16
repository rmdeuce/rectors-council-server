using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsPhotosUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_CouncilMembers_CouncilMemberId",
                table: "PhoneNumbers");

            migrationBuilder.RenameColumn(
                name: "IconUrl",
                table: "ConstituentDocuments",
                newName: "DocumentUrl");

            migrationBuilder.AlterColumn<int>(
                name: "CouncilMemberId",
                table: "PhoneNumbers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IconUrl",
                table: "News",
                type: "text",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.AddColumn<List<string>>(
                name: "PhotosUrl",
                table: "News",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_CouncilMembers_CouncilMemberId",
                table: "PhoneNumbers",
                column: "CouncilMemberId",
                principalTable: "CouncilMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_CouncilMembers_CouncilMemberId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PhotosUrl",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "DocumentUrl",
                table: "ConstituentDocuments",
                newName: "IconUrl");

            migrationBuilder.AlterColumn<int>(
                name: "CouncilMemberId",
                table: "PhoneNumbers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string[]>(
                name: "IconUrl",
                table: "News",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_CouncilMembers_CouncilMemberId",
                table: "PhoneNumbers",
                column: "CouncilMemberId",
                principalTable: "CouncilMembers",
                principalColumn: "Id");
        }
    }
}
