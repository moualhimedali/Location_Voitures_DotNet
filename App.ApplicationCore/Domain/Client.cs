using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [Required (ErrorMessage = "Entrer Votre Nom!!")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Entrer Votre Prenom!!")]
        public string Prenom { get; set; }

        [Required, Range(0,int.MaxValue), RegularExpression(@"^\d{8}$", ErrorMessage = "Le Numéro De Téléphone Doit Comporter 8 Chiffres!!")]
        public int NumeroTelephone { get; set; }

        [Required(ErrorMessage = "Entrer Votre Date De Naissance!!")]
        public DateTime DateNaissance { get; set; }
        public string Photo { get; set; }

        [Required(ErrorMessage = "Entrer Votre Permis!!")]
        public string PermisConduire { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        
    }
}
