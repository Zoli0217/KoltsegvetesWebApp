using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.KategoriaPages;

public class DetailsModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;
    public DetailsModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

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
}
