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
    public partial class VendorsForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public VendorsForm()
        {
            InitializeComponent();
        }

        private void VendorsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.Hide();
           
        }

        private void VendorsForm_Load(object sender, EventArgs e)
        {
            ShowTable();
        }

        public void ShowTable()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dgv2.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from vendors", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgv2.DataSource = dt;
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vname.Text != "" && vadd.Text != "" && vnum.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection


                cmd = new MySqlCommand("call saveV(@n,@s,@a)", con);
                con.Open();
                int x = Int32.Parse(vnum.Text);
                cmd.Parameters.AddWithValue("@n", vname.Text);
                cmd.Parameters.AddWithValue("@s", vadd.Text);
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

        private void ClearData()
        {
            vname.Text = "";
            vadd.Text = "";
            vnum.Text = "";
            id = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vname.Text != "" && vadd.Text != "" && vnum.Text != "")
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call updateV(@id,@n,@s,@a)", con);
                con.Open();
                int x = Convert.ToInt32(vnum.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@n", vname.Text);
                cmd.Parameters.AddWithValue("@s", vadd.Text);
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


        private void button3_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection

                cmd = new MySqlCommand("call delV(@id)", con);
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

        private void dgv2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[0].Value.ToString());
            vid.Text = dgv2.Rows[e.RowIndex].Cells[0].Value.ToString();
            vname.Text = dgv2.Rows[e.RowIndex].Cells[1].Value.ToString();
            vadd.Text = dgv2.Rows[e.RowIndex].Cells[2].Value.ToString();
            vnum.Text = dgv2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            got = filter.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            if (search.Text != "")
            {
                if (got == "Vendor ID")
                {
                    dgv2.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from vendors where vid = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }

                if (got == "Vendor Name")
                {
                    dgv2.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from vendors where vname = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }

                if (got == "Vendor Address")
                {
                    dgv2.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from vendors where vadd = '" + search.Text + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }

                if (got == "Telephone Num")
                {
                    dgv2.DataSource = null;
                    MySqlDataAdapter adapter = new MySqlDataAdapter("select * from vendors where num = " + Convert.ToInt32(search.Text), con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv2.DataSource = dt;
                    con.Close();
                }

            }
            else
            {
                ShowTable();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            VendorViewer v = new VendorViewer();
            v.Show();
        }
        // Vendor Orders
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OrdersForm o = new OrdersForm();
            o.Show();
        }
    }
}
