using API.Dtos;
using API.ServiceInterfaces;
using AutoMapper;
using Core.Domain;
using Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> CreateUserProfile(UserProfileDto userProfileDto)
        {
            var userProfile = await _userProfileRepository.Create(_mapper.Map<UserProfile>(userProfileDto));
            return _mapper.Map<UserProfileDto>(userProfile);
        }

        public async Task<UserProfileDto> GetUserProfile(string username)
        {
            var userProfile = await _userProfileRepository.GetUserProfileAsync(username);
            return _mapper.Map<UserProfileDto>(userProfile);
        }

        public async Task<UserProfileDto> UpdateUserProfile(UserProfileDto userProfileDto)
        {
            var userProfile = await _userProfileRepository.Update(_mapper.Map<UserProfile>(userProfileDto));
            return _mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
