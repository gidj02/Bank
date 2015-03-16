namespace FormViews
{
    partial class login_form
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
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(51, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Account ID:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(51, 89);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "6-Digit Pin Code:";
            // 
            // txtAccountID
            // 
            this.txtAccountID.Lines = new string[0];
            this.txtAccountID.Location = new System.Drawing.Point(177, 56);
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
            this.txtPinCode.Location = new System.Drawing.Point(177, 85);
            this.txtPinCode.MaxLength = 32767;
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.PasswordChar = '\0';
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
            this.btnLogin.Location = new System.Drawing.Point(397, 114);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 161);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPinCode);
            this.Controls.Add(this.txtAccountID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "login_form";
            this.Text = "Bank Account System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.home_form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtAccountID;
        private MetroFramework.Controls.MetroTextBox txtPinCode;
        private MetroFramework.Controls.MetroButton btnLogin;

    }
}

