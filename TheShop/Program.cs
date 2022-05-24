using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TheShop.Common;
using TheShop.Exceptions;
using TheShop.Interfaces;
using TheShop.Model;
using TheShop.Services;

namespace TheShop
{
    public class Program
    {
        private readonly IShopService _shopService;
        public Program(IShopService shopService)
        {
            this._shopService = shopService;
        }
        private static void Main(string[] args)
        {
            //var shopService = new ShopService();
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run().Wait();

        }

        public async Task Run()
        {
            //order and sell
            try
            {
                Article article;
                var orderedArticle = await _shopService.OrderArticle(1, 20, 10);
                await _shopService.SellArticle(orderedArticle);
                //print article on console
                article = await _shopService.GetById(1);
                Console.WriteLine(article.ToString());

                article = await _shopService.GetById(12);
                Console.WriteLine(article.ToString());
            }
            catch (ArticleNotFoundException ex)
            {
                Console.WriteLine("Article not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();

        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<Program>();
                    services.AddScoped<IShopService, ShopService>();
                    services.AddScoped<IDatabaseService, DatabaseDriver>();
                    services.AddScoped<ILogger, Logger>();
                    services.AddScoped<IInventory, InventoryService>();
                });
        }

    }
}