using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.RepositoryInterfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Create(UserProfile userProfile);
        Task<UserProfile> GetUserProfileAsync(string username);
        Task<UserProfile> Update(UserProfile userProfile);
        Task<UserProfile> GetUserProfileByIdAsync(long id);
        Task<List<UserProfile>> GetAllUserProfilesAsync();
    }
}
