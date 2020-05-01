using EntityLayer;
using EntityLayer.Accounts;
using EntityLayer.Credits;
using EntityLayer.Departaments;
using EntityLayer.Entity;
using EntityLayer.Persons;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<CheckingAccounts> CheckingAccounts { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Credits> Credits { get; set; }
        public virtual DbSet<EntityLayer.Departaments.Departaments> Departaments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ExpresCredit> ExpresCredit { get; set; }
        public virtual DbSet<PersonalCredit> PersonalCredit { get; set; }
        public virtual DbSet<EntityLayer.Persons.Persons> Persons { get; set; }
        public virtual DbSet<SavingAccounts> SavingAccounts { get; set; }
        public virtual DbSet<StudentCredit> StudentCredit { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clients>(client =>
            {
                client.HasKey("PersonId");
            });

            modelBuilder.Entity<Employees>(employee =>
            {
                employee.HasKey("PersonId");
            });

            #region
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Accounts__Client__30C33EC3");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CheckingAccounts>(entity =>
            {

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Interes).HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__CheckingA__Accou__32AB8735");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(c => c.PersonId);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Clients__PersonI__1F98B2C1");
            });

            modelBuilder.Entity<Credits>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Credits__ClientI__282DF8C2");
            });

            modelBuilder.Entity<EntityLayer.Departaments.Departaments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.PersonId);
                entity.Property(e => e.DepartamentId).HasColumnName("DepartamentID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Institution).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Departament)
                    .WithMany()
                    .HasForeignKey(d => d.DepartamentId)
                    .HasConstraintName("FK__Employees__Depar__1DB06A4F");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__Employees__Perso__1CBC4616");
            });

            modelBuilder.Entity<ExpresCredit>(entity =>
            {

                entity.Property(e => e.CreditId).HasColumnName("CreditID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Interes).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Credit)
                    .WithMany()
                    .HasForeignKey(d => d.CreditId)
                    .HasConstraintName("FK__ExpresCre__Credi__2BFE89A6");
            });

            modelBuilder.Entity<PersonalCredit>(entity =>
            {

                entity.Property(e => e.CreditId).HasColumnName("CreditID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Interes).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Credit)
                    .WithMany()
                    .HasForeignKey(d => d.CreditId)
                    .HasConstraintName("FK__PersonalC__Credi__2A164134");
            });

            modelBuilder.Entity<EntityLayer.Persons.Persons>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NrTel).HasMaxLength(50);

                entity.Property(e => e.PersonalNumber).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<SavingAccounts>(entity =>
            {

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Interes).HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__SavingAcc__Accou__3493CFA7");
            });

            modelBuilder.Entity<StudentCredit>(entity =>
            {
                entity.Property(e => e.CreditId).HasColumnName("CreditID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Interes).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Credit)
                    .WithMany()
                    .HasForeignKey(d => d.CreditId)
                    .HasConstraintName("FK__StudentCr__Credi__2DE6D218");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.Property(e => e.ToAccountNumber).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Transacti__Clien__25518C17");
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
