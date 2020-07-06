using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopApiCore.DTO
{
    public class BasketDTO
    {
        public int CustomerID { get; set; }
        public List<ItemSelectedDTO> SelectedItems { get; set; }
        public List<FinalCostPromotionDTO> SelectedFinalCostPromotions { get; set; }
    }
}
