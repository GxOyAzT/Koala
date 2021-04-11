using System.Collections.Generic;

namespace Koala.Entities.Models
{
    public class SemesterModel : ParentModel
    {
        public string Name { get; set; }

        public List<GroupModel> GroupModels { get; set; }
    }
}
