using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.KategoriaPages;

public class CreateModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public CreateModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Kategoria Kategoria { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Kategoriak.Add(Kategoria);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
