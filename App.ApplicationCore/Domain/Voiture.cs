using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public enum Marque
    {
        AUDI, BMW, MERCEDES, PEUGEOT, RENAULT
    }
    public enum CouleurVoiture
    {
        BLANC,BLEU,NOIR,ROUGE,GRIS,VERT
    }
    public class Voiture
    {
        [Key]
        public string Matricule { get; set; }

        //[Required(ErrorMessage = "Donner La Marque De La Voiture!!")]
        public Marque Marque { get; set; }

        [Required(ErrorMessage = "Le Nombre De Places De Voiture Est Entre 0 et 5 !!"), Range(0,5)]
        public int NombrePlace { get; set; }
        public CouleurVoiture Couleur { get; set; }
        public virtual ICollection<Contrat> Contrats { get; set; }

    }
}
