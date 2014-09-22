using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Puteshestvenici.Models
{
    public class Trip
    {
        private ICollection<User> passengers;
        private int currentCapacity;

        public Trip()
        {
            this.passengers = new HashSet<User>();
            this.PublishDate = DateTime.Now;
        }

        public int TripID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        
        [Required]
        public int FromLocationID { get; set; }

        [JsonIgnore]
        public virtual Location From { get; set; }

        [Required]
        public int ToLocationID { get; set; }

        [JsonIgnore]
        public virtual Location To { get; set; }

        [Required]
        public int MaxCapacity { get; set; }

        public int CurrentCapacity
        {
            get
            {
                return this.currentCapacity;
            }

            set
            {
                this.currentCapacity += value;
                if (this.currentCapacity >= MaxCapacity)
                {
                    this.IsFull = true;
                }

                this.IsFull = false;
            }
        }

        public bool IsFull { get; set; }

        [Required]
        public DateTime OnDate { get; set; }

        public DateTime PublishDate { get; set; }

        public string Details { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Passengers
        {
            get
            {
                return this.passengers;
            }

            set
            {
                this.passengers = value;
            }
        }
    }
}
