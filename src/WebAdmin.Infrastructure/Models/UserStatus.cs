using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Infrastructure.Models
{
    [Table("mpats_L_UserStatus")]
    public class UserStatus
    {
        public string CultureID { get; set; }

        [Key]
        public byte UserStatusID { get; set; }

        [Column("UserStatus")]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}