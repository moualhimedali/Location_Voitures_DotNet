using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public enum EtatReservation
    {
        ENATTENTE,ACCEPTE,REFUSE
    }
    public enum MarqueVoiture
    {
        AUDI,BMW,MERCEDES,PEUGEOT,RENAULT
    }
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        [Required(ErrorMessage = "Entrer La Date De DebutLocation!!")]
        public DateTime DateDebutLocation { get; set; }

        [Required(ErrorMessage = "Entrer La Date De FinLocation!!")]
        public DateTime DateFinLocation { get; set; }

        [Required(ErrorMessage = "Entrer La Date De Reservation!!")]
        public DateTime DateReservation { get; set; }

        [Required(ErrorMessage = "Le prix doit être exactement égal à 150!!"), Range(150,150)]
        public float PrixLocationParJour { get; set; }
        public MarqueVoiture MarqueVoiture { get; set; }
        public EtatReservation EtatReservation { get; set;}
        public virtual Client Client { get; set; }
        
        [ForeignKey("Client")]
        public int ClientId { get; set; }
    }

}

