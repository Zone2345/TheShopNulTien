using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheShop.Model
{
    public class Article
    {
        public Article(string name, int price, int id)
        {
            NameOfArticle = name;
            ArticlePrice = price;
            Id = id;
        }
        public int Id { get; set; }
        public string NameOfArticle { get; set; }
        public int ArticlePrice { get; set; }
        public bool IsSold { get; set; }
        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }
        
        public override string ToString()
        {
            return "Found article with ID: " + Id;
        }
    }
}
