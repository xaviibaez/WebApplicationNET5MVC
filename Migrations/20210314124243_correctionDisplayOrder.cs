using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationNET.Migrations
{
    public partial class correctionDisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DsiplayOrder",
                table: "Category",
                newName: "DisplayOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Category",
                newName: "DsiplayOrder");
        }
    }
}
