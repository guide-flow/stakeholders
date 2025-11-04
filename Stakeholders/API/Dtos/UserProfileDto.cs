using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserProfileDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ProfilePictureUrl { get; set; }
        public string? ImageBase64 { get; set; }
        public string Biography { get; set; } = string.Empty;
        public string Moto { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
