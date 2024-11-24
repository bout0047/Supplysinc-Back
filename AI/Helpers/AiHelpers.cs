using SupplySyncBackend.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SupplySyncBackend.Helpers
{
    public static class AIHelpers
    {
        public static List<InventoryForecastDto> PredictInventoryNeeds(IEnumerable<InventoryForecastDto> salesData, int lookAheadDays)
        {
            var groupedData = salesData
                .GroupBy(s => s.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    AverageDailySales = g.Average(s => s.SalesQuantity)
                });

            var forecast = groupedData.Select(g => new InventoryForecastDto
            {
                ProductId = g.ProductId,
                SalesQuantity = g.AverageDailySales * lookAheadDays
            }).ToList();

            return forecast;
        }

        public static List<ExpiringProductsDto> GetExpiringProducts(IEnumerable<ExpiringProductsDto> products, int daysThreshold)
        {
            var now = DateTime.Now;

            var expiringProducts = products
                .Where(p => p.ExpirationDate.HasValue &&
                            (p.ExpirationDate.Value - now).TotalDays <= daysThreshold)
                .ToList();

            return expiringProducts;
        }

        public static List<SupplierRecommendationDto> RecommendSuppliers(IEnumerable<SupplierRecommendationDto> suppliers, int productId)
        {
            var recommendedSuppliers = suppliers
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.Rating)
                .ThenBy(s => s.ProductCategory)
                .ToList();

            return recommendedSuppliers;
        }

        public static List<DiscountRecommendationDto> GenerateDiscountRecommendations(IEnumerable<ExpiringProductsDto> products)
        {
            var recommendations = products.Select(p => new DiscountRecommendationDto
            {
                ProductId = p.ProductId,
                SuggestedDiscount = CalculateDiscount(p.ExpirationDate.Value)
            }).ToList();

            return recommendations;
        }

        private static double CalculateDiscount(DateTime expirationDate)
        {
            var daysToExpiration = (expirationDate - DateTime.Now).TotalDays;

            if (daysToExpiration <= 3)
                return 50;
            if (daysToExpiration <= 7)
                return 30;
            return 10;
        }
    }
}
