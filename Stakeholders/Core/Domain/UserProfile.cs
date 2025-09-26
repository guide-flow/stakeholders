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
        public string Username { get; set; } = string.Empty;

        public UserProfile() {
            FirstName = string.Empty;
            LastName = string.Empty;
            Username = string.Empty;
            ProfilePicureUrl = string.Empty;
            Biography = string.Empty;
            Moto = string.Empty;
        }

        public UserProfile(string firstName, string lastName,string username, string profilePicureUrl, string biography, string moto)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfilePicureUrl = profilePicureUrl;
            Biography = biography;
            Moto = moto;
            Username = username;
        }

        public UserProfile(long Id, string firstName, string lastName,string username, string profilePicureUrl, string biography, string moto) : this(firstName, lastName, username
            ,profilePicureUrl, biography, moto)
        {
            this.Id = Id;
        }
    }
}
