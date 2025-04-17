using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp {

    /**
     * The service class to manage orders
     * */
    public class OrderService {

        //the order list
        //private List<Order> orders;

        private readonly OrderContext odDb;
        public OrderService(OrderContext odDb)
        {
            this.odDb = odDb;
            
            
                if (false)
                {
                odDb.Goods.Add(new Product("apple", 100.0));
                odDb.Goods.Add(new Product("egg", 200.0));
                odDb.SaveChanges();
                }
                if (odDb.Customers.Count() == 0)
                {
                    odDb.Customers.Add(new Customer("li"));
                    odDb.Customers.Add(new Customer("zhang"));
                    odDb.SaveChanges();
                }
            
            
        }

        public List<Order> Orders {
            get {
                
                    return odDb.Orders
                      .Include(o => o.Details)
                      .ThenInclude(d=>d.Product)
                      .Include(o => o.Customer)
                      .ToList<Order>();
                
            }
        }

        public Order GetOrder(string id) {
            
                return odDb.Orders
                  .Include(o => o.Details)
                  .ThenInclude(d => d.Product)
                  .Include(o => o.Customer)
                  .SingleOrDefault(o => o.OrderId == id);
            
        }

        public void AddOrder(Order order) {
            FixOrder(order);
            
                odDb.Entry(order).State = EntityState.Added;
                odDb.SaveChanges();
            
        }

        public void RemoveOrder(string orderId) {
            
                var order = odDb.Orders.Include("Details")
                  .SingleOrDefault(o => o.OrderId == orderId);
                if (order == null) return;
                odDb.OrderDetails.RemoveRange(order.Details);
                odDb.Orders.Remove(order);
                odDb.SaveChanges();
            
        }

        public List<Order> QueryOrdersByProductName(string productsName) {
            
                return odDb.Orders
                  .Include(o => o.Details.Select(d => d.Product))
                  .Include(o => o.Customer)
                  .Where(order => order.Details.Any(item => item.Product.Name == productsName))
                  .ToList();
            
        }

        public List<Order> QueryOrdersByCustomerName(string customerName) {
            
                return odDb.Orders
                  .Include(o => o.Details)
                  .ThenInclude(d => d.Product)
                  .Include(o => o.Customer)
                  .Where(order => order.Customer.Name == customerName)
                  .ToList();
            
        }


        public List<Order> QueryByTotalPrice(float price) {
            
                return odDb.Orders
                  .Include(o => o.Details)
                  .ThenInclude(d => d.Product)//EF core中使用ThenInclude
                  .Include("Customer")
                .Where(order => order.Details.Sum(d => d.Quantity * d.Product.Price) > price)
                .ToList();
            
        }

        public void UpdateOrder(Order newOrder) {
            RemoveOrder(newOrder.OrderId);
            AddOrder(newOrder);
        }

        //避免级联添加或修改Customer和Goods
        private static void FixOrder(Order newOrder) {
            newOrder.CustomerId = newOrder.Customer.Id;
            newOrder.Customer = null;
            newOrder.Details.ForEach(d => {
                d.ProductId = d.Product.Id;
                d.Product = null;
            });
        }

        public void Export(String fileName) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path) {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) {
                
                    List<Order> temp = (List<Order>)xs.Deserialize(fs);
                    temp.ForEach(order => {
                        if (odDb.Orders.SingleOrDefault(o => o.OrderId == order.OrderId) == null) {
                            FixOrder(order);
                            odDb.Orders.Add(order);
                        }
                    });
                    odDb.SaveChanges();
                
            }
        }

    }
}
