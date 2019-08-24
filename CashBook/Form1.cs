using CashBook;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CashbookApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        public void bindData()
        {
            try
            {
                MySqlConnection conn;
                String myConnectionString = "server=localhost;userid=root;password=root;database=cashbook";

                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from cashin", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                //DataTable dbdataset = new DataTable();

                adp.Fill(ds);
                //BindingSource bSource = new BindingSource();

                //bSource.DataSource = dbdataset;
                dataGridView1.DataSource = ds.Tables[0]; //bSource;
                //dataGridView1.DataBind();
                //adp.Update(dbdataset);
                cmd.Dispose();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cashbookDataSet.cashin' table. You can move, or remove it, as needed.
            //this.cashinTableAdapter.Fill(this.cashbookDataSet.cashin);
            // TODO: This line of code loads data into the 'cashbookDataSet.cashin' table. You can move, or remove it, as needed.
            // this.cashinTableAdapter.Fill(this.cashbookDataSet.cashin);
            bindData();
            string startdate = dateTimePicker1.Value.ToShortDateString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            bindData();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }

        private void customerFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f2 = new Form3();
            f2.Show();
        }
    }
}

