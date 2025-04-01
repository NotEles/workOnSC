using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;

class Order : IComparable<Order>
{
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> OrderDetailsList { get; set; } = new List<OrderDetails>();

    public double TotalAmount => OrderDetailsList.Sum(od => od.TotalPrice);

    public Order(int orderId, string customer)
    {
        OrderId = orderId;
        Customer = customer;
    }

    public void AddDetail(OrderDetails detail)
    {
        if (OrderDetailsList.Contains(detail))
            throw new Exception("订单明细已存在！");
        OrderDetailsList.Add(detail);
    }

    public void RemoveDetail(OrderDetails detail)
    {
        if (!OrderDetailsList.Remove(detail))
            throw new Exception("订单明细不存在！");
    }

    public override bool Equals(object obj)
    {
        if (obj is Order order)
            return OrderId == order.OrderId;
        return false;
    }

    public override int GetHashCode() => OrderId.GetHashCode();

    public override string ToString()
    {
        return $"订单号: {OrderId}, 客户: {Customer}, 总金额: {TotalAmount:C}, 明细: {string.Join(", ", OrderDetailsList)}";
    }

    public int CompareTo(Order other) => OrderId.CompareTo(other.OrderId);
}

class OrderDetails
{
    public string ProductName { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }

    public double TotalPrice => UnitPrice * Quantity;

    public OrderDetails(string productName, double unitPrice, int quantity)
    {
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public override bool Equals(object obj)
    {
        if (obj is OrderDetails details)
            return ProductName == details.ProductName;
        return false;
    }

    public override int GetHashCode() => ProductName.GetHashCode();

    public override string ToString()
    {
        return $"{ProductName} x {Quantity} (单价: {UnitPrice:C}, 总价: {TotalPrice:C})";
    }
}

class OrderService
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
            throw new Exception("订单已存在！");
        orders.Add(order);
    }

    public void RemoveOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
            throw new Exception("订单不存在！");
        orders.Remove(order);
    }

    public void UpdateOrder(int orderId, string newCustomer)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
            throw new Exception("订单不存在！");
        order.Customer = newCustomer;
    }

    public List<Order> QueryOrders(Func<Order, bool> predicate)
    {
        return orders.Where(predicate).OrderBy(o => o.TotalAmount).ToList();
    }

    public void SortOrders(Comparison<Order> comparison = null)
    {
        if (comparison == null)
            orders.Sort();
        else
            orders.Sort(comparison);
    }

    public void ShowOrders()
    {
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}


class Program
{
    static void Main()
    {
        OrderService service = new OrderService();

        // 添加订单
        Order order1 = new Order(1001, "张三");
        order1.AddDetail(new OrderDetails("苹果", 5, 10));
        order1.AddDetail(new OrderDetails("香蕉", 3, 5));

        Order order2 = new Order(1002, "李四");
        order2.AddDetail(new OrderDetails("电脑", 5000, 1));

        service.AddOrder(order1);
        service.AddOrder(order2);

        Console.WriteLine("🔹 初始订单列表:");
        service.ShowOrders();

        // 查询订单
        Console.WriteLine("\n🔹 查询客户为 '张三' 的订单:");
        var result = service.QueryOrders(o => o.Customer == "张三");
        result.ForEach(o => Console.WriteLine(o));

        // 删除订单
        service.RemoveOrder(1001);
        Console.WriteLine("\n🔹 删除订单 1001 后:");
        service.ShowOrders();

        // 排序
        service.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
        Console.WriteLine("\n🔹 按总金额降序排序:");
        service.ShowOrders();
    }
}
=======
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
>>>>>>> Edit
