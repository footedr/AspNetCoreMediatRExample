using System;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public static class AddressValidation
    {
        public static Guid ToGuid(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException();
            try
            {
                return new Guid(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Address()
        {
            // This is where I would validate the data from the view.
            // I do not trust any data that a user provides

            // State would be set from an enum so that the saved data is in 
            // the same format. Users like to get fancy here.

            // PostalCode would have a regex check

            // Depending on the address book usage, I would run the 
            // full address through an API to validate the address exists.
        }
    }
}
