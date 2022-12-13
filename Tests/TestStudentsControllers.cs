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
    public class TestStudentsControllers : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public TestStudentsControllers(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task GetAllStudentsTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/students");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetStudentByIdTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/students/2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetStudentsWithPostsTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/students/posts");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetStudentByIdWithPostTest_Return_Ok()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/students/2/posts");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateStudentTest_Return_Created()
        {
            var student = new Student
            {
                Name = "TestTop",
                Age = 30,
                Birthday = "27/05/1997",
                Email = "teste1@teste.com",
                Gender = "Feminino",
                Password = "password",
                ConfirmPassword = "password"
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PostAsJsonAsync("/students", student);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateStudentTest_Return_Ok()
        {
            var student = new Student
            {
                Name = "Test",
                Age = 30,
                Birthday = "27/05/1997",
                Email = "teste@teste.com",
                Gender = "Feminino",
                Password = "password",
                ConfirmPassword = "password"
            };

            var client = _applicationFactory.CreateClient();
            using HttpResponseMessage response = await client.PutAsJsonAsync("/students/2", student);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteStudentTest_Return_NoContent()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.DeleteAsync("/students/4");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
