using System;

namespace TheShop.Exceptions
{
    public class ArticleNotFoundException : Exception
    {


        public ArticleNotFoundException(string message) : base(message)
        {
        }


    }
}
