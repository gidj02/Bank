using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankLibrary.Controllers;
using BankLibrary.Models;
using BankLibrary.DataAccess;

namespace Views
{
    public partial class home_form : MaterialForm
    {
        client_controller clientcon = new client_controller();

        string username = string.Empty;
        string password = string.Empty;

        public home_form()
        {
            InitializeComponent();
        }

        private void home_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (clientcon.checkClientLogin(username, password))
            {
                List<client> client = clientcon.getClient();
                foreach (client c in client)
                {
                    MessageBox.Show(c.address);
                }
                
                client_form userform = new client_form(username);
                userform.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Sorry!");
            }
        }

        private void home_form_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }
    }
}
