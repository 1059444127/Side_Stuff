using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Puteshestvenici.Data;
using Puteshestvenici.Models;

namespace Puteshestvenici.ConsoleTestingClient
{
    public class ConsoleTestingClient
    {
        public static void Main()
        {
            var data = new PuteshestveniciData();
            data.Locations.GetAll().Count();
            //var user = data.Users.GetAll().ToList().LastOrDefault();

            ////var trip = new Trip()
            ////{
            ////    CurrentCapacity = 0,
            ////    MaxCapacity = 2,
            ////    OnDate = DateTime.Now,
            ////    User = user,
            ////    ToLocationID = 2,
            ////    FromLocationID = 5
            ////};

            ////data.Trips.Add(trip);
            ////data.SaveChanges();
            //var trip = data.Trips.GetAll().FirstOrDefault();
            //trip.Passengers.Add(user);
            //data.SaveChanges();
        }
    }
}
