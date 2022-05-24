namespace TheShop.Model
{
    public class Supplier3
    {
        public Article GetArticle()
        {
            return new Article("Article from " + nameof(Supplier3), 460, 1);
        }
    }
}
