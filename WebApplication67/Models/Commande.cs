using System.ComponentModel.DataAnnotations;

namespace WebApplication67.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }

        [Required]
        public string? Libelle { get; set; }

        [Required]
        public int Prix { get; set; }

        [Required]
        public int Quantite { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; } 
    }
}