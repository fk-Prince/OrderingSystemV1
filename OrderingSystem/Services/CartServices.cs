using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.Exceptions;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Model;
using OrderingSystem.Repository.Menus;

namespace OrderingSystem.KioskApplication.Services
{
    public class CartServices
    {
        private IKioskMenuRepository menuRepository;
        private FlowLayoutPanel flowCart;
        private List<MenuDetailModel> orderList;
        public event EventHandler quantityChanged;
        private CouponModel coupon;
        public CartServices(IKioskMenuRepository menuRepository, FlowLayoutPanel flowCart, List<MenuDetailModel> orderList)
        {
            this.menuRepository = menuRepository;
            this.flowCart = flowCart;
            this.orderList = orderList;
        }

        public void addMenuToCart(List<MenuDetailModel> newOrders)
        {
            foreach (var menu in newOrders)
            {
                var alreadyExist = orderList.FirstOrDefault(o => o.Menudetail_id == menu.Menudetail_id && o.GetDiscountedPrice() == menu.GetDiscountedPrice());

                if (alreadyExist != null)
                {
                    alreadyExist.PurchaseQty += 1;

                    foreach (var item in flowCart.Controls.OfType<CartCard>())
                    {
                        item.displayPurchasedMenu();
                    }
                }
                else
                {
                    orderList.Add(menu);
                    addNewCart(menu);
                    quantityChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void addQuantity(object sender, MenuDetailModel e)
        {
            CartCard cc = sender as CartCard;
            var order = orderList.FirstOrDefault(o => o.Menudetail_id == e.Menudetail_id);

            int b = menuRepository.getMaxOrderRealTime(e.Menudetail_id, orderList);
            if (b <= 0)
            {
                throw new MaxOrder("Unable to add more quantity.");
            }
            order.PurchaseQty++;
            cc.displayPurchasedMenu();

            quantityChanged?.Invoke(this, EventArgs.Empty);
        }
        private void deductQuantity(object sender, MenuDetailModel e)
        {
            CartCard cc = sender as CartCard;
            var order = orderList.FirstOrDefault(o => o.Menudetail_id == e.Menudetail_id);
            order.PurchaseQty--;
            if (order.PurchaseQty == 0)
            {
                orderList.Remove(order);
                flowCart.Controls.Remove(cc);
            }
            cc.displayPurchasedMenu();
            quantityChanged?.Invoke(this, EventArgs.Empty);
        }


        public double calculateCoupon(CouponModel coupon)
        {
            if (coupon == null) return 0.00;
            this.coupon = coupon;
            double subtotal = calculateSubtotal();
            return coupon.CouponRate * subtotal;
        }

        public double calculateSubtotal()
        {

            return orderList.Sum(e => e.GetDiscountedPrice() * e.PurchaseQty);
        }

        public double calculateTotalAmount()
        {
            double subtotal = calculateSubtotal();
            double vat = calculateVat();
            double coupon = calculateCoupon(this.coupon);
            return (subtotal - coupon) + vat;
        }

        public double calculateVat()
        {
            double tax = 0.12;
            return tax * calculateSubtotal();
        }

        private void addNewCart(MenuDetailModel menu)
        {

            CartCard cc = new CartCard(menu);
            cc.addQuantityEvent += addQuantity;
            cc.deductQuantityEvent += deductQuantity;
            cc.Margin = new Padding(10, 5, 5, 5);
            flowCart.Controls.Add(cc);
        }
    }
}
