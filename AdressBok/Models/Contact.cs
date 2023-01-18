using AdressBok.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBok.Models
{
    internal class Contact : IContact
    {
        public Guid ContactId { get; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get ; set ; } = null!;
        public string Email { get; set; } = null!; 
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;

        public string DisplayName => $"{FirstName} {LastName}";


    }
}
