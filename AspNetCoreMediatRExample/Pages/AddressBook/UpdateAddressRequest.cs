namespace AspNetCoreMediatRExample.Pages.AddressBook {
   public class UpdateAddressRequest : AddressRequestBase<AddressBookEntry> {

      public static UpdateAddressRequest Create(AddressBookEntry addressBookEntry) {
         return new UpdateAddressRequest {
                                            Id         = addressBookEntry.Id.ToString(),
                                            Line1      = addressBookEntry.Line1,
                                            Line2      = addressBookEntry.Line2,
                                            City       = addressBookEntry.City,
                                            State      = addressBookEntry.State,
                                            PostalCode = addressBookEntry.PostalCode
                                         };
      }

   }
}