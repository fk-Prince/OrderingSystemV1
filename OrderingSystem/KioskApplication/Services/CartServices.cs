using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OrderingSystem.KioskApplication.Components;
using OrderingSystem.Repository.Menus;
using Menu = OrderingSystem.Model.Menu;

namespace OrderingSystem.KioskApplication.Services
{
    public class CartServices
    {
        private IMenuRepository menuRepository;
        private FlowLayoutPanel flowCart;
        private List<Menu> orderList;
        public event EventHandler quantityChanged;
        public CartServices(IMenuRepository menuRepository, FlowLayoutPanel flowCart)
        {
            this.menuRepository = menuRepository;
            this.flowCart = flowCart;
            orderList = new List<Menu>();
        }

        public void addMenuToCart(List<Menu> menuOrdered)
        {
            foreach (var menu in menuOrdered)
            {
                var alreadyExist = orderList.FirstOrDefault(o => o.MenuDetail.Menudetail_id == menu.MenuDetail.Menudetail_id);

                if (alreadyExist != null)
                {
                    alreadyExist.MenuDetail.PurchaseQty += 1;

                    foreach (var item in flowCart.Controls.OfType<CartCard>())
                    {
                        item.displayPurchasedMenu();
                    }
                }
                else
                {
                    orderList.Add(menu);
                    addNewCart(menu);
                }
            }
        }

        private void addQuantity(object sender, Menu e)
        {
            CartCard cc = sender as CartCard;
            var order = orderList.FirstOrDefault(o => o.MenuDetail.Menudetail_id == e.MenuDetail.Menudetail_id);
            order.MenuDetail.PurchaseQty++;
            // TODO IF MAX ORDER THEN DONT ADD
            quantityChanged?.Invoke(this, EventArgs.Empty);
        }
        private void deductQuantity(object sender, Menu e)
        {
            CartCard cc = sender as CartCard;
            var order = orderList.FirstOrDefault(o => o.MenuDetail.Menudetail_id == e.MenuDetail.Menudetail_id);
            order.MenuDetail.PurchaseQty--;
            if (order.MenuDetail.PurchaseQty == 0)
            {
                orderList.Remove(order);
                flowCart.Controls.Remove(cc);
            }
            quantityChanged?.Invoke(this, EventArgs.Empty);
        }


        public double calculateCoupon()
        {
            // TODO : COUPON * SUBTOTAL
            throw new NotImplementedException();
        }

        public double calculateSubtotal()
        {
            return orderList.Sum(e => e.MenuDetail.getDiscountedPrice() * e.MenuDetail.PurchaseQty);
        }

        public double calculateTotalAmount()
        {
            double subtotal = calculateSubtotal();
            double vat = calculateVat();
            // double coupon = calculateCoupon();
            return subtotal + vat;
        }

        public double calculateVat()
        {
            double tax = 0.12;
            return tax * orderList.Sum(e => e.MenuDetail.getDiscountedPrice() * e.MenuDetail.PurchaseQty);
        }

        private void addNewCart(Menu menu)
        {
            CartCard cc = new CartCard(menu);
            cc.addQuantityEvent += addQuantity;
            cc.deductQuantityEvent += deductQuantity;
            cc.Margin = new Padding(10, 5, 5, 5);
            flowCart.Controls.Add(cc);
        }

    }
}
