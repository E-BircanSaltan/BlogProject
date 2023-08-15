using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserFollowedCategory",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Like",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Article",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "About",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserFollowedCategory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Like",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Article",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "About",
                newName: "Id");
        }
    }
}
