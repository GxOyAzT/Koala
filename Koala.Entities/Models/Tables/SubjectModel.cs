using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class SubjectModel : ParentModel
    {
        public string Name { get; set; }
        public List<SubjectGroupModel> SubjectGroupModels { get; set; }
    }
}
