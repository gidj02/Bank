using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankLibrary.Models;
using BankLibrary.DataAccess;
using BankLibrary.Controllers;

namespace Views
{
    public partial class register_user_form : MaterialForm
    {
        client_controller clientcon = new client_controller();
        
        public register_user_form()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.clientcon.createClient(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtAddress.Text, txtContact.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Success! Client Registered.");
            }
            else MessageBox.Show("Failed registration.");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
            if (validationEmail())
            {
                MessageBox.Show("true");
                txtEmail.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("false");
                //txtEmail.BackColor = Color.Red;
            }
        }

        private bool validationEmail()
        {
            Regex emailRegex = new Regex(@"([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})");
            String email = txtEmail.Text;
            Match m = emailRegex.Match(email);
            if (!m.Success)
            {
                return false;
            }
            return true;
        }

        private bool validationfName()
        {
            Regex nameRegex = new Regex(@"^[a-zA-Z]+$");
            String fName = txtFirstName.Text;
            Match first = nameRegex.Match(fName);
            if (!first.Success)
            {
                return false;
            }
            return true;
        }

        private bool validationmName()
        {
            Regex nameRegex = new Regex(@"^[a-zA-Z]+$");
            String mName = txtMiddleName.Text;
            Match middle = nameRegex.Match(mName);
            if (!middle.Success)
            {
                return false;
            }
            return true;
        }

        private bool validationlName()
        {
            Regex nameRegex = new Regex(@"^[a-zA-Z]+$");
            String lName = txtLastName.Text;
            Match last = nameRegex.Match(lName);
            if (!last.Success)
            {
                return false;
            }
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
