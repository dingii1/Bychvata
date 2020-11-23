using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bychvata.Data.Models
{
    public class Document : BaseModel<int>
    {
        [Required]
        public DocumentType Type { get; set; }

        [Required]
        public string Number { get; set; }

        public DateTime? IssueDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        [ForeignKey("Guest")]
        public int GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}