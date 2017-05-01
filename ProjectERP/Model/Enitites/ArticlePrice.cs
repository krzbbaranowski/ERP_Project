using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class ArticlePrice
    {
        [Key]
        public int Id { get; set; }

        public double ArticlePriceValueNetto { get; set; }
        public double ArticlePriceValueBrutto { get; set; }

        public virtual Article Article { get; set; }
        public virtual ArticlePriceType ArticlePriceType { get; set; }
    }
}