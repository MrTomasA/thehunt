using Microsoft.EntityFrameworkCore;

namespace TheHunt.EntityFrameworkGenerator.Models
{
    public partial class TheHuntContext : DbContext
    {
        public TheHuntContext()
        {
        }

        public TheHuntContext(DbContextOptions<TheHuntContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessStream> BusinessStream { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<EducationDetail> EducationDetail { get; set; }
        public virtual DbSet<ExperienceDetails> ExperienceDetails { get; set; }
        public virtual DbSet<JobLocation> JobLocation { get; set; }
        public virtual DbSet<JobPost> JobPost { get; set; }
        public virtual DbSet<JobPostActivity> JobPostActivity { get; set; }
        public virtual DbSet<JobPostSkillSet> JobPostSkillSet { get; set; }
        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<SkillSet> SkillSet { get; set; }
        public virtual DbSet<TalentProfile> TalentProfile { get; set; }
        public virtual DbSet<TalentSkillSet> TalentSkillSet { get; set; }
        public virtual DbSet<UserAccount> UserAccount { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TheHunt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessStream>(entity =>
            {
                entity.Property(e => e.BusinessStreamName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyWebsiteUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentDate).HasColumnType("datetime");

                entity.Property(e => e.ProfileDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusinessStream)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.BusinessStreamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_BusinessStream");
            });

            modelBuilder.Entity<EducationDetail>(entity =>
            {
                entity.HasKey(e => new { e.UserAccountId, e.Major, e.CertificateDegreeName });

                entity.Property(e => e.Major)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CertificateDegreeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.Gpa).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.InstitueUniversityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartingDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.EducationDetail)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationDetail_UserAccount");
            });

            modelBuilder.Entity<ExperienceDetails>(entity =>
            {
                entity.HasKey(e => new { e.UserAccountId, e.StartDate, e.EndDate });

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.JobLocationCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobLocationCountry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobLocationState)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.ExperienceDetails)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExperienceDetails_UserAccount");
            });

            modelBuilder.Entity<JobLocation>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPost_Company");

                entity.HasOne(d => d.JobLocation)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(d => d.JobLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPost_JobLocation");

                entity.HasOne(d => d.JobType)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(d => d.JobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPost_JobType");

                entity.HasOne(d => d.PostedBy)
                    .WithMany(p => p.JobPost)
                    .HasForeignKey(d => d.PostedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPost_UserAccount");
            });

            modelBuilder.Entity<JobPostActivity>(entity =>
            {
                entity.HasKey(e => new { e.UserAccountId, e.JostPostId });

                entity.Property(e => e.ApplyDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.JobPostActivity)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPostActivity_UserAccountId");
            });

            modelBuilder.Entity<JobPostSkillSet>(entity =>
            {
                entity.HasKey(e => new { e.SkillSetId, e.JobPostId });
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillSet>(entity =>
            {
                entity.Property(e => e.SkillSetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TalentProfile>(entity =>
            {
                entity.HasKey(e => e.UserAccountId);

                entity.Property(e => e.UserAccountId).ValueGeneratedNever();

                entity.Property(e => e.Currency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAccount)
                    .WithOne(p => p.TalentProfile)
                    .HasForeignKey<TalentProfile>(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TalentProfile_UserAccount");
            });

            modelBuilder.Entity<TalentSkillSet>(entity =>
            {
                entity.HasKey(e => new { e.UserAccountId, e.SkillSetId });

                entity.HasOne(d => d.SkillSet)
                    .WithMany(p => p.TalentSkillSet)
                    .HasForeignKey(d => d.SkillSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TalentSkillSet_SkillSet");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.TalentSkillSet)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TalentSkillSet_TalentProfile");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.UserAccount)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccount_UserType");
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.UserAccountId);

                entity.Property(e => e.UserAccountId).ValueGeneratedNever();

                entity.Property(e => e.LastJobApplyDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserAccount)
                    .WithOne(p => p.UserLog)
                    .HasForeignKey<UserLog>(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLog_UserAccount");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
