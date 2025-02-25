using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcuOnWin
{
    public partial class Form1: Form
    {
        int add1, add2, sum;
        string tem;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tem = textBox1.Text;
            add1 = int.Parse(tem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case '+' :
                    sum = add1 + add2;
                    break;
                case '-':
                    sum = add1 - add2;
                    break;
                case '*':
                    sum = add1 * add2;
                    break;

            }
                 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = sum.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tem = textBox2.Text;
            add2 = int.Parse(tem);
        }
    }
}
