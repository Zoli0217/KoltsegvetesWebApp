using System.ComponentModel.DataAnnotations;

namespace KoltsegvetesWebApp.Models
{
    public class Kategoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Név megadása kötelező!")]
        [StringLength(60, ErrorMessage ="A név maximum 60 karakter hosszú lehet!")]
        public string Nev { get; set; }
        public KategoriaTipus Tipus { get; set; }

        //navigacio
        public List<Tranzakcio> Tranzakciok { get; set; }

        public enum KategoriaTipus
        {
            Bevétel,
            Kiadás
        }
    }
}
