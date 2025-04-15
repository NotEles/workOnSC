using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderApp;

namespace OrderForm {
  public partial class FormDetailEdit : Form {
    public OrderDetail Detail { get; set; }

    public FormDetailEdit() {
      InitializeComponent();
    }

    public FormDetailEdit(OrderDetail detail,OrderService os):this() {
      this.Detail = detail;
      this.bdsDetail.DataSource = detail;
            bdsGoods.DataSource = os.ProductList;
    }

    private void btnOK_Click(object sender, EventArgs e) {

    }
  }
}
