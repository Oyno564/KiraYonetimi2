using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiraYonetimi.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartTypes",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartTypes", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "APIUsers",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    APIUserPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<bool>(type: "boolean", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIUsers", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    TcNo = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    PlakaNo = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartId = table.Column<int>(type: "integer", nullable: false),
                    ApartBlock = table.Column<int>(type: "integer", nullable: false),
                    ApartStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ApartFloor = table.Column<int>(type: "integer", nullable: false),
                    ApartNo = table.Column<int>(type: "integer", nullable: false),
                    ApartOwnerOrTenant = table.Column<bool>(type: "boolean", nullable: false),
                    ApartTypePkId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Apartments_ApartTypes_ApartTypePkId",
                        column: x => x.ApartTypePkId,
                        principalTable: "ApartTypes",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<int>(type: "integer", nullable: false),
                    FromUserId = table.Column<int>(type: "integer", nullable: false),
                    ToUserId = table.Column<int>(type: "integer", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: true),
                    MessageDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserPkId",
                        column: x => x.UserPkId,
                        principalTable: "Users",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ApartmentPkId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApartUserPkId = table.Column<Guid>(type: "uuid", nullable: true),
                    InvoiceMonth = table.Column<int>(type: "integer", nullable: false),
                    InvoiceYear = table.Column<int>(type: "integer", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    InvoiceStatus = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Invoices_Apartments_ApartmentPkId",
                        column: x => x.ApartmentPkId,
                        principalTable: "Apartments",
                        principalColumn: "PkId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartTypePkId",
                table: "Apartments",
                column: "ApartTypePkId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartmentPkId",
                table: "Invoices",
                column: "ApartmentPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserPkId",
                table: "Messages",
                column: "UserPkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIUsers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ApartTypes");
        }
    }
}
