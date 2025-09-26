namespace OrderingSystem.CashierApp.Forms.Menu
{
    partial class MenuCard
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
            this.image = new Guna.UI2.WinForms.Guna2PictureBox();
            this.menuName = new System.Windows.Forms.Label();
            this.menuDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.Transparent;
            this.image.BorderRadius = 10;
            this.image.CustomizableEdges.BottomLeft = false;
            this.image.CustomizableEdges.BottomRight = false;
            this.image.Image = global::OrderingSystem.Properties.Resources.placeholder;
            this.image.ImageRotate = 0F;
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(264, 132);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            this.image.UseTransparentBackground = true;
            // 
            // menuName
            // 
            this.menuName.AutoEllipsis = true;
            this.menuName.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(18, 147);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(226, 32);
            this.menuName.TabIndex = 1;
            this.menuName.Text = "label1";
            // 
            // menuDescription
            // 
            this.menuDescription.AutoEllipsis = true;
            this.menuDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDescription.Location = new System.Drawing.Point(50, 190);
            this.menuDescription.Name = "menuDescription";
            this.menuDescription.Size = new System.Drawing.Size(158, 71);
            this.menuDescription.TabIndex = 2;
            this.menuDescription.Text = "label1";
            this.menuDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.menuDescription.Click += new System.EventHandler(this.menuDescription_Click);
            // 
            // MenuCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(263, 287);
            this.Controls.Add(this.menuDescription);
            this.Controls.Add(this.menuName);
            this.Controls.Add(this.image);
            this.Name = "MenuCard";
            this.Text = "MenuCard";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox image;
        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label menuDescription;
    }
}