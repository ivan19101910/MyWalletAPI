using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWalletAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalNumber = table.Column<double>(type: "double precision", nullable: false),
                    ChangeAmount = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsStatistics_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizedAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    IconId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AuthorizedAccountId",
                        column: x => x.AuthorizedAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Icons_IconId",
                        column: x => x.IconId,
                        principalTable: "Icons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4544bea6-670c-4006-8801-8a056647f049"), "Dmytro" },
                    { new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), "Ivan" },
                    { new Guid("bdc62598-9d2c-4237-9120-14dfd5ef8ad3"), "Roman" }
                });

            migrationBuilder.InsertData(
                table: "Icons",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://ibb.co/Y06rfps" },
                    { 2, "https://ibb.co/dB3ty5W" }
                });

            migrationBuilder.InsertData(
                table: "PointsStatistics",
                columns: new[] { "Id", "AccountId", "ChangeAmount", "CreatedDateTime", "TotalNumber" },
                values: new object[,]
                {
                    { 1, new Guid("bdc62598-9d2c-4237-9120-14dfd5ef8ad3"), 0.0, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0 },
                    { 2, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 10.0, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 3, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 5.0, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 4, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 5, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 6, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 7, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 8, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 9, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 10, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 11, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 0.0, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.0 },
                    { 12, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 5.0, new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 505.0 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "AuthorizedAccountId", "Date", "Description", "IconId", "IsPending", "Name", "TransactionType" },
                values: new object[,]
                {
                    { 1, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, true, "Amazon", 0 },
                    { 2, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 2, false, "Amazon", 0 },
                    { 3, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 4, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 5, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, new Guid("bdc62598-9d2c-4237-9120-14dfd5ef8ad3"), new DateTime(2023, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 6, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 7, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 8, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, new Guid("bdc62598-9d2c-4237-9120-14dfd5ef8ad3"), new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 9, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 0 },
                    { 10, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 11, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 1 },
                    { 12, new Guid("b6dd6eaf-bcc6-4007-8c9d-d47f21f6a6ac"), 500, null, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Time earth spent misery had the seemed for yet it", 1, false, "Amazon", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointsStatistics_AccountId",
                table: "PointsStatistics",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AuthorizedAccountId",
                table: "Transactions",
                column: "AuthorizedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IconId",
                table: "Transactions",
                column: "IconId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsStatistics");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Icons");
        }
    }
}
