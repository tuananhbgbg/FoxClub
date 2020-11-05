using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoxClub.Models;
using FoxClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoxClub.Controllers
{
    public class HomeController : Controller
    {
        FoxListService services;
        public HomeController(FoxListService service)
        {
            services = service;
        }
        [Route("")]
        public IActionResult Index(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return View("Login");
            }
            var fox = services.GetFox(name);
            return View("Index",fox);
        }
        [HttpGet("/login")]
        public IActionResult ShowLoginPage()
        {
            services.NewInstance();
            return View("Login");
        }
        [HttpPost("/login")]
        public IActionResult RegisterFoxName(Fox fox)
        {
            return Index(fox.Name);
        }
        [HttpGet("/nutritionStore")]
        public IActionResult NutritionStore( string food,string drink)
        {
            return View();
        }
        [HttpPost("/nutritionStore")]
        public IActionResult ChangeNutrition(string food, string drink)
        {
            services.BuyNutrition(food,drink);
            return Index(services.FindFoxName());
        }
        [HttpGet("/trick-center")]
        public IActionResult TrickCenter()
        {
            return View();
        }
        [HttpPost("/trick-center")]
        public IActionResult TrickCenter(string trick)
        {
            services.ChangeTrick(trick);
            return Index(services.FindFoxName());
        }
    }
}
