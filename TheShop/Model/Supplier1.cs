namespace TheShop.Model
{
    public class Supplier1
    {
        public Article GetArticle()
        {
            return new Article("Article from " + nameof(Supplier1), 458, 1);
        }
    }

}
