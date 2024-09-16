using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FirstDescendantMVC.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required]
        [EnumDataType(typeof(Rarity))]

        public Rarity Rarity { get; set; } 

        [Required]
        [EnumDataType(typeof(Category))]

        public Category Category { get; set; } 
        [Required]
        public int Price { get; set; }
        [Required]


        public string Description { get; set; } = "";



        public IFormFile? ImageFile { get; set; }
    }
}
