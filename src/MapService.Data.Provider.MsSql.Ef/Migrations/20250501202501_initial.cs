using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHelper.MapService.Data.Provider.MsSql.Ef.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Z2",
                table: "PointTypeRectangularParallelepipeds",
                newName: "ZMin");

            migrationBuilder.RenameColumn(
                name: "Z1",
                table: "PointTypeRectangularParallelepipeds",
                newName: "ZMax");

            migrationBuilder.RenameColumn(
                name: "Y2",
                table: "PointTypeRectangularParallelepipeds",
                newName: "YMin");

            migrationBuilder.RenameColumn(
                name: "Y1",
                table: "PointTypeRectangularParallelepipeds",
                newName: "YMax");

            migrationBuilder.RenameColumn(
                name: "X2",
                table: "PointTypeRectangularParallelepipeds",
                newName: "XMin");

            migrationBuilder.RenameColumn(
                name: "X1",
                table: "PointTypeRectangularParallelepipeds",
                newName: "XMax");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "PointTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PointTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PointTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PointTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "PointTypeRectangularParallelepipeds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PointTypeRectangularParallelepipeds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PointTypeRectangularParallelepipeds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "PointTypeAssociations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PointTypeAssociations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PointTypeAssociations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LabelPoints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "PointTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PointTypes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PointTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PointTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "PointTypeRectangularParallelepipeds");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PointTypeRectangularParallelepipeds");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PointTypeRectangularParallelepipeds");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "PointTypeAssociations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PointTypeAssociations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PointTypeAssociations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LabelPoints");

            migrationBuilder.RenameColumn(
                name: "ZMin",
                table: "PointTypeRectangularParallelepipeds",
                newName: "Z2");

            migrationBuilder.RenameColumn(
                name: "ZMax",
                table: "PointTypeRectangularParallelepipeds",
                newName: "Z1");

            migrationBuilder.RenameColumn(
                name: "YMin",
                table: "PointTypeRectangularParallelepipeds",
                newName: "Y2");

            migrationBuilder.RenameColumn(
                name: "YMax",
                table: "PointTypeRectangularParallelepipeds",
                newName: "Y1");

            migrationBuilder.RenameColumn(
                name: "XMin",
                table: "PointTypeRectangularParallelepipeds",
                newName: "X2");

            migrationBuilder.RenameColumn(
                name: "XMax",
                table: "PointTypeRectangularParallelepipeds",
                newName: "X1");
        }
    }
}
