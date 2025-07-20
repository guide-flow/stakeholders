using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class UserProfile
    {
        public long Id { get; protected set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string ProfilePicureUrl { get; set; }
        public string Biography { get; set; }
        public string Moto { get; set; }
        public long UserId { get; set; }

        public UserProfile() {
            FirstName = string.Empty;
            LastName = string.Empty;
            ProfilePicureUrl = string.Empty;
            Biography = string.Empty;
            Moto = string.Empty;
        }

        public UserProfile(string firstName, string lastName, string profilePicureUrl, string biography, string moto)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilePicureUrl = profilePicureUrl;
            Biography = biography;
            Moto = moto;
        }   
    }
}
