using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTrackAPI.Data.Migrations
{
    public partial class CHangeDbEntitiesStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "TrackName",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "TrackPosition",
                table: "Playlists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(4260),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(3090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(730),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.CreateTable(
                name: "TracksPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    TrackPosition = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracksPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TracksPlaylists_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TracksPlaylists_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "IX_TracksPlaylists_PlaylistId",
                table: "TracksPlaylists",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_TracksPlaylists_TrackId",
                table: "TracksPlaylists",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "TracksPlaylists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(8380),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(7170),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 17, 23, 4, 54, 731, DateTimeKind.Utc).AddTicks(6020),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.AddColumn<string>(
                name: "TrackName",
                table: "Playlists",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<int>(
                name: "TrackPosition",
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
                oldDefaultValue: new DateTime(2022, 7, 23, 21, 27, 0, 111, DateTimeKind.Utc).AddTicks(730));

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");
        }
    }
}
