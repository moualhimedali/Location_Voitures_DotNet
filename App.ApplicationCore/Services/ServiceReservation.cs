using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {

        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
