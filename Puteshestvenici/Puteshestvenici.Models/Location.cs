using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Puteshestvenici.Models
{
    public class Location
    {
        private ICollection<Trip> fromTrips;
        private ICollection<Trip> toTrips;

        public Location()
        {
            this.fromTrips = new HashSet<Trip>();
            this.toTrips = new HashSet<Trip>();
        }

        public int LocationID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Trip> FromTrip
        {
            get
            {
                return this.fromTrips;
            }

            set
            {
                this.fromTrips = value;
            }
        }

        public virtual ICollection<Trip> ToTrip
        {
            get
            {
                return this.toTrips;
            }

            set
            {
                this.toTrips = value;
            }
        }
    }
}
