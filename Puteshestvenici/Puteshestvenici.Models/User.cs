using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Puteshestvenici.Models
{
    public class User
    {
        private ICollection<Trip> trips;
        private ICollection<Trip> tripsAsPassenger;

        public User()
        {
            this.trips = new HashSet<Trip>();
            this.tripsAsPassenger = new HashSet<Trip>();
        }

        public Guid UserID { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username must be at least {2} symbols long", MinimumLength = 3)]
        public string Username { get; set; }

        public string ProfilePicLocation { get; set; }

        public virtual Location City { get; set; }

        public virtual ICollection<Trip> Trips
        {
            get
            {
                return this.trips;
            }

            set
            {
                this.trips = value;
            }
        }

        public virtual ICollection<Trip> TripsAsPassenger
        {
            get
            {
                return this.tripsAsPassenger;
            }

            set
            {
                this.tripsAsPassenger = value;
            }
        }
    }
}
