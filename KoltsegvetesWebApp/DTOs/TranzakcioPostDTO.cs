namespace KoltsegvetesWebApp.DTOs
{
    public class TranzakcioPostDTO
    {
        public decimal Osszeg { get; set; }
        public DateTime Datum { get; set; }
        public string Megjegyzes { get; set; }
        public int KategoriaId { get; set; }

    }
}
