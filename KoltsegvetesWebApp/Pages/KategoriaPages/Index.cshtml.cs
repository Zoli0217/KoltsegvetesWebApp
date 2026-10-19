using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;

namespace KoltsegvetesWebApp.Pages.KategoriaPages;

public class IndexModel : PageModel
{
    private readonly KoltsegvetesDbContext _context;

    public IndexModel(KoltsegvetesDbContext context)
    {
        _context = context;
    }

    public IList<Kategoria> Kategoria { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Kategoria = await _context.Kategoriak.ToListAsync();
    }
}
