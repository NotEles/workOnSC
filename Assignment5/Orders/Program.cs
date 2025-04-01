using System;
using System.Text;
namespace pr
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int price { get; set; }
        public Product(int id, string name, int price)
        {
            Id = id;
            Name = name;
            this.price = price;
        }
        public override bool Equals(object? obj)
        {
            var pro = obj as Product;
            return pro != null && this.Id == pro.Id;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + 7586;
        }
        public override string ToString()
        {
            return $"ProId:{this.Id},ProName:{this.Name},Price:{this.price}";
        }
    }



    class OrderDetails
    {
        public Product product;
        public int TotalPrice { get; set; }
        public int quentity { get; set; }
        public OrderDetails(int Id, int price, string name, int quentity)
        {
            product = new Product(Id, name, price);
            this.quentity = quentity;
            TotalPrice = quentity * price;
        }
        public OrderDetails(Product pro, int qu)
        {
            product = pro;
            quentity = qu;
        }
        public override bool Equals(object? obj)
        {
            var od = obj as OrderDetails;
            return od != null && od.quentity == this.quentity && od.product == this.product;
        }
        public override int GetHashCode()
        {
            return this.product.GetHashCode() + this.quentity;
        }
        public override string ToString()
        {
            return this.product.ToString() + $"quentity:{this.quentity}";
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            var cu = obj as Customer;
            return cu != null && cu.Id == this.Id && cu.Name == this.Name;
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + 7;
        }
        public override string ToString()
        {
            return $"cusId:{this.Id},cusName:{this.Name}";
        }
    }

    class Order : IComparable<Order>
    {
        public List<OrderDetails> oderDetailsList = new List<OrderDetails>();
        public int Id { get; set; }
        public int TotalPrice { get => oderDetailsList.Sum(d => d.TotalPrice); }
        public Customer customer { get; set; }
        public Order() { }
        public Order(int id, Customer customer)
        {

            Id = id;
            this.customer = customer;
        }
        public void AddOrdersDetails(OrderDetails od)
        {
            if (oderDetailsList.Contains(od))
                throw new ApplicationException($"the order {od.product.Name} has already exited");
            oderDetailsList.Add(od);
        }
        public int CompareTo(Order ot)
        {
            return (ot == null) ? 1 : Id - ot.Id;
        }
        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void RemoveDetails(int num)
        {
            oderDetailsList.RemoveAt(num);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"orderId:{Id}, customer:({customer})");
            oderDetailsList.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }
    }

    class OrderService
    {
        public List<Order> orders = new List<Order>();
        public OrderService() { }
        public void AddOrder(Order ord)
        {
            if (orders.Contains(ord))
            {
                throw new ApplicationException($"the order{ord.Id} has already exited");
            }
            orders.Add(ord);
        }
        public void Update(Order ord)
        {
            int idx = orders.FindIndex(o => o.Id == ord.Id);
            if (idx < 0)
                throw new ApplicationException($"not in the orders");
            orders.RemoveAt(idx);
            orders.Add(ord);
        }

        public Order GetOrder(int idx)
        {
            return orders.FirstOrDefault(o => o.Id == idx);
        }
        public void RemoveById(int idx)
        {
            int id = orders.FindIndex(o => o.Id == idx);
            if (id > 0)
                orders.RemoveAt(id);
        }
        public List<Order> QueryByCusName(string nam)
        {
            var querry = orders.Where(o => o.customer.Name == nam).OrderBy(o => o.TotalPrice);
            return querry.ToList();
        }
        public List<Order> QueryByProductName(string productName)
        {
            var query = orders.Where(
              o => o.oderDetailsList.Any(d => d.product.Name == productName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> QueryByPrice(int topri)
        {
            var query = orders.Where(o => o.TotalPrice >= topri).OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> QueryAll()
        {
            return orders;
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Product milk = new Product(1, "Milk", 69);
                Product eggs = new Product(2, "eggs", 4);
                Product apple = new Product(3, "apple", 5);

                Order order1 = new Order(1, customer1);
                order1.AddOrdersDetails(new OrderDetails(apple, 8));
                order1.AddOrdersDetails(new OrderDetails(eggs, 10));
                //order1.AddDetails(new OrderDetail(eggs, 8));
                //order1.AddDetails(new OrderDetail(milk, 10));

                Order order2 = new Order()
                {
                    Id = 2,
                    customer = customer2,

                    oderDetailsList = { new OrderDetails(eggs, 10), new OrderDetails(milk, 10) }
                };

                Order order3 = new Order(3, customer2);
                order3.AddOrdersDetails(new OrderDetails(milk, 100));

                OrderService orderService = new OrderService();
                orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);

                Console.WriteLine("\n GetOrder");
                Console.WriteLine(orderService.GetOrder(1));
                Console.WriteLine(orderService.GetOrder(5) == null);

                Console.WriteLine("\nGetAllOrders");
                List<Order> orders = orderService.QueryAll();
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByCustomerName:'Customer2'");
                orders = orderService.QueryByCusName("Customer2");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersByProductName:'eggs'");
                orders = orderService.QueryByProductName("eggs");
                orders.ForEach(o => Console.WriteLine(o));

                Console.WriteLine("\nGetOrdersTotalAmount:1000");
                orders = orderService.QueryByPrice(1000);
                orders.ForEach(o => Console.WriteLine(o));



                Console.WriteLine("\nRemove order(id=2) and qurey all");
                orderService.RemoveById(2);
                orderService.QueryAll().ForEach(
                    o => Console.WriteLine(o));



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
