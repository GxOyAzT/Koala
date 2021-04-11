using System;

namespace Koala.Entities.Models
{
    public abstract class UserParent : ParentModel
    {
        public Guid PersonModelId { get; set; }
        public PersonModel PersonModel { get; set; }

        public Guid ContactModelId { get; set; }
        public ContactModel ContactModel { get; set; }
    }
}
