using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class ArticleType
    {
        [Key]
        public int Id { get; set; }

        public string ArticleTypeName { get; set; }
    }
}