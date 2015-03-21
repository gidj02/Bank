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
using System.Text.RegularExpressions;

namespace Views
{
    public partial class client_form : MaterialForm
    {
        account_controller accountcon = new account_controller();
        client_controller clientcon = new client_controller();
        Regex firstNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex middleNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex lastNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex addressRegex = new Regex(@"[A-Za-z0-9'\.\-\s\,]");
        Regex contactRegex = new Regex(@"^[+]*[0-9,\.]+$");
        Regex emailRegex = new Regex(@"([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})");
        Regex usernameRegex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
        Regex passwordRegex = new Regex(@"^(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\d]).*$");
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
            dgAccounts.Columns[0].HeaderText = "Account ID";
            dgAccounts.Columns[1].HeaderText = "Status";
            dgAccounts.Columns[2].HeaderText = "Date Created";
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
            if (firstNameRegex.IsMatch(txtFirstName.Text) && middleNameRegex.IsMatch(txtMiddleName.Text) && lastNameRegex.IsMatch(txtLastName.Text) && addressRegex.IsMatch(txtAddress.Text) && contactRegex.IsMatch(txtContact.Text) && emailRegex.IsMatch(txtEmail.Text) && usernameRegex.IsMatch(txtUsername.Text))
            {
                if (this.clientcon.updateClient(client.clientid, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtAddress.Text, txtContact.Text, txtEmail.Text, txtUsername.Text))
                {
                    MessageBox.Show("Account successfully updated");
                }
                else MessageBox.Show("Failed to update account.");
            }else MessageBox.Show("Please check all field!");
        }

        private void btnChangeAcc_Click(object sender, EventArgs e)
        {
            home_form home = new home_form();
            home.Show();
            this.Dispose();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (passwordRegex.IsMatch(txtDelPass.Text) && passwordRegex.IsMatch(txtDelCon.Text))
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this client account?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (this.clientcon.deleteClient(client.clientid, txtPassword.Text))
                        {
                            MessageBox.Show("Client Deleted.");
                            new home_form().Show();
                            this.Dispose();
                        }
                        else MessageBox.Show("Your account has existing loan.");
                    }
                    else MessageBox.Show("Password did not match.");
                }
                else MessageBox.Show("Password did not match.");
            }
            else MessageBox.Show("Invalid Password.");
                        
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (passwordRegex.IsMatch(txtConfirmPassword.Text) && passwordRegex.IsMatch(txtPassword.Text) && passwordRegex.IsMatch(txtOldPass.Text))
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    if (clientcon.changePass(client.clientid, txtOldPass.Text, txtPassword.Text))
                    {
                        MessageBox.Show("Password changed!");
                    }
                    else MessageBox.Show("Unable to change pass!");
                }
                else MessageBox.Show("Password did not match!");
            }else MessageBox.Show("Invalid password!");
        }


        
    }
}
