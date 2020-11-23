using System;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class AvailabilityViewModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public bool IsAvailable { get; set; }
    }
}