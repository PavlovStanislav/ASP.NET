using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {

        public Product Product { get; set; }
        public string MessageRezult { get; private set; }

        public void OnGet(string name, decimal? price)
        {
            MessageRezult = "Для товара можно определить скидку";
        }
        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = price * (decimal?)0.18;
            MessageRezult = $"Для товара { name} с ценой { price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
    }
}