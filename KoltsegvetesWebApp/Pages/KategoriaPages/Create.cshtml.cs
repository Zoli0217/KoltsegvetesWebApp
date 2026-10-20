using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoltsegvetesWebApp.Models;
using KoltsegvetesWebApp.Data;
using KoltsegvetesWebApp.DTOs;

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
    public KategoriaPostDTO Kategoria { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var ujKategoria = new Kategoria
        {
            Nev = Kategoria.Nev,
            Tipus = Enum.Parse<Kategoria.KategoriaTipus>(Kategoria.Tipus)
        };

        _context.Kategoriak.Add(ujKategoria);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
