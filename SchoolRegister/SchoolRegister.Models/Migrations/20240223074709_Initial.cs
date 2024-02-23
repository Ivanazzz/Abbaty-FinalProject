using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolRegister.Models.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "settlement",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    ekatte = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    namealt = table.Column<string>(type: "text", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settlement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: true),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    uic = table.Column<string>(type: "text", nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    birthplaceid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_person_settlement_birthplaceid",
                        column: x => x.birthplaceid,
                        principalTable: "settlement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "school",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    namealt = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    settlementid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.id);
                    table.ForeignKey(
                        name: "FK_school_settlement_settlementid",
                        column: x => x.settlementid,
                        principalTable: "settlement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personschool",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    personid = table.Column<int>(type: "integer", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personschool", x => x.id);
                    table.ForeignKey(
                        name: "FK_personschool_person_personid",
                        column: x => x.personid,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personschool_school_schoolid",
                        column: x => x.schoolid,
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: false),
                    passwordsalt = table.Column<string>(type: "text", nullable: false),
                    schoolid = table.Column<int>(type: "integer", nullable: false),
                    isactive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_school_schoolid",
                        column: x => x.schoolid,
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personhistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    creatoruserid = table.Column<int>(type: "integer", nullable: false),
                    personid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    actiondate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datamodified = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personhistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_personhistory_person_personid",
                        column: x => x.personid,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personhistory_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_person_birthplaceid",
                table: "person",
                column: "birthplaceid");

            migrationBuilder.CreateIndex(
                name: "IX_person_uic",
                table: "person",
                column: "uic",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personhistory_personid",
                table: "personhistory",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_personhistory_userid",
                table: "personhistory",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_personschool_personid",
                table: "personschool",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_personschool_schoolid",
                table: "personschool",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_school_settlementid",
                table: "school",
                column: "settlementid");

            migrationBuilder.CreateIndex(
                name: "IX_settlement_ekatte",
                table: "settlement",
                column: "ekatte",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_schoolid",
                table: "user",
                column: "schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_user_username",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personhistory");

            migrationBuilder.DropTable(
                name: "personschool");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "school");

            migrationBuilder.DropTable(
                name: "settlement");
        }
    }
}
