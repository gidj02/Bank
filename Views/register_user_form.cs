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
        int check = 0;
        Regex firstNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex middleNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex lastNameRegex = new Regex(@"^[a-zA-Z-\ ]+$");
        Regex addressRegex = new Regex(@"[A-Za-z0-9'\.\-\s\,]");
        Regex contactRegex = new Regex(@"^[+]*[0-9,\.]+$");
        Regex emailRegex = new Regex(@"([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})");
        Regex usernameRegex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
        Regex passwordRegex = new Regex(@"^(?=.{6,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\d]).*$");
        
        public register_user_form()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int value = validation();
            if (value == 9)
            {
                MessageBox.Show(value.ToString());if (this.clientcon.createClient(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtAddress.Text, txtContact.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("Success! Client Registered.");
                    clear();
                    hideButtons();
                    new home_form().Show();
                    this.Dispose();
                }
                else MessageBox.Show("Failed registration.");
            }
            else MessageBox.Show("Registration failed. Please check all input fields. ");
        }

      
        private bool validationEmail()
        {
            String email = txtEmail.Text;
            Match m = emailRegex.Match(email);
            if (!m.Success)
            {
                return false;
            }
            else return true; 
            
        }

        private bool validationfName()
        {
            String fName = txtFirstName.Text;
            Match first = firstNameRegex.Match(fName);
            if (!first.Success)
            {
                return false;
            }
            else return true; 
        }

        private bool validationmName()
        {
            String mName = txtMiddleName.Text;
            Match middle = middleNameRegex.Match(mName);
            if (!middle.Success)
            {
                return false;
            }
            else return true; 
        }

        private bool validationlName()
        {
            String lName = txtLastName.Text;
            Match last = lastNameRegex.Match(lName);
            if (!last.Success)
            {
                return false;
            }
            else return true; 
        }

        private bool validationAddress()
        {
            String address = txtAddress.Text;
            Match add = addressRegex.Match(address);
            if (!add.Success)
            {
                return false;
            }
            else return true; 
        }

        private bool validationContact()
        {
            String contact = txtContact.Text;
            Match con = contactRegex.Match(contact);
            if (!con.Success)
            {
                return false;
            }
            else return true; 
        }

        private bool validationUsername()
        {
            String user = txtUsername.Text;
            Match uname = usernameRegex.Match(user);
            if (!uname.Success)
            {
                return false;
            }
            else return true; 
        }
        private bool validationPassword()
        {
            String pass = txtPassword.Text;
            Match pw = passwordRegex.Match(pass);
            if (!pw.Success)
            {
                return false;
            }
            else return true; 
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            hideButtons();
        }

        private void clear()
        {
            txtAddress.Text = "";
            txtConfirmPassword.Text = "";
            txtContact.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
        }

        
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (validationfName())
            {
                check1.Visible = true;
                x1.Visible = false;
            }
            else
            {
                x1.Visible = true;
                check1.Visible = false;
             
            }
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            if (validationmName())
            {
                check2.Visible = true;
                x2.Visible = false;
            }
            else
            {
                x2.Visible = true;
                check2.Visible = false;
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (validationlName())
            {
                check3.Visible = true;
                x3.Visible = false;
            }
            else
            {
                x3.Visible = true;
                check3.Visible = false;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (validationAddress())
            {
                check4.Visible = true;
                x4.Visible = false;
            }
            else
            {
                x4.Visible = true;
                check4.Visible = false;
            }
        }



        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (validationContact())
            {
                check5.Visible = true;
                x5.Visible = false;
            }
            else
            {
                x5.Visible = true;
                check5.Visible = false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (validationEmail())
            {
                check6.Visible = true;
                x6.Visible = false;
            }
            else
            {
                x6.Visible = true;
                check6.Visible = false;
            }
        }
        
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (validationUsername())
            {
                check7.Visible = true;
                x7.Visible = false;
                lblUser.Visible = false;
            }
            else
            {
                x7.Visible = true;
                check7.Visible = false;
                lblUser.Visible = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (validationPassword())
            {
                check8.Visible = true;
                x8.Visible = false;
                lblPass.Visible = false;
            }
            else
            {
                x8.Visible = true;
                check8.Visible = false;
                lblPass.Visible = true;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtConfirmPassword.Text)
            {
                check9.Visible = true;
                x9.Visible = false;
            }
            else
            {
                x9.Visible = true;
                check9.Visible = false;
            }
        }

       public int validation()
        {
            check = 0;
            if (firstNameRegex.IsMatch(txtFirstName.Text))
            {
                check = check + 1;
            }
            if (middleNameRegex.IsMatch(txtMiddleName.Text))
            {
                check = check + 1;
            }
            if (lastNameRegex.IsMatch(txtLastName.Text))
            {
                check = check + 1;
            }
            if (addressRegex.IsMatch(txtAddress.Text))
            {
                check = check + 1;
            }
            if (contactRegex.IsMatch(txtContact.Text))
            {
                check = check + 1;
            }
            if (emailRegex.IsMatch(txtEmail.Text))
            {
                check = check + 1;
            }
            if (usernameRegex.IsMatch(txtUsername.Text))
            {
                check = check + 1;
            }
            if (passwordRegex.IsMatch(txtPassword.Text))
            {
                check = check + 1;
            }
           if(txtPassword.Text == txtConfirmPassword.Text)
           {
               check = check + 1;
           }
           return check;
        }

       private void btnBack_Click(object sender, EventArgs e)
       {
           new home_form().Show();
           this.Dispose();
       }
       

        private void hideButtons()
       {
           x1.Visible = false;
           x2.Visible = false;
           x3.Visible = false;
           x4.Visible = false;
           x5.Visible = false;
           x6.Visible = false;
           x7.Visible = false;
           x8.Visible = false;
           x9.Visible = false;
           check1.Visible = false;
           check2.Visible = false;
           check3.Visible = false;
           check4.Visible = false;
           check5.Visible = false;
           check6.Visible = false;
           check7.Visible = false;
           check8.Visible = false;
           check9.Visible = false;
           lblPass.Visible = false;
           lblUser.Visible = false;
        }


    }
}
