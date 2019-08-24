using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CashbookApp;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private MySqlConnection objConnection;
        private string server, database, uid, password;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            OpenConnection();
            string query = "SELECT * FROM tbl_user where u_name ='" + txtUserId.Text + "' and u_password='"+ txtPassword.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, objConnection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds.Tables[0].Rows.Count>0)
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect...");
            }
            objConnection.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetMyForm();
        }
        private bool OpenConnection()
        {
            try
            {
                server = "localhost";
                database = "cashbook";
                uid = "root";
                password = "root";

                string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password;

                objConnection = new MySqlConnection(connectionString);
                objConnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact Administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid Username/Password. Please try again");
                        break;
                }
                return false;
            }
            
        }

        private bool CloseConnection()
        {
            try
            {
                objConnection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void resetMyForm()
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                login();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                resetMyForm();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
