namespace FormViews
{
    partial class loginaccount_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtAccountID = new MetroFramework.Controls.MetroTextBox();
            this.txtPinCode = new MetroFramework.Controls.MetroTextBox();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnHome = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(61, 95);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Account ID:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(61, 124);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "6-Digit Pin Code:";
            // 
            // txtAccountID
            // 
            this.txtAccountID.Lines = new string[0];
            this.txtAccountID.Location = new System.Drawing.Point(187, 91);
            this.txtAccountID.MaxLength = 32767;
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.PasswordChar = '\0';
            this.txtAccountID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccountID.SelectedText = "";
            this.txtAccountID.Size = new System.Drawing.Size(295, 23);
            this.txtAccountID.TabIndex = 2;
            this.txtAccountID.UseSelectable = true;
            // 
            // txtPinCode
            // 
            this.txtPinCode.Lines = new string[0];
            this.txtPinCode.Location = new System.Drawing.Point(187, 120);
            this.txtPinCode.MaxLength = 32767;
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.PasswordChar = '*';
            this.txtPinCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPinCode.SelectedText = "";
            this.txtPinCode.Size = new System.Drawing.Size(295, 23);
            this.txtPinCode.TabIndex = 3;
            this.txtPinCode.UseSelectable = true;
            // 
            // btnLogin
            // 
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLogin.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.btnLogin.Location = new System.Drawing.Point(407, 149);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(24, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(104, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Login Account";
            // 
            // btnHome
            // 
            this.btnHome.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnHome.Location = new System.Drawing.Point(11, 171);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(55, 22);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseSelectable = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // loginaccount_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 202);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPinCode);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.MinimizeBox = false;
            this.Name = "loginaccount_form";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Bank Account System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_form_FormClosed);
            this.Load += new System.EventHandler(this.login_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtAccountID;
        private MetroFramework.Controls.MetroTextBox txtPinCode;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnHome;

    }
}

