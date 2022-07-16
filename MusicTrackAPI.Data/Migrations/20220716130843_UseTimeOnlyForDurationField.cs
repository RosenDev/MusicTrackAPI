using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicTrackAPI.Data.Migrations
{
    public partial class UseTimeOnlyForDurationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 936, DateTimeKind.Utc).AddTicks(3151),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(4134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 936, DateTimeKind.Utc).AddTicks(1059),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(1828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 935, DateTimeKind.Utc).AddTicks(9419),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 935, DateTimeKind.Utc).AddTicks(7428),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(7886));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(4134),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 936, DateTimeKind.Utc).AddTicks(3151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tracks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 572, DateTimeKind.Utc).AddTicks(1828),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 936, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Playlists",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(9770),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 935, DateTimeKind.Utc).AddTicks(9419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Albums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 10, 20, 30, 5, 571, DateTimeKind.Utc).AddTicks(7886),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 16, 13, 8, 42, 935, DateTimeKind.Utc).AddTicks(7428));
        }
    }
}
