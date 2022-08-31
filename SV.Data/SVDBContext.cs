using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SV.Models.Entities;

#nullable disable

namespace SV.Data
{
    public partial class SVDBContext : IdentityDbContext
    {
        public SVDBContext(DbContextOptions<SVDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyResponseProfile> SurveyResponseProfiles { get; set; }
        public virtual DbSet<UserShareSurvey> UserShareSurveys { get; set; }
        public virtual DbSet<SurveySharedWithCustomers> SurveySharedWithCustomers { get; set; }
        public virtual DbSet<UserLogs> UserLogs { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<UserDepartments> UserDepartments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.DocPath).IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Question_Answer");

                entity.HasOne(d => d.SurveyResponseProfile)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.SurveyResponseProfileId)
                    .HasConstraintName("FK_SurveyResponseProfile_Answer");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SenderName).HasMaxLength(60);

                entity.Property(e => e.Subject).HasMaxLength(256);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.CssClass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocPath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.LogicalQuestionText).HasMaxLength(256);

                entity.Property(e => e.OptionsAlignment)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentQuestion)
                    .WithMany(p => p.InverseParentQuestion)
                    .HasForeignKey(d => d.ParentQuestionId)
                    .HasConstraintName("FK_Question_ToQuestion");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_Survey_Question");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.BackgroundImagePath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.BannerPath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LogoPath)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<SurveyResponseProfile>(entity =>
            {
                entity.ToTable("SurveyResponseProfile");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Full Name");

                entity.Property(e => e.ResponseOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserShareSurvey>(entity =>
            {
                entity.ToTable("UserShareSurvey");

                entity.HasIndex(e => new { e.UserId, e.SurveyId }, "UC_User_Survey")
                    .IsUnique();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.UserShareSurveys)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_SurveyUserShare_Survey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
