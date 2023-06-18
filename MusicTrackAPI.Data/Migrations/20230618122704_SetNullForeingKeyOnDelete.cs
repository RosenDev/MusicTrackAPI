using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTrackAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetNullForeingKeyOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(5355),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(2835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "TrackPosition",
                table: "TrackPlaylist",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(1102),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Playlists",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 740, DateTimeKind.Utc).AddTicks(9253),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(2090),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(5355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 202, DateTimeKind.Utc).AddTicks(750),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(2835));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrackPosition",
                table: "TrackPlaylist",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(9680),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 741, DateTimeKind.Utc).AddTicks(1102));

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Playlists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 27, 16, 15, 39, 201, DateTimeKind.Utc).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 18, 12, 27, 4, 740, DateTimeKind.Utc).AddTicks(9253));

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Albums_AlbumId",
                table: "Playlists",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Albums_AlbumId",
                table: "Tracks",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");
        }
    }
}
