using System.ComponentModel.DataAnnotations;

namespace KoltsegvetesWebApp.Models
{
    public class Tranzakcio
    {
        public int Id { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Az összegnek pozitív számnak kell lennie!")]
        public decimal Osszeg { get; set; }
        public DateTime Datum { get; set; }

        [StringLength(200, ErrorMessage = "A megjegyzés maximum 200 karakter hosszú lehet!")]
        public string Megjegyzes { get; set; }
        public int KategoriaId { get; set; }

        //navigacio
        public Kategoria Kategoria { get; set; }
    }
}
