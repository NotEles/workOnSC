using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WInform
{
    public partial class EditForm : Form
    {
        public OrderDetail od { get; set; }
        public Product pr;
        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(OrderDetail detail) : this()
        {

            this.od = detail;
            this.bdDetails.DataSource = detail;
            bdPro.Add(new Product("1", "apple", 100.0));
            bdPro.Add(new Product("2", "egg", 200.0));
            textBox1.DataBindings.Add("Text", this.bdDetails, "Quantity");
            comboBox1.DataBindings.Add("SelectedItem", this.bdDetails, "ProductItem");
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
