namespace OrderingSystem.KioskApplication.Components
{
    partial class FotCard
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
            this.menuName = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.price = new System.Windows.Forms.Label();
            this.checkBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoSize = true;
            this.menuName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuName.Location = new System.Drawing.Point(135, 18);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(51, 21);
            this.menuName.TabIndex = 0;
            this.menuName.Text = "label1";
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size.Location = new System.Drawing.Point(179, 47);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(43, 17);
            this.size.TabIndex = 1;
            this.size.Text = "label1";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 3;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(53, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(76, 76);
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // price
            // 
            this.price.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(477, 47);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(109, 22);
            this.price.TabIndex = 3;
            this.price.Text = "label1";
            this.price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox
            // 
            this.checkBox.Checked = true;
            this.checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.CheckedState.BorderRadius = 2;
            this.checkBox.CheckedState.BorderThickness = 1;
            this.checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.Location = new System.Drawing.Point(13, 38);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(31, 23);
            this.checkBox.TabIndex = 4;
            this.checkBox.Text = "guna2CustomCheckBox1";
            this.checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.UncheckedState.BorderRadius = 2;
            this.checkBox.UncheckedState.BorderThickness = 1;
            this.checkBox.UncheckedState.FillColor = System.Drawing.Color.White;
            this.checkBox.Click += new System.EventHandler(this.checkBoxChanged);
            // 
            // FotCard
            // 
            this.ClientSize = new System.Drawing.Size(598, 101);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.price);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.size);
            this.Controls.Add(this.menuName);
            this.Name = "FotCard";
            this.Text = "FotCard";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label size;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label price;
        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBox;
    }
}