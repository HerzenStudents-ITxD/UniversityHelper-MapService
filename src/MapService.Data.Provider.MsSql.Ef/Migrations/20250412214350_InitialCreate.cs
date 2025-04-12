using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityHelper.MapService.Data.Provider.MsSql.Ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Z = table.Column<float>(type: "real", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabelPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelPoints_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelPoints_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    PointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointAssociations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Association = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointAssociations_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DbPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_Points_DbPointId",
                        column: x => x.DbPointId,
                        principalTable: "Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relations_Points_FirstPointId",
                        column: x => x.FirstPointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Points_SecondPointId",
                        column: x => x.SecondPointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointTypeAssociations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Association = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypeAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTypeAssociations_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointTypePoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTypePoints_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointTypePoints_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointTypeRectangularParallelepipeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PointTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    X1 = table.Column<float>(type: "real", nullable: false),
                    Y1 = table.Column<float>(type: "real", nullable: false),
                    Z1 = table.Column<float>(type: "real", nullable: false),
                    X2 = table.Column<float>(type: "real", nullable: false),
                    Y2 = table.Column<float>(type: "real", nullable: false),
                    Z2 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointTypeRectangularParallelepipeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointTypeRectangularParallelepipeds_PointTypes_PointTypeId",
                        column: x => x.PointTypeId,
                        principalTable: "PointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelPoints_LabelId",
                table: "LabelPoints",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelPoints_PointId",
                table: "LabelPoints",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PointId",
                table: "Photos",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAssociations_PointId",
                table: "PointAssociations",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypeAssociations_PointTypeId",
                table: "PointTypeAssociations",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypePoints_PointId",
                table: "PointTypePoints",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypePoints_PointTypeId",
                table: "PointTypePoints",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PointTypeRectangularParallelepipeds_PointTypeId",
                table: "PointTypeRectangularParallelepipeds",
                column: "PointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_DbPointId",
                table: "Relations",
                column: "DbPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_FirstPointId",
                table: "Relations",
                column: "FirstPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relations_SecondPointId",
                table: "Relations",
                column: "SecondPointId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelPoints");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PointAssociations");

            migrationBuilder.DropTable(
                name: "PointTypeAssociations");

            migrationBuilder.DropTable(
                name: "PointTypePoints");

            migrationBuilder.DropTable(
                name: "PointTypeRectangularParallelepipeds");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "PointTypes");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
