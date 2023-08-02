using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SaamApp.Domain.Entities;
using SaamAppLib.SharedKernel;


// make sure package Microsoft.EntityFrameworkCore.Design
//--RUN THIS FROM SaamApp.Api project folder   << ---------

// -c	The DbContext class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
// -p	Relative path to the project folder of the target project. Default value is the current folder.
// -s	Relative path to the project folder of the startup project. Default value is the current folder.
// -o	The directory to put files in. Paths are relative to the project directory.


// to drop the database
// dotnet ef database drop -c appdbcontext -p ../SaamApp.Infrastructure/SaamApp.Infrastructure.csproj -f -v

// dotnet ef migrations add initialSaamAppAppMigration -c appdbcontext -p ../SaamApp.Infrastructure/SaamApp.Infrastructure.csproj -s SaamApp.Api.csproj -o Data/Migrations

// dotnet ef database update -c appdbcontext --project ../SaamApp.Infrastructure/SaamApp.Infrastructure.csproj -s SaamApp.Api.csproj

// then look at AppDbContextSeed


namespace SaamApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;
        private readonly Guid _tenantId = Guid.Parse("424CB1C1-8C9E-70BE-71B5-64B48B9769F8");

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            //https://learn.microsoft.com/en-us/ef/core/logging-events-diagnostics/events
            SavedChanges += PublishEvent;
            _mediator = mediator;
        }

        public DbSet<AppConfigParam> AppConfigParams { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAdjustment> AccountAdjustments { get; set; }
        public DbSet<AccountAdjustmentRef> AccountAdjustmentRefs { get; set; }
        public DbSet<AccountStateType> AccountStateTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<AdvisorAddress> AdvisorAddresses { get; set; }
        public DbSet<AdvisorApplicant> AdvisorApplicants { get; set; }
        public DbSet<AdvisorBank> AdvisorBanks { get; set; }
        public DbSet<AdvisorBankTransferInfo> AdvisorBankTransferInfoes { get; set; }
        public DbSet<AdvisorCustomer> AdvisorCustomers { get; set; }
        public DbSet<AdvisorDocument> AdvisorDocuments { get; set; }
        public DbSet<AdvisorEmailAddress> AdvisorEmailAddresses { get; set; }
        public DbSet<AdvisorIdentityDocument> AdvisorIdentityDocuments { get; set; }
        public DbSet<AdvisorLogin> AdvisorLogins { get; set; }
        public DbSet<AdvisorPayment> AdvisorPayments { get; set; }
        public DbSet<AdvisorPhoneNumber> AdvisorPhoneNumbers { get; set; }
        public DbSet<AdvisorRating> AdvisorRatings { get; set; }
        public DbSet<AiAreaExpertise> AiAreaExpertises { get; set; }
        public DbSet<AiErrorLog> AiErrorLogs { get; set; }
        public DbSet<AiFeedback> AiFeedbacks { get; set; }
        public DbSet<AiInteraction> AiInteractions { get; set; }
        public DbSet<AiMemory> AiMemories { get; set; }
        public DbSet<AiModel> AiModels { get; set; }
        public DbSet<AiRobot> AiRobots { get; set; }
        public DbSet<AiRobotCategory> AiRobotCategories { get; set; }
        public DbSet<AiSession> AiSessions { get; set; }
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<BusinessUnitAddress> BusinessUnitAddresses { get; set; }
        public DbSet<BusinessUnitCategory> BusinessUnitCategories { get; set; }
        public DbSet<BusinessUnitDocument> BusinessUnitDocuments { get; set; }
        public DbSet<BusinessUnitEmailAddress> BusinessUnitEmailAddresses { get; set; }
        public DbSet<BusinessUnitPhoneNumber> BusinessUnitPhoneNumbers { get; set; }
        public DbSet<BusinessUnitType> BusinessUnitTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comission> Comissions { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationPayment> ConversationPayments { get; set; }
        public DbSet<ConversationStage> ConversationStages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerAiHistory> CustomerAiHistories { get; set; }
        public DbSet<CustomerDocument> CustomerDocuments { get; set; }
        public DbSet<CustomerEmailAddress> CustomerEmailAddresses { get; set; }
        public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
        public DbSet<CustomerPayment> CustomerPayments { get; set; }
        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }
        public DbSet<CustomerPurchase> CustomerPurchases { get; set; }
        public DbSet<CustomerReview> CustomerReviews { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<DiscountCodeRedemption> DiscountCodeRedemptions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<EmailAddressType> EmailAddressTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeEmailAddress> EmployeeEmailAddresses { get; set; }
        public DbSet<EmployeePhoneNumber> EmployeePhoneNumbers { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<FinancialAccountingPeriod> FinancialAccountingPeriods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GiftCode> GiftCodes { get; set; }
        public DbSet<GiftCodeRedemption> GiftCodeRedemptions { get; set; }
        public DbSet<IdentityDocument> IdentityDocuments { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
        public DbSet<JournalEntryReference> JournalEntryReferences { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageDocument> MessageDocuments { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PaymentFrequency> PaymentFrequencies { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<PrepaidPackage> PrepaidPackages { get; set; }
        public DbSet<PrepaidPackageRedemption> PrepaidPackageRedemptions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<RatingReason> RatingReasons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RegionAreaAdvisorCategory> RegionAreaAdvisorCategories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<SerfinsaPayment> SerfinsaPayments { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<TaxInformation> TaxInformations { get; set; }
        public DbSet<TaxpayerType> TaxpayerTypes { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateCategory> TemplateCategories { get; set; }
        public DbSet<TemplateDocument> TemplateDocuments { get; set; }
        public DbSet<TemplateType> TemplateTypes { get; set; }
        public DbSet<TrainingLesson> TrainingLessons { get; set; }
        public DbSet<TrainingProgress> TrainingProgresses { get; set; }
        public DbSet<TrainingQuestion> TrainingQuestions { get; set; }
        public DbSet<TrainingQuestionOption> TrainingQuestionOptions { get; set; }
        public DbSet<TrainingQuizHistory> TrainingQuizHistories { get; set; }
        public DbSet<UnansweredConversation> UnansweredConversations { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<VoiceNoteDocument> VoiceNoteDocuments { get; set; }

        private static void PublishEvent(object sender, SavedChangesEventArgs e)
        {
            var aa = e;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.Entity<UserMembership>()
                .HasIndex(p => p.Username)
                .IsUnique();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            if (_mediator == null)
            {
                return result;
            }

            var entitiesWithEventsTracked = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntityEv<Guid>)
                .Where(e => e?.Events != null && e.Events.Any())
                .ToArray();
            var entitiesAll = ChangeTracker
                .Entries()
                .ToList();
            foreach (var entity in entitiesWithEventsTracked)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = new())
        {
            var aa = 5;
            return base.AddAsync(entity, cancellationToken);
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            return base.Add(entity);
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            return base.Attach(entity);
        }

        public override EntityEntry Attach(object entity)
        {
            return base.Attach(entity);
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            return base.Update(entity);
        }
    }
}