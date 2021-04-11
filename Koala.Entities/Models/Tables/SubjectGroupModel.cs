using System;
using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class SubjectGroupModel : ParentModel
    {
        public Guid GroupModelId { get; set; }
        public GroupModel GroupModel { get; set; }

        public Guid SubjectModelId { get; set; }
        public SubjectModel SubjectModel { get; set; }

        public List<SubjectGroupTeacherModel> SubjectGroupTeacherModels{ get; set; }
    }
}