using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Models
{
    public class Fox
    {
        public string Name { get; set; }
        public List<string> Tricks { get; set; }
        public List<string> FoodDrink { get; set; }
        public Fox(string name)
        {
            Name = name;
            FoodDrink = new List<string>();
            Tricks = new List<string>();
            FoodDrink.Add("salad");
            FoodDrink.Add("water");
        }
        public Fox()
        {

        }
    }
}
