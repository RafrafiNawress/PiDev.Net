namespace PiDev.Domain.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Diagnostics;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public virtual DbSet<bill> bill { get; set; }
        public virtual DbSet<commentaire> commentaire { get; set; }
        public virtual DbSet<compentency> compentency { get; set; }
        public virtual DbSet<criteria> criteria { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<employeecompentency> employeecompentency { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheet { get; set; }
        public virtual DbSet<followedup> followedup { get; set; }
        public virtual DbSet<holiday> holiday { get; set; }
        public virtual DbSet<job> job { get; set; }
        public virtual DbSet<jobcompetency> jobcompetency { get; set; }
        public virtual DbSet<jobfamily> jobfamily { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<mission> mission { get; set; }
        public virtual DbSet<missionrequest> missionrequest { get; set; }
        public virtual DbSet<notification> notification { get; set; }
        public virtual DbSet<planifiedtraining> planifiedtraining { get; set; }
        public virtual DbSet<planing> planing { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<reclamation> reclamation { get; set; }
        public virtual DbSet<request> request { get; set; }
        public virtual DbSet<task> task { get; set; }
        public virtual DbSet<team> team { get; set; }
        public virtual DbSet<team_employee> team_employee { get; set; }
        public virtual DbSet<training> training { get; set; }
        public virtual DbSet<trainingcentre> trainingcentre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<commentaire>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<criteria>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.commentaire)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.idEmploye);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.team_employee)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.Employees_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<evaluationsheet>()
                .Property(e => e.typeevaluation)
                .IsUnicode(false);

            modelBuilder.Entity<evaluationsheet>()
                .HasMany(e => e.criteria)
                .WithOptional(e => e.evaluationsheet)
                .HasForeignKey(e => e.idEvaluationSheet);

            
                modelBuilder.Entity<rating>()
                    .Property(e => e.comment)
                    .IsUnicode(false);
            

            modelBuilder.Entity<team>()
                .HasMany(e => e.team_employee)
                .WithRequired(e => e.team)
                .HasForeignKey(e => e.Team_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.team_employee1)
                .WithRequired(e => e.team1)
                .HasForeignKey(e => e.Teams_id)
                .WillCascadeOnDelete(false);
        }
    }
}
