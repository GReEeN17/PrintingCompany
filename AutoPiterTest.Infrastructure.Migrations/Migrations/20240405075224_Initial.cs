using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPiterTest.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MacAddresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mac_address_name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacAddresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PrintingDevices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    connection_type = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingDevices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    branch_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchPrintingDevices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    branch_printing_device_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    serial_number = table.Column<int>(type: "int", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "bit", nullable: false),
                    branch_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    printing_device_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchPrintingDevices", x => x.id);
                    table.ForeignKey(
                        name: "FK_BranchPrintingDevices_Branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchPrintingDevices_PrintingDevices_printing_device_id",
                        column: x => x.printing_device_id,
                        principalTable: "PrintingDevices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintingDevicesMacAddresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    printing_device_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    mac_address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingDevicesMacAddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_PrintingDevicesMacAddresses_MacAddresses_mac_address_id",
                        column: x => x.mac_address_id,
                        principalTable: "MacAddresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrintingDevicesMacAddresses_PrintingDevices_printing_device_id",
                        column: x => x.printing_device_id,
                        principalTable: "PrintingDevices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintingTasks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    serial_number = table.Column<int>(type: "int", nullable: false),
                    number_of_pages = table.Column<int>(type: "int", nullable: false),
                    is_successful = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingTasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_PrintingTasks_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchPrintingDevices_branch_id",
                table: "BranchPrintingDevices",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchPrintingDevices_printing_device_id",
                table: "BranchPrintingDevices",
                column: "printing_device_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_branch_id",
                table: "Employees",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintingDevicesMacAddresses_mac_address_id",
                table: "PrintingDevicesMacAddresses",
                column: "mac_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintingDevicesMacAddresses_printing_device_id",
                table: "PrintingDevicesMacAddresses",
                column: "printing_device_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintingTasks_employee_id",
                table: "PrintingTasks",
                column: "employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchPrintingDevices");

            migrationBuilder.DropTable(
                name: "PrintingDevicesMacAddresses");

            migrationBuilder.DropTable(
                name: "PrintingTasks");

            migrationBuilder.DropTable(
                name: "MacAddresses");

            migrationBuilder.DropTable(
                name: "PrintingDevices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
