using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DuckyTalk.Database
{
    public partial class DuckyTalkContext : DbContext
    {
        public DuckyTalkContext()
        {
        }

        public DuckyTalkContext(DbContextOptions<DuckyTalkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBreakReminder> UserBreakReminders { get; set; }
        public virtual DbSet<UserInterest> UserInterests { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
        public virtual DbSet<UserTechnology> UserTechnologies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DuckyTalk; Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__Techno__2B3F6F97");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserBreakReminder>(entity =>
            {
                entity.ToTable("UserBreakReminder");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBreakReminders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserBreak__UserI__3C69FB99");
            });

            modelBuilder.Entity<UserInterest>(entity =>
            {
                entity.ToTable("UserInterest");

                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.UserInterests)
                    .HasForeignKey(d => d.InterestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInter__Inter__33D4B598");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInterests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInter__UserI__32E0915F");
            });

            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.Property(e => e.dateTime).HasColumnType("datetime");

                entity.ToTable("UserMessage");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMessa__Messa__38996AB5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMessa__UserI__37A5467C");
            });

            modelBuilder.Entity<UserTechnology>(entity =>
            {
                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.UserTechnologies)
                    .HasForeignKey(d => d.TechnologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTechn__Techn__2F10007B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTechnologies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTechn__UserI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
