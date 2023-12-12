using App.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IServiceContrat : IService<Contrat>
    {
        public float CalculTotaleSalaires(List<Contrat> contrats);
        public Contrat ADDContrat(Contrat contrat);
    }
}
