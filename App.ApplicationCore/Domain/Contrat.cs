using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Contrat
    {
        [Key]
        public int NumeroContrat { get; set; }

        [Required(ErrorMessage = "Entrer La Date De DebutContrat!!")]
        public DateTime DateDebutContrat { get; set; }

        [Required(ErrorMessage = "Entrer La Date De FinContrat!!")]
        public DateTime DateFinContrat { get; set; }

        [Required(ErrorMessage = "Entrer Le Nombre De Jours De Location De La Voiture!!")]
        public int NombreJoursLocation { get; set; }
        public virtual Reservation Reservation { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public virtual Voiture Voiture { get; set; }

        [ForeignKey("Voiture")]
        public string VoitureId { get; set; }
    }
}
