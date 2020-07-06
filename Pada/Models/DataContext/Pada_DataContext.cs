using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pada.Models
{
    public partial class Pada_DataContext : DbContext
    {
        public Pada_DataContext()
        {
        }

        public Pada_DataContext(DbContextOptions<Pada_DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityList> ActivityList { get; set; }
        public virtual DbSet<AdminSetup> AdminSetup { get; set; }
        public virtual DbSet<CompletedActivity> CompletedActivity { get; set; }
        public virtual DbSet<CompletedFmtrans> CompletedFmtrans { get; set; }
        public virtual DbSet<CompletedInvitation> CompletedInvitation { get; set; }
        public virtual DbSet<CompletedPhotoRequest> CompletedPhotoRequest { get; set; }
        public virtual DbSet<CompletedPhotoTransaction> CompletedPhotoTransaction { get; set; }
        public virtual DbSet<CompletedReportTransaction> CompletedReportTransaction { get; set; }
        public virtual DbSet<CountryStateCity> CountryStateCity { get; set; }
        public virtual DbSet<PendingActivity> PendingActivity { get; set; }
        public virtual DbSet<PendingBattleRequest> PendingBattleRequest { get; set; }
        public virtual DbSet<PendingFmtrans> PendingFmtrans { get; set; }
        public virtual DbSet<PendingInvitation> PendingInvitation { get; set; }
        public virtual DbSet<PendingPhotoRequest> PendingPhotoRequest { get; set; }
        public virtual DbSet<PendingPhotoTransaction> PendingPhotoTransaction { get; set; }
        public virtual DbSet<PendingReportTransaction> PendingReportTransaction { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalog { get; set; }
        public virtual DbSet<ReferalIncome> ReferalIncome { get; set; }
        public virtual DbSet<ReportList> ReportList { get; set; }
        public virtual DbSet<SalesTransaction> SalesTransaction { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:alexong.database.windows.net,1433;Initial Catalog=Pada_Data;Persist Security Info=False;User ID=anh.ong-tuan@tek-experts.com@alexong;Password=Anlac1997$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityList>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdminSetup>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BaseDp)
                    .HasColumnName("BaseDP")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.BaseFs)
                    .HasColumnName("BaseFS")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.BaseIncome).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ChangePhotoAwardPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ChangePhotoDeductPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ChangePhotoSubmitPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CreateActivityPostCost).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Fmdpfactor)
                    .HasColumnName("FMDPFactor")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IncomePeriodMinute)
                    .HasColumnName("IncomePeriod_Minute")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.NewFaceMashSubmitPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NewPhotoAwardPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NewPhotoDeductPoint).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ReferralAward).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ReferralIncome).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.SaturatedFaceScore).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.SendInvitationCost).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.WelcomeMessage)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompletedActivity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Activities)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateTimeCompleted).HasColumnType("datetime");

                entity.Property(e => e.InvitationId).HasColumnName("InvitationID");

                entity.Property(e => e.PartnerId)
                    .IsRequired()
                    .HasColumnName("PartnerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompletedFmtrans>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CompletedFMTrans");

                entity.Property(e => e.Chooser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatePlayed).HasColumnType("datetime");

                entity.Property(e => e.Dpoint)
                    .HasColumnName("DPoint")
                    .HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Loser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerB)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScoreLost).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ScoreWon).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Winner)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompletedInvitation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateTimeCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.FromUserId)
                    .IsRequired()
                    .HasColumnName("FromUserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<CompletedPhotoRequest>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AnyPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DateCompleted).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacePhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FullPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.NewPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.OldPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<CompletedPhotoTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeductPoint).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.JudgeId)
                    .IsRequired()
                    .HasColumnName("JudgeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoRequestId).HasColumnName("PhotoRequestID");

                entity.Property(e => e.RewardPoint).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.TimeDone).HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<CompletedReportTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateReported).HasColumnType("datetime");

                entity.Property(e => e.ReportReason)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ReportTransId).HasColumnName("ReportTransID");

                entity.Property(e => e.ReporterId)
                    .HasColumnName("ReporterID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportingId)
                    .HasColumnName("ReportingID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<CountryStateCity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PendingActivity>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Activities)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.ActivityId)
                    .HasColumnName("ActivityID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PendingBattleRequest>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BatteId)
                    .HasColumnName("BatteID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LowerPoint).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.RequestorId)
                    .IsRequired()
                    .HasColumnName("RequestorID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpperPoint).HasColumnType("decimal(10, 5)");
            });

            modelBuilder.Entity<PendingFmtrans>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PendingFMTrans");

                entity.Property(e => e.Chooser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PlayerA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerAbattleId).HasColumnName("PlayerABattleID");

                entity.Property(e => e.PlayerB)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerBbattleId).HasColumnName("PlayerBBattleID");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PendingInvitation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.FromUserId)
                    .IsRequired()
                    .HasColumnName("FromUserID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PendingPhotoRequest>(entity =>
            {
                entity.HasKey(e => e.TransactionId).HasName("Transaction ID") ;

                entity.Property(e => e.AnyPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacePhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FullPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.NewPhotoPath)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.OldPhotoPath)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PendingPhotoTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeductPoint).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.JudgeId)
                    .HasColumnName("JudgeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoRequestId).HasColumnName("PhotoRequestID");

                entity.Property(e => e.RewardPoint).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.TimeDone).HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PendingReportTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateReported).HasColumnType("datetime");

                entity.Property(e => e.ReportReason)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.ReportTransId).HasColumnName("ReportTransID");

                entity.Property(e => e.ReporterId)
                    .HasColumnName("ReporterID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportingId)
                    .HasColumnName("ReportingID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProductCatalog>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ProductValue).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<ReferalIncome>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.JuniorEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeniorEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportList>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateTimeReported).HasColumnType("datetime");

                entity.Property(e => e.FromUserId)
                    .IsRequired()
                    .HasColumnName("FromUserID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ReportId)
                    .HasColumnName("ReportID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReportingUserId)
                    .IsRequired()
                    .HasColumnName("ReportingUserID")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SalesTransaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ProductValue).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ReceiptNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.Email).HasName("Email") ;

                entity.Property(e => e.AccessToken)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActivationCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AnyPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.DailyPointGain).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.DatePoint).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacePhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.FaceScore).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.Fbemail)
                    .HasColumnName("FBEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullPhotoPath)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.HeightCm)
                    .HasColumnName("Height_cm")
                    .HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Income).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.LastDateTimeCollected).HasColumnType("datetime");

                entity.Property(e => e.LastDateTimeReported).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RatingScore).HasColumnType("decimal(11, 4)");

                entity.Property(e => e.ReferalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.WeightKg)
                    .HasColumnName("Weight_kg")
                    .HasColumnType("decimal(8, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
