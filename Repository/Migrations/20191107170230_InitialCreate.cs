using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.CreateIndex(
            //    name: "IX_EmployeesCards_BanksId",
            //    table: "EmployeesCards",
            //    column: "BanksId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesCards_company_id",
                table: "EmployeesCards",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesCards_user_id",
                table: "EmployeesCards",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
