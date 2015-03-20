namespace Views
{
    partial class transac_form
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
            this.btnWithdraw = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnDeposit = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnEncashment = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new MaterialSkin.Controls.MaterialFlatButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtAmount = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lblBalance = new MetroFramework.Controls.MetroLabel();
            this.lblLoan = new MetroFramework.Controls.MetroLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.AutoSize = true;
            this.btnWithdraw.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnWithdraw.BackColor = System.Drawing.Color.Maroon;
            this.btnWithdraw.Depth = 0;
            this.btnWithdraw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnWithdraw.Location = new System.Drawing.Point(14, 125);
            this.btnWithdraw.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnWithdraw.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Primary = false;
            this.btnWithdraw.Size = new System.Drawing.Size(85, 36);
            this.btnWithdraw.TabIndex = 0;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = false;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.AutoSize = true;
            this.btnDeposit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(239)))));
            this.btnDeposit.Depth = 0;
            this.btnDeposit.Location = new System.Drawing.Point(107, 125);
            this.btnDeposit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeposit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Primary = false;
            this.btnDeposit.Size = new System.Drawing.Size(67, 36);
            this.btnDeposit.TabIndex = 1;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = false;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnEncashment
            // 
            this.btnEncashment.AutoSize = true;
            this.btnEncashment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEncashment.Depth = 0;
            this.btnEncashment.Location = new System.Drawing.Point(182, 125);
            this.btnEncashment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEncashment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEncashment.Name = "btnEncashment";
            this.btnEncashment.Primary = false;
            this.btnEncashment.Size = new System.Drawing.Size(103, 36);
            this.btnEncashment.TabIndex = 2;
            this.btnEncashment.Text = "Encashment";
            this.btnEncashment.UseVisualStyleBackColor = true;
            this.btnEncashment.Click += new System.EventHandler(this.btnEncashment_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Location = new System.Drawing.Point(14, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 165);
            this.panel1.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSubmit.BackColor = System.Drawing.Color.Aqua;
            this.btnSubmit.Depth = 0;
            this.btnSubmit.Location = new System.Drawing.Point(246, 58);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Primary = false;
            this.btnSubmit.Size = new System.Drawing.Size(62, 36);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(98, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Enter Value:";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Lines = new string[0];
            this.txtAmount.Location = new System.Drawing.Point(186, 26);
            this.txtAmount.MaxLength = 32767;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PasswordChar = '\0';
            this.txtAmount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmount.SelectedText = "";
            this.txtAmount.Size = new System.Drawing.Size(178, 23);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(12, 69);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(102, 25);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Transaction";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBalance.Location = new System.Drawing.Point(273, 69);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(164, 19);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "Current Balance: 1500.00";
            // 
            // lblLoan
            // 
            this.lblLoan.AutoSize = true;
            this.lblLoan.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblLoan.Location = new System.Drawing.Point(273, 94);
            this.lblLoan.Name = "lblLoan";
            this.lblLoan.Size = new System.Drawing.Size(148, 19);
            this.lblLoan.TabIndex = 6;
            this.lblLoan.Text = "Current Loan: 1500.00";
            // 
            // transac_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(118)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(492, 348);
            this.Controls.Add(this.lblLoan);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEncashment);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.MaximizeBox = false;
            this.Name = "transac_form";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking System";
            this.Load += new System.EventHandler(this.transac_form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btnWithdraw;
        private MaterialSkin.Controls.MaterialFlatButton btnDeposit;
        private MaterialSkin.Controls.MaterialFlatButton btnEncashment;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton btnSubmit;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtAmount;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel lblBalance;
        private MetroFramework.Controls.MetroLabel lblLoan;

    }
}