using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.TranzakcioPages;

public class DeleteModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public DeleteModel(KoltsegvetesDbContext context)
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
        else
        {
            Tranzakcio = tranzakcio;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var tranzakcio = await _context.Tranzakciok.FindAsync(id);
        if (tranzakcio != null)
        {
            Tranzakcio = tranzakcio;
            _context.Tranzakciok.Remove(Tranzakcio);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
