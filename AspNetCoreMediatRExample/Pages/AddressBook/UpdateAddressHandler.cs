using MediatR;
using System;
using System.Linq;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    // I do not believe this is correct, but IRequestHandler
    // seems to require a return. 
    public class UpdateAddressHandler : RequestHandler<UpdateAddressRequest>
    {
        protected override void Handle(UpdateAddressRequest request)
        {
            // I didn't know if you wanted me to stay out of AddressList.cs
            // so I used the delete and recreate logic, but I would typically 
            // do an update. If there was a requirement on restricting updates I 
            // would have private setters on the properties and do the update in the model
            var guidId = AddressValidation.ToGuid(request.Id);
            var address = AddressDb.Addresses.Where(x => x.Id == guidId).FirstOrDefault();
            if (address == null)
                throw new Exception("Address " + request.Id + " does not exists.");
            AddressDb.Addresses.Remove(address);
            AddressDb.Addresses.Add(AddressBookEntry.Create(request.Line1, request.Line2, request.City, request.State, request.PostalCode));
        }
    }
}
