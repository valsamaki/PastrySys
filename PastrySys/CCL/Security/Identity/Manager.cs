﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Manager : Worker
    {
        public Manager(int UID1, string Email1, int FabricID1)
           : base(UID1, Email1, nameof(Manager), FabricID1)
        {
        }
    }
}



