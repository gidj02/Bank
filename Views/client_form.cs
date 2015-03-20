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
        client_controller clientcon = new client_controller();

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
            this.client = client;
            dgAccounts.DataSource = accountcon.listAccount(client.clientid);
        }

        private void dgAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                int accountid;
                accountid = Convert.ToInt32(dgAccounts.Rows[e.RowIndex].Cells[0].Value);
                account = accountcon.setAccount(accountid);

                pin_form pform = new pin_form(account, client);
                pform.FormClosed += new FormClosedEventHandler(pform_FormClosed);
                pform.Show();
                this.Hide();
                //this.Hide();
                //pform.ShowDialog();
                //this.Show();
            }
        }

        private void user_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkCreate_Click(object sender, EventArgs e)
        {
            create_account_form createAcc = new create_account_form(client);
            createAcc.FormClosed += new FormClosedEventHandler(createAcc_FormClosed);
            createAcc.Show();
            this.Hide();
        }

        private void pform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void createAcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            dgAccounts.DataSource = accountcon.listAccount(client.clientid);
        }

        private void client_form_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = client.firstname;
            txtMiddleName.Text = client.middlename;
            txtLastName.Text = client.lastname;
            txtAddress.Text = client.address;
            txtContact.Text = client.contact;
            txtEmail.Text = client.email;
            txtUsername.Text = client.username;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.clientcon.updateClient(client.clientid, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtAddress.Text, txtContact.Text, txtEmail.Text, txtUsername.Text))
            {
                MessageBox.Show("Account successfully updated");
            }
            else MessageBox.Show("Failed to update account.");
        }

        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            home_form home = new home_form();
            home.Show();
            this.Dispose();
        }

       /* private void txtDelete_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == client.password && client.password == txtConfirmPassword.Text)
            {
                if

            }

        }*/

    }
}
