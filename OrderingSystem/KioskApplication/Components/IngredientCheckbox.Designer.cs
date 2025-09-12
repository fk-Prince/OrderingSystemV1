namespace OrderingSystem.KioskApplication.Components
{
    partial class IngredientCheckbox
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
            this.checkBox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox
            // 
            this.checkBox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.CheckedState.BorderRadius = 2;
            this.checkBox.CheckedState.BorderThickness = 1;
            this.checkBox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBox.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.Location = new System.Drawing.Point(14, 8);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(18, 23);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "guna2CustomCheckBox1";
            this.checkBox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.checkBox.UncheckedState.BorderRadius = 2;
            this.checkBox.UncheckedState.BorderThickness = 1;
            this.checkBox.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(59, 11);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 15);
            this.name.TabIndex = 6;
            this.name.Text = "label1";
            // 
            // IngredientCheckbox
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 41);
            this.Controls.Add(this.name);
            this.Controls.Add(this.checkBox);
            this.Name = "IngredientCheckbox";
            this.Text = "IngredientCheckbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBox;
        private System.Windows.Forms.Label name;
    }
}