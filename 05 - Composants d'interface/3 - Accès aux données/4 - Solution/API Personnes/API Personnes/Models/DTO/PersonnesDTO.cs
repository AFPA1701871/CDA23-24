namespace API_Personnes.Models.DTO
{
    public class PersonnesDTO
    {
        public string? Nom { get; set; }

        public string? Prenom { get; set; }

        public string Adresse { get; set; } = null!;

        public string Ville { get; set; } = null!;
    }
}
