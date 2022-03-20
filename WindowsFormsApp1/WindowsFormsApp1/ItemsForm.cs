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
    public partial class ItemsForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public ItemsForm()
        {
            InitializeComponent();
        }

        private void ItemsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Hide();
            
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            ShowTable();
            getCombo();
        }
        //Show table
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
        // search/filter
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            got = filter.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            
            if (search.Text != "")
            {
                if (got == "Item ID")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where ItemID = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

                if (got == "Item Name")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where iname = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

                if (got == "ID Unit")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where Unit = '" + search.Text+"'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

                if (got == "Price")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where price = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

                if (got == "Cost")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from items where cost = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

            }
            else
            {
                ShowTable();
            }
        }
        //show data
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            ItemID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            iname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            idUnit.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            price.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cost.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (iname.Text != "" && idUnit.Text != "" && price.Text != "" && cost.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection


                cmd = new MySqlCommand("call saveItems(@n,@s,@a,@b)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@n", iname.Text);
                cmd.Parameters.AddWithValue("@s", idUnit.Text);
                cmd.Parameters.AddWithValue("@a", price.Text);
                cmd.Parameters.AddWithValue("@b", cost.Text);

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

        private void getCombo() {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            cmd = new MySqlCommand("select uname from units", con);
            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                //Iterate through the rows and add it to the combobox's items
                while (reader.Read())
                {
                    idUnit.Items.Add(reader.GetString("uname"));
                }
            }

        }

        //Clear Data
        private void ClearData()
        {
            iname.Text = "";
            idUnit.Text = "";
            price.Text = "";
            cost.Text = "";
            id = 0;
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (iname.Text != "" && idUnit.Text != "" && price.Text != "" && cost.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call updateItems(@id,@n,@s,@a,@b)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", iname.Text);
                cmd.Parameters.AddWithValue("@s", idUnit.Text);
                cmd.Parameters.AddWithValue("@a", price.Text);
                cmd.Parameters.AddWithValue("@b", cost.Text);

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

        private void delete_Click(object sender, EventArgs e)
        {

            if (id != 0)
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call delItems(@id)", con);
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

        private void idUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
