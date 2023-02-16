using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ehbb.Data.DataAccess.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class defaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleAssocs_Roles_RoleID",
                table: "UserRoleAssocs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleAssocs_Users_UserID",
                table: "UserRoleAssocs");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAssocs_RoleID",
                table: "UserRoleAssocs");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAssocs_UserID",
                table: "UserRoleAssocs");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "UserRoleAssocs",
                columns: new[] { "UserRoleID", "RoleID", "UserID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 1, "admin@admin", "admin", "Admin_999", "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoleAssocs",
                keyColumn: "UserRoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAssocs_RoleID",
                table: "UserRoleAssocs",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAssocs_UserID",
                table: "UserRoleAssocs",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleAssocs_Roles_RoleID",
                table: "UserRoleAssocs",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleAssocs_Users_UserID",
                table: "UserRoleAssocs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
