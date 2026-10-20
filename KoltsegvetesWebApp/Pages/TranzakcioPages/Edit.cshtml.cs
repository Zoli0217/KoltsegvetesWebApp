using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.TranzakcioPages;

public class EditModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public EditModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Tranzakcio Tranzakcio { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tranzakcio = await _context.Tranzakciok.FirstOrDefaultAsync(m => m.Id == id);
        if (tranzakcio is null)
        {
            return NotFound();
        }
        Tranzakcio = tranzakcio;
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

        _context.Attach(Tranzakcio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TranzakcioExists(Tranzakcio.Id))
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

    private bool TranzakcioExists(int id)
    {
        return _context.Tranzakciok.Any(e => e.Id == id);
    }
}
