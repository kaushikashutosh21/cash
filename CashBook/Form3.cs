using CashbookApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashBook
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void customerFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 myform1 = new Form1();
            myform1.Show();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
