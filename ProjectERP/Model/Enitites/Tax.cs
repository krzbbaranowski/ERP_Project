using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }
        public double TaxValue { get; set; }
    }
}