using System;

namespace Koala.Entities.Models
{
    public class GradeModel : ParentModel
    {
        public Guid GradeTitleModelId { get; set; }
        public GradeTitleModel GradeTitleModel { get; set; }

        public Guid StudentModelId { get; set; }
        public StudentModel StudentModel { get; set; }

        public double Grade { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
