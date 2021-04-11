using System;
using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class GradeTitleModel : ParentModel
    {
        public Guid SubjectGroupTeacherModelId { get; set; }
        public SubjectGroupTeacherModel SubjectGroupTeacherModel { get; set; }

        public List<GradeModel> GradeModels { get; set; }

        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public double Weight { get; set; }
    }
}
