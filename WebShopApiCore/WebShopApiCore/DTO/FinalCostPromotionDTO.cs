using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopApiCore.Models;

namespace WebShopApiCore.DTO
{
    public class FinalCostPromotionDTO
    {
        public Int32 FinalCostPromotionID { get; set; }

        public Decimal PercentageValue { get; set; }

        public Decimal AbsoluteValue { get; set; }

        public Boolean Cumulative { get; set; }

        public String Description { get; set; }

        public static FinalCostPromotionDTO FromEntity(FinalCostPromotion entity)
        {
            return new FinalCostPromotionDTO
            {
                FinalCostPromotionID = entity.FinalCostPromotionID,
                PercentageValue = entity.PercentageValue,
                AbsoluteValue = entity.AbsoluteValue,
                Cumulative = entity.Cumulative,
                Description = entity.Description
            };
        }

        public void ToEntity(FinalCostPromotion entity)
        {
            entity.FinalCostPromotionID = FinalCostPromotionID;
            entity.PercentageValue = PercentageValue;
            entity.AbsoluteValue = AbsoluteValue;
            entity.Cumulative = Cumulative;
            entity.Description = Description;
        }
    }
}
