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
    public partial class CustOrdersForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public CustOrdersForm()
        {
            InitializeComponent();
        }
        //addOrder
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            got = getVendor.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            if (got == "Select Customer")
            {
                MessageBox.Show("Select a Customer!!");
            }
            else
            {
                cmd = new MySqlCommand("call createOrderCust(@n)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@n", got);
                cmd.ExecuteNonQuery();
                con.Close();
                // MessageBox.Show("Record Inserted Successfully");
                //i.Show();
                ShowTable();
            }
        }


        public void ShowTable()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dgvO.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select OrderID,OrderDate,Customer from orders where Vendor is null", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvO.DataSource = dt;
            con.Close();

        }


        private void getCombo()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            cmd = new MySqlCommand("select cname from customers", con);
            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                //Iterate through the rows and add it to the combobox's items
                while (reader.Read())
                {
                    getVendor.ComboBox.Items.Add(reader.GetString("cname"));
                }
            }

        }

        private void CustOrdersForm_Load(object sender, EventArgs e)
        {
            getCombo();
            ShowTable();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PurchaseForm p = new PurchaseForm();
            p.Show();
        }

        private void dgvO_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgvO.Rows[e.RowIndex].Cells[0].Value.ToString());
            Globals.OrderID = id;
        }
    }
}
