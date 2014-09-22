using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Puteshestvenici.Services.Models
{
    public class UserTripsModel
    {
        public UserTripsModel()
        {
            this.TripsAsCreator = new HashSet<TripModel>();
            this.TripsAsPassenger = new HashSet<TripModel>();
        }

        public Guid UserID { get; set; }

        public string Username { get; set; }

        public ICollection<TripModel> TripsAsCreator { get; set; }

        public ICollection<TripModel> TripsAsPassenger { get; set; }
    }
}