using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class Counterparty
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string Pesel { get; set; }

        public virtual Address Address { get; set; }
    }
}