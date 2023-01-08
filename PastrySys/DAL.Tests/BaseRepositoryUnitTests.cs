using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestOrderRepository
        : BaseRepository<Order>
    {
        public TestOrderRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputOrderInstance_CalledAddMethodOfDBSetWithOrderInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FabricContext>()
                .Options;
            var mockContext = new Mock<FabricContext>(opt);
            var mockDbSet = new Mock<DbSet<Order>>();
            mockContext
                .Setup(context => 
                    context.Set<Order>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestOrderRepository(mockContext.Object);

            Order expectedOrder = new Mock<Order>().Object;

            //Act
            repository.Create(expectedOrder);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedOrder
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FabricContext>()
                .Options;
            var mockContext = new Mock<FabricContext>(opt);
            var mockDbSet = new Mock<DbSet<Order>>();
            mockContext
                .Setup(context =>
                    context.Set<Order>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IItemRepository repository = uow.Items;
            var repository = new TestOrderRepository(mockContext.Object);

            Order expectedOrder = new Order() { order_id = 1};
            mockDbSet.Setup(mock => mock.Find(expectedOrder.order_id)).Returns(expectedOrder);

            //Act
            repository.Delete(expectedOrder.order_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedOrder.order_id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedOrder
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<FabricContext>()
                .Options;
            var mockContext = new Mock<FabricContext>(opt);
            var mockDbSet = new Mock<DbSet<Order>>();
            mockContext
                .Setup(context =>
                    context.Set<Order>(
                        ))
                .Returns(mockDbSet.Object);

            Order expectedOrder = new Order() { order_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedOrder.order_id))
                    .Returns(expectedOrder);
            var repository = new TestOrderRepository(mockContext.Object);

            //Act
            var actualOrder = repository.Get(expectedOrder.order_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedOrder.order_id
                    ), Times.Once());
            Assert.Equal(expectedOrder, actualOrder);
        }

      
    }
}
