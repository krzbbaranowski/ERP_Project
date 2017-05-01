using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectERP.Model.Enitites
{
    public class ArticlePriceType
    {
        [Key]
        public int Id { get; set; }
        public string ArticlePriceName { get; set; }
    }
}