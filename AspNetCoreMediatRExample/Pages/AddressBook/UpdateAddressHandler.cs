using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook {
   public class UpdateAddressHandler
      : IRequestHandler<UpdateAddressRequest, AddressBookEntry> {

      public async Task<AddressBookEntry> Handle(UpdateAddressRequest request, CancellationToken cancellationToken) {
         Guid.TryParse(request.Id, out Guid guid);
         if (Equals(guid, Guid.Empty)) {
            Debug.WriteLine($"({nameof(UpdateAddressRequest)}){nameof(request)}.Id - {request.Id} is not a valid Guid");
            return AddressBookEntry.CreateEmpty();
         }

         int index = AddressDb.Addresses.FindIndex(x=>x.Id == guid);
         if (index == -1) {
            Debug.WriteLine($"Can't find {nameof(AddressBookEntry)} for {guid.ToString()}");
            return AddressBookEntry.CreateEmpty();
         }

         AddressDb.Addresses[index] = AddressBookEntry.Create(guid, request.Line1, request.Line2, request.City, request.State, request.PostalCode);
         return await Task.FromResult(AddressDb.Addresses[index]);
      }

   }
}
