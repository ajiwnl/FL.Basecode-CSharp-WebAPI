using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FL.Basecode.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    iconId = table.Column<string>(type: "TEXT", nullable: false),
                    iconName = table.Column<string>(type: "TEXT", nullable: false),
                    iconUrl = table.Column<string>(type: "TEXT", nullable: false),
                    createdAt = table.Column<int>(type: "INTEGER", nullable: false),
                    updatedAt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.iconId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    createdAt = table.Column<int>(type: "INTEGER", nullable: false),
                    lastLogin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    acctId = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    initialBalance = table.Column<string>(type: "TEXT", nullable: false),
                    currentBalance = table.Column<string>(type: "TEXT", nullable: false),
                    iconId = table.Column<string>(type: "TEXT", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdAt = table.Column<int>(type: "INTEGER", nullable: false),
                    updatedAt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.acctId);
                    table.ForeignKey(
                        name: "FK_Accounts_Icons_iconId",
                        column: x => x.iconId,
                        principalTable: "Icons",
                        principalColumn: "iconId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_iconId",
                table: "Accounts",
                column: "iconId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_userId",
                table: "Accounts",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Icons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
