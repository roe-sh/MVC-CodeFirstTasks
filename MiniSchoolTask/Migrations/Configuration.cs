namespace MiniSchoolTask.Migrations
{
    using MiniSchoolTask.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniSchoolTask.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(MiniSchoolTask.Models.DataContext context)
        {
            // 1. Seed the Teachers first
            context.Teachers.AddOrUpdate(
                t => t.TeacherEmail, 
                new Teachers { TeacherName = "John Doe", TeacherEmail = "john.doe@example.com", TeacherPassword = "password1" },
                new Teachers { TeacherName = "Jane Smith", TeacherEmail = "jane.smith@example.com", TeacherPassword = "password2" }
            );

            context.SaveChanges(); 

           
            var johnDoe = context.Teachers.FirstOrDefault(t => t.TeacherEmail == "john.doe@example.com");
            var janeSmith = context.Teachers.FirstOrDefault(t => t.TeacherEmail == "jane.smith@example.com");

            
            context.Classs.AddOrUpdate(
                c => c.ClassName,
                new Class { ClassName = "Math Class", Description = "Class for Mathematics", TeacherId = johnDoe.TeacherId },
                new Class { ClassName = "Science Class", Description = "Class for Science", TeacherId = janeSmith.TeacherId },
                new Class { ClassName = "History Class", Description = "Class for History", TeacherId = johnDoe.TeacherId }
            );

            context.SaveChanges(); 

            
            var mathClassId = context.Classs.FirstOrDefault(c => c.ClassName == "Math Class").ClassId;
            var scienceClassId = context.Classs.FirstOrDefault(c => c.ClassName == "Science Class").ClassId;
            var historyClassId = context.Classs.FirstOrDefault(c => c.ClassName == "History Class").ClassId;

           

            context.SaveChanges(); 
        }



    }
}
