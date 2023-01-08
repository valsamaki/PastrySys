using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private FabricContext db;
        private FabricRepository fabricRepository;
        private ProductRepository productRepository;
        private GatheringRepository gatheringRepository;
        private PlanRepository planRepository;
        private OrderRepository orderRepository;
        private PaymentRepository paymentRepository;

        public EFUnitOfWork(FabricContext context)
        {
            db = context;
        }
        public IFabricRepository Fabrics
        {
            get
            {
                if (fabricRepository == null)
                    fabricRepository = new FabricRepository(db);
                return fabricRepository;
            }
        }
        public IGatheringRepository Gatherings
        {
            get
            {
                if (gatheringRepository == null)
                    gatheringRepository = new GatheringRepository(db);
                return gatheringRepository;
            }
        }
        public IProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public IPlanRepository Plans
        {
            get
            {
                if (planRepository == null)
                    planRepository = new PlanRepository(db);
                return planRepository;
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IPaymentRepository Payments
        {
            get
            {
                if (paymentRepository == null)
                    paymentRepository = new PaymentRepository(db);
                return paymentRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
