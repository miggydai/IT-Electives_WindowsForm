using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            
        }

        


        //Items
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ItemsForm a = new ItemsForm();
            //this.Hide();
            a.Show();
        }
        //Logout
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Units
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Units b = new Units();
            //this.Hide();
            b.Show();
        }
        //Customers
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CustomersForm b = new CustomersForm();
            //this.Hide();
            b.Show();
        }
        //Vendors
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VendorsForm b = new VendorsForm();
            //this.Hide();
            b.Show();
        }
        //Users
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            UsersForm b = new UsersForm();
            //this.Hide();
            b.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else {
                Application.Exit();
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            //this.Hide();
            a.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            String b = Globals.gUserName;
            label1.Text = "Welcome "+ b + "!!";
        }



        private void vendorOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdersForm o = new OrdersForm();
            o.Show();
        }

        private void customerOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustOrdersForm c = new CustOrdersForm();
            c.Show();
        }
    }
}
