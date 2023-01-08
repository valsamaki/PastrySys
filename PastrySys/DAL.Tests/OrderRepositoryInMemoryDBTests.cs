using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Remotion.Linq;

namespace DAL.Tests
{
    public class OrderRepositoryInMemoryDBTests
    {
        public FabricContext Context => SqlLiteInMemoryContext();

        private FabricContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<FabricContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new FabricContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputOrderWithId0_SetItemId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IOrderRepository repository = uow.Orders;

            Order order = new Order()
            {
                order_id = 5,
                seller_id = 1,
                status = "Accepted",
                cost = 3.5f,
                amount = 300,
                recipe = "Lorem ipsum",
                deadline = new DateTime(233242),
                product = new Product() { product_id = 1, status = "Stored" },
    };

            //Act
            repository.Create(order);
            uow.Save();
            var factListCount = context.products.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistOrderId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IOrderRepository repository = uow.Orders;
            Order order = new Order()
            {
                //order_id = 2,
                seller_id = 1,
                status = "Accepted",
                cost = 3.5f,
                amount = 300,
                recipe = "Lorem ipsum",
                deadline = new DateTime(233242),
                product = new Product() { product_id = 1, status = "Stored" },
            };
            context.orders.Add(order);
            context.SaveChanges();

            //Act
            repository.Delete(order.order_id);
            uow.Save();
            var factStreetCount = context.orders.Count();

            // Assert
            Assert.Equal(expectedListCount, factStreetCount);
        }

        [Fact]
        public void Get_InputExistOrderId_ReturnOrder()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IOrderRepository repository = uow.Orders;
            Order expectedOrder = new Order()
            {
                //order_id = 2,
                seller_id = 1,
                status = "Accepted",
                cost = 3.5f,
                amount = 300,
                recipe = "Lorem ipsum",
                deadline = new DateTime(233242),
                product = new Product() { product_id = 1, status = "Stored" },
            };
            context.orders.Add(expectedOrder);
            context.SaveChanges();

            //Act
            var factOrder = repository.Get(expectedOrder.order_id);

            // Assert
            Assert.Equal(expectedOrder, factOrder);
        }
    }
}
