using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.KategoriaPages;

public class EditModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public EditModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Kategoria Kategoria { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var kategoria = await _context.Kategoriak.FirstOrDefaultAsync(m => m.Id == id);
        if (kategoria is null)
        {
            return NotFound();
        }
        Kategoria = kategoria;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Kategoria).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KategoriaExists(Kategoria.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool KategoriaExists(int id)
    {
        return _context.Kategoriak.Any(e => e.Id == id);
    }
}
