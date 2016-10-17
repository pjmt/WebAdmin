using System;

namespace WebAdmin.Infrastructure.Models
{
    public class OrganisationStatus
    {
        public string CultureID { get; set; }
        public byte OrganisationStatusID { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}