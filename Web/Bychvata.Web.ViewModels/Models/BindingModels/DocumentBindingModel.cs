using Bychvata.Data.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class DocumentBindingModel
    {
        [Required]
        public DocumentType Type { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public int GuestId { get; set; }
    }
}