using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBokConsole.Interface
{
    internal interface IContact
    {
        Guid ContactId { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }    
        string Address { get; set; }
        string PostalCode { get; set; }
        string City { get; set; }

    }
}
