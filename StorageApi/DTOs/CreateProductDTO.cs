using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Produktnamn måste anges")]
        [MinLength(1)]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Pris måste anges")]
        [Range(1, 1000000, ErrorMessage = "Pris måste vara inom intervallet 1 till 1000000")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Kategori måste anges")]
        public string Category { get; set; } = "";
        [Required(ErrorMessage = "Hylla måste anges")]
        public string Shelf { get; set; } = "";
        [Required(ErrorMessage = "Antal måste anges")]
        [Range(0, 10000000, ErrorMessage = "Antal måste vara inom intervallet 0 till 10000000")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Beskrivning måste anges")]
        [MinLength(0)]
        public string Description { get; set; } = "";
    }
}
