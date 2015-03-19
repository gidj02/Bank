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
using BankLibrary.Models;
using BankLibrary.DataAccess;
using BankLibrary.Controllers;

namespace Views
{
    public partial class client_form : MaterialForm
    {
        account_controller accountcon = new account_controller();

        string username = string.Empty;
        client client;
        account account;

        public client_form()
        {
            InitializeComponent();
        }

        public client_form(client client)
        {
            InitializeComponent();
            lblWelcome.Text = "Welcome " + client.username;
            MessageBox.Show("Welcome " + client.username);
            this.client = client;
            dgAccounts.DataSource = accountcon.listAccount(client.clientid);
        }

        private void dgAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                int accountid;
                accountid = Convert.ToInt32(dgAccounts.Rows[e.RowIndex].Cells[0].Value);
                //accountcon.setAccount(accountid);
                pin_form pform = new pin_form(accountid);
                this.Hide();
                pform.ShowDialog();
                this.Show();
            }
        }

        private void user_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
