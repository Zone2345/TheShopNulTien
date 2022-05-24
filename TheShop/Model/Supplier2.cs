namespace TheShop.Model
{
    public class Supplier2
    {
        public Article GetArticle()
        {
            return new Article("Article from " + nameof(Supplier2), 459, 1);
        }
    }
}
