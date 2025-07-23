using API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ServiceInterfaces
{
    public interface IUserProfileService
    {
        Task<UserProfileDto> GetUserProfile(string username);
        Task<UserProfileDto> UpdateUserProfile(UserProfileDto userProfileDto);
    }
}
