﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using OrderingSystem.Model;
using OrderingSystem.Repository;

namespace OrderingSystem.KioskApplication
{
    public partial class CouponFrm : Form
    {
        private ICouponRepository couponRepository;
        public event EventHandler<CouponModel> CouponSelected;
        private CouponModel currentCoupon;
        private Guna2ProgressIndicator spinner = null;
        private Guna2Button b = null;

        public CouponFrm(ICouponRepository couponRepository)
        {
            InitializeComponent();
            this.couponRepository = couponRepository;
        }


        private void guna2PictureBox2_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void t_Tick(object sender, System.EventArgs e)
        {
            if (spinner != null && b != null)
            {
                this.Focus();
                txtCoupon.Focus();

                t.Stop();
                message.Visible = true;
                spinner.Stop();
                b.Controls.Remove(spinner);
                spinner.Dispose();
                spinner = null;
                b.Enabled = true;
                b.Text = "Redeem";
                b = null;
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            message.Visible = false;
            Guna2Button b = (Guna2Button)sender;
            Guna2ProgressIndicator spinner = new Guna2ProgressIndicator();
            spinner.Size = new Size(35, 37);
            spinner.BackColor = Color.Transparent;
            spinner.Location = new Point(
                        (b.Width - spinner.Width) / 2,
                        (b.Height - spinner.Height) / 2
                    );
            b.Controls.Add(spinner);
            spinner.Start();
            t.Start();
            b.Enabled = false;
            b.Text = "";
            this.spinner = spinner;
            this.b = b;
            try
            {
                CouponModel c = await couponRepository.getCoupon(txtCoupon.Text);
                if (currentCoupon != null)
                {
                    message.Text = "You’ve already selected a coupon. If you want to change it, please click gift icon.";
                    message.ForeColor = Color.IndianRed;
                    return;
                }



                if (c != null)
                {
                    if (c.Status.ToLower() == "used")
                    {
                        message.Text = "This coupon is already used. Try Another one.";
                        message.ForeColor = Color.IndianRed;
                    }
                    if (c.ExpiryDate < DateTime.Now)
                    {
                        message.Text = "Sorry, this coupon has expired.";
                        message.ForeColor = Color.IndianRed;
                    }
                    else
                    {
                        message.Text = "Success! Your coupon is applied.";
                        CouponSelected?.Invoke(this, c);
                        currentCoupon = c;
                        message.ForeColor = Color.Green;
                    }
                }
                else
                {
                    message.Text = "Uh-oh! That coupon code isn’t valid. Please try again.";
                    message.ForeColor = Color.IndianRed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
