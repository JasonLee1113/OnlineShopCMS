﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopCMS.Data;

namespace OnlineShopCMS.ViewComponents
{
    public class CategoriesList : ViewComponent
    {
        private readonly OnlineShopContext _context;

        public CategoriesList(OnlineShopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.Category.ToListAsync();
            return View(items);
        }
    }
}
