using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koala.Entities.Models
{
    public class SubjectGroupTeacherModel : ParentModel
    {
        public Guid SubjectGroupModelId { get; set; }
        public SubjectGroupModel SubjectGroupModel { get; set; }

        public Guid TeacherModelId { get; set; }
        public TeacherModel TeacherModel { get; set; }

        public List<GradeTitleModel> GradeTitleModels { get; set; }
    }
}
