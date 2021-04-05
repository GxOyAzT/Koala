using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koala.Api.Identity.Services
{
    public interface IPasswordGenerator
    {
        public string GenerateRandPass();
    }
}
