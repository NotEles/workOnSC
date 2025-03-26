using System;
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
