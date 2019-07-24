using System.Collections.Generic;
using DaveLavelle.CheckoutKata;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Checkout _checkout;

        private readonly Item Apple = new Item
        {
            SKU = "A99",
            UnitPrice = 0.5m
        };

        private readonly Item Banana = new Item
        {
            SKU = "B15",
            UnitPrice = 0.3m
        };

        private readonly Item Cherry = new Item
        {
            SKU = "C40",
            UnitPrice = 0.6m
        };


        private readonly List<Discount> Discounts = new List<Discount>
        {
            new Discount{SKU = "A99", Qty = 3, TotalCost = 1.3m},
            new Discount{SKU = "B15", Qty = 2, TotalCost = 0.45m},
        };


        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout(Discounts);
        }

        [Test]
        public void When_Scanning_One_Apple_Then_Checkout_Total_Should_Be_50p()
        {
            _checkout.Scan(Apple);

            _checkout.Total().Should().Be(0.5m);

        }

        [Test]
        public void When_Scanning_One_Apple_And_One_Banana_Then_Checkout_Total_Should_Be_80p()
        {
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);

            _checkout.Total().Should().Be(0.8m);

        }

        [Test]
        public void When_Scanning_One_Apple_And_One_Banana_And_One_Cherry_Then_Checkout_Total_Should_Be_1_Pound_40p()
        {
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);
            _checkout.Scan(Cherry);

            _checkout.Total().Should().Be(1.4m);

        }

        [Test]
        public void When_Scanning_One_Banana_And_One_Apple_And_One_Banana_Then_Checkout_Total_Should_Be_95p()
        {
            _checkout.Scan(Banana);
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);

            _checkout.Total().Should().Be(0.95m);

        }

        [Test]
        public void When_Scanning_Four_Apples_And_Three_Bananas_And_Two_Cherries_In_Any_Order_Then_Checkout_Total_Should_Be_3_Pounds_75p()
        {
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);
            _checkout.Scan(Cherry);
            _checkout.Scan(Apple);
            _checkout.Scan(Banana);
            _checkout.Scan(Cherry);
            _checkout.Scan(Apple);

            _checkout.Total().Should().Be(3.75m);

        }
    }
}