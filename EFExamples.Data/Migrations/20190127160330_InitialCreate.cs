using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFExamples.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime2(2)", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2(2)", nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime2(2)", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2(2)", nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime2(2)", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2(2)", nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime2(2)", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2(2)", nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    StreetAddress = table.Column<string>(maxLength: 600, nullable: true, defaultValue: ""),
                    City = table.Column<string>(maxLength: 150, nullable: true, defaultValue: ""),
                    State = table.Column<string>(maxLength: 60, nullable: true, defaultValue: ""),
                    ZipCode = table.Column<string>(maxLength: 12, nullable: true, defaultValue: ""),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    LastName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractor_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime2(2)", nullable: false, defaultValueSql: "sysdatetime()"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2(2)", nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    StreetAddress = table.Column<string>(maxLength: 600, nullable: true, defaultValue: ""),
                    City = table.Column<string>(maxLength: 150, nullable: true, defaultValue: ""),
                    State = table.Column<string>(maxLength: 60, nullable: true, defaultValue: ""),
                    ZipCode = table.Column<string>(maxLength: 12, nullable: true, defaultValue: ""),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: ""),
                    LastName = table.Column<string>(maxLength: 300, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentContractor",
                columns: table => new
                {
                    ContractorId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentContractor", x => new { x.ContractorId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DepartmentContractor_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentContractor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_VendorId",
                table: "Contractor",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_CompanyId",
                table: "Department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentContractor_DepartmentId",
                table: "DepartmentContractor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeId",
                table: "Employee",
                column: "EmployeeId")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentContractor");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
