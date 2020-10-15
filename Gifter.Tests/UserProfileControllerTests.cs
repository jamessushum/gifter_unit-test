using Gifter.Controllers;
using Gifter.Models;
using Gifter.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Gifter.Tests
{
    public class UserProfileControllerTests
    {
        [Fact]
        public void Get_Returns_All_UserProfiles()
        {
            // Arrange
            var userProfileCount = 10;
            var userProfiles = CreateTestUserProfiles(userProfileCount);

            var repo = new InMemoryUserProfileRepository(userProfiles);
            var controller = new UserProfileController(repo);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualUserProfiles = Assert.IsType<List<UserProfile>>(okResult.Value);

            // Verifying result count equals the user profile count 
            Assert.Equal(userProfileCount, actualUserProfiles.Count);
            // Verifying result user profiles list equals user profiles list
            Assert.Equal(userProfiles, actualUserProfiles);
        }

        // Method creating/returning list of dummy user profiles depending on count
        private List<UserProfile> CreateTestUserProfiles(int count)
        {
            var userProfiles = new List<UserProfile>();
            for (var i = 1; i <= count; i++)
            {
                userProfiles.Add(new UserProfile()
                {
                    Id = i,
                    Name = $"User {i}",
                    Email = $"user{i}@example.com",
                    Bio = $"Bio {i}",
                    DateCreated = DateTime.Today.AddDays(-i),
                    ImageUrl = $"http://user.image.url/{i}"
                });
            }
            return userProfiles;
        }
    }
}
