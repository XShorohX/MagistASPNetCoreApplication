using Corpa4Sem4.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace PraktASPApp.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<StaffStatus> StaffStatuses { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.OpeningDate).HasColumnName("OpeningDate").HasColumnType("date").IsRequired();
                entity.Property(e => e.CurrentBalance).HasColumnName("CurrentBalance").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.OwnerId).HasColumnName("OwnerId").IsRequired();

                entity.HasOne(d => d.Owner)
                    .WithMany()
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accounts_NaturalPersons");

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeId").IsRequired();

                entity.HasOne(d => d.Type)
                    .WithMany()
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Accounts_AccountType");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Value).HasColumnName("Value").HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loans");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.PaymentDate).HasColumnName("PaymentDate").HasColumnType("date").IsRequired();
                entity.Property(e => e.DebtAmount).HasColumnName("DebtAmount").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.Closed).HasColumnName("Closed").IsRequired();
                entity.Property(e => e.AccountId).HasColumnName("AccountId").IsRequired();

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Loans_Accounts");
            });

            modelBuilder.Entity<LegalPerson>(entity =>
            {
                entity.ToTable("LegalPersons");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Address).HasColumnName("Address").HasMaxLength(255).IsRequired();
                entity.Property(e => e.CeoId).HasColumnName("CeoId");
                entity.Property(e => e.BookkeeperFullName).HasColumnName("BookkeeperFullName").HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(15);
                entity.Property(e => e.OwnershipId).HasColumnName("OwnershipId");

                entity.HasOne(d => d.Ceo)
                    .WithMany()
                    .HasForeignKey(d => d.CeoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LegalPersons_NaturalPersons_CeoId");

                entity.HasOne(d => d.Ownership)
                    .WithMany()
                    .HasForeignKey(d => d.OwnershipId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LegalPersons_Ownerships");
            });

            modelBuilder.Entity<NaturalPerson>(entity =>
            {
                entity.ToTable("NaturalPersons");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Surname).HasColumnName("Surname").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Patronymic).HasColumnName("Patronymic").HasMaxLength(50);
                entity.Property(e => e.Address).HasColumnName("Address");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(15);
                entity.Property(e => e.SexId).HasColumnName("SexId");
                entity.Property(e => e.StatusId).HasColumnName("StatusId");
                entity.Property(e => e.InStaffId).HasColumnName("InStaffId");

                entity.HasOne(d => d.Sex)
                    .WithMany()
                    .HasForeignKey(d => d.SexId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NaturalPersons_Genders");

                entity.HasOne(d => d.Status)
                    .WithMany()
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NaturalPersons_ClientStatuses");

                entity.HasOne(d => d.InStaff)
                    .WithMany()
                    .HasForeignKey(d => d.InStaffId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NaturalPersons_StaffStatuses");
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("ClientStatuses");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Value).HasColumnName("Value").HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Genders");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Value).HasColumnName("Value").HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Ownership>(entity =>
            {
                entity.ToTable("Ownerships");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Value).HasColumnName("Value").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<StaffStatus>(entity =>
            {
                entity.ToTable("StaffStatuses");

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Value).HasColumnName("Value").HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Login).HasColumnName("login").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Password).HasColumnName("password").HasMaxLength(50).IsRequired();
                entity.Property(e => e.FullName).HasColumnName("full_name").HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FromUserId).HasColumnName("from_user_id").IsRequired();
                entity.Property(e => e.ToUserId).HasColumnName("to_user_id").IsRequired();
                entity.Property(e => e.MessageHeadline).HasColumnName("message_headline").HasMaxLength(100).IsRequired();
                entity.Property(e => e.MessageText).HasColumnName("message_text").IsRequired();
                entity.Property(e => e.SendDate)
                    .HasColumnName("send_date")
                    .HasColumnType("timestamp with time zone") // Ensuring the property is of correct type
                    .IsRequired();
                entity.Property(e => e.Status).HasColumnName("status").IsRequired();

                entity.HasOne(d => d.FromUser)
                    .WithMany()
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Users_FromUserId");

                entity.HasOne(d => d.ToUser)
                    .WithMany()
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Users_ToUserId");
            });
            
            // Ensure all DateTime properties are configured to use UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetColumnType("timestamp with time zone");
                    }
                }
            }
        }
    }
}