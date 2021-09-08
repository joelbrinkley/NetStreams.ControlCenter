using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetStreams.ControlCenter.TelemetryProcessor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumedMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreamProcessorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    StartedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CompletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProcessingDurationSeconds = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreamProcessors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Running = table.Column<bool>(type: "bit", nullable: false),
                    LastStarted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastHeartBeat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamProcessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StreamPartitions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Partition = table.Column<int>(type: "int", nullable: false),
                    StreamProcessorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Lag = table.Column<long>(type: "bigint", nullable: false),
                    Offset = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreamPartitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StreamPartitions_StreamProcessors_StreamProcessorId",
                        column: x => x.StreamProcessorId,
                        principalTable: "StreamProcessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StreamPartitions_StreamProcessorId",
                table: "StreamPartitions",
                column: "StreamProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_StreamProcessors_Name",
                table: "StreamProcessors",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumedMessages");

            migrationBuilder.DropTable(
                name: "StreamPartitions");

            migrationBuilder.DropTable(
                name: "StreamProcessors");
        }
    }
}
