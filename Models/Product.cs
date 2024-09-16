using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FirstDescendantMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [EnumDataType(typeof(Rarity))]
        public Rarity Rarity { get; set; }

        [EnumDataType(typeof(Category))]
        public Category Category { get; set; } 
        
        public int Price { get; set; }



        public string Description { get; set; } = "";

        [MaxLength(100)]

        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public enum Rarity
    {
        Normal=1,
        Rare=2,
        Ultimate=3,
        Descendant=4
    }

    public enum Category
    {
        Code=1,
        Blueprint=2,
        Modules=3,
        [Display (Name ="Basic Material")]
        Basic_Material=4


    }
}
