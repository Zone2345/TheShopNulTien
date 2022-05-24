using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Interfaces
{
    public interface IInventory
    {
        Task<bool> ArticleInInventory(int id);
        //Task<Article> GetArticle(Suppliers supplier, int price);

        Task<List<Article>> ListOfArticles();
    }
}
