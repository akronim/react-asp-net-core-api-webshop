using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.DTO;
using WebShopApiCore.Models;

namespace WebShopApiCore.Repository
{
    public interface IWebShopRepository
    {
        IEnumerable<ItemDTO> GetItems();

        IEnumerable<FinalCostPromotionDTO> GetFinalCostPromotions();

        IEnumerable<ItemQuantityPromotionDTO> GetItemQuantityPromotions();

        int SaveCustomer(CustomerDTO customerDTO);

        int SaveOrder(BasketDTO basket);

        decimal CalculatePrice(BasketDTO basket);
    }
}
