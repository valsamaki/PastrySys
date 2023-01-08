using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class DeliveryDriver
        : User
    {
        public DeliveryDriver(int UID1, string Email1)
            : base(UID1, Email1, nameof(DeliveryDriver))
        {
        }
    }
}
