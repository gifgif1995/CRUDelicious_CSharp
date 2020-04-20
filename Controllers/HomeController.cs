using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CRUDelicious.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private DishContext dbContext;
        public HomeController(DishContext context)
        {
            dbContext = context;
        }
       
        [HttpGet("")] 
           public IActionResult Index()
        {
            List<Dish> Dishes = dbContext.dish.OrderByDescending(d=>d.created_at).ToList();
            
            return View(Dishes);
        }
        [HttpPost("addDish")] 
        public IActionResult CreateDish(Dish newDish)
        {   
            if(ModelState.IsValid)
            {
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }
        [HttpGet("new")] 
        public IActionResult New()
        {
            return View();
        }

        [HttpGet("{dishID}")]  
        public IActionResult Dish(int dishID)
        {
            Dish Dish = dbContext.dish.FirstOrDefault(d=>d.ID == dishID);
            ;
            return View(Dish);
        }

        [HttpGet("/edit/{dishID}")] 
        public IActionResult Edit(int dishID)
        {
            Dish Dish = dbContext.dish.FirstOrDefault(d=>d.ID ==dishID);
            
            return View(Dish);
        }
        [HttpPost("/edit/{dishID}")] 
        public IActionResult editDish(Dish upDish, int dishID)
        {
            if(ModelState.IsValid)
            {
                Dish thisDish = dbContext.dish.FirstOrDefault(d=>d.ID ==dishID);
                thisDish.ChefName = upDish.ChefName;
                thisDish.Calories = upDish.Calories;
                thisDish.DishName = upDish.DishName;
                thisDish.Description = upDish.Description;
                thisDish.Tastiness = upDish.Tastiness;
                dbContext.SaveChanges();
                return RedirectToAction("Index", thisDish.ID);
            }
            return View("Edit", dishID);
        }
        [HttpGet("/delete/{dishID}")]
        public IActionResult Destroy(int dishID)
        {
            Dish thisDish = dbContext.dish.FirstOrDefault(d=> d.ID == dishID);
            dbContext.dish.Remove(thisDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}