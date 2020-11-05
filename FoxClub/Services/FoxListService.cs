using FoxClub.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxClub.Services
{
    public class FoxListService
    {
        public List<Fox> Foxes { get; set; }
        public int FoxIndex { get; set; }
        public FoxListService()
        {
            Foxes = new List<Fox>();
            FoxIndex = -1;
        }
        public void FoxCheckerAdder(string Name)
        {
            if (!Foxes.Exists(f => f.Name.Contains(Name)))
            {
                Foxes.Add(new Fox(Name));
                FoxIndex = Foxes.Count() - 1;
            } else
            {
                FoxIndex = Foxes.FindIndex(f => f.Name.Contains(Name));
            }
        }
        public void NewInstance()
        {
            FoxIndex = -1;
        }
        public Fox GetFox(string fox)
        {
            if (FoxIndex<0)
            {
            FoxCheckerAdder(fox);
            }

            return Foxes[FoxIndex];
        }
        public string FindFoxName()
        {
            return Foxes[FoxIndex].Name;
        }
        public void BuyNutrition(string food,string drink)
        {
            if (!String.IsNullOrEmpty(food))
            {
            Foxes[FoxIndex].FoodDrink[0] = food;
            }
            if (!String.IsNullOrEmpty(drink))
            {
            Foxes[FoxIndex].FoodDrink[1] = drink;
            }
        }
        public void ChangeTrick(string trick)
        {
            Foxes[FoxIndex].Tricks.Add(trick);
        }
    }
}
