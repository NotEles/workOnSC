using System;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int price{ get; set; }
    public Product(int id, string name, int price)
    {
        Id = id;
        Name = name;
        this.price = price;
    }
    public override bool Equals(object? obj)
    {
        var pro = obj as Product;
        return pro!=null&&this.Id == pro.Id;
    }
    public override int GetHashCode()
    {
        return this.Id.GetHashCode()+7586;
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
    public OrderDetails(int Id,int price,string name,int quentity)
    {
        product = new Product(Id, name, price);
        this.quentity = quentity;
        TotalPrice = quentity * price;
    }
    public override bool Equals(object? obj)
    {
        var od = obj as OrderDetails;
        return od != null && od.quentity == this.quentity && od.product == this.product;
    }
    public override int GetHashCode()
    {
        return this.product.GetHashCode()+this.quentity;
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
        return this.Id.GetHashCode()+7;
    }
    public override string ToString()
    {
        return $"cusId:{this.Id},cusName:{this.Name}";
    }
}

class Order
{
    public List<OrderDetails> oderDetailsList=new List<OrderDetails>();
    public int Id { get; set; }
    public int TotalPrice { get => oderDetailsList.Sum(d => d.TotalPrice); }
    public Customer customer { get; set; }
}