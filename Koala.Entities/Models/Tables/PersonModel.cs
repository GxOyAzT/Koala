using System;

namespace Koala.Entities.Models
{
    public class PersonModel : ParentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
