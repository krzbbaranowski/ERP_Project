using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string REGON { get; set; }
        public string PESEL { get; set; }

        public virtual Address Address { get; set; }
    }
}
