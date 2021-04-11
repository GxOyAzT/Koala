using Koala.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Koala.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<PersonModel> PersonModels { get; set; }
        public DbSet<ContactModel> ContactModels { get; set; }
        public DbSet<TeacherModel> TeacherModels { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }
        public DbSet<PrincipalModel> PrincipalModels { get; set; }
        public DbSet<GroupModel> GroupModels { get; set; }
        public DbSet<GroupStudentModel> GroupStudentModels { get; set; }
        public DbSet<SemesterModel> SemesterModels { get; set; }
        public DbSet<SubjectGroupModel> SubjectGroupModels { get; set; }
        public DbSet<GradeModel> GradeModels { get; set; }
        public DbSet<SubjectGroupTeacherModel> SubjectGroupTeacherModels { get; set; }
        public DbSet<GradeTitleModel> GradeTitleModels { get; set; }
        public DbSet<SubjectModel> SubjectModels { get; set; }
    }
}
