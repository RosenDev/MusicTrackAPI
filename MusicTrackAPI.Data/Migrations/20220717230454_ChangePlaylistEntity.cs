using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTrackAPI.Data.Migrations
{
    public partial class ChangePlaylistEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumName",
                table: "Playlists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(8380),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(4134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(7170),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(6020),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(4840),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(7886));

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_AlbumId",
                table: "Playlists",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_AlbumId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Playlists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(4134),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(1828),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(9770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.AddColumn<string>(
                name: "AlbumName",
                table: "Playlists",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(7886),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(4840));
        }
    }
}
