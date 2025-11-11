using Core.Domain;
using Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly StakeholdersContext _context;
        public UserProfileRepository(StakeholdersContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> Create(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<UserProfile> GetUserProfileAsync(string username)
        {
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.Username == username);
            return userProfile;
        }

        public async Task<UserProfile> Update(UserProfile userProfile)
        {
            var existing = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.Username == userProfile.Username);

            if (existing == null) return null;

            existing.FirstName = userProfile.FirstName;
            existing.LastName = userProfile.LastName;

            // Only update ProfilePictureUrl if a new value is provided
            if (!string.IsNullOrEmpty(userProfile.ProfilePictureUrl))
            {
                existing.ProfilePictureUrl = userProfile.ProfilePictureUrl;
            }

            existing.Biography = userProfile.Biography;
            existing.Moto = userProfile.Moto;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<UserProfile> GetUserProfileByIdAsync(long id)
        {
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.Id == id);
            return userProfile;
        }

        public async Task<List<UserProfile>> GetAllUserProfilesAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

    }
}
