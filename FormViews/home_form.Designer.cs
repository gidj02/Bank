namespace FormViews
{
    partial class home_form
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
            this.tileBalance = new MetroFramework.Controls.MetroTile();
            this.tileDeposit = new MetroFramework.Controls.MetroTile();
            this.tileProfile = new MetroFramework.Controls.MetroTile();
            this.tileCheck = new MetroFramework.Controls.MetroTile();
            this.tileWithdraw = new MetroFramework.Controls.MetroTile();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tileBalance
            // 
            this.tileBalance.ActiveControl = null;
            this.tileBalance.Location = new System.Drawing.Point(249, 95);
            this.tileBalance.Name = "tileBalance";
            this.tileBalance.Size = new System.Drawing.Size(107, 91);
            this.tileBalance.Style = MetroFramework.MetroColorStyle.Purple;
            this.tileBalance.TabIndex = 0;
            this.tileBalance.Text = "Balance";
            this.tileBalance.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileBalance.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileBalance.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileBalance.UseSelectable = true;
            // 
            // tileDeposit
            // 
            this.tileDeposit.ActiveControl = null;
            this.tileDeposit.Location = new System.Drawing.Point(23, 95);
            this.tileDeposit.Name = "tileDeposit";
            this.tileDeposit.Size = new System.Drawing.Size(220, 200);
            this.tileDeposit.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileDeposit.TabIndex = 1;
            this.tileDeposit.Text = "Deposit";
            this.tileDeposit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileDeposit.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileDeposit.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileDeposit.UseSelectable = true;
            this.tileDeposit.Click += new System.EventHandler(this.tileDeposit_Click);
            // 
            // tileProfile
            // 
            this.tileProfile.ActiveControl = null;
            this.tileProfile.Location = new System.Drawing.Point(23, 301);
            this.tileProfile.Name = "tileProfile";
            this.tileProfile.Size = new System.Drawing.Size(220, 91);
            this.tileProfile.Style = MetroFramework.MetroColorStyle.Red;
            this.tileProfile.TabIndex = 2;
            this.tileProfile.Text = "Manage Profile";
            this.tileProfile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileProfile.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileProfile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileProfile.UseSelectable = true;
            // 
            // tileCheck
            // 
            this.tileCheck.ActiveControl = null;
            this.tileCheck.Location = new System.Drawing.Point(249, 192);
            this.tileCheck.Name = "tileCheck";
            this.tileCheck.Size = new System.Drawing.Size(220, 200);
            this.tileCheck.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileCheck.TabIndex = 3;
            this.tileCheck.Text = "Issue Check";
            this.tileCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileCheck.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileCheck.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileCheck.UseSelectable = true;
            // 
            // tileWithdraw
            // 
            this.tileWithdraw.ActiveControl = null;
            this.tileWithdraw.Location = new System.Drawing.Point(362, 95);
            this.tileWithdraw.Name = "tileWithdraw";
            this.tileWithdraw.Size = new System.Drawing.Size(107, 91);
            this.tileWithdraw.Style = MetroFramework.MetroColorStyle.Green;
            this.tileWithdraw.TabIndex = 4;
            this.tileWithdraw.Text = "Withdraw";
            this.tileWithdraw.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileWithdraw.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileWithdraw.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileWithdraw.UseSelectable = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 19);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Client Name";
            // 
            // home_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 405);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tileWithdraw);
            this.Controls.Add(this.tileCheck);
            this.Controls.Add(this.tileProfile);
            this.Controls.Add(this.tileDeposit);
            this.Controls.Add(this.tileBalance);
            this.MaximizeBox = false;
            this.Name = "home_form";
            this.Resizable = false;
            this.Text = "Bank Account Sytem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile tileBalance;
        private MetroFramework.Controls.MetroTile tileDeposit;
        private MetroFramework.Controls.MetroTile tileProfile;
        private MetroFramework.Controls.MetroTile tileCheck;
        private MetroFramework.Controls.MetroTile tileWithdraw;
        private MetroFramework.Controls.MetroLabel lblName;
    }
}