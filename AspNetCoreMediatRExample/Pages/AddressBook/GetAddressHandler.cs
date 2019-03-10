using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook {
   public class GetAddressHandler
      : IRequestHandler<GetAddressRequest, AddressBookEntry> {

      public async Task<AddressBookEntry> Handle(GetAddressRequest request, CancellationToken cancellationToken) {
         try {
            //Create Guid from id string
            Guid.TryParse(request.Id, out Guid guid);
            if (guid.Equals(Guid.Empty)) {
               Debug.WriteLine($"{nameof(GetAddressHandler)}.{nameof(Handle)}: id is not a guid");
               return AddressBookEntry.CreateEmpty();
            }

            //Get AddressBookEntry from AddressDb
            AddressBookEntry addressBookEntry = AddressDb.Addresses.FirstOrDefault(x=>x.Id == guid);
            if (addressBookEntry == null) {
               Debug.WriteLine($"{nameof(GetAddressHandler)}.{nameof(Handle)}: can't find Address with id={guid.ToString()}");
               return AddressBookEntry.CreateEmpty();
            }

            return await Task.FromResult(addressBookEntry);
         }
         catch (Exception e) {
            Debug.WriteLine($"{nameof(GetAddressHandler)}.{nameof(Handle)} {e}");
            return AddressBookEntry.CreateEmpty();
         }
      }
   }
}
