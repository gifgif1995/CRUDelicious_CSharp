using System.ComponentModel.DataAnnotations;
using System;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int ID{get;set;}
        
        [Required(ErrorMessage="Chef's Name is required")]
        [MinLength(2,ErrorMessage="Name needs to be a little longer please")]
        [MaxLength(45, ErrorMessage="Thats a really long name!")]
        [Display(Name="Chef's Name: ")]
        public string ChefName {get;set;}

        [Required (ErrorMessage="We need a name for that delicious Dish!")]
        [MinLength(2, ErrorMessage="There is no way your dish name is that small!")]
        [MaxLength(45, ErrorMessage="Okay, now that is way too much to remember!")]
        [Display(Name="Name of Dish: ")]
        
        public string DishName{get;set;}

        [Required(ErrorMessage="How many calories in this delicious dish?")]
        [MinValue(0, ErrorMessage="If it really has no calories, I want in!")]
        [Display(Name="# of Calories: ")]
        public int Calories{get;set;}

        [Required(ErrorMessage="How delicious was it?")]
        [Range(1,5, ErrorMessage="Needs to be a valid number between 1 & 5")]
        [Display(Name="Tastiness: ")]
        public int Tastiness{get;set;}

        [Required (ErrorMessage="Tell us how delicious this dish is!")]
        [MinLength(5, ErrorMessage="Come on, You can do better than that!")]
        public string Description{get;set;}
        public DateTime created_at {get;set;} = DateTime.Now;
        public DateTime updated_at{get;set;} = DateTime.Now;
    }
        public class MaxValueAttribute : ValidationAttribute
        {
            private readonly int _maxValue;
            public MaxValueAttribute(int maxValue)
            {
                _maxValue = maxValue;
            }
            public override bool IsValid(object value)
            {
                return (int)value <= _maxValue;
            }
        }
        public class MinValueAttribute : ValidationAttribute
        {
            private readonly int _minValue;
            public MinValueAttribute(int minValue)
            {
                _minValue = minValue;
            }
            public override bool IsValid(object value)
            {
                return (int)value >= _minValue;
            }
        }
}