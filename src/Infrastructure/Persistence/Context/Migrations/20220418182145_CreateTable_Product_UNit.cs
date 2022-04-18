using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Context.Migrations
{
    public partial class CreateTable_Product_UNit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseUnitId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                schema: "dbo",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BaseUnitId",
                schema: "dbo",
                table: "Product",
                column: "BaseUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_BaseUnitId",
                schema: "dbo",
                table: "Product",
                column: "BaseUnitId",
                principalSchema: "dbo",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unit_BaseUnitId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Product_BaseUnitId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BaseUnitId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                schema: "dbo",
                table: "Product");
        }
    }
}
