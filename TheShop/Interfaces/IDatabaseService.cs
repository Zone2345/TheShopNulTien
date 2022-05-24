using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Model;

namespace TheShop.Interfaces
{
    public interface IDatabaseService
    {
		Task<Article> GetById(int id);
		Task Save(Article article);
    }
}
