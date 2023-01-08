using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Seller
        : User
    {
        public Seller(int UID1, string Email1)
            : base(UID1, Email1, nameof(Seller))
        {
        }
    }
}
