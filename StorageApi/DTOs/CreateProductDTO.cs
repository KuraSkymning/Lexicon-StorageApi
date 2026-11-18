using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Produktnamn måste anges")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Pris måste anges")]
        [Range(1, 99999, ErrorMessage = "Pris måste vara inom intervallet 1 till 99999")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Kategori måste anges")]
        public string Category { get; set; } = "";
        [Required(ErrorMessage = "Hylla måste anges")]
        public string Shelf { get; set; } = "";
        [Required(ErrorMessage = "Antal måste anges")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Beskrivning måste anges")]
        [MinLength(0)]
        public string Description { get; set; } = "";
    }
}
