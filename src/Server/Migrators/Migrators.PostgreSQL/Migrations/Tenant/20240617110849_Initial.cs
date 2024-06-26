﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.PostgreSQL.Migrations.Tenant
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "multitenancy");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "multitenancy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DbProvider = table.Column<string>(type: "text", nullable: false),
                    ConnectionString = table.Column<string>(type: "text", nullable: false),
                    AdminEmail = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ValidUpto = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Issuer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Identifier",
                schema: "multitenancy",
                table: "Tenants",
                column: "Identifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "multitenancy");
        }
    }
}
