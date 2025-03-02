// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Store.DB;

#nullable disable

namespace Store.DB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:order_type", "card,sell");

            migrationBuilder.CreateTable(
                name: "table_customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "table_products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_products", x => x.id);
                    table.CheckConstraint("CK_table_products_quantity", "quantity >= 0");
                });

            migrationBuilder.CreateTable(
                name: "table_orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<OrderType>(type: "order_type", nullable: false),
                    products = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_table_orders_table_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "table_customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_table_customers_first_name",
                table: "table_customers",
                column: "first_name");

            migrationBuilder.CreateIndex(
                name: "IX_table_customers_last_name",
                table: "table_customers",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "IX_table_customers_login",
                table: "table_customers",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_table_orders_customer_id",
                table: "table_orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_table_products_name",
                table: "table_products",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_orders");

            migrationBuilder.DropTable(
                name: "table_products");

            migrationBuilder.DropTable(
                name: "table_customers");
        }
    }
}
