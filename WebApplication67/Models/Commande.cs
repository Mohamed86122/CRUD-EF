using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication67.Models
{

    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }

        [Required(ErrorMessage = "Libelle obligatoire")]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "Prix obligatoire")]
        public int Prix { get; set; }

        [Required(ErrorMessage = "Quantite is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Entrez Quantité Valide")]

        public int Quantite { get; set; }


        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}