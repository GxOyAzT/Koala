using System;
using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class GroupModel : ParentModel
    {
        public Guid SemesterModelId { get; set; }
        public SemesterModel SemesterModel { get; set; }

        public List<GroupStudentModel> GroupStudentModels { get; set; }
        public List<SubjectGroupModel> SubjectGroupModels { get; set; }

        public string Name { get; set; }
    }
}
