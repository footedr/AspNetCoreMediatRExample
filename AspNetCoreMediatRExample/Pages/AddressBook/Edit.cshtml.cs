using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator) => _mediator = mediator;
        [BindProperty]
        public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public void OnGet(string id)
        {
            var guidId = AddressValidation.ToGuid(id);
            var address = AddressDb.Addresses.Where(x => x.Id == guidId).FirstOrDefault();
            if (address == null)
                throw new Exception("Address " + id + " does not exists.");
            // I would typically have a mapper method, but it 
            // seemed unnecessary in this situation
            UpdateAddressRequest = new UpdateAddressRequest()
            {
                Id = id,
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode
            };
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
                _ = await _mediator.Send(UpdateAddressRequest);
            /*else
                I would log this, but not throw an exception
            */
            return RedirectToPage("Index");
        }
    }
}