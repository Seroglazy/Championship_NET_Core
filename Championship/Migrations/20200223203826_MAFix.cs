using Microsoft.EntityFrameworkCore.Migrations;

namespace Championship.Migrations
{
    public partial class MAFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "p1",
                table: "MatchAdd");

            migrationBuilder.RenameColumn(
                name: "p2",
                table: "MatchAdd",
                newName: "lose");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lose",
                table: "MatchAdd",
                newName: "p2");

            migrationBuilder.AddColumn<string>(
                name: "p1",
                table: "MatchAdd",
                nullable: true);
        }
    }
}
