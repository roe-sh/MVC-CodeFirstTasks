using System.Data.Entity;

namespace MiniSchoolTask.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("rahaf") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<Class>()
                .HasRequired(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId);


            modelBuilder.Entity<Subject>()
                .HasRequired(s => s.Class)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.ClassId);

           
            modelBuilder.Entity<Tasks>()
                .HasRequired(t => t.Subject)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.SubjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
