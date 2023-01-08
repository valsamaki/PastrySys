using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using User = CCL.Security.Identity.User;

namespace BLL.Tests
{
    public class OrderServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new OrderService(nullUnitOfWork));
        }

        [Fact]
        public void GetOrders_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test");
            SecurityContext.SetUser(user, true);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IOrderService orderService = new OrderService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => orderService.GetOrders(0));
        }

        [Fact]
        public void GetOrder_OrderFromDAL_CorrectMappingToOrderDTO()
        {
            // Arrange
            User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user, true);
            var orderService = GetOrderService();

            // Act
            var actualOrderDTO = orderService.GetOrders(0).First();

            // Assert
            Assert.True(
                actualOrderDTO.order_id == 1
                && actualOrderDTO.seller_id == 1
                && actualOrderDTO.cost == 23.5f
                );
        }

        IOrderService GetOrderService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedOrder = new Order() { order_id = 1, seller_id = 1, cost = 23.5f, status = "Accepted"};
            var mockDbSet = new Mock<IOrderRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Order,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Order>() { expectedOrder }
                    );
            mockContext
                .Setup(context =>
                    context.Orders)
                .Returns(mockDbSet.Object);

            IOrderService orderService = new OrderService(mockContext.Object);

            return orderService;
        }
    }
}
