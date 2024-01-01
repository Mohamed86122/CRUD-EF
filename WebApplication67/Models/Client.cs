using System.ComponentModel.DataAnnotations;

namespace WebApplication67.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        public string nomcomplet { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }
}
