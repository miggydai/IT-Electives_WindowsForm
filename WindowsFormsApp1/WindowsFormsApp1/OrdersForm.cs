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
    public partial class OrdersForm : Form
    {
        int id = 0;
        MySqlCommand cmd;
        string got;
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {

            getCombo();
            ShowTable();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void getCombo()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            cmd = new MySqlCommand("select vname from vendors", con);
            con.Open();
            using (var reader = cmd.ExecuteReader())
            {
                //Iterate through the rows and add it to the combobox's items
                while (reader.Read())
                {
                    getVendor.ComboBox.Items.Add(reader.GetString("vname"));
                }
            }

        }
        //Add Order
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PurchaseForm i = new PurchaseForm();
            got = getVendor.ComboBox.SelectedItem.ToString();
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            if (got == "select vendor")
            {
                MessageBox.Show("Select a Vendor!!");
            }
            else {
                cmd = new MySqlCommand("call createOrder(@n)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@n", got);
                cmd.ExecuteNonQuery();
                con.Close();
                // MessageBox.Show("Record Inserted Successfully");
                //i.Show();
                ShowTable();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PurchaseForm p = new PurchaseForm();
            p.Show();

        }


        public void ShowTable()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=appdev;port=3306; username = root; password= AyayaMeg0521!"); //open connection
            con.Open();

            dgvO.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select OrderID,OrderDate,Vendor from orders where Customer is null", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvO.DataSource = dt;
            con.Close();

        }

        private void dgvO_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dgvO.Rows[e.RowIndex].Cells[0].Value.ToString());
            Globals.OrderID = id;
        }
    }
}
