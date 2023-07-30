using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiIntro.Data.Migrations
{
    public partial class updateproducttableimageurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 13, 51, 37, 635, DateTimeKind.Utc).AddTicks(4098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 9, 49, 46, 313, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 13, 51, 37, 635, DateTimeKind.Utc).AddTicks(3817),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 9, 49, 46, 313, DateTimeKind.Utc).AddTicks(2363));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 9, 49, 46, 313, DateTimeKind.Utc).AddTicks(3845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 13, 51, 37, 635, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 30, 9, 49, 46, 313, DateTimeKind.Utc).AddTicks(2363),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 30, 13, 51, 37, 635, DateTimeKind.Utc).AddTicks(3817));
        }
    }
}
