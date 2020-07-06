using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.DTO;
using WebShopApiCore.Models;
using Microsoft.EntityFrameworkCore;
using WebShopApiCore.Utils;

namespace WebShopApiCore.Repository
{
    public class WebShopRepository : IWebShopRepository
    {
        private readonly AppDbContext context;

        public WebShopRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ItemDTO> GetItems()
        {
            return context.Items.Select(x => ItemDTO.FromEntity(x));
        }

        public IEnumerable<FinalCostPromotionDTO> GetFinalCostPromotions()
        {
            return context.FinalCostPromotions.Select(x => FinalCostPromotionDTO.FromEntity(x));
        }

        public IEnumerable<ItemQuantityPromotionDTO> GetItemQuantityPromotions()
        {
            return context.ItemQuantityPromotions.Include(x => x.Item).Include(x => x.QuantityPromotion).Select(x => ItemQuantityPromotionDTO.FromEntity(x));
        }

        public int SaveCustomer(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            customer.Email = customerDTO.Email;
            customer.Address = customerDTO.Address;
            customer.CreditCard = customerDTO.CreditCard;

            context.Customers.Add(customer);
            context.SaveChanges();

            return customer.CustomerID;
        }

        public decimal CalculatePrice(BasketDTO basket)
        {
            decimal finalPrice = 0;

            foreach (var item in basket.SelectedItems)
            {
                var itemQuantityPromotion = context.ItemQuantityPromotions.Include("Item").Include("QuantityPromotion").FirstOrDefault(x => x.ItemID == item.ItemID);

                decimal itemPrice = 0;

                if (itemQuantityPromotion != null)
                {
                    itemPrice = itemQuantityPromotion.Item.Price;
                    var promoQuantity = itemQuantityPromotion.QuantityPromotion.PromoQuantity;
                    var promoPrice = itemQuantityPromotion.QuantityPromotion.PromoPrice;

                    finalPrice += CostUtils.CalculatePriceWithQuantityDiscount(item.ItemQuantity, itemPrice, promoQuantity, promoPrice);
                }
                else
                {
                    itemPrice = context.Items.FirstOrDefault(x => x.ItemID == item.ItemID).Price;
                    finalPrice += itemPrice * item.ItemQuantity;
                }
            }


            // FinalCostPromotion

            var non_cumulative = basket.SelectedFinalCostPromotions.FirstOrDefault(x => !x.Cumulative);

            if (non_cumulative != null)
            {
                if (non_cumulative.PercentageValue > 0.00M)
                {
                    finalPrice -= CostUtils.CalculateFinalCostPercentageDiscount(finalPrice, non_cumulative.PercentageValue);
                }
                else if (non_cumulative.AbsoluteValue > 0.00M)
                {
                    finalPrice -= non_cumulative.AbsoluteValue;
                }
            }
            else
            {
                foreach (var promo in basket.SelectedFinalCostPromotions)
                {
                    if (promo.PercentageValue > 0.00M)
                    {
                        finalPrice -= CostUtils.CalculateFinalCostPercentageDiscount(finalPrice, promo.PercentageValue);
                    }
                    else if (promo.AbsoluteValue > 0.00M)
                    {
                        finalPrice -= promo.AbsoluteValue;
                    }
                }
            }

            return decimal.Truncate(finalPrice * 100m) / 100m;
        }

        public int SaveOrder(BasketDTO basket)
        {
            int ok = 0;

            var totalPrice = CalculatePrice(basket);

            var order = new Order() {
                CustomerID = basket.CustomerID,
                TotalPrice = totalPrice,
                Date = DateTime.Now.Date
            };
            context.Orders.Add(order);
            ok = context.SaveChanges();

            var orderID = order.OrderID;

            foreach (var item in basket.SelectedItems)
            {
                var orderItem = new OrderItem()
                {
                    OrderID = orderID,
                    ItemID = item.ItemID,
                    Quantity = item.ItemQuantity
                };

                context.OrderItems.Add(orderItem);

                ok = context.SaveChanges();
            }

            foreach (var item in basket.SelectedFinalCostPromotions)
            {
                var orderFinalCostPromotion = new OrderFinalCostPromotion()
                {
                    OrderID = orderID,
                    FinalCostPromotionID = item.FinalCostPromotionID
                };

                context.OrderFinalCostPromotions.Add(orderFinalCostPromotion);
                ok = context.SaveChanges();
            }

            return ok;
        }
    }
}
