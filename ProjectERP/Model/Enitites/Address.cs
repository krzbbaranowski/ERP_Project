using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectERP.Model.Enitites
{
    public class Address
    {
        [Key]
        [ForeignKey("Counterparty")]
        public int Id { get; set; }

        public string Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public string Province { get; set; }

        public virtual Counterparty Counterparty { get; set; }
    }
}