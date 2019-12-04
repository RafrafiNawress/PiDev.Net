namespace PiDev.Data
{
    using Domain.Entites;
    using Domain.Entities;
    using System.Data.Entity;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<commentaire> commentaires { get; set; }
        public virtual DbSet<compentency> compentencies { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<employeecompentency> employeecompentencies { get; set; }
        public virtual DbSet<evaluationsheet> evaluationsheets { get; set; }
        public virtual DbSet<followedup> followedups { get; set; }
        public virtual DbSet<holiday> holidays { get; set; }
        public virtual DbSet<job> jobs { get; set; }
        public virtual DbSet<jobcompetency> jobcompetencies { get; set; }
        public virtual DbSet<jobfamily> jobfamilies { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<missionrequest> missionrequests { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<planifiedtraining> planifiedtrainings { get; set; }
        public virtual DbSet<planing> planings { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<reclamation> reclamations { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<training> trainings { get; set; }
        public virtual DbSet<trainingcentre> trainingcentres { get; set; }
        public virtual DbSet<claim> claims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.teams)
                .WithMany(e => e.employees)
                .Map(m => m.ToTable("team_employee", "pidev").MapLeftKey("Employees_id").MapRightKey("Teams_id"));
        }
    }
}
