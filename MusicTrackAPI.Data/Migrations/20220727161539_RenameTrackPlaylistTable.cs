using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTrackAPI.Data.Migrations
{
    public partial class RenameTrackPlaylistTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TracksPlaylists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 24, 16, 51, 42, 0, DateTimeKind.Utc).AddTicks(1763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 24, 16, 51, 42, 0, DateTimeKind.Utc).AddTicks(358));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(9680),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 24, 16, 51, 41, 999, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 24, 16, 51, 41, 999, DateTimeKind.Utc).AddTicks(7343));

            migrationBuilder.CreateTable(
                name: "TrackPlaylist",
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
                    table.PrimaryKey("PK_TrackPlaylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackPlaylist_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackPlaylist_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylist_PlaylistId",
                table: "TrackPlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackPlaylist_TrackId",
                table: "TrackPlaylist",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackPlaylist");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 24, 16, 51, 42, 0, DateTimeKind.Utc).AddTicks(1763),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 24, 16, 51, 42, 0, DateTimeKind.Utc).AddTicks(358),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 24, 16, 51, 41, 999, DateTimeKind.Utc).AddTicks(9106),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 24, 16, 51, 41, 999, DateTimeKind.Utc).AddTicks(7343),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.CreateTable(
                name: "TracksPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TrackPosition = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
        }
    }
}
