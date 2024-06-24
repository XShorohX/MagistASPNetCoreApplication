using Corpa4Sem4.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PraktASPApp.Database
{
    public class ApplicationContext : DbContext
    {
        

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

        public DbSet<User>? Users { get; set; }
        public DbSet<Message>? Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			var options = new
			{
				Server = "127.0.0.1:5432",
				Database = "messages_db",
				User = "postgres",
				Password = "postpunk",
			};

			optionsBuilder.UseNpgsql($"Server = {options.Server}; Database ={options.Database}; Uid = {options.User}; Pwd = {options.Password};");
		}
        */
    }
}
