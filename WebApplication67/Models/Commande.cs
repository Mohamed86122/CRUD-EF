using System.ComponentModel.DataAnnotations;

namespace WebApplication67.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }

        public string libelle { get; set; }


        public int prix { get; set; }

        public int quantité { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }


    }
}
