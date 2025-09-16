using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KiraYonetimi.API.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ApartTypes_ApartTypeId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ApartUsers_ApartUserId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartUsers_Users_UserId",
                table: "ApartUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ApartUsers_ApartUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Apartments_ApartmentApartId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ApartmentApartId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ApartUserId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartUsers",
                table: "ApartUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApartUsers_UserId",
                table: "ApartUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartTypes",
                table: "ApartTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartTypeId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartUserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartUserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ApartmentApartId",
                table: "Invoices");

            migrationBuilder.AlterColumn<string>(
                name: "TcNo",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Payments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InvoicePkId",
                table: "Payments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserPkId",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "Messages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserPkId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "Invoices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApartUserPkId",
                table: "Invoices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentPkId",
                table: "Invoices",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartUserId",
                table: "ApartUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "ApartUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserPkId",
                table: "ApartUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ApartTypeId",
                table: "ApartTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "ApartTypes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ApartId",
                table: "Apartments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "PkId",
                table: "Apartments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApartTypePkId",
                table: "Apartments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApartUserPkId",
                table: "Apartments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartUsers",
                table: "ApartUsers",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartTypes",
                table: "ApartTypes",
                column: "PkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "PkId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoicePkId",
                table: "Payments",
                column: "InvoicePkId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserPkId",
                table: "Payments",
                column: "UserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserPkId",
                table: "Messages",
                column: "UserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartmentPkId",
                table: "Invoices",
                column: "ApartmentPkId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartUserPkId",
                table: "Invoices",
                column: "ApartUserPkId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartUsers_UserPkId",
                table: "ApartUsers",
                column: "UserPkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartTypePkId",
                table: "Apartments",
                column: "ApartTypePkId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartUserPkId",
                table: "Apartments",
                column: "ApartUserPkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ApartTypes_ApartTypePkId",
                table: "Apartments",
                column: "ApartTypePkId",
                principalTable: "ApartTypes",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ApartUsers_ApartUserPkId",
                table: "Apartments",
                column: "ApartUserPkId",
                principalTable: "ApartUsers",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartUsers_Users_UserPkId",
                table: "ApartUsers",
                column: "UserPkId",
                principalTable: "Users",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ApartUsers_ApartUserPkId",
                table: "Invoices",
                column: "ApartUserPkId",
                principalTable: "ApartUsers",
                principalColumn: "PkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Apartments_ApartmentPkId",
                table: "Invoices",
                column: "ApartmentPkId",
                principalTable: "Apartments",
                principalColumn: "PkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserPkId",
                table: "Messages",
                column: "UserPkId",
                principalTable: "Users",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoicePkId",
                table: "Payments",
                column: "InvoicePkId",
                principalTable: "Invoices",
                principalColumn: "PkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserPkId",
                table: "Payments",
                column: "UserPkId",
                principalTable: "Users",
                principalColumn: "PkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ApartTypes_ApartTypePkId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_ApartUsers_ApartUserPkId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartUsers_Users_UserPkId",
                table: "ApartUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ApartUsers_ApartUserPkId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Apartments_ApartmentPkId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserPkId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Invoices_InvoicePkId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserPkId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_InvoicePkId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserPkId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserPkId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ApartmentPkId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ApartUserPkId",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartUsers",
                table: "ApartUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApartUsers_UserPkId",
                table: "ApartUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartTypes",
                table: "ApartTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartTypePkId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_ApartUserPkId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "InvoicePkId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserPkId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserPkId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ApartUserPkId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ApartmentPkId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "ApartUsers");

            migrationBuilder.DropColumn(
                name: "UserPkId",
                table: "ApartUsers");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "ApartTypes");

            migrationBuilder.DropColumn(
                name: "PkId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartTypePkId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartUserPkId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TcNo",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "Payments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "Messages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ApartUserId",
                table: "Invoices",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentApartId",
                table: "Invoices",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartUserId",
                table: "ApartUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ApartTypeId",
                table: "ApartTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ApartId",
                table: "Apartments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartUsers",
                table: "ApartUsers",
                column: "ApartUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartTypes",
                table: "ApartTypes",
                column: "ApartTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "ApartId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartmentApartId",
                table: "Invoices",
                column: "ApartmentApartId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ApartUserId",
                table: "Invoices",
                column: "ApartUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartUsers_UserId",
                table: "ApartUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartTypeId",
                table: "Apartments",
                column: "ApartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartUserId",
                table: "Apartments",
                column: "ApartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ApartTypes_ApartTypeId",
                table: "Apartments",
                column: "ApartTypeId",
                principalTable: "ApartTypes",
                principalColumn: "ApartTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_ApartUsers_ApartUserId",
                table: "Apartments",
                column: "ApartUserId",
                principalTable: "ApartUsers",
                principalColumn: "ApartUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartUsers_Users_UserId",
                table: "ApartUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ApartUsers_ApartUserId",
                table: "Invoices",
                column: "ApartUserId",
                principalTable: "ApartUsers",
                principalColumn: "ApartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Apartments_ApartmentApartId",
                table: "Invoices",
                column: "ApartmentApartId",
                principalTable: "Apartments",
                principalColumn: "ApartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Invoices_InvoiceId",
                table: "Payments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
