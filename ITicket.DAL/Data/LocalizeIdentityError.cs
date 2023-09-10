using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITicket.DAL.Data
{
    public class LocalizeIdentityError : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Description = "Email təkrarlana bilməz",
                Code = "101"
            };
        }

    }
}
