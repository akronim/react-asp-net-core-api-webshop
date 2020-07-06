using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.Utils
{
    public class CostUtils
    {
        public static decimal CalculateFinalCostPercentageDiscount(decimal priceWithoutDiscount, decimal discountPercentage)
        {
            var discount = (priceWithoutDiscount * discountPercentage) / 100;

            return decimal.Truncate(discount * 100m) / 100m;
        }

        public static decimal CalculatePriceWithQuantityDiscount(int actual_quantity, decimal piecePrice, int discount_quantity, decimal discount_price)
        {
            var modulus = actual_quantity % discount_quantity;
            var x = actual_quantity / discount_quantity;

            decimal price = 0;

            // case a > b
            if (modulus != actual_quantity)
            {
                // case 3 3 , 6 3 , 9 3 ...
                if (modulus == 0)
                {
                    price = x * discount_price;
                }
                else
                {
                    // case 4 3, 5 3, 7 3 ...
                    price = x * discount_price + modulus * piecePrice;
                }
            }
            else
            {
                // case a < b
                price = actual_quantity * piecePrice;
            }
            return decimal.Truncate(price * 100m) / 100m;
        }
    }
}
