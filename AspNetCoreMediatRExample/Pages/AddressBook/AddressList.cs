using System;
using System.Collections.Generic;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public static class AddressDb
    {
        public static List<AddressBookEntry> Addresses { get; } = new List<AddressBookEntry>();
    }

    public class AddressBookEntry
    {
        private AddressBookEntry(string line1, string city, string state, string postalCode)
        {
            Id = Guid.NewGuid();
            Line1 = line1;
            Line2 = Line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        private AddressBookEntry(string line1, string line2, string city, string state, string postalCode)
            : this(line1, city, state, postalCode) =>
            Line2 = line2;

        public Guid   Id         { get; private set; }
        public string Line1      { get; }
        public string Line2      { get; }
        public string City       { get; }
        public string State      { get; }
        public string PostalCode { get; }

        public static AddressBookEntry Create(string line1, string city, string state, string postalCode)
            => new AddressBookEntry(line1, city, state, postalCode);

        public static AddressBookEntry Create(string line1, string line2, string city, string state, string postalCode)
            => new AddressBookEntry(line1, line2, city, state, postalCode);

        public static AddressBookEntry Create(Guid id, string line1, string line2, string city, string state, string postalCode)
            => new AddressBookEntry(line1, line2, city, state, postalCode){Id = id};

        public static AddressBookEntry CreateEmpty() => Create(Guid.Empty, null, null, null, null, null);

        public string Lines1And2() => string.IsNullOrEmpty(Line2) ? Line1 : $"{Line1} {Line2}";
    }
}