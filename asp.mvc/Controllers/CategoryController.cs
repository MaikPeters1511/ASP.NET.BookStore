﻿using asp.mvc.Data;
using asp.mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp.mvc.Controllers
{
    public class CategoryController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext context = context;

        public IEnumerable<Category> GetCategoriesList() => context.Categories;

        public IActionResult Index() => View(GetCategoriesList());
    }
}
