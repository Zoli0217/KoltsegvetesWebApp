using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.KategoriaPages;

public class DeleteModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public DeleteModel(KoltsegvetesDbContext context)
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
        else
        {
            Kategoria = kategoria;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var kategoria = await _context.Kategoriak.FindAsync(id);
        if (kategoria != null)
        {
            Kategoria = kategoria;
            _context.Kategoriak.Remove(Kategoria);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
