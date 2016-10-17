using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Infrastructure.Models
{
    [Table("mpats_L_OrganisationStatus")]
    public class OrganisationStatus
    {
        public string CultureID { get; set; }
        [Key]
        public byte OrganisationStatusID { get; set; }
        [Column("OrganisationStatus")]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}