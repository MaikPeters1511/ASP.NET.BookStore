using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace asp.mvc.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDateT",
                table: "Categories",
                newName: "CreateDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Categories",
                newName: "CreateDateT");
        }
    }
}
