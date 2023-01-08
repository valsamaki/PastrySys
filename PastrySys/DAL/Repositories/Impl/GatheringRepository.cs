using DAL.Entities;
using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Impl
{
    public class GatheringRepository : BaseRepository<Gathering>, IGatheringRepository
    {
        internal GatheringRepository(FabricContext context) : base(context)
        {
        }
    }
}
