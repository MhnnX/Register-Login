using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Registration_and_Login_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MUHAFANX\SQLEXPRESS;Initial Catalog=RegnLog;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select username, user_pass from db_datauser where username = @username and user_pass = @user_pass", conn);

            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsername.Text;
            cmd.Parameters.Add("@user_pass", SqlDbType.VarChar).Value = txtPassword.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();
            }
            else
            {
                    MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Focus();
            }

        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }
    }
}
