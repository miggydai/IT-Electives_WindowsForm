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
    public partial class Form3 : Form
    {
        string id;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect con = new Connect();
            Form1 a = new Form1();
            try
            {
                if (euser.Text != "" && newpass.Text != "")
                {
                    
                    con.Open();
                    string query = "UPDATE users SET pass = '"+newpass.Text+"' WHERE name = '"+euser.Text+"';";
                    int b = con.ExecuteNonQuery(query);
                    if (b>0)
                    {    
                        MessageBox.Show("user "+euser.Text+" has been updated");
                        this.Hide();
                        a.Show();
                    }
                    else
                    {
                        MessageBox.Show("Data not found", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Form1");
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }
    }
}
