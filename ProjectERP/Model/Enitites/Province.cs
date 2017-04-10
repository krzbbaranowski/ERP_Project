using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectERP.Model.Enitites
{
    public class Province
    {
        public Province()
        {
            Address = new HashSet<Address>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}