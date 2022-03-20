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
    public partial class Units : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public Units()
        {
            InitializeComponent();
        }

        private void Units_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Hide();
           
        }

        private void Units_Load(object sender, EventArgs e)
        {
            ShowTable();
        }

        public void ShowTable()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dataGridView1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from units", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // for search
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            got = filter.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            if (search.Text != "")
            {
                if (got == "Unit ID")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from units where uid = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

                if (got == "Unit Name")
                {
                    dataGridView1.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from units where uname = '" + search.Text + "'", con);
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

        //Get Data
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            uid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            uname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        //Save
        private void button1_Click(object sender, EventArgs e)
        {
            if (uname.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection


                cmd = new MySqlCommand("call saveUnits(@n)", con);
                con.Open();
       
                cmd.Parameters.AddWithValue("@n", uname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
                ShowTable();
                //ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (uname.Text != "" )
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call updateUnits(@id,@n)", con);
                con.Open();
                
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", uname.Text);
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                ShowTable();
                //ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call delUnits(@id)", con);
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


        //Clear Data
        private void ClearData()
        {
            uname.Text = "";
            id = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            UnitsReports u = new UnitsReports();
            u.Show();
        }
    }
}
