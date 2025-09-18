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
                    ApartTypePkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartTypeId = table.Column<int>(type: "integer", nullable: false),
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
                name: "ApartUsers",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartUserId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ApartId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartUsers", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_ApartUsers_Users_UserPkId",
                        column: x => x.UserPkId,
                        principalTable: "Users",
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
                    ApartTypeId = table.Column<int>(type: "integer", nullable: false),
                    ApartTypePkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartUserPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApartUserId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Apartments_ApartUsers_ApartUserPkId",
                        column: x => x.ApartUserPkId,
                        principalTable: "ApartUsers",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ApartPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceMonth = table.Column<int>(type: "integer", nullable: false),
                    InvoiceYear = table.Column<int>(type: "integer", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    InvoiceStatus = table.Column<bool>(type: "boolean", nullable: false),
                    ApartUserPkId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApartmentPkId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Invoices_ApartUsers_ApartUserPkId",
                        column: x => x.ApartUserPkId,
                        principalTable: "ApartUsers",
                        principalColumn: "PkId");
                    table.ForeignKey(
                        name: "FK_Invoices_Apartments_ApartmentPkId",
                        column: x => x.ApartmentPkId,
                        principalTable: "Apartments",
                        principalColumn: "PkId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PkId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<int>(type: "integer", nullable: false),
                    InvoicePkId = table.Column<int>(type: "integer", nullable: false),
                    InvoicePkId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    UserPkId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoicePkId1",
                        column: x => x.InvoicePkId1,
                        principalTable: "Invoices",
                        principalColumn: "PkId");
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserPkId",
                        column: x => x.UserPkId,
                        principalTable: "Users",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartTypePkId",
                table: "Apartments",
                column: "ApartTypePkId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartUserPkId",
                table: "Apartments",
                column: "ApartUserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartUsers_UserPkId",
                table: "ApartUsers",
                column: "UserPkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartmentPkId",
                table: "Invoices",
                column: "ApartmentPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartUserPkId",
                table: "Invoices",
                column: "ApartUserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserPkId",
                table: "Messages",
                column: "UserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoicePkId1",
                table: "Payments",
                column: "InvoicePkId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserPkId",
                table: "Payments",
                column: "UserPkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "ApartTypes");

            migrationBuilder.DropTable(
                name: "ApartUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
