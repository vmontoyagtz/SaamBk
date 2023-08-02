using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaamApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialSaamAppAppMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountAdjustmentRef",
                columns: table => new
                {
                    AccountAdjustmentRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountAdjustmentRefName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountAdjustmentRefDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAdjustmentRef", x => x.AccountAdjustmentRefId);
                });

            migrationBuilder.CreateTable(
                name: "AccountStateType",
                columns: table => new
                {
                    AccountStateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountStateTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStateTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStateTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStateType", x => x.AccountStateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AiErrorLog",
                columns: table => new
                {
                    AiErrorLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiErrorLog", x => x.AiErrorLogId);
                });

            migrationBuilder.CreateTable(
                name: "AiMemory",
                columns: table => new
                {
                    AiMemoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiMemory", x => x.AiMemoryId);
                });

            migrationBuilder.CreateTable(
                name: "AiModel",
                columns: table => new
                {
                    AiModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accuracy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiModel", x => x.AiModelId);
                });

            migrationBuilder.CreateTable(
                name: "AiRobot",
                columns: table => new
                {
                    AiRobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AiRobotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiRobotDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiRobotUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AiRobotIsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiRobot", x => x.AiRobotId);
                });

            migrationBuilder.CreateTable(
                name: "AppConfigParam",
                columns: table => new
                {
                    AppConfigParamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppConfigParamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppConfigParamValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppConfigParamDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLowBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppConfigSettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigParam", x => x.AppConfigParamId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsLoginAllowed = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFailedLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccountVerified = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.ApplicationUserId);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaStage = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    AuditLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangesMade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangeReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.AuditLogId);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankSwiftCodeInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessPhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessEmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.BusinessUnitId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitType",
                columns: table => new
                {
                    BusinessUnitTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUnitTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessUnitTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitType", x => x.BusinessUnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryStage = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ConversationStage",
                columns: table => new
                {
                    ConversationStageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationStageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationStage", x => x.ConversationStageId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentSecuredUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    EmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.EmailAddressId);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddressType",
                columns: table => new
                {
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddressType", x => x.EmailAddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeJobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeHireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    FaqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaqQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaqAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAccountingPeriod",
                columns: table => new
                {
                    FinancialAccountingPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountingPeriod = table.Column<int>(type: "int", nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZippedStatementsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZippedStatementsSharedAccessSignatureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStatementsJobRunning = table.Column<bool>(type: "bit", nullable: true),
                    SettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccountingPeriod", x => x.FinancialAccountingPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "InteractionType",
                columns: table => new
                {
                    InteractionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionType", x => x.InteractionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntry",
                columns: table => new
                {
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceIdDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JournalEntryTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalTaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntry", x => x.JournalEntryId);
                });

            migrationBuilder.CreateTable(
                name: "MessageType",
                columns: table => new
                {
                    MessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageType", x => x.MessageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentFrequency",
                columns: table => new
                {
                    PaymentFrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentFrequencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentFrequencyValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentFrequency", x => x.PaymentFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentFrequencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.PhoneNumberId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                columns: table => new
                {
                    PhoneNumberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.PhoneNumberTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductIsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductMinimumCharacters = table.Column<int>(type: "int", nullable: false),
                    ProductMinimumCallMinutes = table.Column<int>(type: "int", nullable: false),
                    ProductChargeRatePerCharacter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductChargeRateCallPerSecond = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "RatingReason",
                columns: table => new
                {
                    RatingReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingReason", x => x.RatingReasonId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "ReportType",
                columns: table => new
                {
                    ReportTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportType", x => x.ReportTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaxpayerType",
                columns: table => new
                {
                    TaxpayerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxpayerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxpayerType", x => x.TaxpayerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TemplateType",
                columns: table => new
                {
                    TemplateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateType", x => x.TemplateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextBillingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettingsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingLesson",
                columns: table => new
                {
                    TrainingLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingLessonTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLessonDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLessonVimeoVideoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLessonVideoDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLessonUserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingLessonPreviousLesson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingLesson", x => x.TrainingLessonId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingQuestion",
                columns: table => new
                {
                    TrainingQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingQuestionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingQuestion", x => x.TrainingQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "UserMembership",
                columns: table => new
                {
                    UserMembershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: true),
                    OwnerSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: true),
                    AdminSince = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAllowedToRunMobile = table.Column<bool>(type: "bit", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPasswordChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMembership", x => x.UserMembershipId);
                });

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNotificationPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNotificationEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccount_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_BusinessUnitDocument_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitEmailAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitEmailAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_BusinessUnitEmailAddress_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitEmailAddress_EmailAddressType_EmailAddressTypeId",
                        column: x => x.EmailAddressTypeId,
                        principalTable: "EmailAddressType",
                        principalColumn: "EmailAddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitEmailAddress_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "EmailAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEmailAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEmailAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddress_EmailAddressType_EmailAddressTypeId",
                        column: x => x.EmailAddressTypeId,
                        principalTable: "EmailAddressType",
                        principalColumn: "EmailAddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddress_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "EmailAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEmailAddress_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerProfileThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitPhoneNumber",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitPhoneNumber", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_BusinessUnitPhoneNumber_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitPhoneNumber_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitPhoneNumber_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePhoneNumber",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePhoneNumber", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumber_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumber_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeePhoneNumber_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                    table.ForeignKey(
                        name: "FK_Country_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCode",
                columns: table => new
                {
                    DiscountCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCodeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCodePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountCodeStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountCodeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCode", x => x.DiscountCodeId);
                    table.ForeignKey(
                        name: "FK_DiscountCode_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftCode",
                columns: table => new
                {
                    GiftCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiftCodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftCodeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiftCodeStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiftCodeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCode", x => x.GiftCodeId);
                    table.ForeignKey(
                        name: "FK_GiftCode_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrepaidPackage",
                columns: table => new
                {
                    PrepaidPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrepaidPackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepaidPackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrepaidPackageIsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepaidPackage", x => x.PrepaidPackageId);
                    table.ForeignKey(
                        name: "FK_PrepaidPackage_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsListReport = table.Column<bool>(type: "bit", nullable: true),
                    IsFormReport = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ReportJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontEndMethodToCall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiMethodToCall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParametersJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_ReportType_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportType",
                        principalColumn: "ReportTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxInformation",
                columns: table => new
                {
                    TaxInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxInformationBusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxInformationCommercialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxInformationRegistrationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxInformationBusinessIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxpayerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxInformation", x => x.TaxInformationId);
                    table.ForeignKey(
                        name: "FK_TaxInformation_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaxInformation_TaxpayerType_TaxpayerTypeId",
                        column: x => x.TaxpayerTypeId,
                        principalTable: "TaxpayerType",
                        principalColumn: "TaxpayerTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemplateIsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.TemplateId);
                    table.ForeignKey(
                        name: "FK_Template_TemplateType_TemplateTypeId",
                        column: x => x.TemplateTypeId,
                        principalTable: "TemplateType",
                        principalColumn: "TemplateTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingQuestionOption",
                columns: table => new
                {
                    TrainingQuestionOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingQuestionOptionValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingQuestionOptionAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingQuestionOption", x => x.TrainingQuestionOptionId);
                    table.ForeignKey(
                        name: "FK_TrainingQuestionOption_TrainingQuestion_TrainingQuestionId",
                        column: x => x.TrainingQuestionId,
                        principalTable: "TrainingQuestion",
                        principalColumn: "TrainingQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiFeedback",
                columns: table => new
                {
                    AiFeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFeedback = table.Column<bool>(type: "bit", nullable: true),
                    AISessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiFeedback", x => x.AiFeedbackId);
                    table.ForeignKey(
                        name: "FK_AiFeedback_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiInteraction",
                columns: table => new
                {
                    AiInteractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    AiRobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiInteraction", x => x.AiInteractionId);
                    table.ForeignKey(
                        name: "FK_AiInteraction_AiRobot_AiRobotId",
                        column: x => x.AiRobotId,
                        principalTable: "AiRobot",
                        principalColumn: "AiRobotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiInteraction_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiInteraction_UserSession_SessionId",
                        column: x => x.SessionId,
                        principalTable: "UserSession",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiSession",
                columns: table => new
                {
                    AiSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfInteractions = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiSession", x => x.AiSessionId);
                    table.ForeignKey(
                        name: "FK_AiSession_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAiHistory",
                columns: table => new
                {
                    CustomerAiHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAiHistory", x => x.CustomerAiHistoryId);
                    table.ForeignKey(
                        name: "FK_CustomerAiHistory_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerDocument_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEmailAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEmailAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerEmailAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerEmailAddress_EmailAddressType_EmailAddressTypeId",
                        column: x => x.EmailAddressTypeId,
                        principalTable: "EmailAddressType",
                        principalColumn: "EmailAddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerEmailAddress_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "EmailAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFeedback",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFeedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_CustomerFeedback_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPhoneNumber",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhoneNumber", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPhoneNumber_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPurchase",
                columns: table => new
                {
                    CustomerPurchaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceIdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerPurchaseTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPositive = table.Column<bool>(type: "bit", nullable: false),
                    IsNegative = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPurchase", x => x.CustomerPurchaseId);
                    table.ForeignKey(
                        name: "FK_CustomerPurchase_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDocument",
                columns: table => new
                {
                    IdentityDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityDocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityDocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityDocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDocument", x => x.IdentityDocumentId);
                    table.ForeignKey(
                        name: "FK_IdentityDocument_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodeRedemption",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCodeRedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodeRedemption", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_DiscountCodeRedemption_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscountCodeRedemption_DiscountCode_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCode",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftCodeRedemption",
                columns: table => new
                {
                    GiftCodeRedemptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftCodeRedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiftCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftCodeRedemption", x => x.GiftCodeRedemptionId);
                    table.ForeignKey(
                        name: "FK_GiftCodeRedemption_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftCodeRedemption_GiftCode_GiftCodeId",
                        column: x => x.GiftCodeId,
                        principalTable: "GiftCode",
                        principalColumn: "GiftCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrepaidPackageRedemption",
                columns: table => new
                {
                    PrepaidPackageRedemptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrepaidPackageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrepaidPackageRedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrepaidPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepaidPackageRedemption", x => x.PrepaidPackageRedemptionId);
                    table.ForeignKey(
                        name: "FK_PrepaidPackageRedemption_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrepaidPackageRedemption_PrepaidPackage_PrepaidPackageId",
                        column: x => x.PrepaidPackageId,
                        principalTable: "PrepaidPackage",
                        principalColumn: "PrepaidPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SerfinsaPayment",
                columns: table => new
                {
                    SerfinsaPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerfinsaPaymentAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentAuditNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentTimeMessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentTimeAuthorize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerfinsaPaymentTimeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerfinsaPaymentTimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrepaidPackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerfinsaPayment", x => x.SerfinsaPaymentId);
                    table.ForeignKey(
                        name: "FK_SerfinsaPayment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SerfinsaPayment_DiscountCode_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCode",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SerfinsaPayment_PrepaidPackage_PrepaidPackageId",
                        column: x => x.PrepaidPackageId,
                        principalTable: "PrepaidPackage",
                        principalColumn: "PrepaidPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountStateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_AccountStateType_AccountStateTypeId",
                        column: x => x.AccountStateTypeId,
                        principalTable: "AccountStateType",
                        principalColumn: "AccountStateTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_TaxInformation_TaxInformationId",
                        column: x => x.TaxInformationId,
                        principalTable: "TaxInformation",
                        principalColumn: "TaxInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvisorLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvisorNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvisorTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvisorJsonResume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNaturalPerson = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentFrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisor", x => x.AdvisorId);
                    table.ForeignKey(
                        name: "FK_Advisor_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisor_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisor_PaymentFrequency_PaymentFrequencyId",
                        column: x => x.PaymentFrequencyId,
                        principalTable: "PaymentFrequency",
                        principalColumn: "PaymentFrequencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advisor_TaxInformation_TaxInformationId",
                        column: x => x.TaxInformationId,
                        principalTable: "TaxInformation",
                        principalColumn: "TaxInformationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_TemplateDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateDocument_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPayment",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerfinsaPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPayment", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerPayment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerPayment_SerfinsaPayment_SerfinsaPaymentId",
                        column: x => x.SerfinsaPaymentId,
                        principalTable: "SerfinsaPayment",
                        principalColumn: "SerfinsaPaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountAdjustment",
                columns: table => new
                {
                    AccountAdjustmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdjustmentReason = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalChargeCredited = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalTaxCredited = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountAdjustmentRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAdjustment", x => x.AccountAdjustmentId);
                    table.ForeignKey(
                        name: "FK_AccountAdjustment_AccountAdjustmentRef_AccountAdjustmentRefId",
                        column: x => x.AccountAdjustmentRefId,
                        principalTable: "AccountAdjustmentRef",
                        principalColumn: "AccountAdjustmentRefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountAdjustment_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccount",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccount", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerAccount_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAccount_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentState = table.Column<int>(type: "int", nullable: false),
                    InternalComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoicedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoicingNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalSaleTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialAccountingPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_FinancialAccountingPeriod_FinancialAccountingPeriodId",
                        column: x => x.FinancialAccountingPeriodId,
                        principalTable: "FinancialAccountingPeriod",
                        principalColumn: "FinancialAccountingPeriodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryLine",
                columns: table => new
                {
                    JournalEntryLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    JournalEntryTypeRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDebit = table.Column<bool>(type: "bit", nullable: false),
                    IsCredit = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialAccountingPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryLine", x => x.JournalEntryLineId);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_FinancialAccountingPeriod_FinancialAccountingPeriodId",
                        column: x => x.FinancialAccountingPeriodId,
                        principalTable: "FinancialAccountingPeriod",
                        principalColumn: "FinancialAccountingPeriodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_JournalEntry_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntry",
                        principalColumn: "JournalEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorBank",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorBank", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorBank_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorBank_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorBankTransferInfo",
                columns: table => new
                {
                    AdvisorBankTransferInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankTransferNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorBankTransferInfo", x => x.AdvisorBankTransferInfoId);
                    table.ForeignKey(
                        name: "FK_AdvisorBankTransferInfo_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorBankTransferInfo_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorCustomer",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorCustomer", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorCustomer_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorCustomer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorDocument_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorEmailAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailAddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorEmailAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorEmailAddress_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorEmailAddress_EmailAddressType_EmailAddressTypeId",
                        column: x => x.EmailAddressTypeId,
                        principalTable: "EmailAddressType",
                        principalColumn: "EmailAddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorEmailAddress_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "EmailAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorIdentityDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorIdentityDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorIdentityDocument_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorIdentityDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorIdentityDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorIdentityDocument_IdentityDocument_IdentityDocumentId",
                        column: x => x.IdentityDocumentId,
                        principalTable: "IdentityDocument",
                        principalColumn: "IdentityDocumentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorLogin",
                columns: table => new
                {
                    AdvisorLoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvisorLoginStage = table.Column<bool>(type: "bit", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorLogin", x => x.AdvisorLoginId);
                    table.ForeignKey(
                        name: "FK_AdvisorLogin_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorPayment",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorPaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvisorPaymentsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorPayment", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorPayment_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorPayment_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorPayment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorPhoneNumber",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorPhoneNumber", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorPhoneNumber_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorPhoneNumber_PhoneNumberType_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorPhoneNumber_PhoneNumber_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSchedule",
                columns: table => new
                {
                    AppointmentScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSchedule", x => x.AppointmentScheduleId);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedule_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedule_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerReview",
                columns: table => new
                {
                    CustomerReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReview", x => x.CustomerReviewId);
                    table.ForeignKey(
                        name: "FK_CustomerReview_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerReview_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegionAreaAdvisorCategory",
                columns: table => new
                {
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionAreaAdvisorCategory", x => x.RegionAreaAdvisorCategoryId);
                    table.ForeignKey(
                        name: "FK_RegionAreaAdvisorCategory_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionAreaAdvisorCategory_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionAreaAdvisorCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionAreaAdvisorCategory_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgress",
                columns: table => new
                {
                    TrainingProgressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingProgressPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingLessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgress", x => x.TrainingProgressId);
                    table.ForeignKey(
                        name: "FK_TrainingProgress_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingProgress_TrainingLesson_TrainingLessonId",
                        column: x => x.TrainingLessonId,
                        principalTable: "TrainingLesson",
                        principalColumn: "TrainingLessonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingQuizHistory",
                columns: table => new
                {
                    TrainingQuizHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingQuizHistoryAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingQuizHistoryStage = table.Column<int>(type: "int", nullable: false),
                    HistoryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingQuizHistory", x => x.TrainingQuizHistoryId);
                    table.ForeignKey(
                        name: "FK_TrainingQuizHistory_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressStr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LineSale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LineTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LineDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.InvoiceDetailId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryReference",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryTypeRefId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JournalEntryLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryReference", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_JournalEntryReference_JournalEntryLine_JournalEntryLineId",
                        column: x => x.JournalEntryLineId,
                        principalTable: "JournalEntryLine",
                        principalColumn: "JournalEntryLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorApplicant",
                columns: table => new
                {
                    AdvisorApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApplicantNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorApplicant", x => x.AdvisorApplicantId);
                    table.ForeignKey(
                        name: "FK_AdvisorApplicant_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiAreaExpertise",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiAreaExpertise", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AiAreaExpertise_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitCategory",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitCategory", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_BusinessUnitCategory_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitCategory_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comission",
                columns: table => new
                {
                    ComissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComissionPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comission", x => x.ComissionId);
                    table.ForeignKey(
                        name: "FK_Comission_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnansweredConversation",
                columns: table => new
                {
                    UnansweredConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnansweredConversationQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnansweredConversationAnsweredTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Answered = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: true),
                    Unanswered = table.Column<bool>(type: "bit", nullable: true),
                    AiRobot = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnansweredConversation", x => x.UnansweredConversationId);
                    table.ForeignKey(
                        name: "FK_UnansweredConversation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnansweredConversation_InteractionType_InteractionTypeId",
                        column: x => x.InteractionTypeId,
                        principalTable: "InteractionType",
                        principalColumn: "InteractionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnansweredConversation_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorAddress_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorAddress_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_BusinessUnitAddress_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessUnitAddress_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "BusinessUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiRobotCategory",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AiRobotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiRobotCategory", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AiRobotCategory_AiRobot_AiRobotId",
                        column: x => x.AiRobotId,
                        principalTable: "AiRobot",
                        principalColumn: "AiRobotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiRobotCategory_Comission_ComissionId",
                        column: x => x.ComissionId,
                        principalTable: "Comission",
                        principalColumn: "ComissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiRobotCategory_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Comission_ComissionId",
                        column: x => x.ComissionId,
                        principalTable: "Comission",
                        principalColumn: "ComissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategory_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCategory",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCategory", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_TemplateCategory_Comission_ComissionId",
                        column: x => x.ComissionId,
                        principalTable: "Comission",
                        principalColumn: "ComissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateCategory_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateCategory_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReconnectConversationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationSumTimeInSecs = table.Column<int>(type: "int", nullable: false),
                    ConversationSumSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LostSignalCustomer = table.Column<bool>(type: "bit", nullable: true),
                    LostSignalAdvisor = table.Column<bool>(type: "bit", nullable: true),
                    CanceledByCustomer = table.Column<bool>(type: "bit", nullable: true),
                    CanceledByAdvisor = table.Column<bool>(type: "bit", nullable: true),
                    EndedByNoBalance = table.Column<bool>(type: "bit", nullable: true),
                    StillActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnansweredConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ConversationId);
                    table.ForeignKey(
                        name: "FK_Conversation_InteractionType_InteractionTypeId",
                        column: x => x.InteractionTypeId,
                        principalTable: "InteractionType",
                        principalColumn: "InteractionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversation_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversation_UnansweredConversation_UnansweredConversationId",
                        column: x => x.UnansweredConversationId,
                        principalTable: "UnansweredConversation",
                        principalColumn: "UnansweredConversationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorRating",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorRatingFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvisorRatingRate = table.Column<int>(type: "int", nullable: false),
                    AdvisorRatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingReasonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorRating", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_AdvisorRating_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorRating_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorRating_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdvisorRating_RatingReason_RatingReasonId",
                        column: x => x.RatingReasonId,
                        principalTable: "RatingReason",
                        principalColumn: "RatingReasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversationPayment",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvisorPaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationPaymentStage = table.Column<bool>(type: "bit", nullable: true),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationPayment", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_ConversationPayment_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetailTimeInSecs = table.Column<int>(type: "int", nullable: false),
                    MessageDetailSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TemplatetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplyToMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentByAdvisor = table.Column<bool>(type: "bit", nullable: false),
                    SentByCustomer = table.Column<bool>(type: "bit", nullable: false),
                    HasBeenReadByCustomer = table.Column<bool>(type: "bit", nullable: false),
                    HasBeenReadByAdvisor = table.Column<bool>(type: "bit", nullable: false),
                    ReadByCustomerAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadByAdvisorAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    AiRobot = table.Column<bool>(type: "bit", nullable: false),
                    IsChat = table.Column<bool>(type: "bit", nullable: false),
                    IsVoiceCall = table.Column<bool>(type: "bit", nullable: false),
                    IsVideoCall = table.Column<bool>(type: "bit", nullable: false),
                    IsVoiceNote = table.Column<bool>(type: "bit", nullable: false),
                    VoiceNoteApproved = table.Column<bool>(type: "bit", nullable: true),
                    VoiceNoteSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LowBalance = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteractionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionAreaAdvisorCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "AdvisorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_InteractionType_InteractionTypeId",
                        column: x => x.InteractionTypeId,
                        principalTable: "InteractionType",
                        principalColumn: "InteractionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_MessageType_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageType",
                        principalColumn: "MessageTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_RegionAreaAdvisorCategory_RegionAreaAdvisorCategoryId",
                        column: x => x.RegionAreaAdvisorCategoryId,
                        principalTable: "RegionAreaAdvisorCategory",
                        principalColumn: "RegionAreaAdvisorCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_MessageDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageDocument_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoiceNoteDocument",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceNoteDocument", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_VoiceNoteDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoiceNoteDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoiceNoteDocument_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountStateTypeId",
                table: "Account",
                column: "AccountStateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_TaxInformationId",
                table: "Account",
                column: "TaxInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAdjustment_AccountAdjustmentRefId",
                table: "AccountAdjustment",
                column: "AccountAdjustmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAdjustment_AccountId",
                table: "AccountAdjustment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_RegionId",
                table: "Address",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_BusinessUnitId",
                table: "Advisor",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_GenderId",
                table: "Advisor",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_PaymentFrequencyId",
                table: "Advisor",
                column: "PaymentFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_TaxInformationId",
                table: "Advisor",
                column: "TaxInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAddress_AddressId",
                table: "AdvisorAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAddress_AddressTypeId",
                table: "AdvisorAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorAddress_AdvisorId",
                table: "AdvisorAddress",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorApplicant_RegionAreaAdvisorCategoryId",
                table: "AdvisorApplicant",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorBank_AdvisorId",
                table: "AdvisorBank",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorBank_BankAccountId",
                table: "AdvisorBank",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorBankTransferInfo_AdvisorId",
                table: "AdvisorBankTransferInfo",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorBankTransferInfo_BankAccountId",
                table: "AdvisorBankTransferInfo",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorCustomer_AdvisorId",
                table: "AdvisorCustomer",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorCustomer_CustomerId",
                table: "AdvisorCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorDocument_AdvisorId",
                table: "AdvisorDocument",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorDocument_DocumentId",
                table: "AdvisorDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorDocument_DocumentTypeId",
                table: "AdvisorDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorEmailAddress_AdvisorId",
                table: "AdvisorEmailAddress",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorEmailAddress_EmailAddressId",
                table: "AdvisorEmailAddress",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorEmailAddress_EmailAddressTypeId",
                table: "AdvisorEmailAddress",
                column: "EmailAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorIdentityDocument_AdvisorId",
                table: "AdvisorIdentityDocument",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorIdentityDocument_DocumentId",
                table: "AdvisorIdentityDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorIdentityDocument_DocumentTypeId",
                table: "AdvisorIdentityDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorIdentityDocument_IdentityDocumentId",
                table: "AdvisorIdentityDocument",
                column: "IdentityDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorLogin_AdvisorId",
                table: "AdvisorLogin",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPayment_AdvisorId",
                table: "AdvisorPayment",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPayment_BankAccountId",
                table: "AdvisorPayment",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPayment_PaymentMethodId",
                table: "AdvisorPayment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPhoneNumber_AdvisorId",
                table: "AdvisorPhoneNumber",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPhoneNumber_PhoneNumberId",
                table: "AdvisorPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorPhoneNumber_PhoneNumberTypeId",
                table: "AdvisorPhoneNumber",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorRating_AdvisorId",
                table: "AdvisorRating",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorRating_ConversationId",
                table: "AdvisorRating",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorRating_CustomerId",
                table: "AdvisorRating",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvisorRating_RatingReasonId",
                table: "AdvisorRating",
                column: "RatingReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AiAreaExpertise_RegionAreaAdvisorCategoryId",
                table: "AiAreaExpertise",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AiFeedback_CustomerId",
                table: "AiFeedback",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AiInteraction_AiRobotId",
                table: "AiInteraction",
                column: "AiRobotId");

            migrationBuilder.CreateIndex(
                name: "IX_AiInteraction_CustomerId",
                table: "AiInteraction",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AiInteraction_SessionId",
                table: "AiInteraction",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AiRobotCategory_AiRobotId",
                table: "AiRobotCategory",
                column: "AiRobotId");

            migrationBuilder.CreateIndex(
                name: "IX_AiRobotCategory_ComissionId",
                table: "AiRobotCategory",
                column: "ComissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AiRobotCategory_RegionAreaAdvisorCategoryId",
                table: "AiRobotCategory",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AiSession_CustomerId",
                table: "AiSession",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedule_AdvisorId",
                table: "AppointmentSchedule",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedule_CustomerId",
                table: "AppointmentSchedule",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankId",
                table: "BankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitAddress_AddressId",
                table: "BusinessUnitAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitAddress_AddressTypeId",
                table: "BusinessUnitAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitAddress_BusinessUnitId",
                table: "BusinessUnitAddress",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitCategory_BusinessUnitId",
                table: "BusinessUnitCategory",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitCategory_RegionAreaAdvisorCategoryId",
                table: "BusinessUnitCategory",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitDocument_BusinessUnitId",
                table: "BusinessUnitDocument",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitDocument_DocumentId",
                table: "BusinessUnitDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitDocument_DocumentTypeId",
                table: "BusinessUnitDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitEmailAddress_BusinessUnitId",
                table: "BusinessUnitEmailAddress",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitEmailAddress_EmailAddressId",
                table: "BusinessUnitEmailAddress",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitEmailAddress_EmailAddressTypeId",
                table: "BusinessUnitEmailAddress",
                column: "EmailAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitPhoneNumber_BusinessUnitId",
                table: "BusinessUnitPhoneNumber",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitPhoneNumber_PhoneNumberId",
                table: "BusinessUnitPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitPhoneNumber_PhoneNumberTypeId",
                table: "BusinessUnitPhoneNumber",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_RegionAreaAdvisorCategoryId",
                table: "Comission",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_InteractionTypeId",
                table: "Conversation",
                column: "InteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_RegionAreaAdvisorCategoryId",
                table: "Conversation",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_UnansweredConversationId",
                table: "Conversation",
                column: "UnansweredConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationPayment_ConversationId",
                table: "ConversationPayment",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_RegionId",
                table: "Country",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GenderId",
                table: "Customer",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccount_AccountId",
                table: "CustomerAccount",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccount_CustomerId",
                table: "CustomerAccount",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressId",
                table: "CustomerAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressTypeId",
                table: "CustomerAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAiHistory_CustomerId",
                table: "CustomerAiHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocument_CustomerId",
                table: "CustomerDocument",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocument_DocumentId",
                table: "CustomerDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDocument_DocumentTypeId",
                table: "CustomerDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEmailAddress_CustomerId",
                table: "CustomerEmailAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEmailAddress_EmailAddressId",
                table: "CustomerEmailAddress",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEmailAddress_EmailAddressTypeId",
                table: "CustomerEmailAddress",
                column: "EmailAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFeedback_CustomerId",
                table: "CustomerFeedback",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayment_PaymentMethodId",
                table: "CustomerPayment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayment_SerfinsaPaymentId",
                table: "CustomerPayment",
                column: "SerfinsaPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumber_CustomerId",
                table: "CustomerPhoneNumber",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumber_PhoneNumberId",
                table: "CustomerPhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhoneNumber_PhoneNumberTypeId",
                table: "CustomerPhoneNumber",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPurchase_CustomerId",
                table: "CustomerPurchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReview_AdvisorId",
                table: "CustomerReview",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerReview_CustomerId",
                table: "CustomerReview",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCode_RegionId",
                table: "DiscountCode",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeRedemption_CustomerId",
                table: "DiscountCodeRedemption",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodeRedemption_DiscountCodeId",
                table: "DiscountCodeRedemption",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_AddressId",
                table: "EmployeeAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_AddressTypeId",
                table: "EmployeeAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddress_EmailAddressId",
                table: "EmployeeEmailAddress",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddress_EmailAddressTypeId",
                table: "EmployeeEmailAddress",
                column: "EmailAddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEmailAddress_EmployeeId",
                table: "EmployeeEmailAddress",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_EmployeeId",
                table: "EmployeePhoneNumber",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_PhoneNumberId",
                table: "EmployeePhoneNumber",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePhoneNumber_PhoneNumberTypeId",
                table: "EmployeePhoneNumber",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCode_RegionId",
                table: "GiftCode",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCodeRedemption_CustomerId",
                table: "GiftCodeRedemption",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftCodeRedemption_GiftCodeId",
                table: "GiftCodeRedemption",
                column: "GiftCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDocument_CountryId",
                table: "IdentityDocument",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AccountId",
                table: "Invoice",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FinancialAccountingPeriodId",
                table: "Invoice",
                column: "FinancialAccountingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_AccountId",
                table: "JournalEntryLine",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_FinancialAccountingPeriodId",
                table: "JournalEntryLine",
                column: "FinancialAccountingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_JournalEntryId",
                table: "JournalEntryLine",
                column: "JournalEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryReference_JournalEntryLineId",
                table: "JournalEntryReference",
                column: "JournalEntryLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AdvisorId",
                table: "Message",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ConversationId",
                table: "Message",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CustomerId",
                table: "Message",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_InteractionTypeId",
                table: "Message",
                column: "InteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageTypeId",
                table: "Message",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ProductId",
                table: "Message",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RegionAreaAdvisorCategoryId",
                table: "Message",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDocument_DocumentId",
                table: "MessageDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDocument_DocumentTypeId",
                table: "MessageDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageDocument_MessageId",
                table: "MessageDocument",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepaidPackage_RegionId",
                table: "PrepaidPackage",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepaidPackageRedemption_CustomerId",
                table: "PrepaidPackageRedemption",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrepaidPackageRedemption_PrepaidPackageId",
                table: "PrepaidPackageRedemption",
                column: "PrepaidPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ComissionId",
                table: "ProductCategory",
                column: "ComissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_RegionAreaAdvisorCategoryId",
                table: "ProductCategory",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionAreaAdvisorCategory_AdvisorId",
                table: "RegionAreaAdvisorCategory",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionAreaAdvisorCategory_AreaId",
                table: "RegionAreaAdvisorCategory",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionAreaAdvisorCategory_CategoryId",
                table: "RegionAreaAdvisorCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionAreaAdvisorCategory_RegionId",
                table: "RegionAreaAdvisorCategory",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ReportTypeId",
                table: "Report",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerfinsaPayment_CustomerId",
                table: "SerfinsaPayment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SerfinsaPayment_DiscountCodeId",
                table: "SerfinsaPayment",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SerfinsaPayment_PrepaidPackageId",
                table: "SerfinsaPayment",
                column: "PrepaidPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxInformation_BusinessUnitId",
                table: "TaxInformation",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxInformation_TaxpayerTypeId",
                table: "TaxInformation",
                column: "TaxpayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_TemplateTypeId",
                table: "Template",
                column: "TemplateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCategory_ComissionId",
                table: "TemplateCategory",
                column: "ComissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCategory_RegionAreaAdvisorCategoryId",
                table: "TemplateCategory",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCategory_TemplateId",
                table: "TemplateCategory",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDocument_DocumentId",
                table: "TemplateDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDocument_DocumentTypeId",
                table: "TemplateDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDocument_TemplateId",
                table: "TemplateDocument",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgress_AdvisorId",
                table: "TrainingProgress",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgress_TrainingLessonId",
                table: "TrainingProgress",
                column: "TrainingLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingQuestionOption_TrainingQuestionId",
                table: "TrainingQuestionOption",
                column: "TrainingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingQuizHistory_AdvisorId",
                table: "TrainingQuizHistory",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_UnansweredConversation_CustomerId",
                table: "UnansweredConversation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UnansweredConversation_InteractionTypeId",
                table: "UnansweredConversation",
                column: "InteractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UnansweredConversation_RegionAreaAdvisorCategoryId",
                table: "UnansweredConversation",
                column: "RegionAreaAdvisorCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMembership_Username",
                table: "UserMembership",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoiceNoteDocument_DocumentId",
                table: "VoiceNoteDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceNoteDocument_DocumentTypeId",
                table: "VoiceNoteDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceNoteDocument_MessageId",
                table: "VoiceNoteDocument",
                column: "MessageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAdjustment");

            migrationBuilder.DropTable(
                name: "AdvisorAddress");

            migrationBuilder.DropTable(
                name: "AdvisorApplicant");

            migrationBuilder.DropTable(
                name: "AdvisorBank");

            migrationBuilder.DropTable(
                name: "AdvisorBankTransferInfo");

            migrationBuilder.DropTable(
                name: "AdvisorCustomer");

            migrationBuilder.DropTable(
                name: "AdvisorDocument");

            migrationBuilder.DropTable(
                name: "AdvisorEmailAddress");

            migrationBuilder.DropTable(
                name: "AdvisorIdentityDocument");

            migrationBuilder.DropTable(
                name: "AdvisorLogin");

            migrationBuilder.DropTable(
                name: "AdvisorPayment");

            migrationBuilder.DropTable(
                name: "AdvisorPhoneNumber");

            migrationBuilder.DropTable(
                name: "AdvisorRating");

            migrationBuilder.DropTable(
                name: "AiAreaExpertise");

            migrationBuilder.DropTable(
                name: "AiErrorLog");

            migrationBuilder.DropTable(
                name: "AiFeedback");

            migrationBuilder.DropTable(
                name: "AiInteraction");

            migrationBuilder.DropTable(
                name: "AiMemory");

            migrationBuilder.DropTable(
                name: "AiModel");

            migrationBuilder.DropTable(
                name: "AiRobotCategory");

            migrationBuilder.DropTable(
                name: "AiSession");

            migrationBuilder.DropTable(
                name: "AppConfigParam");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "AppointmentSchedule");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "BusinessUnitAddress");

            migrationBuilder.DropTable(
                name: "BusinessUnitCategory");

            migrationBuilder.DropTable(
                name: "BusinessUnitDocument");

            migrationBuilder.DropTable(
                name: "BusinessUnitEmailAddress");

            migrationBuilder.DropTable(
                name: "BusinessUnitPhoneNumber");

            migrationBuilder.DropTable(
                name: "BusinessUnitType");

            migrationBuilder.DropTable(
                name: "ConversationPayment");

            migrationBuilder.DropTable(
                name: "ConversationStage");

            migrationBuilder.DropTable(
                name: "CustomerAccount");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "CustomerAiHistory");

            migrationBuilder.DropTable(
                name: "CustomerDocument");

            migrationBuilder.DropTable(
                name: "CustomerEmailAddress");

            migrationBuilder.DropTable(
                name: "CustomerFeedback");

            migrationBuilder.DropTable(
                name: "CustomerPayment");

            migrationBuilder.DropTable(
                name: "CustomerPhoneNumber");

            migrationBuilder.DropTable(
                name: "CustomerPurchase");

            migrationBuilder.DropTable(
                name: "CustomerReview");

            migrationBuilder.DropTable(
                name: "DiscountCodeRedemption");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "EmployeeEmailAddress");

            migrationBuilder.DropTable(
                name: "EmployeePhoneNumber");

            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "GiftCodeRedemption");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "JournalEntryReference");

            migrationBuilder.DropTable(
                name: "MessageDocument");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PrepaidPackageRedemption");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "TemplateCategory");

            migrationBuilder.DropTable(
                name: "TemplateDocument");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "TrainingProgress");

            migrationBuilder.DropTable(
                name: "TrainingQuestionOption");

            migrationBuilder.DropTable(
                name: "TrainingQuizHistory");

            migrationBuilder.DropTable(
                name: "UserMembership");

            migrationBuilder.DropTable(
                name: "VoiceNoteDocument");

            migrationBuilder.DropTable(
                name: "AccountAdjustmentRef");

            migrationBuilder.DropTable(
                name: "IdentityDocument");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "RatingReason");

            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropTable(
                name: "AiRobot");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "SerfinsaPayment");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "EmailAddressType");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PhoneNumberType");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "GiftCode");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "JournalEntryLine");

            migrationBuilder.DropTable(
                name: "ReportType");

            migrationBuilder.DropTable(
                name: "Comission");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropTable(
                name: "TrainingLesson");

            migrationBuilder.DropTable(
                name: "TrainingQuestion");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "DiscountCode");

            migrationBuilder.DropTable(
                name: "PrepaidPackage");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "FinancialAccountingPeriod");

            migrationBuilder.DropTable(
                name: "JournalEntry");

            migrationBuilder.DropTable(
                name: "TemplateType");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "MessageType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "AccountStateType");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropTable(
                name: "UnansweredConversation");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "InteractionType");

            migrationBuilder.DropTable(
                name: "RegionAreaAdvisorCategory");

            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "PaymentFrequency");

            migrationBuilder.DropTable(
                name: "TaxInformation");

            migrationBuilder.DropTable(
                name: "BusinessUnit");

            migrationBuilder.DropTable(
                name: "TaxpayerType");
        }
    }
}
