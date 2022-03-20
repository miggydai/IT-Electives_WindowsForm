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
    public partial class PurchaseForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        int order = 0;
        int pid = 0;
        string got;
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void ChooseItem_Load(object sender, EventArgs e)
        {
            ShowTable();
            ShowTable2();
            ShowTable3();
            oid.Text = Globals.OrderID.ToString();

        }
        //show Items
        public void ShowTable()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dataGridView1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Globals.ProdID = id;
            System.Console.WriteLine(Globals.ProdID);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //add to cart
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection


            cmd = new MySqlCommand("call addPurchase(@n,@s,@a)", con);
            con.Open();
            int x = Int32.Parse(qty.Text);
            cmd.Parameters.AddWithValue("@n", Globals.OrderID);
            cmd.Parameters.AddWithValue("@s", Globals.ProdID);
            cmd.Parameters.AddWithValue("@a", x);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
            ShowTable2();
            ShowTable3();
            ClearData();
        }

        //your Orders
        public void ShowTable2()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dataGridView2.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select OrderNum, ItemID, iname AS Item, OrderQty, Unit, items.cost as Cost, purchase_order.cost as Total from items, orders, purchase_order where orders.OrderID = purchase_order.OrderID and ProdID = ItemID and purchase_order.OrderID = "+Globals.OrderID, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }
        //Show Total
        public void ShowTable3()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            cmd = new MySqlCommand("select sum(cost) AS Total_Amount from purchase_order where OrderID = "+Globals.OrderID, con);
            con.Open();
               
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                        total.Text = (reader.GetString("Total_Amount"));
                        }
                        catch (Exception e) {
                        System.Console.WriteLine("hehe");
                        }
                    

                    }

                }
           
            con.Close();

        }
        //update
        private void update_Click(object sender, EventArgs e)
        {
            if (updateqty.Text != "") {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call updatePurchase(@id,@n,@p)", con);
                con.Open();
                int x = Int32.Parse(updateqty.Text);
                cmd.Parameters.AddWithValue("@id", order);
                cmd.Parameters.AddWithValue("@n", x);
                cmd.Parameters.AddWithValue("@p", pid);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                ShowTable2();
                ShowTable3();


            }
        }
        //delete
        private void delete_Click(object sender, EventArgs e)
        {
            if (order != 0)
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call delPurchase(@id)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", order);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                ShowTable2();
                ShowTable3();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            order = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            updateqty.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            pid = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()); //productid
            System.Console.WriteLine(order);
        }

        private void ClearData()
        {
            //total.Text = "";
            qty.Text = "";
            
        }
        // Print Report
        private void button3_Click(object sender, EventArgs e)
        {
            OrderPrint rr = new OrderPrint();
            rr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //search
        private void button4_Click(object sender, EventArgs e)
        {
            if (search.Text != "")
            {
                got = search.Text;
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
                con.Open();

                dataGridView1.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where iname='" + got + "'", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            else {
                ShowTable();
            }
        }
    }


}
