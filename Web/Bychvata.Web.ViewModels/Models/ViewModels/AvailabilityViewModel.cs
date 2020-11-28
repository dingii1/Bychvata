using System;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class AvailabilityViewModel
    {
        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public bool IsAvailable { get; set; }
    }
}