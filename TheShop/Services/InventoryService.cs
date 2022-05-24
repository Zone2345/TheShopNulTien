using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Interfaces;
using TheShop.Model;

namespace TheShop.Services
{
    public class InventoryService : IInventory
    {
        private List<Article> articleList => new() { new Supplier1().GetArticle(), new Supplier2().GetArticle(), new Supplier3().GetArticle() };
        public async Task<bool> ArticleInInventory(int id) => articleList.Exists(x => x.Id == id);
        public async Task<List<Article>> ListOfArticles() => articleList;
    }

}
