using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    private readonly IdentityContext _context;

    public ContactsController(IdentityContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";

        return View();
    }

    [HttpPost]
    public IActionResult Index(ContactFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            ContactFormEntity contactEntity = viewModel;
            MessageEntity messageEntity = viewModel;

            _context.ContactForm.Add(contactEntity);
            _context.Message.Add(messageEntity);
            _context.SaveChanges();

            ModelState.Clear();
            return View();
        }

   
        return View(viewModel);
    }

    public IActionResult Success()
    {
        return View();
    }
}
