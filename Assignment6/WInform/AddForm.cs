using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInform
{
    public partial class AddForm : Form
    {
        public event Action<AddForm> CloseEditFrom = (f => { });

        private OrderService os = new OrderService();
        public Order CurrentOrder { get; set; }
        public AddForm(Order oRD, OrderService oS)
        {
            InitializeComponent();

            dbCustomers.Add(new Customer("1", "li"));
            dbCustomers.Add(new Customer("2", "zhang"));
            this.CurrentOrder = oRD;
            bdorders.DataSource = CurrentOrder;
            this.os = oS;
            textBox1.DataBindings.Add("Text", this.bdorders, "OrderId");
            comboBox1.DataBindings.Add("SelectedItem", this.bdorders, "Customer");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditForm formDetailEdit = new EditForm(new OrderDetail());
            try
            {
                if (formDetailEdit.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    if (CurrentOrder.Details.Count != 0)
                    {
                        index = CurrentOrder.Details.Max(i => i.Index) + 1;
                    }
                    formDetailEdit.od.Index = index;
                    CurrentOrder.AddDetail(formDetailEdit.od);
                    dbdetails.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                os.AddOrder(CurrentOrder);
                this.Close();


            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }

        private void dbCustomers_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
