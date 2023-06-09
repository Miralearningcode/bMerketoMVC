﻿using WebApp.Models.Dto;

namespace WebApp.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string? ImageUrl { get; set; }

   
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
