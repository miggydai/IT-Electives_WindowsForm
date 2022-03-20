using System;
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
    public partial class UnitsReports : Form
    {
        public UnitsReports()
        {
            InitializeComponent();
        }

        private void UnitsReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'UnitsDataSet1.units' table. You can move, or remove it, as needed.
            this.unitsTableAdapter.Fill(this.UnitsDataSet1.units);

            this.reportViewer1.RefreshReport();
        }
    }
}
