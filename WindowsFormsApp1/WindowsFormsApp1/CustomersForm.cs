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
    public partial class CustomersForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            this.Hide();
            

        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            ShowTable();

        }


        public void ShowTable() {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dgv1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from customers", con);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            dgv1.DataSource = dt;
            con.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //Insert Data
        private void button1_Click(object sender, EventArgs e)
        {
            if (cname.Text != "" && cadd.Text != "" && cnum.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
                
                cmd = new MySqlCommand("call saveC(@n,@s,@a)", con);
                con.Open();
                int x = Int32.Parse(cnum.Text);
                cmd.Parameters.AddWithValue("@n", cname.Text);
                cmd.Parameters.AddWithValue("@s", cadd.Text);
                cmd.Parameters.AddWithValue("@a", x);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                ShowTable();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }
        //Clear Data
        private void ClearData()
        {
            cname.Text = "";
            cadd.Text = "";
            cnum.Text = "";
            id = 0;
        }

        //Select Row
        private void dgv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[0].Value.ToString());
            cid.Text = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cname.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cadd.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cnum.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (cname.Text != "" && cadd.Text != "" && cnum.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call updateC(@id,@n,@s,@a)", con);
                con.Open();
                int x = Convert.ToInt32(cnum.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", cname.Text);
                cmd.Parameters.AddWithValue("@s", cadd.Text);
                cmd.Parameters.AddWithValue("@a", x);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                ShowTable();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        //Delete Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call delC(@id)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                ShowTable();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        // search button
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            got = filter.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            if (search.Text != "")
            {
                if (got == "Customer ID")
                {
                    dgv1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from customers where cid = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv1.DataSource = dt;
                    con.Close();
                }

                if (got == "Customer Name")
                {
                    dgv1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from customers where cname = '" + search.Text+"'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv1.DataSource = dt;
                    con.Close();
                }

                if (got == "Customer Address")
                {
                    dgv1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from customers where cadd = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv1.DataSource = dt;
                    con.Close();
                }

                if (got == "Telephone Num")
                {
                    dgv1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from customers where telephoneNum = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv1.DataSource = dt;
                    con.Close();
                }

            }
            else {
                ShowTable();
            }
        }

        private void filter_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CustomerViewer c = new CustomerViewer();
            c.Show();

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CustOrdersForm c = new CustOrdersForm();
            c.Show();
        }
    }
}
