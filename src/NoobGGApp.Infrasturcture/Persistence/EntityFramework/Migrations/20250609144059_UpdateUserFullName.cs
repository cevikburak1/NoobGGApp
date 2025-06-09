using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banner_url",
                table: "application_users");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "application_users");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "application_users");

            migrationBuilder.DropColumn(
                name: "last_online",
                table: "application_users");

            migrationBuilder.DropColumn(
                name: "profile_picture_url",
                table: "application_users");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "application_users",
                newName: "full_name");

            migrationBuilder.AddColumn<bool>(
                name: "is_microphone_required",
                table: "lobby",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "max_game_rank_id",
                table: "lobby",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "max_team_size",
                table: "lobby",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "min_game_rank_id",
                table: "lobby",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "min_team_size",
                table: "lobby",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "note",
                table: "lobby",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "owner_id",
                table: "lobby",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "lobby",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "games",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_on",
                table: "games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 6, 9, 14, 40, 58, 612, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 5, 11, 13, 19, 22, 494, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_on",
                table: "game_regions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 6, 9, 14, 40, 58, 612, DateTimeKind.Unspecified).AddTicks(2972), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 5, 11, 13, 19, 22, 494, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "game_mode",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    min_team_size = table.Column<int>(type: "integer", nullable: false),
                    max_team_size = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_mode", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_mode_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_rank",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: false),
                    game_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_rank", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_rank_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lobby_event_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    event_type = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_event_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_event_history_application_users_user_id",
                        column: x => x.user_id,
                        principalTable: "application_users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_lobby_event_history_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_message",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    sender_id = table.Column<long>(type: "bigint", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_message", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_message_application_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "application_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_message_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lobby_language",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lobby_id = table.Column<long>(type: "bigint", nullable: false),
                    language_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by_user_id = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_by_user_id = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lobby_language", x => x.id);
                    table.ForeignKey(
                        name: "fk_lobby_language_language_language_id",
                        column: x => x.language_id,
                        principalTable: "language",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lobby_language_lobby_lobby_id",
                        column: x => x.lobby_id,
                        principalTable: "lobby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_lobby_creator_id",
                table: "lobby",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_id",
                table: "lobby",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_mode_id",
                table: "lobby",
                column: "game_mode_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_game_region_id",
                table: "lobby",
                column: "game_region_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_max_game_rank_id",
                table: "lobby",
                column: "max_game_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_min_game_rank_id",
                table: "lobby",
                column: "min_game_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_owner_id",
                table: "lobby",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_mode_game_id",
                table: "game_mode",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_rank_game_id",
                table: "game_rank",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_event_history_lobby_id",
                table: "lobby_event_history",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_event_history_user_id",
                table: "lobby_event_history",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_language_language_id",
                table: "lobby_language",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_language_lobby_id",
                table: "lobby_language",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_message_lobby_id",
                table: "lobby_message",
                column: "lobby_id");

            migrationBuilder.CreateIndex(
                name: "ix_lobby_message_sender_id",
                table: "lobby_message",
                column: "sender_id");

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_application_users_creator_id",
                table: "lobby",
                column: "creator_id",
                principalTable: "application_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_application_users_owner_id",
                table: "lobby",
                column: "owner_id",
                principalTable: "application_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_game_mode_game_mode_id",
                table: "lobby",
                column: "game_mode_id",
                principalTable: "game_mode",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_game_rank_max_game_rank_id",
                table: "lobby",
                column: "max_game_rank_id",
                principalTable: "game_rank",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_game_rank_min_game_rank_id",
                table: "lobby",
                column: "min_game_rank_id",
                principalTable: "game_rank",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_game_regions_game_region_id",
                table: "lobby",
                column: "game_region_id",
                principalTable: "game_regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_lobby_games_game_id",
                table: "lobby",
                column: "game_id",
                principalTable: "games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_lobby_application_users_creator_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_application_users_owner_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_game_mode_game_mode_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_game_rank_max_game_rank_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_game_rank_min_game_rank_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_game_regions_game_region_id",
                table: "lobby");

            migrationBuilder.DropForeignKey(
                name: "fk_lobby_games_game_id",
                table: "lobby");

            migrationBuilder.DropTable(
                name: "game_mode");

            migrationBuilder.DropTable(
                name: "game_rank");

            migrationBuilder.DropTable(
                name: "lobby_event_history");

            migrationBuilder.DropTable(
                name: "lobby_language");

            migrationBuilder.DropTable(
                name: "lobby_message");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropIndex(
                name: "ix_lobby_creator_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_game_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_game_mode_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_game_region_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_max_game_rank_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_min_game_rank_id",
                table: "lobby");

            migrationBuilder.DropIndex(
                name: "ix_lobby_owner_id",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "is_microphone_required",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "max_game_rank_id",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "max_team_size",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "min_game_rank_id",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "min_team_size",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "note",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "lobby");

            migrationBuilder.DropColumn(
                name: "type",
                table: "lobby");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "application_users",
                newName: "last_name");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "games",
                type: "character varying(5000)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(5000)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_on",
                table: "games",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 5, 11, 13, 19, 22, 494, DateTimeKind.Unspecified).AddTicks(926), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 6, 9, 14, 40, 58, 612, DateTimeKind.Unspecified).AddTicks(883), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_on",
                table: "game_regions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2025, 5, 11, 13, 19, 22, 494, DateTimeKind.Unspecified).AddTicks(2787), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2025, 6, 9, 14, 40, 58, 612, DateTimeKind.Unspecified).AddTicks(2972), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "banner_url",
                table: "application_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "application_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "application_users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "last_online",
                table: "application_users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "profile_picture_url",
                table: "application_users",
                type: "text",
                nullable: true);
        }
    }
}
