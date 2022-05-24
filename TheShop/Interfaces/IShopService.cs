using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Interfaces
{
    public interface IShopService
    {
        Task<Article> OrderArticle(int id, int maxExpectedPrice, int buyerId);
        Task<Article> GetById(int id);

        Task SellArticle(Article article);

    }
}
