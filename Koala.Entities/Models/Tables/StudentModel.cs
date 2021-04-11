using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class StudentModel : UserParent
    {
        public List<GroupStudentModel> GroupStudentModels { get; set; }
        public List<GradeModel> GradeModels { get; set; }
    }
}
