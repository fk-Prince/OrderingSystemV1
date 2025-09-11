using System;
namespace OrderingSystem.Model
{
    public class MenuDetail
    {
        private int menudetail_id;
        private double price;
        private double discountRate;
        private string sizeName;
        private TimeSpan estimated_time;
        private int maxOrder;
        private int purchaseQty;

        public int Menudetail_id { get => menudetail_id; }
        public double Price { get => price; }
        public string SizeName { get => sizeName; }
        public double DiscountRate { get => discountRate; }
        public TimeSpan EstimatedTime { get => estimated_time; }
        public int MaxOrder { get => maxOrder; }
        public int PurchaseQty { get => purchaseQty; set => purchaseQty = value; }

        public static MenuDetailBuilder Builder() => new MenuDetailBuilder();

        public double getDiscountedPrice()
        {
            return Price + (Price * discountRate);
        }
        public class MenuDetailBuilder
        {
            private MenuDetail _menuDetail;

            public MenuDetailBuilder()
            {
                _menuDetail = new MenuDetail();
            }

            public MenuDetailBuilder SetMenuDetailID(int id)
            {
                _menuDetail.menudetail_id = id;
                return this;
            }

            public MenuDetailBuilder SetPrice(double price)
            {
                _menuDetail.price = price;
                return this;
            }

            public MenuDetailBuilder SetSizeName(string sizeName)
            {
                _menuDetail.sizeName = sizeName;
                return this;
            }

            public MenuDetailBuilder SetEstimatedTime(TimeSpan estimatedTime)
            {
                _menuDetail.estimated_time = estimatedTime;
                return this;
            }

            public MenuDetailBuilder SetDiscountRate(double rate)
            {
                _menuDetail.discountRate = rate;
                return this;
            }

            public MenuDetailBuilder SetMaxOrder(int maxOrder)
            {
                _menuDetail.maxOrder = maxOrder;
                return this;
            }

            public MenuDetailBuilder SetPurchaseQty(int purchaseQty)
            {
                _menuDetail.purchaseQty = purchaseQty;
                return this;
            }

            public MenuDetail Build()
            {
                return _menuDetail;
            }


        }
    }
}