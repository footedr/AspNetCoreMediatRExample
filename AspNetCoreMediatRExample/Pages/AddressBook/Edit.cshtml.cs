using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public async Task<ActionResult> OnGet(string id) {
            GetAddressRequest request          = new GetAddressRequest { Id = id };
            AddressBookEntry  addressBookEntry = await _mediator.Send(request);
            if (addressBookEntry.Id == Guid.Empty)
                return NotFound();

            UpdateAddressRequest = UpdateAddressRequest.Create(addressBookEntry);
            return Page();
        }

        public async Task<ActionResult> OnPost() {
            if (ModelState.IsValid) {
                AddressBookEntry addressBookEntry = await _mediator.Send(UpdateAddressRequest);
                Debug.WriteLine("");
                Debug.WriteLine($"Updated AddressBookEntry for {addressBookEntry}");
                Debug.WriteLine("");
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}