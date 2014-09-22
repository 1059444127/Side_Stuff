using System;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Puteshestvenici.Data;
using Puteshestvenici.Models;
using Puteshestvenici.Services.Infrastructure;
using Puteshestvenici.Services.Models;

namespace Puteshestvenici.Services.Controllers
{
    [Authorize]
    public class TripsController : BaseController
    {
        public TripsController()
            : this(new PuteshestveniciData(), new AspUserIDProvider())
        {
        }

        public TripsController(IPuteshestveniciData data, IUserIDProvider userIDProvider)
            : base(data, userIDProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult UserTrips()
        {
            var userID = this.idProvider.GetUserID();
            var guidUserID = Guid.Parse(userID);
            var user = this.data.Users.Find(u => u.UserID == guidUserID).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Invalid user id.");
            }

            return this.GetUserTrips(user);
        }

        [HttpGet]
        public IHttpActionResult UserTrips(string id)
        {
            var guidUserID = Guid.Parse(id);
            var user = this.data.Users.Find(u => u.UserID == guidUserID).FirstOrDefault();
            if (user == null)
            { 
                return BadRequest("Invalid user id.");
            }

            return this.GetUserTrips(user);
        }



        private IHttpActionResult GetUserTrips(User user)
        {
            var userTripsModel = this.BuildUserTripsModel(user);
            return Ok(userTripsModel);
        }

        private UserTripsModel BuildUserTripsModel(User user)
        {
            var userTrips = new UserTripsModel()
            {
                UserID = user.UserID,
                Username = user.Username
            };

            foreach (var trip in user.Trips)
            {
                var currentTripModel = this.BuildTripModel(trip);
                userTrips.TripsAsCreator.Add(currentTripModel);
            }

            foreach (var trip in user.TripsAsPassenger)
            {
                var currentTripModel = this.BuildTripModel(trip);
                userTrips.TripsAsPassenger.Add(currentTripModel);
            }

            return userTrips;
        }

        private TripModel BuildTripModel(Trip trip)
        {
            var tripModel = new TripModel()
            {
                TripID = trip.TripID,
                ToLocation = trip.To.Name,
                FromLocation = trip.From.Name,
                PublishDate = trip.PublishDate,
                OnDate = trip.OnDate,
                MaxCapacity = trip.MaxCapacity,
                CurrentCapacity = trip.CurrentCapacity,
                IsFull = trip.IsFull
            };

            return tripModel;
        }
    }
}
