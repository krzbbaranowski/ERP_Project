using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class ArticleGroup
    {
        [Key]
        public int Id { get; set; }

        public string ArticleGroupCode { get; set; }
        public string ArticleGroupName{ get; set; }

        public virtual ArticleGroup MasterArticleGroup { get; set; }

    }
}