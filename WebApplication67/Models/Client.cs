using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication67.Models
{
    public class Client
    {
        public Client()
        {
            Commandes = new List<Commande>();
        }

        [Key]
        public int IdClient { get; set; }

        [Required]
        [Display(Name = "Nom Complet")]
        public string NomComplet { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }
}