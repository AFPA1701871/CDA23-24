﻿namespace API_Personnes2.Models.DTOs
{
    public class PersonnesDto
    {

        public string Nom { get; set; } = null!;

        public string Prenom { get; set; } = null!;

        public string? Adresse { get; set; }

        public string? Ville { get; set; }
    }

}
