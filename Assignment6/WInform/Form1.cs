namespace WInform
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public event Action<AddForm> ShowEditForm = (f => { });
        public String Keyword { get; set; }
        public Form1()
        {
            InitializeComponent();
            InitOrders();
            bdorder.DataSource = orderService.GetAllOrders();
            textBox1.DataBindings.Add("Text", this, "Keyword");
        }
        private void InitOrders()
        {
            Order order = new Order(1, new Customer("1", "li"), new List<OrderDetail>());
            order.AddDetail(new OrderDetail(1, new Product("1", "apple", 100.0), 10));
            order.AddDetail(new OrderDetail(2, new Product("2", "egg", 50.0), 61));
            orderService.AddOrder(order);
            Order order2 = new Order(2, new Customer("2", "zhang"), new List<OrderDetail>());
            order2.AddDetail(new OrderDetail(1, new Product("2", "egg", 200.0), 10));
            orderService.AddOrder(order2);
        }
        public void QueryAll()
        {
            bdorder.DataSource = orderService.GetAllOrders();
            bdorder.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0://所有订单
                        bdorder.DataSource = orderService.GetAllOrders();
                        break;
                    case 1://根据ID查询
                        int id = Convert.ToInt32(Keyword);
                        bdorder.DataSource = orderService.GetOrder(id);
                        break;
                    case 2://根据总价格查询（大于某个总价）
                        float totalPrice = Convert.ToInt32(Keyword);
                        bdorder.DataSource = orderService.QueryByTotalAmount(totalPrice);
                        break;
                }
                bdorder.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddForm formEdit = new AddForm(new Order(), orderService);
            formEdit.Show();
        }
    }
}
