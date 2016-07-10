using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class OrderProcessing
    {
        public Order order = new Order();
        private double tax = .056;
        private double shipping = 5.00;

        public Order ProcessOrder()
        {
            if (CheckCreditCard(order.getCardNumber()))
            {
                var subTotal = order.getAmount()*ChickenFarm.getPrice();
                var withTax = (subTotal*tax) + subTotal;
                var grandTotal = withTax + shipping;
                order.setPrice(grandTotal);
                return order;
            }
            else
            {
                return order;
            }
        }

        private bool CheckCreditCard(string cardNumber)
        {
            if (cardNumber.Length == 16)
            {
                return true;
            }
            return false;
        }
    }
}
