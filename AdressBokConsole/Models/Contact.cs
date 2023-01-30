using AdressBokConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBokConsole.Models
{
    public class Contact : IContact
    {
        public Guid ContactId { get; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
