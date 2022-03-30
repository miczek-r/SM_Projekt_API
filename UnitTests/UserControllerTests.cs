using Application.DTO;
using Application.DTO.User;
using Core.Entities;
using Faker;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UserControllerTests
    {
        private readonly HttpClient _client;

        public UserControllerTests()
        {
            var _application = new Application();
            _client = _application.CreateClient();
           
        }

        [Fact]
        public async Task ShouldCreateUser()
        {
            UserCreateDTO userCreateDTO = new UserCreateDTO();
            userCreateDTO.Username = Internet.UserName();
            userCreateDTO.Email = Internet.Email();
            userCreateDTO.Password = "!Admin123";
            var response = await _client.PostAsJsonAsync("/api/user", userCreateDTO);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            UserBaseDTO user = await response.Content.ReadFromJsonAsync<UserBaseDTO>();
           
            user.Should().NotBeNull();
            user.Email.Should().Be(userCreateDTO.Email);
            user.Username.Should().Be(userCreateDTO.Username);

        }

        [Fact]
        public async Task ShouldGetUser()
        {
            var response = await _client.GetAsync("/api/user/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var user = await response.Content.ReadFromJsonAsync<UserBaseDTO>();
            user.Should().NotBeNull();
            user.Id.Should().Be("1");
        }

        [Fact]
        public async Task ShouldGetAllUsers()
        {
            var response = await _client.GetAsync("/api/user");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var users = await response.Content.ReadFromJsonAsync<List<UserBaseDTO>>();
            users.Should().NotBeNull();
            users.Should().HaveCountGreaterOrEqualTo(50);
        }
    }
}