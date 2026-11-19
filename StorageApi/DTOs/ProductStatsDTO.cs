using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductStatsDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Antal produkter får inte vara negativt")]
        public int NumberOfProducts { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Totalt värde får inte vara negativt")]
        public int TotalInventoryValue { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Genomsnittligt pris får inte vara negativt")]
        public double AveragePrice { get; set; }
    }
}
