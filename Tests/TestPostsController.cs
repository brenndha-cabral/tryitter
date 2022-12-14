using Azure;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using tryitter.DTO;
using tryitter.Models;

namespace tests
{
    public class TestPostsControllers : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public TestPostsControllers(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task GetAllPostsTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/posts");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetPostByIdTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/posts/1");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreatePostTest_Return_Created()
        {
            var posts = new Post
            {
                Content = "Hello Word",
                StudentId = 2
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("/posts", posts);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdatePostTest_Return_Ok()
        {
            var posts = new Post
            {
                Content = "Hello Mundo",
                StudentId = 2
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PutAsJsonAsync("/post/4", posts);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeletePostTest_Return_NoContent()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync("/posts/2");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
