using Gifter.Models;
using Gifter.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gifter.Tests.Mocks
{
    class InMemoryUserProfileRepository : IUserProfileRepository
    {
        private readonly List<UserProfile> _data;

        // Public property returning list of user profiles
        public List<UserProfile> InternalData
        {
            get
            {
                return _data;
            }
        }

        // Constructor will require a list of user profiles to be passed-in to fill _data
        public InMemoryUserProfileRepository(List<UserProfile> startingData)
        {
            _data = startingData;
        }

        public void Add(UserProfile userProfile)
        {
            var lastUserProfile = _data.Last();
            userProfile.Id = lastUserProfile.Id + 1;
            _data.Add(userProfile);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserProfile> GetAll()
        {
            return _data;
        }

        public UserProfile GetById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public UserProfile GetByIdWithPosts(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfile userProfile)
        {
            var currentUserProfile = _data.FirstOrDefault(p => p.Id == userProfile.Id);
            if (currentUserProfile == null)
            {
                return;
            }

            currentUserProfile.Name = userProfile.Name;
            currentUserProfile.Email = userProfile.Email;
            currentUserProfile.Bio = userProfile.Bio;
            currentUserProfile.DateCreated = userProfile.DateCreated;
            currentUserProfile.ImageUrl = userProfile.ImageUrl;
        }
    }
}
