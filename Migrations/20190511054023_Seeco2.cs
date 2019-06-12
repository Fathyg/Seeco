using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Seeco.Migrations
{
    public partial class Seeco2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblClients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Phones = table.Column<string>(maxLength: 50, nullable: true),
                    Faxes = table.Column<string>(maxLength: 50, nullable: true),
                    Ceo = table.Column<string>(maxLength: 50, nullable: true),
                    Parent = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblConsultants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Phones = table.Column<string>(maxLength: 50, nullable: true),
                    Faxes = table.Column<string>(maxLength: 50, nullable: true),
                    Ceo = table.Column<string>(maxLength: 50, nullable: true),
                    Cofounder = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblConsultants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblContractors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Phones = table.Column<string>(maxLength: 50, nullable: true),
                    Faxes = table.Column<string>(maxLength: 50, nullable: true),
                    Ceo = table.Column<string>(maxLength: 50, nullable: true),
                    Parent = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContractors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblContracts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ContractorID = table.Column<int>(nullable: true),
                    ConsultantDesignID = table.Column<int>(nullable: true),
                    ConsultantSupervisionID = table.Column<int>(nullable: true),
                    ConsultantContractorID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    BaseValue = table.Column<decimal>(type: "money", nullable: true),
                    Period = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContracts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblClients",
                        column: x => x.ClientID,
                        principalTable: "tblClients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblConsultantsContractor",
                        column: x => x.ConsultantContractorID,
                        principalTable: "tblConsultants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblConsultantsDesign",
                        column: x => x.ConsultantDesignID,
                        principalTable: "tblConsultants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblConsultantsSupervision",
                        column: x => x.ConsultantSupervisionID,
                        principalTable: "tblConsultants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblContracts_tblContractors",
                        column: x => x.ContractorID,
                        principalTable: "tblContractors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProjects",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    ContractID = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "date", nullable: true),
                    Period = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblProjects_tblContracts",
                        column: x => x.ContractID,
                        principalTable: "tblContracts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblClientsTeams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientID = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    ResponsibleName = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    IdNo = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Sector = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClientsTeams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblClientsTeams_tblClients",
                        column: x => x.ClientID,
                        principalTable: "tblClients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblClientsTeams_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblConsultantsTeams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultantID = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    ResponsibleName = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    IdNo = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Sector = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblConsultantsTeams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblConsultantsTeams_tblConsultants",
                        column: x => x.ConsultantID,
                        principalTable: "tblConsultants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblConsultantsTeams_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblContractorsTeams",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorID = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    ResponsibleName = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    IdNo = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Sector = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContractorsTeams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblContractorsTeams_tblContractors",
                        column: x => x.ContractorID,
                        principalTable: "tblContractors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblContractorsTeams_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblInvoicesContractor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: true),
                    InvoiceNo = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    StoresValue = table.Column<decimal>(type: "money", nullable: true),
                    WorksUpToDate = table.Column<decimal>(type: "money", nullable: true),
                    Total = table.Column<decimal>(type: "money", nullable: true),
                    DiscountContractor = table.Column<decimal>(type: "money", nullable: true),
                    TotalAfterDiscountContractor = table.Column<decimal>(type: "money", nullable: true),
                    PreviousInvoices = table.Column<decimal>(type: "money", nullable: true),
                    InvoiceValue = table.Column<decimal>(type: "money", nullable: true),
                    PrePayed = table.Column<decimal>(type: "money", nullable: true),
                    Liability = table.Column<decimal>(type: "money", nullable: true),
                    Net = table.Column<decimal>(type: "money", nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInvoicesContractor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblInvoicesContractor_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    ItemNo = table.Column<string>(maxLength: 50, nullable: false),
                    ItemType = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblItems_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLetters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true),
                    IssuedBy = table.Column<string>(maxLength: 50, nullable: true),
                    DirectedTo = table.Column<string>(maxLength: 50, nullable: true),
                    Subject = table.Column<string>(maxLength: 300, nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Descriptiopn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLetters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblLetters_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSchedules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    ScheduleNo = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectID = table.Column<int>(nullable: true),
                    SchStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    SchEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Period = table.Column<int>(nullable: true),
                    Decision = table.Column<string>(nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "date", nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSchedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblSchedules_tblProjects",
                        column: x => x.ProjectID,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblUsers_tblProjects",
                        column: x => x.ProjectId,
                        principalTable: "tblProjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoqViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: true),
                    Uprice = table.Column<decimal>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemNo = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoqViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoqViewModel_tblItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "tblItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: true),
                    ItemsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemViewModel_tblItems_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "tblItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblBoq",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(maxLength: 20, nullable: false),
                    Qty = table.Column<int>(nullable: true),
                    UPrice = table.Column<decimal>(type: "money", nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoq", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblBoq_tblItems",
                        column: x => x.ItemID,
                        principalTable: "tblItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDrawings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: true),
                    DrawingName = table.Column<string>(maxLength: 50, nullable: true),
                    DrawingType = table.Column<string>(maxLength: 50, nullable: true),
                    DateIssued = table.Column<DateTime>(type: "date", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true),
                    DrawBy = table.Column<string>(maxLength: 50, nullable: true),
                    Receiver = table.Column<string>(maxLength: 50, nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDrawings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDrawings_tblItems",
                        column: x => x.ItemID,
                        principalTable: "tblItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSubItemsSpecifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<int>(nullable: true),
                    SubItemName = table.Column<string>(maxLength: 50, nullable: true),
                    Spcifications = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubItemsSpecifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblSubItemsSpecifications_tblItems",
                        column: x => x.ItemID,
                        principalTable: "tblItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRole",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblRoles",
                        column: x => x.RoleId,
                        principalTable: "tblRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblUsers",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDrawingDet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrawingID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    DecisionMaker = table.Column<string>(maxLength: 50, nullable: true),
                    Decisions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDrawingDet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblDrawingDet_tblDrawings",
                        column: x => x.DrawingID,
                        principalTable: "tblDrawings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubItemID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Subject = table.Column<string>(maxLength: 50, nullable: true),
                    ContractorTeamID = table.Column<int>(nullable: true),
                    ConsultantTeamID = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Decisions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblRequests_tblConsultantsTeams",
                        column: x => x.ConsultantTeamID,
                        principalTable: "tblConsultantsTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequests_tblContractorsTeams",
                        column: x => x.ContractorTeamID,
                        principalTable: "tblContractorsTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequests_tblSubItemsSpecifications",
                        column: x => x.SubItemID,
                        principalTable: "tblSubItemsSpecifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTechProposals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubItemID = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    ConsultantTeamID = table.Column<int>(nullable: true),
                    ContractorTeamID = table.Column<int>(nullable: true),
                    FilePath = table.Column<string>(maxLength: 200, nullable: true),
                    Provider = table.Column<string>(maxLength: 200, nullable: true),
                    Decesions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTechProposals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblTechProposals_tblConsultantsTeams",
                        column: x => x.ConsultantTeamID,
                        principalTable: "tblConsultantsTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTechProposals_tblContractorsTeams",
                        column: x => x.ContractorTeamID,
                        principalTable: "tblContractorsTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblTechProposals_tblSubItemsSpecifications",
                        column: x => x.SubItemID,
                        principalTable: "tblSubItemsSpecifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BoqViewModel_ItemId",
                table: "BoqViewModel",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemViewModel_ItemsId",
                table: "ItemViewModel",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBoq_ItemID",
                table: "tblBoq",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblClientsTeams_ClientID",
                table: "tblClientsTeams",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_tblClientsTeams_ProjectID",
                table: "tblClientsTeams",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultantsTeams_ConsultantID",
                table: "tblConsultantsTeams",
                column: "ConsultantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblConsultantsTeams_ProjectID",
                table: "tblConsultantsTeams",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContractorsTeams_ContractorID",
                table: "tblContractorsTeams",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContractorsTeams_ProjectID",
                table: "tblContractorsTeams",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_ClientID",
                table: "tblContracts",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_ConsultantContractorID",
                table: "tblContracts",
                column: "ConsultantContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_ConsultantDesignID",
                table: "tblContracts",
                column: "ConsultantDesignID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_ConsultantSupervisionID",
                table: "tblContracts",
                column: "ConsultantSupervisionID");

            migrationBuilder.CreateIndex(
                name: "IX_tblContracts_ContractorID",
                table: "tblContracts",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDrawingDet_DrawingID",
                table: "tblDrawingDet",
                column: "DrawingID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDrawings_ItemID",
                table: "tblDrawings",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblInvoicesContractor_ProjectID",
                table: "tblInvoicesContractor",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblItems_ProjectID",
                table: "tblItems",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblLetters_ProjectID",
                table: "tblLetters",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProjects_ContractID",
                table: "tblProjects",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequests_ConsultantTeamID",
                table: "tblRequests",
                column: "ConsultantTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequests_ContractorTeamID",
                table: "tblRequests",
                column: "ContractorTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequests_SubItemID",
                table: "tblRequests",
                column: "SubItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSchedules_ProjectID",
                table: "tblSchedules",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubItemsSpecifications_ItemID",
                table: "tblSubItemsSpecifications",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTechProposals_ConsultantTeamID",
                table: "tblTechProposals",
                column: "ConsultantTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTechProposals_ContractorTeamID",
                table: "tblTechProposals",
                column: "ContractorTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTechProposals_SubItemID",
                table: "tblTechProposals",
                column: "SubItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_RoleId",
                table: "tblUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_UserId",
                table: "tblUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_ProjectId",
                table: "tblUsers",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BoqViewModel");

            migrationBuilder.DropTable(
                name: "ItemViewModel");

            migrationBuilder.DropTable(
                name: "tblBoq");

            migrationBuilder.DropTable(
                name: "tblClientsTeams");

            migrationBuilder.DropTable(
                name: "tblDrawingDet");

            migrationBuilder.DropTable(
                name: "tblInvoicesContractor");

            migrationBuilder.DropTable(
                name: "tblLetters");

            migrationBuilder.DropTable(
                name: "tblRequests");

            migrationBuilder.DropTable(
                name: "tblSchedules");

            migrationBuilder.DropTable(
                name: "tblTechProposals");

            migrationBuilder.DropTable(
                name: "tblUserRole");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblDrawings");

            migrationBuilder.DropTable(
                name: "tblConsultantsTeams");

            migrationBuilder.DropTable(
                name: "tblContractorsTeams");

            migrationBuilder.DropTable(
                name: "tblSubItemsSpecifications");

            migrationBuilder.DropTable(
                name: "tblRoles");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblItems");

            migrationBuilder.DropTable(
                name: "tblProjects");

            migrationBuilder.DropTable(
                name: "tblContracts");

            migrationBuilder.DropTable(
                name: "tblClients");

            migrationBuilder.DropTable(
                name: "tblConsultants");

            migrationBuilder.DropTable(
                name: "tblContractors");
        }
    }
}
