using System;

namespace WebAdmin.Infrastructure.Models
{
    public class UserStatus
    {
        public string CultureID { get; set; }
        public byte UserStatusID { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}