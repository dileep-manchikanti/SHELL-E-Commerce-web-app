using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.PaymentMethodDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using Bootcamp_Project.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_Project.Service
{
    public class OrderService
    {
        private readonly EF_DataContext _context;
        private readonly ILogger _logger;

        public OrderService(EF_DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public int CreateOrder(OrderCreationRequest request)
        {
            _logger.LogInformation("Inside CreateOrder");
            User user = _context.Users.FirstOrDefault(p => p.Id == request.userId);
            if (user == null)
            {
                throw new BadHttpRequestException("UserId is invalid");
            }
            _logger.LogInformation("User fetched");

            Cart cart = _context.Carts.FirstOrDefault(p => p.user.Id == request.userId);
            if (cart == null)
            {
                throw new BadHttpRequestException("Cart is empty or not created");
            }
            _logger.LogInformation("Cart fetched");

            Order order = new Order();
            order.user = user;
            order.totalAmount = request.totalAmount;
            order.orderStatus = OrderStatus.Initiated;
            _context.Orders.Add(order);
            _context.SaveChanges();

            AddOrderItems(cart, order);
            _logger.LogInformation("Order successfully created");
            return order.Id;
        }

        private void AddOrderItems(Cart cart, Order order)
        {
            List<CartItem> cartItems = _context.CartItems.Where(p => p.cart.Id == cart.Id).ToList();
            List<OrderItem> orderItems = new List<OrderItem>();
            cartItems.ForEach(cartItem => orderItems.Add(new OrderItem()
            {
                order = order,
                product = cartItem.product,
                quantity = cartItem.quantity
            }));

            foreach (var orderItem in orderItems)
            {
                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();
        }

        public int UpdateAddressInOrder(OrderAddressUpdate addressUpdate)
        {
            _logger.LogInformation("Inside UpdateAddressInOrder");
            Order order = _context.Orders.FirstOrDefault(p => p.status && p.Id == addressUpdate.orderId);
            if(order == null)
            {
                throw new BadHttpRequestException("OrderId is invalid");
            }

            Address address = _context.Addresses.FirstOrDefault(p => p.status && p.Id == addressUpdate.addressId);
            if(address == null)
            {
                throw new BadHttpRequestException("AddressId is invalid");
            }

            order.address = address;
            _context.Orders.Update(order);
            _context.SaveChanges();

            return addressUpdate.orderId;
        }

        public int UpdatePaymentMethodInOrder(OrderPaymentMethodUpdate paymentUpdate)
        {
            _logger.LogInformation("Inside UpdatePaymentMethodInOrder");
            Order order = _context.Orders.FirstOrDefault(p => p.status && p.Id == paymentUpdate.orderId);
            if (order == null)
            {
                throw new BadHttpRequestException("OrderId is invalid");
            }

            PaymentType paymentType = _context.PaymentTypes.FirstOrDefault(p => p.status && p.Id == paymentUpdate.paymentTypeId);

            order.paymentType = paymentType.paymentMethod;
            _context.Orders.Update(order);
            _context.SaveChanges();

            return paymentUpdate.orderId;
        }
    }
}
