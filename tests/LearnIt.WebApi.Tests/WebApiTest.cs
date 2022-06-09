using LearnIt.DTO;
using System.Net.Http.Json;
using Xunit;

namespace LearnIt.WebApi.Tests
{
    public class WebApiTest
    {
        private readonly TestWebApplication _factory;

        public WebApiTest()
        {
            _factory = new TestWebApplication();
        }

        [Theory]
        [InlineData("/api/Device/d5efff7b38ede24b/learn/new")]
        [InlineData("/api/Device/d5efff7b38ede24b/learn/repeat")]
        [InlineData("/api/Device/d5efff7b38ede24b/info")]
        public async Task Get_DeviceController(string url)
        {
            // Act
            var response = await _factory.CreateClient().GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/Word/search?searchWord=arm")]
        [InlineData("/api/Word?word=arm")]
        public async Task Get_WordController(string url)
        {
            // Act
            var response = await _factory.CreateClient().GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/Category")]
        [InlineData("/api/Category/1")]
        public async Task Get_CategoryController(string url)
        {
            // Act
            var response = await _factory.CreateClient().GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_CreateWord()
        {
            var content = JsonContent.Create(new CreateWordDto
            {
                CategoryId = 1,
                OriginalText = "test_orig",
                TranslatedText = "test_tran"
            });

            var response = await _factory.CreateClient().PostAsync("/api/Word", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_CreateCategory()
        {
            var content = JsonContent.Create(new CreateCategoryDto
            {
                Name = "test_category"
            });

            var response = await _factory.CreateClient().PostAsync("/api/Category", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_Word()
        {
            var response = await _factory.CreateClient().DeleteAsync("/api/Word?wordId=10");
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}