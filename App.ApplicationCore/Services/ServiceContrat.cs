using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ServiceContrat : Service<Contrat>, IServiceContrat
    {
        public ServiceContrat(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Contrat ADDContrat(Contrat contrat)
        {
            
            //var status = contrat.Contrats.Where(m => m.ReservationId != contrat.ReservationId && m.VoitureId != contrat.VoitureId).FirstOrDefault();
            //if (status == null)
            //throw new NotImplementedException();
            return contrat;
        }

        public float CalculTotaleSalaires(List<Contrat> contrats)
        {


            float totaleSalaires = 0;
            foreach (Contrat contrat in contrats)
            {
                //totaleSalaires += contrat.Salaire;
            }
            return totaleSalaires;
        }

    }
}
