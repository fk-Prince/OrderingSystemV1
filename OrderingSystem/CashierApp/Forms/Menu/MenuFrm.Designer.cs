namespace OrderingSystem.CashierApp.Forms
{
    partial class MenuFrm
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
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.mm = new Guna.UI2.WinForms.Guna2Panel();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // flowMenu
            // 
            this.flowMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.flowMenu.Location = new System.Drawing.Point(0, 79);
            this.flowMenu.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.flowMenu.MinimumSize = new System.Drawing.Size(776, 581);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Size = new System.Drawing.Size(796, 581);
            this.flowMenu.TabIndex = 0;
            // 
            // mm
            // 
            this.mm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mm.BackColor = System.Drawing.Color.White;
            this.mm.Location = new System.Drawing.Point(794, 1);
            this.mm.MaximumSize = new System.Drawing.Size(327, 1080);
            this.mm.MinimumSize = new System.Drawing.Size(327, 660);
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(327, 660);
            this.mm.TabIndex = 1;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(12, 37);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(358, 36);
            this.guna2TextBox1.TabIndex = 2;
            // 
            // MenuFrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.ClientSize = new System.Drawing.Size(1121, 660);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.flowMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1121, 660);
            this.Name = "MenuFrm";
            this.Text = "MenuFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private Guna.UI2.WinForms.Guna2Panel mm;
        private System.Windows.Forms.OpenFileDialog ofd;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}