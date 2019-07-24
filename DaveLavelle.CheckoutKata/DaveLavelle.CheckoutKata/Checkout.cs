using System.Collections.Generic;
using System.Linq;

namespace DaveLavelle.CheckoutKata
{
    public class Checkout
    {
        private readonly List<Item> _items;
        private readonly List<Discount> _discounts;

        public Checkout(List<Discount> discounts)
        {
            _discounts = discounts;
            _items = new List<Item>();
        }
        public decimal Total()
        {
            var total = 0m;
            var individualItems = _items.Distinct();
            foreach (var individualItem in individualItems)
            {
                var qty = _items.Count(x => x.SKU == individualItem.SKU);
                var discount = _discounts.FirstOrDefault(x => x.SKU == individualItem.SKU);
                if (discount != null)
                {
                    var discountQty = (int) (qty /discount.Qty);
                    total += discountQty * discount.TotalCost;
                    var remainder = qty - (discountQty * discount.Qty);
                    total += remainder * individualItem.UnitPrice;
                }
                else
                {
                    total += individualItem.UnitPrice * qty;
                }
            }

            return total;
        }

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }

    public class Item
    {
        public string SKU { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class Discount
    {
        public string SKU { get; set; }
        public int Qty { get; set; }
        public decimal TotalCost { get; set; }
    }
}
