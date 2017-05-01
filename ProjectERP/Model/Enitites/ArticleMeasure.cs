using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class ArticleMeasure
    {
        [Key]
        public int Id { get; set; }

        public string ArticleMeasureName { get; set; }
    }
}