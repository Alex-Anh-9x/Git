using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pada.Migrations
{
    public partial class PadaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityList",
                columns: table => new
                {
                    ActivityName = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AdminSetup",
                columns: table => new
                {
                    IndexNo = table.Column<int>(nullable: true),
                    ChangePhotoSubmitPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ChangePhotoVoteRequired = table.Column<int>(nullable: true),
                    NewPhotoVoteRequired = table.Column<int>(nullable: true),
                    NewPhotoAwardPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    NewPhotoDeductPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ChangePhotoAwardPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ChangePhotoDeductPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    NewFaceMashSubmitPoint = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    SaturatedFaceScore = table.Column<decimal>(type: "decimal(7, 2)", nullable: true),
                    MinBattleRequiredToRank = table.Column<int>(nullable: true),
                    FMDPFactor = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    BeginnerBattleLevel = table.Column<int>(nullable: true),
                    BeginnerKvalue = table.Column<int>(nullable: true),
                    NormalKvalue = table.Column<int>(nullable: true),
                    SaturatedKvalue = table.Column<int>(nullable: true),
                    CreateActivityPostCost = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    SendInvitationCost = table.Column<decimal>(type: "decimal(6, 2)", nullable: true),
                    IncomePeriod_Minute = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    BaseDP = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    BaseFS = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    BaseIncome = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    ReferralIncome = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ReferralAward = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    WelcomeMessage = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    MaxCurrentBattle = table.Column<int>(nullable: true),
                    MaxCurrentJudge = table.Column<int>(nullable: true),
                    MinCurrentBattle = table.Column<int>(nullable: true),
                    MinCurrentJudge = table.Column<int>(nullable: true),
                    AdminPassword = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedActivity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TargetGender = table.Column<int>(nullable: false),
                    InstantRelationship = table.Column<int>(nullable: false),
                    Activities = table.Column<string>(fixedLength: true, maxLength: 30, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PartnerID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    InvitationID = table.Column<int>(nullable: false),
                    DateTimeCompleted = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedFMTrans",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    PlayerA = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PlayerB = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Chooser = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Winner = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DatePlayed = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScoreWon = table.Column<decimal>(type: "decimal(10, 5)", nullable: false),
                    ScoreLost = table.Column<decimal>(type: "decimal(10, 5)", nullable: false),
                    DPoint = table.Column<decimal>(type: "decimal(10, 5)", nullable: false),
                    Loser = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedInvitation",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    ActivityID = table.Column<int>(nullable: false),
                    FromUserID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTimeCompleted = table.Column<DateTime>(type: "datetime", nullable: false),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedPhotoRequest",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    OldPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    NewPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    AcceptedVote = table.Column<int>(nullable: true),
                    RejectedVote = table.Column<int>(nullable: true),
                    VoteRequired = table.Column<int>(nullable: true),
                    FullPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    FacePhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    AnyPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    Result = table.Column<int>(nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedPhotoTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    PhotoRequestID = table.Column<int>(nullable: false),
                    JudgeID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Approve = table.Column<int>(nullable: false),
                    TimeDone = table.Column<DateTime>(type: "datetime", nullable: true),
                    RewardPoint = table.Column<decimal>(type: "decimal(6, 3)", nullable: true),
                    DeductPoint = table.Column<decimal>(type: "decimal(6, 3)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CompletedReportTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false),
                    ReporterID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReportingID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReportType = table.Column<int>(nullable: true),
                    ReportTransID = table.Column<int>(nullable: true),
                    ReportReason = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    DateReported = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CountryStateCity",
                columns: table => new
                {
                    Country = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    State = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false),
                    City = table.Column<string>(fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingActivity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TargetGender = table.Column<int>(nullable: false),
                    InstantRelationship = table.Column<int>(nullable: false),
                    Activities = table.Column<string>(fixedLength: true, maxLength: 30, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    InvitationCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingBattleRequest",
                columns: table => new
                {
                    BatteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<int>(nullable: false),
                    RequestorID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LowerPoint = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    UpperPoint = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    Processing = table.Column<int>(nullable: true),
                    BattlePlayed = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingFMTrans",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<int>(nullable: false),
                    PlayerA = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PlayerB = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Chooser = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlayerABattleID = table.Column<int>(nullable: true),
                    PlayerBBattleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingInvitation",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityID = table.Column<int>(nullable: false),
                    FromUserID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingPhotoRequest",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    OldPhotoPath = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    NewPhotoPath = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    AcceptedVote = table.Column<int>(nullable: true),
                    RejectedVote = table.Column<int>(nullable: true),
                    VoteRequired = table.Column<int>(nullable: true),
                    FullPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    FacePhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    AnyPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    PendingVote = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Transaction ID", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "PendingPhotoTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoRequestID = table.Column<int>(nullable: false),
                    JudgeID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Approve = table.Column<int>(nullable: true),
                    TimeDone = table.Column<DateTime>(type: "datetime", nullable: true),
                    RewardPoint = table.Column<decimal>(type: "decimal(6, 3)", nullable: true),
                    DeductPoint = table.Column<decimal>(type: "decimal(6, 3)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PendingReportTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporterID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReportingID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReportType = table.Column<int>(nullable: true),
                    ReportTransID = table.Column<int>(nullable: true),
                    ReportReason = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Status = table.Column<int>(nullable: true),
                    DateReported = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalog",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProductDescription = table.Column<string>(unicode: false, maxLength: 300, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(7, 2)", nullable: true),
                    ProductValue = table.Column<decimal>(type: "decimal(8, 2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReferalIncome",
                columns: table => new
                {
                    SeniorEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    JuniorEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ReferalType = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ReferalValue = table.Column<int>(nullable: false),
                    PackageName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReportList",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    ReportingUserID = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false),
                    DateTimeReported = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reason = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SalesTransaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Userid = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    ProductType = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(7, 2)", nullable: true),
                    ProductValue = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    ReceiptNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Country = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    State = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    City = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorldRank = table.Column<int>(nullable: true),
                    CityRank = table.Column<int>(nullable: true),
                    RatingScore = table.Column<decimal>(type: "decimal(11, 4)", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "date", nullable: true),
                    Height_cm = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    Weight_kg = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    AccountStatus = table.Column<int>(nullable: true),
                    NoReported = table.Column<int>(nullable: true),
                    ContactNo = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    ActivationCode = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DatePoint = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    FaceScore = table.Column<decimal>(type: "decimal(10, 5)", nullable: true),
                    RankStatus = table.Column<int>(nullable: true),
                    TotalGamePlayed = table.Column<int>(nullable: true),
                    PhotosApproved = table.Column<int>(nullable: true),
                    ReferalCode = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ActiveReferal = table.Column<int>(nullable: true),
                    DailyPointGain = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    LastDateTimeCollected = table.Column<DateTime>(type: "datetime", nullable: true),
                    Income = table.Column<decimal>(type: "decimal(8, 4)", nullable: true),
                    FacePhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    FullPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    AnyPhotoPath = table.Column<string>(unicode: false, maxLength: 120, nullable: true),
                    LastDateTimeReported = table.Column<DateTime>(type: "datetime", nullable: true),
                    Advertisement = table.Column<int>(nullable: true),
                    CurrentBattle = table.Column<int>(nullable: true),
                    CurrentJudge = table.Column<int>(nullable: true),
                    UserLevel = table.Column<int>(nullable: true),
                    ReadUploadPhoto = table.Column<int>(nullable: true),
                    ReadPhotoCheck = table.Column<int>(nullable: true),
                    ReadPageantReg = table.Column<int>(nullable: true),
                    ReadPageantJudge = table.Column<int>(nullable: true),
                    ReadNewDating = table.Column<int>(nullable: true),
                    ReadFindDate = table.Column<int>(nullable: true),
                    AccessToken = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsFaceBookUser = table.Column<int>(nullable: true),
                    PageantRegistered = table.Column<int>(nullable: true),
                    FBEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PreviousAccountStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Email", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityList");

            migrationBuilder.DropTable(
                name: "AdminSetup");

            migrationBuilder.DropTable(
                name: "CompletedActivity");

            migrationBuilder.DropTable(
                name: "CompletedFMTrans");

            migrationBuilder.DropTable(
                name: "CompletedInvitation");

            migrationBuilder.DropTable(
                name: "CompletedPhotoRequest");

            migrationBuilder.DropTable(
                name: "CompletedPhotoTransaction");

            migrationBuilder.DropTable(
                name: "CompletedReportTransaction");

            migrationBuilder.DropTable(
                name: "CountryStateCity");

            migrationBuilder.DropTable(
                name: "PendingActivity");

            migrationBuilder.DropTable(
                name: "PendingBattleRequest");

            migrationBuilder.DropTable(
                name: "PendingFMTrans");

            migrationBuilder.DropTable(
                name: "PendingInvitation");

            migrationBuilder.DropTable(
                name: "PendingPhotoRequest");

            migrationBuilder.DropTable(
                name: "PendingPhotoTransaction");

            migrationBuilder.DropTable(
                name: "PendingReportTransaction");

            migrationBuilder.DropTable(
                name: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "ReferalIncome");

            migrationBuilder.DropTable(
                name: "ReportList");

            migrationBuilder.DropTable(
                name: "SalesTransaction");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
