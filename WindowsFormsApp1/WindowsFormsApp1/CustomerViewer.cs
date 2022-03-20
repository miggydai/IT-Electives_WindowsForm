﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CustomerViewer : Form
    {
        public CustomerViewer()
        {
            InitializeComponent();
        }

        private void CustomerViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appdevDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.appdevDataSet.customers);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
