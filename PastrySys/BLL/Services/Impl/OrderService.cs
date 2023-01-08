using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using System.Security.Cryptography;

namespace BLL.Services.Impl
{
    public class OrderService
        : IOrderService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public OrderService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<OrderDTO> GetOrders(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Accountant)
                && userType != typeof(Seller))
            {
                throw new MethodAccessException();
            }
            var sellerID = user.UID;
            var itemsEntities = 
                _database
            .Orders
                    .Find(z => z.seller_id == sellerID, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Order, OrderDTO>()
                    ).CreateMapper();
            var ordersDto = 
                mapper
                    .Map<IEnumerable<Order>, List<OrderDTO>>(
                        itemsEntities);
            return ordersDto;
        }

        public void AddOrder(OrderDTO order)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Manager)
                || userType != typeof(Director))
            {
                throw new MethodAccessException();
            }
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            validate(order);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var orderEntity = mapper.Map<OrderDTO, Order>(order);
            _database.Orders.Create(orderEntity);
        }

        private void validate(OrderDTO order)
        {
            if (string.IsNullOrEmpty(order.recipe))
            {
                throw new ArgumentException("Recipe повинне містити значення!");
            }
        }
    }
}
