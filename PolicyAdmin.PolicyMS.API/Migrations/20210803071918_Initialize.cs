using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyAdmin.PolicyMS.API.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    ConsumerType = table.Column<int>(type: "int", nullable: false),
                    AssuredSum = table.Column<double>(type: "float", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    BusinessValue = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false),
                    Loacation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    policyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PolicyMasterId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_PolicyMasters_PolicyMasterId",
                        column: x => x.PolicyMasterId,
                        principalTable: "PolicyMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumerPolicies_Transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_PolicyMasterId",
                table: "ConsumerPolicies",
                column: "PolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicies_TransactionID",
                table: "ConsumerPolicies",
                column: "TransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerPolicies");

            migrationBuilder.DropTable(
                name: "PolicyMasters");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
