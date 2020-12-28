namespace Bychvata.Web.ViewModels.Models.Documents
{
    using Bychvata.Data.Common.Enums;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DocumentBindingModel : IMapFrom<Document>
    {
        [Required]
        public DocumentType Type { get; set; }

        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public int GuestId { get; set; }
    }
}