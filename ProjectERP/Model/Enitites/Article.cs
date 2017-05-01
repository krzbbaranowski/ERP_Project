using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class Article
    {
        public Article()
        {
            ArticlePrice = new HashSet<ArticlePrice>();
        }

        [Key]
        public int Id { get; set; }

        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public double ArticleQuantity { get; set; }

        public double ArticleCount { get; set; }
        public string ArticleEan { get; set; }

        public virtual ArticlePrice DefaultArticlePrice { get; set; }
        public virtual ICollection<ArticlePrice> ArticlePrice { get; set; }
        public virtual Tax ArticleTax { get; set; }
        public virtual ArticleType ArticleType { get; set; }
        public virtual ArticleMeasure ArticleMeasure { get; set; }
    }
}