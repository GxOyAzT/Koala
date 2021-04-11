using System;
using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class TeacherModel : UserParent
    {
        public List<SubjectGroupTeacherModel> SubjectGroupTeacherModels { get; set; }
    }
}
