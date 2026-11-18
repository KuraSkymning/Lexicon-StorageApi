using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Produktnamn måste anges")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Pris måste anges")]
        [Range(1, 1000000, ErrorMessage = "Pris måste vara inom intervallet 1 till 1000000")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Antal måste anges")]
        [Range(0, 10000000, ErrorMessage = "Antal måste vara inom intervallet 0 till 10000000")]
        public int Count { get; set; }
        public int InventoryValue => Price * Count;
    }
}
