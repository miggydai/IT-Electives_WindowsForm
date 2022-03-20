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
    public partial class Form1 : Form
    {
        Connect con = new Connect();
        Form2 a = new Form2();
        string id;
        string name;
       //public string gname = "";
        public Form1()
        {
            InitializeComponent();
           


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (user.Text != "" && passw.Text != "")
                {

                    con.Open();
                    string query = "select * from users WHERE name ='" + user.Text + "' AND pass ='" + passw.Text + "';";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            id = row["id"].ToString();
                            name = row["name"].ToString();
                         
                        }
                        //MessageBox.Show("Hello "+ name);
                        this.Hide();
                        //gname = name;
                        Globals.gUserName = name;
                        a.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password/username", "Information");
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
    


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
         
        }

        //New Password
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 b = new Form3();
            this.Hide();
            b.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
