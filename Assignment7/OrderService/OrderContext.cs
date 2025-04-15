using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class  OrderContext : DbContext
    {
        public OrderContext():base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Goods { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }

}