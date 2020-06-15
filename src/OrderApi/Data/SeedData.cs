using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApi.Models;

namespace OrderApi.Data
{
    public class SeedData
    {
        public static async Task Initialize(OrderContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Orders.Any())
            {
                await context.AddAsync(new Order
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.Preparing,
                    Address = "Address",
                    PaymentAuthCode = "Code",
                    Total = 99.9M,
                    Note = "a",
                    OrderItems = new List<OrderItem>{
                        new OrderItem(1, "Muỗng basic",99.9M, "PictureUrl",null, OrderItemStatus.Preparing)
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}