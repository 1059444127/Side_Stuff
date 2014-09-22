using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Puteshestvenici.Services.Models
{
    public class TripModel
    {
        public int TripID { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public DateTime OnDate { get; set; }

        public DateTime PublishDate { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public bool IsFull { get; set; }
    }
}