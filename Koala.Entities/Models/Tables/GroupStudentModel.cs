using System;

namespace Koala.Entities.Models
{
    public class GroupStudentModel : ParentModel
    {
        public Guid GroupModelId { get; set; }
        public GroupModel GroupModel { get; set; }

        public Guid StudentModelId { get; set; }
        public StudentModel StudentModel { get; set; }
    }
}
