using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFabricRepository Fabrics { get; }
        IProductRepository Products { get; }
        IGatheringRepository Gatherings { get; }
        IPlanRepository Plans { get; }
        IOrderRepository Orders { get; }
        IPaymentRepository Payments { get; }
        void Save();
    }
}

