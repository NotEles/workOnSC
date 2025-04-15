using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Data.Entity;
using Mysqlx.Crud;

namespace OrderApp {

    /**
     * The service class to manage orders
     * */
    public class OrderService {

        //the order list
        private List<Order> orders;


        public OrderService() {
            using (var ctx = new OrderContext())
            {
                if (ctx.Goods.Count() == 0)
                {
                    ctx.Goods.Add(new Product("apple", 100.0));
                    ctx.Goods.Add(new Product("egg", 200.0));
                    ctx.SaveChanges();
                }
                if (ctx.Customers.Count() == 0)
                {
                    ctx.Customers.Add(new Customer("li"));
                    ctx.Customers.Add(new Customer("zhang"));
                    ctx.SaveChanges();
                }
                
            } 
        }
        public List<Order> Orders {
                get{
                    using (var ctx = new OrderContext())
                    {
                    return ctx.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Details.Select(od => od.ProductItem))
                    .ToList();
                    }
                }
            }
        
        public List<Customer> CustomerList
        {
            get
            {
                using (var ctx = new OrderContext())
                {
                    return ctx.Customers
                    .ToList();
                }
            }
        }
        public List<Product> ProductList
        {
            get
            {
                using (var ctx = new OrderContext())
                {
                    return ctx.Goods
                    .ToList();
                }
            }
        }
        //here

        public List<Order> GetAllOrders() {
            return Orders;
        }


        public Order GetOrder(string id) {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                    .Include(o=>o.Details.Select(od => od.ProductItem))
                    .Include(o=>o.Customer)
                    .SingleOrDefault(o=>o.OrderId == id);
            }
            ;
        }

        private static void FixOrder(Order newOrder)
        {
            newOrder.CustomerId = newOrder.Customer.ID;
            newOrder.Customer = null;
            newOrder.Details.ForEach(d => { d.ProductId = d.ProductItem.ID; d.ProductItem = null; });
        }

        public void AddOrder(Order order) {
            FixOrder(order);
            using(var ctx=new OrderContext())
            {
                ctx.Entry(order).State= EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public void RemoveOrder(string orderId) {
            using (var ctx= new OrderContext())
            {
                var order = ctx.Orders.Include("Details").SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                ctx.OrderDetails.RemoveRange(order.Details);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
        }

        public List<Order> QueryOrdersByProductName(string productName) {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                    .Include(o=>o.Details.Select(d=>d.ProductItem))
                    .Include(o=> o.Customer)
                    .Where(o=>o.Details.Any(item=>item.ProductItem.Name==productName))
                    .ToList();
            }
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            using(var ctx= new OrderContext())
            {
                return ctx.Orders
                    .Include("Customer")
                    .Include(o => o.Details.Select(d => d.ProductItem))
                    .Where(o => o.Customer.Name == customerName)
                    .ToList();
            }
        }

        public void UpdateOrder(Order newOrder) {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
        }

        public void Export(String fileName) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                xs.Serialize(fs, orders);
            }
        }

        public void Import(string path) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!orders.Contains(order)) {
                        orders.Add(order);
                    }
                });
            }
        }

        public object QueryByTotalAmount(float amout)
        { using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.ProductItem)) //EF core中使用ThenInclude
                  .Include("Customer")
                .Where(order => order.Details.Sum(d => d.Quantity * d.ProductItem.Price) > amout)
                .ToList();
            }
}
    }
}
