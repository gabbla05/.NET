using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public interface IReservable
    {
        void Reserve(string customer);
        void CancelReservation();
    }


}
