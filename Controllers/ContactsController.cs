using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contact_Management_Web_Application.Models;

namespace Contact_Management_Web_Application.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        // GET: search Contacts by name
        public IActionResult Search(string searchTerm)
        {
            var contacts = string.IsNullOrEmpty(searchTerm)
                ? _context.Contact.ToList()
                : _context.Contact
                    .Where(c => c.Name.Contains(searchTerm))
                    .ToList();

            if (contacts.Count == 0 && !string.IsNullOrEmpty(searchTerm))
            {
                TempData["SearchMessage"] = $"No contacts found with the name '{searchTerm}'.";
            }

            return View(contacts);
        }

        // GET: search Contacts by name
        public IActionResult DeleteByName(string searchTerm)
        {
            var contacts = string.IsNullOrEmpty(searchTerm)
                ? _context.Contact.ToList()
                : _context.Contact
                    .Where(c => c.Name.Contains(searchTerm))
                    .ToList();

            return View(contacts);
        }



        // Action to delete a contact by name
        [HttpPost, ActionName("DeleteByNameCon")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteByNameComfrimed(string name)
        {
            var contact = _context.Contact.FirstOrDefault(c => c.Name == name);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Contact with the name '{name}' was deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = $"Contact with the name '{name}' does not exist.";
            }
            return RedirectToAction(nameof(DeleteByName));
        }
        

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Name,Email,PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContactId,Name,Email,PhoneNumber")] Contact contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5 normale delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5 normale delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
