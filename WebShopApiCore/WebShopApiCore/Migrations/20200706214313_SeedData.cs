using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopApiCore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FinalCostPromotion",
                columns: new[] { "FinalCostPromotionID", "AbsoluteValue", "Cumulative", "Description", "PercentageValue" },
                values: new object[,]
                {
                    { 1, 0m, false, "20% OFF", 20m },
                    { 2, 0m, true, "5% OFF", 5m },
                    { 3, 20m, true, "20 EURO FF", 0m }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Smart Hub", 49.99m },
                    { 2, "Motion Sensor", 24.99m },
                    { 3, "Wireless Camera", 99.99m },
                    { 4, "Smoke Sensor", 19.99m },
                    { 5, "Water Leak Sensor", 14.99m }
                });

            migrationBuilder.InsertData(
                table: "QuantityPromotion",
                columns: new[] { "QuantityPromotionID", "Description", "PromoPrice", "PromoQuantity" },
                values: new object[,]
                {
                    { 1, null, 65m, 3 },
                    { 2, null, 35m, 2 }
                });

            migrationBuilder.InsertData(
                table: "ItemQuantityPromotion",
                columns: new[] { "ItemQuantityPromotionID", "ItemID", "QuantityPromotionID" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ItemQuantityPromotion",
                columns: new[] { "ItemQuantityPromotionID", "ItemID", "QuantityPromotionID" },
                values: new object[] { 2, 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinalCostPromotion",
                keyColumn: "FinalCostPromotionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinalCostPromotion",
                keyColumn: "FinalCostPromotionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FinalCostPromotion",
                keyColumn: "FinalCostPromotionID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemQuantityPromotion",
                keyColumn: "ItemQuantityPromotionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemQuantityPromotion",
                keyColumn: "ItemQuantityPromotionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuantityPromotion",
                keyColumn: "QuantityPromotionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuantityPromotion",
                keyColumn: "QuantityPromotionID",
                keyValue: 2);
        }
    }
}
