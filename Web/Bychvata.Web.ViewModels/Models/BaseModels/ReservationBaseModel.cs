using System;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Web.ViewModels.Models.BaseModels
{
    public class ReservationBaseModel
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }
    }
}