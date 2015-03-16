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
            this.tileActivate = new MetroFramework.Controls.MetroTile();
            this.tileAccount = new MetroFramework.Controls.MetroTile();
            this.tileClient = new MetroFramework.Controls.MetroTile();
            this.tileDeactivate = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // tileActivate
            // 
            this.tileActivate.ActiveControl = null;
            this.tileActivate.Location = new System.Drawing.Point(249, 196);
            this.tileActivate.Name = "tileActivate";
            this.tileActivate.Size = new System.Drawing.Size(220, 200);
            this.tileActivate.Style = MetroFramework.MetroColorStyle.Teal;
            this.tileActivate.TabIndex = 7;
            this.tileActivate.Text = "Login Account";
            this.tileActivate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileActivate.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileActivate.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileActivate.UseSelectable = true;
            this.tileActivate.Click += new System.EventHandler(this.tileActivate_Click);
            // 
            // tileAccount
            // 
            this.tileAccount.ActiveControl = null;
            this.tileAccount.Location = new System.Drawing.Point(23, 305);
            this.tileAccount.Name = "tileAccount";
            this.tileAccount.Size = new System.Drawing.Size(220, 91);
            this.tileAccount.Style = MetroFramework.MetroColorStyle.Red;
            this.tileAccount.TabIndex = 6;
            this.tileAccount.Text = "Open New Account";
            this.tileAccount.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileAccount.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileAccount.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileAccount.UseSelectable = true;
            // 
            // tileClient
            // 
            this.tileClient.ActiveControl = null;
            this.tileClient.Location = new System.Drawing.Point(23, 99);
            this.tileClient.Name = "tileClient";
            this.tileClient.Size = new System.Drawing.Size(220, 200);
            this.tileClient.Style = MetroFramework.MetroColorStyle.Blue;
            this.tileClient.TabIndex = 5;
            this.tileClient.Text = "Register New Client";
            this.tileClient.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileClient.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileClient.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileClient.UseSelectable = true;
            // 
            // tileDeactivate
            // 
            this.tileDeactivate.ActiveControl = null;
            this.tileDeactivate.Location = new System.Drawing.Point(249, 99);
            this.tileDeactivate.Name = "tileDeactivate";
            this.tileDeactivate.Size = new System.Drawing.Size(220, 91);
            this.tileDeactivate.Style = MetroFramework.MetroColorStyle.Purple;
            this.tileDeactivate.TabIndex = 4;
            this.tileDeactivate.Text = "Help";
            this.tileDeactivate.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tileDeactivate.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.tileDeactivate.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.tileDeactivate.UseSelectable = true;
            // 
            // home_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 418);
            this.Controls.Add(this.tileActivate);
            this.Controls.Add(this.tileAccount);
            this.Controls.Add(this.tileClient);
            this.Controls.Add(this.tileDeactivate);
            this.MaximizeBox = false;
            this.Name = "home_form";
            this.Resizable = false;
            this.Text = "Bank Account System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.home_form_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile tileActivate;
        private MetroFramework.Controls.MetroTile tileAccount;
        private MetroFramework.Controls.MetroTile tileClient;
        private MetroFramework.Controls.MetroTile tileDeactivate;
    }
}